using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Soulsplit.Api.Contratos;
using Soulsplit.Api.ServiciosDistribuidos.Helpers;
using Soulsplit.Api.Utilitarios.Dto;
using System;
using System.Threading.Tasks;

namespace Soulsplit.Api.ServiciosDistribuidos
{
    [Produces("application/json")]
    [Route("api/[controller]")]
    [ApiController]
    [ServiceFilter(typeof(LoggerHelper))]
    public class FrmPgController : ControllerBase
    {
        private readonly IFormaPagoService _formaPagoService;
        private readonly ILogger _logger;

        public FrmPgController(IFormaPagoService formaPagoService, ILogger<FrmPgController> logger)
        {
            _formaPagoService = formaPagoService;
            _logger = logger;
        }

        [HttpPost]
        [Route("VmLst")]
        public async Task<IActionResult> VmLst()
        {
            try
            {
                return Ok(await _formaPagoService.ObtenerFormasPago());
            }
            catch (Exception e)
            {
                _logger.LogError(e.Message);
                throw new Exception(e.Message);
            }
        }
    }
}
