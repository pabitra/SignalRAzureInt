using Microsoft.AspNet.SignalR;
using Microsoft.Owin;
using Owin;

[assembly: OwinStartup(typeof(MessageAPI.Startup))]

namespace MessageAPI
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
           // var hubConfiguration = new HubConfiguration();
           // hubConfiguration.EnableJavaScriptProxies = false;
            app.MapSignalR();

        }
    }
}
