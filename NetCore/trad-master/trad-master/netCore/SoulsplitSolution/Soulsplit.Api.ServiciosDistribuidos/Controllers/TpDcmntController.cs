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
    public class TpDcmntController : ControllerBase
    {
        private readonly ITipoDocumentoService _tipoDocumentoService;
        private readonly ILogger _logger;

        public TpDcmntController(ITipoDocumentoService tipoDocumentoService, ILogger<BncController> logger)
        {
            _tipoDocumentoService = tipoDocumentoService;
            _logger = logger;
        }

        [HttpPost]
        [Route("VmLst")]
        public async Task<IActionResult> VmLst()
        {
            try
            {
                return Ok(await _tipoDocumentoService.ListarTipoDocumentos());
            }
            catch (Exception e)
            {
                _logger.LogError(e.Message);
                throw new Exception(e.Message);
            }
        }

    }
}
