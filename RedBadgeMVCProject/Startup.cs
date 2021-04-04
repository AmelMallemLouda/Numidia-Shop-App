using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(RedBadgeMVCProject.Startup))]
namespace RedBadgeMVCProject
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
