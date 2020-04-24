using System;
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
    using Models;
    using Repositories;
    using Interfaces;

    /// <summary>
    /// Interaction logic for UpdateTrackPage.xaml
    /// </summary>
    public partial class UpdateTrackPage : Page
    {
        /// <summary>
        /// Store edited track data
        /// </summary>
        public Track oldTrack;

        /// <summary>
        /// Constructor of UpdateTrackPage
        /// </summary>
        /// <param name="track"> Track that we want to update, requires Track object </param>
        /// <remarks>
        /// Fill boxes with oldTrack data and initilaize combobox
        /// </remarks>
        public UpdateTrackPage(Track track)
        {
            InitializeComponent();

            IArtistRepository repo = new ArtistRepository();
            string[] artistsNames = repo.GetArtistNames();
            uArtistSelect.ItemsSource = artistsNames;

            oldTrack = track;
            uArtistSelect.SelectedItem = track.Artist.Name;
            uTrackNameBox.Text = track.Name;
            uYoutubeTrackPathBox.Text = track.YoutubePath;
        }

        /// <summary>
        /// UpdateTrackButton action
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        /// <remarks>
        /// Update track record if data changes
        /// </remarks>
        private void updateTrack_Click(object sender, RoutedEventArgs e)
        {
            if (uArtistSelect.SelectedItem.ToString() == oldTrack.Artist.Name && uTrackNameBox.Text == oldTrack.Name && uYoutubeTrackPathBox.Text == oldTrack.YoutubePath) uTrackStatusLabel.Content = "Nothing changed";
            else
            {
                var artistRepo = new ArtistRepository();
                var trackRepo = new TrackRepository();
                Artist artist = artistRepo.GetArtist(uArtistSelect.SelectedItem.ToString());
                Track newTrack = new Track { Name = uTrackNameBox.Text, YoutubePath = uYoutubeTrackPathBox.Text, ArtistId = artist.ArtistId };
                trackRepo.UpdateTrack(oldTrack.TrackId, newTrack);
                uTrackStatusLabel.Content = "Updated";
            }
        }
    }
}
