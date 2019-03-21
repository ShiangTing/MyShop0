using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(Myshop.WebUI.Test.Startup))]
namespace Myshop.WebUI.Test
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
