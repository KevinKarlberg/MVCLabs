using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace MVCLabData.Tables
{
    public class Comment
    {
        public Guid id { get; set; }
        public string Title { get; set; }
        public string Body { get; set; }
        public Guid UserID { get; set; }
        public Guid PictureID { get; set; }
        public Nullable<System.DateTime> DatePosted { get; set; }
        public Nullable<System.DateTime> DateEdited { get; set; }
        [ForeignKey("PictureID")]
        public virtual Picture Picture { get; set; }
        [ForeignKey("UserID")]
        public virtual User User { get; set; }
    }
}