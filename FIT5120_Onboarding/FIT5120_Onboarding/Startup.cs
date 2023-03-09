using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(FIT5120_Onboarding.Startup))]
namespace FIT5120_Onboarding
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
