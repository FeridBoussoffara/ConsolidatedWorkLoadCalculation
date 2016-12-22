using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(CWC.MVC.Startup))]
namespace CWC.MVC
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
