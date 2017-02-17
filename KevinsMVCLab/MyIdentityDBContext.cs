using Microsoft.AspNet.Identity.EntityFramework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace KevinsMVCLab
{
    public class MyIdentityDBContext : IdentityDbContext<IdentityUser>
    {
        public MyIdentityDBContext() : base("name = DefaultConnection") {
        }
    }
}