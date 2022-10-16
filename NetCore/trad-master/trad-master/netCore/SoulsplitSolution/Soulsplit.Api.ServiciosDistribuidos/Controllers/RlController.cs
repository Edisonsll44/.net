using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Soulsplit.Api.Contratos.ContratosServicios;
using Soulsplit.Api.ServiciosDistribuidos.Helpers;
using System;
using System.Threading.Tasks;

namespace Soulsplit.Api.ServiciosDistribuidos
{
    [Produces("application/json")]
    [Route("api/[controller]")]
    [ApiController]
    [ServiceFilter(typeof(LoggerHelper))]
    public class RlController : ControllerBase
    {
        private readonly IRolService _rolService;
        private readonly ILogger _logger;

        public RlController(IRolService rolService, ILogger<RlController> logger)
        {
            _rolService = rolService;
            _logger = logger;
        }

        [HttpPost]
        [Route("VmLst")]
        public async Task<IActionResult> VmLst()
        {
            try
            {
                return Ok(await _rolService.ListarRol());
            }
            catch (Exception e)
            {
                _logger.LogError(e.Message);
                throw new Exception(e.Message);
            }
        }

    }
}
