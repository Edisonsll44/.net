using Microsoft.AspNetCore.Authorization;
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
    public class PsController : ControllerBase
    {
        private readonly IPaisService _paisService;
        private readonly ILogger _logger;

        public PsController(IPaisService paisService, ILogger<PsController> logger)
        {
            _paisService = paisService;
            _logger = logger;
        }

        [HttpPost("VmCrtPs")]
        public async Task<IActionResult> VmCrtPs(Pais nuevoPais)
        {
            try
            {
                var paisAgregado = await _paisService.CrearPais(nuevoPais);
                return Ok(paisAgregado);
            }
            catch (Exception e)
            {
                _logger.LogError(e.Message);
                throw new Exception(e.Message);
            }
        }

        [HttpGet("VmLstPs")]
        public async Task<IActionResult> VmLstPs()
        {
            try
            {
                var paises = await _paisService.ObtenerPaises();
                return Ok(paises);
            }
            catch (Exception e)
            {
                _logger.LogError(e.Message);
                throw new Exception(e.Message);
            }
        }

        [HttpPut("VmUpdtPs")]
        public async Task<IActionResult> VmUpdtPs([FromBody] Pais pais)
        {
            try
            {
                var paises = await _paisService.ActualizarPais(pais);
                return Ok(paises);
            }
            catch (Exception e)
            {
                _logger.LogError(e.Message);
                throw new Exception(e.Message);
            }
        }

        [HttpPut("VElmRctPs")]
        public async Task<IActionResult> VElmRctPs([FromBody] Pais pais)
        {
            try
            {
                var paises = await _paisService.EliminarPais(pais.Id, pais.Accion);
                return Ok(paises);
            }
            catch (Exception e)
            {
                _logger.LogError(e.Message);
                throw new Exception(e.Message);
            }
        }

        [HttpGet("{id}")]
        [Route("VmLstPsId")]
        [Produces("application/json", Type = typeof(Pais))]
        public async Task<IActionResult> VmLstPsId(Guid id)
        {
            try
            {
                var paises = await _paisService.ObtenerPais(id);
                return Ok(paises);
            }
            catch (Exception e)
            {
                _logger.LogError(e.Message);
                throw new Exception(e.Message);
            }
        }

        [AllowAnonymous]
        [HttpGet("VmCr")]
        public async Task<IActionResult> VmCr()
        {
            try
            {
                await _paisService.CrearPaises();
                return Ok();
            }
            catch (Exception e)
            {
                _logger.LogError(e.Message);
                throw new Exception(e.Message);
            }
        }

    }
}
