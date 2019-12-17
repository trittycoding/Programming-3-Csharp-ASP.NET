using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(Section2WebApp.Startup))]
namespace Section2WebApp
{
    public partial class Startup {
        public void Configuration(IAppBuilder app) {
            ConfigureAuth(app);
        }
    }
}
