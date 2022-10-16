using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace Soulsplit.Api.Contratos.ContratosServicios
{
    public interface IChannelService
    {
        Task<IActionResult> Trigger(object data, string channelName, string eventName);
    }
}
