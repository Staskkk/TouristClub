using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(DB_Cource_1_03_Web.Startup))]
namespace DB_Cource_1_03_Web
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
