using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MVCLabData.Tables
{
    public class Comment
    {
        public int id { get; set; }
        public string Title { get; set; }
        public string Body { get; set; }
        public int UserID { get; set; }
        public int PictureID { get; set; }
        public Nullable<System.DateTime> DatePosted { get; set; }
        public Nullable<System.DateTime> DateEdited { get; set; }

        public virtual Picture Picture { get; set; }
        public virtual User User { get; set; }
    }
}