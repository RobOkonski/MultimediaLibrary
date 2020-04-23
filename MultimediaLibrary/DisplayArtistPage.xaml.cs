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
    /// Interaction logic for DisplayPage.xaml
    /// </summary>
    public partial class DisplayArtistPage : Page
    {
        /// <summary>
        /// Constructor that create DisplayArtistPage
        /// </summary>
        /// <remarks>
        /// Display all artists from database
        /// </remarks>
        public DisplayArtistPage()
        {
            InitializeComponent();
            IArtistRepository repo = new ArtistRepository();
            displayArtist.ItemsSource = repo.GetArtists();
        }

        /// <summary>
        /// OpneButton action
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        /// <remarks>
        /// Open artist account on youtube if the path exist
        /// </remarks>
        private void OpenButton_Click(object sender, RoutedEventArgs e)
        {
            Artist artist = displayArtist.SelectedItem as Artist;
            if (artist.YoutubeAccountPath == null) MessageBox.Show("Click");
            else MessageBox.Show(artist.YoutubeAccountPath);
        }

        /// <summary>
        /// DisplayButton action
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        /// <remarks>
        /// Open DisplayTrackPage wtih all track of this artist
        /// </remarks>
        private void DisplayButton_Click(object sender, RoutedEventArgs e)
        {
            Artist artist = displayArtist.SelectedItem as Artist;
            this.NavigationService.Navigate(new DisplayTrackPage(artist.ArtistId));
        }
    }
}
