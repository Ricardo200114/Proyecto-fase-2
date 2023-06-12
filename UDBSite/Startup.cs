using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(UDBSite.Startup))]
namespace UDBSite
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
