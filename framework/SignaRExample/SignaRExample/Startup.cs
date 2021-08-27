using Microsoft.Owin;
using Owin;

[assembly: OwinStartup(typeof(SignaRExample.Startup))]

namespace SignaRExample
{
    public class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            app.MapSignalR();
        }
    }
}
