using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(TEST22.Startup))]
namespace TEST22
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
