using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MVCLabData.Tables
{
    public class Gallery
    {
        public Gallery()
        {
            this.Pictures = new HashSet<Picture>();
        }

        public int id { get; set; }
        public string GalleryName { get; set; }
        public System.DateTime DateCreated { get; set; }
        public int UserID { get; set; }

        public virtual User User { get; set; }
        public virtual ICollection<Picture> Pictures { get; set; }
    }
}