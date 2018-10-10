using System;
using System.Collections.Generic;
using System.Text;

namespace IRunesWebApp.Models
{
    public class TrackAlbum : BaseEntity<int>
    {
        public Guid AlbumId { get; set; }

        public virtual Album Album { get; set; }

        public Guid TrackId { get; set; }

        public virtual Track Track { get; set; }
    }
}
