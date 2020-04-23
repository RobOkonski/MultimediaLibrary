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
        /// <summary>
        /// Constructor of AddArtistPage
        /// </summary>
        /// <remarks>
        /// Open artist form
        /// </remarks>
        public AddArtistPage()
        {
            InitializeComponent();
        }

        /// <summary>
        /// saveArtist button action
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        /// <remarks>
        /// Save inscribed data as a new Artist in database
        /// </remarks>
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
