using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(LIS.v10.Startup))]
namespace LIS.v10
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
