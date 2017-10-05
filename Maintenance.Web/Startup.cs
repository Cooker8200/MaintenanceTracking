using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(Maintenance.Web.Startup))]
namespace Maintenance.Web
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
