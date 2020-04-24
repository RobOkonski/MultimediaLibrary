using System;
using System.Collections.Generic;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Threading;
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

    /// <summary>
    /// Interaction logic for AddTrackPage.xaml
    /// </summary>
    public partial class AddTrackPage : Page
    {
        /// <summary>
        /// Constructor that creates AddTrackPage
        /// </summary>
        /// <remarks>
        /// Open Track form
        /// </remarks>
        public AddTrackPage()
        {
            InitializeComponent();

            IArtistRepository repo = new ArtistRepository();
            string[] artistsNames = repo.GetArtistNames();
            artistSelect.ItemsSource = artistsNames;
        }

        /// <summary>
        /// saveTrack button action 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        /// <remarks>
        /// Save inscribed data as a new Track in database
        /// </remarks>
        private void saveTrack_Click(object sender, RoutedEventArgs e)
        {
            if (trackNameBox.Text.Length != 0 && artistSelect.SelectedItem != null)
            {
                if (TrackAlreadyExist(trackNameBox.Text, artistSelect.Text)) trackStatusLabel.Content = "Track already exist";
                else
                {
                    IArtistRepository artistRepo = new ArtistRepository();
                    Track track = new Track() { Name = trackNameBox.Text, ArtistId = artistRepo.GetArtist(artistSelect.Text).ArtistId };
                    if (youtubeTrackPathBox.Text.Length != 0) track.YoutubePath = youtubeTrackPathBox.Text;
                    ITrackRepository repo = new TrackRepository();
                    repo.CreateTrack(track);
                    trackStatusLabel.Content = "Saved";
                }
            }
            else trackStatusLabel.Content = "Databox empty";
        }

        /// <summary>
        /// Check if track of this name exist in choosen artist collection
        /// </summary>
        /// <param name="trackName">Name of track </param>
        /// <param name="artistName">Name of artist</param>
        /// <returns> Returns true if track exits in artis collection or false if doesn't </returns>
        private bool TrackAlreadyExist(string trackName, string artistName)
        {
            var artistRepo = new ArtistRepository();
            var tracks = artistRepo.GetArtist(artistName).Tracks;
            foreach(Track t in tracks)
            {
                if (t.Name == trackName) return true;
            }
            return false;
        }
    }
}
