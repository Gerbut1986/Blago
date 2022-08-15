using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(Blago.PL.Startup))]
namespace Blago.PL
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
