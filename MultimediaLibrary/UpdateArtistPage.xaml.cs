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
    /// Interaction logic for UpdateArtistPage.xaml
    /// </summary>
    public partial class UpdateArtistPage : Page
    {
        /// <summary>
        /// Store id of updated artist
        /// </summary>
        public Artist oldArtist;

        /// <summary>
        /// Constructor of UpdateArtistPage
        /// </summary>
        /// <param name="artist"> Artist that we want to edit, requires Artist object </param>
        /// <remarks>
        /// Fill boxes with existing data
        /// </remarks>
        public UpdateArtistPage(Artist artist)
        {
            InitializeComponent();
            oldArtist = artist;
            uArtistNameBox.Text = artist.Name;
            uYoutubeAccountPathBox.Text = artist.YoutubeAccountPath;
        }

        /// <summary>
        /// UpdateArtistButton action
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        /// <remarks>
        /// Update data of existing Artist
        /// </remarks>
        private void updateArtist_Click(object sender, RoutedEventArgs e)
        {
            Artist newArtist = new Artist { Name = uArtistNameBox.Text, YoutubeAccountPath = uYoutubeAccountPathBox.Text };
            var repo = new ArtistRepository();
            if (newArtist.Name == oldArtist.Name && newArtist.YoutubeAccountPath == oldArtist.YoutubeAccountPath) uArtistStatusLabel.Content = "Nothing changed";
            else
            {
                repo.UpdateArtist(oldArtist.ArtistId, newArtist);
                uArtistStatusLabel.Content = "Updated";
            }
        }
    }
}