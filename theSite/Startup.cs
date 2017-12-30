using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(theSite.Startup))]
namespace theSite
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
