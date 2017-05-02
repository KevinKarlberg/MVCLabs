using Kunskapskollen.DBModels;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kunskapskollen
{
    public class AdressbookDBContext : DbContext
    {
        public AdressbookDBContext() : base("name=DefaultConnection")
        { 

        }
        public DbSet<PersonAdress> PersonAdress { get; set; }
    }
}
