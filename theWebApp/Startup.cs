using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(theWebApp.Startup))]
namespace theWebApp
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
