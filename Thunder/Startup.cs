using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(Thunder.Startup))]
namespace Thunder
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
