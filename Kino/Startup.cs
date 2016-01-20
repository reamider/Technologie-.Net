using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(Kino.Startup))]
namespace Kino
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
