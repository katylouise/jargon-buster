using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(Parliament.JargonBuster.Web.Startup))]
namespace Parliament.JargonBuster.Web
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
