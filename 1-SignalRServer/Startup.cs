using Microsoft.AspNet.SignalR;
using Microsoft.Owin;
using Owin;
using System;
using System.Threading.Tasks;

[assembly: OwinStartup(typeof(_1_SignalRServer.Startup))]

namespace _1_SignalRServer
{
    public class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            var hubConfiguration = new HubConfiguration
            {
                EnableDetailedErrors = true
            };

            //Any connection or hub wire up and configuration should go here
            app.MapSignalR(hubConfiguration);
        }
    }
}
