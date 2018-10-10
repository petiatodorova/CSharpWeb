using System;
using System.Collections.Generic;

namespace IRunesWebApp.Models
{
    //• Id – a string (GuID).
    //• Name – a string.
    //• Cover – a string (a link to an image).
    //• Price – a decimal (sum of all Tracks’ prices, reduced by 13%).
    //• Tracks – a collection of Tracks.

    public class Album : BaseEntity<Guid>
    {
        public Album()
        {
            this.Tracks = new HashSet<TrackAlbum>();
        }

        public string AlbumName { get; set; }

        public string CoverUrl { get; set; }

        public decimal AlbumPrice { get; set; }

        public virtual ICollection<TrackAlbum> Tracks { get; set; }

    }
}
