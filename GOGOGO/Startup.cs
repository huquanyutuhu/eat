using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(GOGOGO.Startup))]
namespace GOGOGO
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
