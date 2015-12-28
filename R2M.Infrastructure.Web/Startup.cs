using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(R2M.Infrastructure.Web.Startup))]
namespace R2M.Infrastructure.Web
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
