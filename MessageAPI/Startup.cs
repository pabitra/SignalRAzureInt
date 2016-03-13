using Microsoft.Owin;
using Owin;

[assembly: OwinStartup(typeof(MessageAPI.Startup))]

namespace MessageAPI
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            app.MapSignalR();

        }
    }
}
