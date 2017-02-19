using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MVCLabData.Tables
{
    public class Picture
    {
        public Picture()
        {
            this.Comments = new HashSet<Comment>();
        }

        public Guid id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string Path { get; set; }
        
        public string User { get; set; }
        public Nullable<System.DateTime> DatePosted { get; set; }
        public Nullable<System.DateTime> DateEdited { get; set; }
        public bool @public { get; set; }
        public Guid GalleryID { get; set; }

        public virtual ICollection<Comment> Comments { get; set; }
        public virtual Gallery Gallery { get; set; }
    }
}