using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(fantasyF1.Startup))]
namespace fantasyF1
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
