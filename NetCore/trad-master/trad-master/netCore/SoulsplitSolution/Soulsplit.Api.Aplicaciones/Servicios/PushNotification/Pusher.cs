using Microsoft.AspNetCore.Mvc;
using PusherServer;
using Soulsplit.Api.Contratos;
using Soulsplit.Api.Contratos.ContratosServicios;
using System.Threading.Tasks;

namespace Soulsplit.Api.Aplicaciones.Servicios
{
    public class ChannelService : IChannelService
    {
        private readonly IAppConfig _appConfig;

        public ChannelService(IAppConfig appConfig)
        {
            _appConfig = appConfig;
        }
        public async Task<IActionResult> Trigger(object data, string channelName, string eventName)
        {
            var options = new PusherOptions
            {
                Cluster = _appConfig.Pusher_cluster,
                Encrypted = true
            };
            var pusher = new Pusher(_appConfig.Pusher_app_id, _appConfig.Pusher_key, _appConfig.Pusher_secret, options);

            await pusher.TriggerAsync(channelName, eventName, data);
            return new OkObjectResult(data);
        }
    }
}
