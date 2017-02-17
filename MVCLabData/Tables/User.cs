using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MVCLabData.Tables
{
    public class User
    {
        public User()
        {
            this.Comments = new HashSet<Comment>();
            this.Pictures = new HashSet<Picture>();
            this.Galleries = new HashSet<Gallery>();
        }

        public Guid id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }

        public virtual ICollection<Comment> Comments { get; set; }
        public virtual ICollection<Picture> Pictures { get; set; }
        public virtual ICollection<Gallery> Galleries { get; set; }
    }
}