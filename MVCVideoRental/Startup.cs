using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(MVCVideoRental.Startup))]
namespace MVCVideoRental
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
