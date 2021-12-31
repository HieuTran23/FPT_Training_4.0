using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(FPT_Training_4._0.Startup))]
namespace FPT_Training_4._0
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
