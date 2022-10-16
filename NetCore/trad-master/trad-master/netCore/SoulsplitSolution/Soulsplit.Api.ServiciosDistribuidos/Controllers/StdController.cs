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
    public class StdController : ControllerBase
    {
        private readonly IEstadoService _estadoService;
        private readonly ILogger _logger;

        public StdController(IEstadoService estadoService, ILogger<MnController> logger)
        {
            _estadoService = estadoService;
            _logger = logger;
        }

        [HttpPost]
        [Route("VmCrt")]
        public async Task<IActionResult> VmCrt(DtoCombo dto)
        {
            try
            {
                return Ok(await _estadoService.CrearEstado(dto));
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
                return Ok(await _estadoService.ObtenerEstados());
            }
            catch (Exception e)
            {
                _logger.LogError(e.Message);
                throw new Exception(e.Message);
            }
        }

        [HttpPost]
        [Route("VmLstDt")]
        public async Task<IActionResult> VmLstDt(DtoCombo dto)
        {
            try
            {
                return Ok(await _estadoService.ObtenerDetallesEstado(dto));
            }
            catch (Exception e)
            {
                _logger.LogError(e.Message);
                throw new Exception(e.Message);
            }
        }
    }
}
