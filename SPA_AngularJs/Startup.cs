using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(SPA_AngularJs.Startup))]
namespace SPA_AngularJs
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
