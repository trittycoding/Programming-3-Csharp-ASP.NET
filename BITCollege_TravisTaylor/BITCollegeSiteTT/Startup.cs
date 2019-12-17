using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(BITCollegeSiteTT.Startup))]
namespace BITCollegeSiteTT
{
    public partial class Startup {
        public void Configuration(IAppBuilder app) {
            ConfigureAuth(app);
        }
    }
}
