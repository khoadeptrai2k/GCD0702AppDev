using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(GCD0702AppDev.Startup))]
namespace GCD0702AppDev
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
