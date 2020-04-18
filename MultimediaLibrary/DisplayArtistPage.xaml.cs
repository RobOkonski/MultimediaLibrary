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
        public DisplayArtistPage()
        {
            InitializeComponent();
            IArtistRepository repo = new ArtistRepository();
            displayArtist.ItemsSource = repo.GetArtists();
        }

        private void OpenButton_Click(object sender, RoutedEventArgs e)
        {
            Artist artist = displayArtist.SelectedItem as Artist;
            if (artist.YoutubeAccountPath == null) MessageBox.Show("Click");
            else MessageBox.Show(artist.YoutubeAccountPath);
        }

        private void DisplayButton_Click(object sender, RoutedEventArgs e)
        {
            Artist artist = displayArtist.SelectedItem as Artist;
            this.NavigationService.Navigate(new DisplayTrackPage(artist.ArtistId));
        }
    }
}
