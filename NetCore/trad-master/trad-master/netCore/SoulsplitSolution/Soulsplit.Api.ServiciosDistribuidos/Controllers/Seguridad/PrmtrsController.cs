using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Soulsplit.Api.Contratos;
using Soulsplit.Api.ServiciosDistribuidos.Helpers;
using Soulsplit.Api.Utilitarios.Dto;
using System;
using System.Threading.Tasks;

namespace Soulsplit.Api.ServiciosDistribuidos.Controllers.Seguridad
{
    [Route("api/[controller]")]
    [ApiController]
    [ServiceFilter(typeof(LoggerHelper))]
    public class PrmtrsController : ControllerBase
    {
        private readonly IParametroSistemaService _parametroSistemaService;
        private readonly IFuncionalidadSistemaService _funcionalidadSistemaService;
        private readonly IParametroFuncionalidaSistemaService _parametroFuncionalidaSistemaService;
        private readonly ILogger _logger;
        public PrmtrsController(IParametroSistemaService parametroSistemaService, IFuncionalidadSistemaService funcionalidadSistemaService, ILogger<PrmtrsController> logger, IParametroFuncionalidaSistemaService parametroFuncionalidaSistemaService)
        {
            _logger = logger;
            _parametroSistemaService = parametroSistemaService;
            _funcionalidadSistemaService = funcionalidadSistemaService;
            _parametroFuncionalidaSistemaService = parametroFuncionalidaSistemaService;
        }

        [HttpPost("VmCrtPrmtr")]
        public async Task<IActionResult> VmCrtPrmtr(ParametroSistemaDto dto)
        {
            try
            {
                return Ok(await _parametroSistemaService.CrearParametroSistema(dto));
            }
            catch (Exception e)
            {
                _logger.LogError(e.Message);
                return BadRequest(e.Message);
            }
        }

        [HttpPost("VmCrtFnc")]
        public async Task<IActionResult> VmCrtFnc(FuncionalidadSistemaDto dto)
        {
            try
            {
                return Ok(await _funcionalidadSistemaService.CrearFuncionalidadSistema(dto));
            }
            catch (Exception e)
            {
                _logger.LogError(e.Message);
                return BadRequest(e.Message);
            }
        }

        [HttpPost("VmSlLnc")]
        public async Task<IActionResult> VmSlLnc(FuncionalidadSistemaDto dto)
        {
            try
            {
                return Ok(await _parametroFuncionalidaSistemaService.ObtenerEnlacePlan(dto.NombreFuncionalidad));
            }
            catch (Exception e)
            {
                _logger.LogError(e.Message);
                return BadRequest(e.Message);
            }
        }

        [HttpPost("VmSndCtc")]
        public IActionResult VmSndCtc(PersonaDto dto)
        {
            try
            {
                return Ok(_parametroFuncionalidaSistemaService.EnviarMailContacto(dto));
            }
            catch (Exception e)
            {
                _logger.LogError(e.Message);
                return BadRequest(e.Message);
            }
        }
    }
}
