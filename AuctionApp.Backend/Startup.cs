using Microsoft.Owin;
using Owin;

[assembly: OwinStartup(typeof(AuctionApp.Backend.Startup))]

namespace AuctionApp.Backend
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureMobileApp(app);
        }
    }
}