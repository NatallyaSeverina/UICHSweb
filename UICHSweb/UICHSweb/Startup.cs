using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(UICHSweb.Startup))]
namespace UICHSweb
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
