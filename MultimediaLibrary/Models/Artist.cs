using System;
using System.Collections.Generic;
using System.Text;

namespace MultimediaLibrary.Models
{
    public class Artist
    {
        public int ArtistId { set; get; }
        public string Name { set; get; }
        public string YoutubeAccountPath { set; get; } = null;
        public virtual ICollection<Track> Tracks { set; get; }
    }
}
