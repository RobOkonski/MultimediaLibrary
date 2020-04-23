using System;
using System.Collections.Generic;
using System.Text;

namespace MultimediaLibrary.Models
{

    /// <summary>
    /// Database model of track
    /// </summary>
    public class Track
    {
        /// <summary>
        /// Store Id of a track, primary key
        /// </summary>
        public int TrackId { set; get; }

        /// <summary>
        /// Store name of a track
        /// </summary>
        public string Name { set; get; }

        /// <summary>
        /// Store id of an artist, foreign key
        /// </summary>
        public int ArtistId { set; get; } 

        /// <summary>
        /// Store artist referance
        /// </summary>
        public virtual Artist Artist { set; get; }

        /// <summary>
        /// Store YouTube path to this track, nullable
        /// </summary>
        public string YoutubePath { set; get; } = null;
    }
}
