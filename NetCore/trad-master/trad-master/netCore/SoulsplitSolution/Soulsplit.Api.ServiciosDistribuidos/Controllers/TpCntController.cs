using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Soulsplit.Api.Contratos;
using Soulsplit.Api.ServiciosDistribuidos.Helpers;
using System;
using System.Threading.Tasks;

namespace Soulsplit.Api.ServiciosDistribuidos
{
    [Produces("application/json")]
    [Route("api/[controller]")]
    [ApiController]
    [ServiceFilter(typeof(LoggerHelper))]
    public class TpCntController : ControllerBase
    {
        private readonly ITipoCuentaService _tipoCuentaService;
        private readonly ILogger _logger;

        public TpCntController(ITipoCuentaService tipoCuentaService, ILogger<TpCntController> logger)
        {
            _tipoCuentaService = tipoCuentaService;
            _logger = logger;
        }

        [HttpPost]
        [Route("VmLst")]
        public async Task<IActionResult> VmLst()
        {
            try
            {
                return Ok(await _tipoCuentaService.ObtenerTipoCuentas());
            }
            catch (Exception e)
            {
                _logger.LogError(e.Message);
                throw new Exception(e.Message);
            }
        }
    }
}
