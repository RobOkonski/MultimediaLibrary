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
            if (track.YoutubePath == null) MessageBox.Show("Not found");
            else MessageBox.Show(track.YoutubePath);
        }
    }
}
