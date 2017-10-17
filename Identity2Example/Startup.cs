using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(Identity2Example.Startup))]
namespace Identity2Example
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
