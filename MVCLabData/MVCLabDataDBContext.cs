using MVCLabData.Tables;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
using System.Linq;
using System.Web;


namespace MVCLabData
{
    public class MVCLabDataDbContext : DbContext
    {
        public MVCLabDataDbContext() : base("name=DefaultConnection")
        {

            this.Configuration.LazyLoadingEnabled = false;
            
            
        }
        public DbSet<Comment> Comments { get; set; }
        public DbSet<Picture> Pictures { get; set; }
        public DbSet<Gallery> Galleries { get; set; }

    }
}