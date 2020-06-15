using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(FightShop.WebUI.Startup))]
namespace FightShop.WebUI
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
