﻿using System;
using System.Collections.Generic;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace MultimediaLibrary
{
    using Interfaces;
    using Repositories;
    using Models;
    using System.Diagnostics;

    /// <summary>
    /// Interaction logic for DisplayTrackPage.xaml
    /// </summary>
    public partial class DisplayTrackPage : Page
    {
        /// <summary>
        /// Constructor that create new DisplayTrackPage
        /// </summary>
        /// <param name="artistId"> Id of artist whose track would be displayed </param>
        /// <remarks>
        /// Display tracks of indicated artist
        /// </remarks>
        public DisplayTrackPage(int artistId)
        {
            InitializeComponent();
            IArtistRepository artistRepo = new ArtistRepository();
            displayTracks.ItemsSource = artistRepo.GetArtist(artistId).Tracks;
        }

        /// <summary>
        /// OpenTrackButton action
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        /// <remarks>
        /// Open this track on youtube if the path exist
        /// </remarks>
        private void OpenTrackButton_Click(object sender, RoutedEventArgs e)
        {
            Track track = displayTracks.SelectedItem as Track;
            Process myProcess = new Process();
            if (track.YoutubePath.Length == 0) MessageBox.Show("No ID");
            else
            {
                try
                {
                    myProcess.StartInfo.UseShellExecute = true;
                    myProcess.StartInfo.FileName = track.YoutubePath;
                    myProcess.Start();

                }
                catch (Exception er)
                {
                    MessageBox.Show(er.Message);
                }
            }
        }

        /// <summary>
        /// EditTrackButton action
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        /// <remarks>
        /// Open UpdateTrackPage wtih indicated track data
        /// </remarks>
        private void EditTrackButton_Click(object sender, RoutedEventArgs e)
        {
            Track track = displayTracks.SelectedItem as Track;
            this.NavigationService.Navigate(new UpdateTrackPage(track));
        }

        /// <summary>
        /// DeleteTrackButton action
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        /// <remarks>
        /// Delete indicated track
        /// </remarks>
        private void DeleteTrackButton_Click(object sender, RoutedEventArgs e)
        {
            var trackRepo = new TrackRepository();
            Track track = displayTracks.SelectedItem as Track;
            trackRepo.DeleteTrack(track.TrackId);
            this.NavigationService.Navigate(new DisplayTrackPage(track.ArtistId));
        }
    }
}
