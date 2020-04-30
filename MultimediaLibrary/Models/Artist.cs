using System;
using System.Collections.Generic;
using System.Text;

namespace MultimediaLibrary.Models
{
    /// <summary>
    /// Database model of an artist
    /// </summary>
    public class Artist
    {
        /// <summary>
        /// Store id of an artist, primary key
        /// </summary>
        public int ArtistId { set; get; }

        /// <summary>
        /// Store name of an artist
        /// </summary>
        public string Name { set; get; }

        /// <summary>
        /// Store path to artists youtube account, nullable
        /// </summary>
        public string YoutubeAccountPath { set; get; } = null;       

        /// <summary>
        /// Store count of subscribers, nullable
        /// </summary>
        public ulong? Subscribers { get; set; }

        /// <summary>
        /// Provde lazy loading of artists tracks
        /// </summary>
        public virtual ICollection<Track> Tracks { set; get; }
    }
}
