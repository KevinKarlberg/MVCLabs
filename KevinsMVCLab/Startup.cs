using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(KevinsMVCLab.Startup))]
namespace KevinsMVCLab
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
