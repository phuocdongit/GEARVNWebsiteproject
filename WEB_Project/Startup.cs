using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(WEB_Project.Startup))]
namespace WEB_Project
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
