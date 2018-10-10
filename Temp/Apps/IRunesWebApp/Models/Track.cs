using System;
using System.Collections.Generic;

namespace IRunesWebApp.Models
{
    //• Id – a string (GuID).
    //• Name – a string.
    //• Link – a string (a link to a video).
    //• Price – a decimal.

    public class Track : BaseEntity<Guid>
    {
        public Track()
        {
            this.Albums = new HashSet<TrackAlbum>();
        }

        public string TrackName { get; set; }

        public string VideoUrl { get; set; }

        public decimal TrackPrice { get; set; }

        public virtual ICollection<TrackAlbum> Albums { get; set; }
    }
}
