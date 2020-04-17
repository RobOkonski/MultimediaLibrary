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
        public AddTrackPage()
        {
            InitializeComponent();

            IArtistRepository repo = new ArtistRepository();
            string[] artistsNames = repo.GetArtistNames();
            artistSelect.ItemsSource = artistsNames;
            //Artist[] artists = repo.GetArtists();
            //artistSelect.ItemsSource = artists;
        }

        private void saveTrack_Click(object sender, RoutedEventArgs e)
        {
            if (trackNameBox.Text.Length != 0 && artistSelect.SelectedItem != null)
            {
                IArtistRepository artistRepo = new ArtistRepository();
                Track track = new Track() { Name = trackNameBox.Text, ArtistId = artistRepo.GetArtist(artistSelect.Text).Id};
                ITrackRepository repo = new TrackRepository();
                repo.CreateTrack(track);
                trackStatusLabel.Content = "Saved";
            }
            else trackStatusLabel.Content = "Databox empty";
        }
    }
}
