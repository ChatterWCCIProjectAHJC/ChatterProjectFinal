using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(ChatterProjects.Startup))]
namespace ChatterProjects
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
