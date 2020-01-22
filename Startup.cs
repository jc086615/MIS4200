using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(CarrMIS4200.Startup))]
namespace CarrMIS4200
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
