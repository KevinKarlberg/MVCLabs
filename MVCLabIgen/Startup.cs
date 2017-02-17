using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(MVCLabIgen.Startup))]
namespace MVCLabIgen
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
