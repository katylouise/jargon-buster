using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(BackEndAdminApp.Startup))]
namespace BackEndAdminApp
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
