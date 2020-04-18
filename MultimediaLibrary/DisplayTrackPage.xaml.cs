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
    using Interfaces;
    using Repositories;
    using Models;
    /// <summary>
    /// Interaction logic for DisplayTrackPage.xaml
    /// </summary>
    public partial class DisplayTrackPage : Page
    {
        public DisplayTrackPage(int artistId)
        {
            InitializeComponent();
            IArtistRepository artistRepo = new ArtistRepository();
            artistNameLabel.Content = artistRepo.GetArtist(artistId).Name;
            ITrackRepository repo = new TrackRepository();            
            displayTracks.ItemsSource = repo.GetTracksThatContains(artistId);
        }

        private void OpenTrackButton_Click(object sender, RoutedEventArgs e)
        {
            Track track = displayTracks.SelectedItem as Track;
            if (track.YoutubePath == null) MessageBox.Show("Not found");
            else MessageBox.Show(track.YoutubePath);
        }
    }
}
