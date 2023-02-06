using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(SmlSmartLocker.Startup))]
namespace SmlSmartLocker
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
