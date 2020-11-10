using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(SSS.TestWeb.Startup))]
namespace SSS.TestWeb
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
