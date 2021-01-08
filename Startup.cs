using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(proiectDaw.Startup))]
namespace proiectDaw
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
