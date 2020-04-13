using System;
using System.Collections.Generic;
using System.Text;

namespace MultimediaLibrary
{
    public class Track
    {
        public string Name { set; get; }
        public virtual Artist Artist { set; get; } 
        public string YoutubePath { set; get; } = null;
    }
}
