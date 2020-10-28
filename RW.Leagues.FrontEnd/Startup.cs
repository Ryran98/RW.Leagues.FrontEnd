using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(RW.Leagues.FrontEnd.Startup))]
namespace RW.Leagues.FrontEnd
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
