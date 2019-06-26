using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(DapperExt.Startup))]
namespace DapperExt
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
