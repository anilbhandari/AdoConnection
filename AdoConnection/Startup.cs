using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(AdoConnection.Startup))]
namespace AdoConnection
{
    public partial class Startup {
        public void Configuration(IAppBuilder app) {
            ConfigureAuth(app);
        }
    }
}
