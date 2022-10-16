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
    public class BncController : ControllerBase
    {
        private readonly IBancoService _bancoService;
        private readonly ILogger _logger;

        public BncController(IBancoService bancoService, ILogger<BncController> logger)
        {
            _bancoService = bancoService;
            _logger = logger;
        }

        [HttpPost]
        [Route("VmCrt")]
        public async Task<IActionResult> VmCrt(DtoCombo Banco)
        {
            try
            {
                return Ok(await _bancoService.CrearBanco(Banco));
            }
            catch (Exception e)
            {
                _logger.LogError(e.Message);
                throw new Exception(e.Message);
            }
        }

        [HttpPost]
        [Route("VmLst")]
        public async Task<IActionResult> VmLst()
        {
            try
            {
                return Ok(await _bancoService.ObtenerBancos());
            }
            catch (Exception e)
            {
                _logger.LogError(e.Message);
                throw new Exception(e.Message);
            }
        }

    }
}
