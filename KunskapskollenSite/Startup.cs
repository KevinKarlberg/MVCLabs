using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(KunskapskollenSite.Startup))]
namespace KunskapskollenSite
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
           
        }
    }
}
