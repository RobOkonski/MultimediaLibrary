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
    using Interfaces;
    using Repositories;
    /// <summary>
    /// Interaction logic for AddArtistPage.xaml
    /// </summary>
    public partial class AddArtistPage : Page
    {
        public AddArtistPage()
        {
            InitializeComponent();
        }

        private void saveArtist_Click(object sender, RoutedEventArgs e)
        {
            if (artistNameBox.Text.Length !=0)
            {
                Artist artist = new Artist() { Name = artistNameBox.Text };
                if (youtubeAccountPathBox.Text.Length != 0) artist.YoutubeAccountPath = youtubeAccountPathBox.Text;
                IArtistRepository repo = new ArtistRepository();
                repo.CreateArtist(artist);
                artistStatusLabel.Content = "Saved";
            }
            else artistStatusLabel.Content = "Artist name box empty"; 
        }

    }
}
