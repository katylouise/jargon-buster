using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(Parliament.JargonBuster.BackEndAdminApp.Startup))]
namespace Parliament.JargonBuster.BackEndAdminApp
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
