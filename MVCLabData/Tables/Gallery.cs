using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
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

        public Guid id { get; set; }
        public string GalleryName { get; set; }
        public System.DateTime DateCreated { get; set; }
        public string User { get; set; }
        public virtual ICollection<Picture> Pictures { get; set; }
    }
}