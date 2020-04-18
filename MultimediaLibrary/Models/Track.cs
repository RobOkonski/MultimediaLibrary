using System;
using System.Collections.Generic;
using System.Text;

namespace MultimediaLibrary.Models
{
    public class Track
    {
        public int TrackId { set; get; }
        public string Name { set; get; }
        public int ArtistId { set; get; } 
        public virtual Artist Artist { set; get; }
        public string YoutubePath { set; get; } = null;
    }
}
