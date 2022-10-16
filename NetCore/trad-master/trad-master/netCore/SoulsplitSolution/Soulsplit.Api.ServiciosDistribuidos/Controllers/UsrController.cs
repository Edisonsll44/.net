using Microsoft.AspNetCore.Mvc;
using Soulsplit.Api.Contratos.ContratosServicios;
using Soulsplit.Api.Utilitarios.Dto;
using System;
using System.Threading.Tasks;
using Microsoft.Extensions.Logging;
using Soulsplit.Api.Validaciones.Validaciones;
using Soulsplit.Api.ServiciosDistribuidos.Helpers;

namespace Soulsplit.Api.ServiciosDistribuidos.Controllers
{
    [Produces("application/json")]
    [Route("api/[controller]")]
    [ApiController]
    [ServiceFilter(typeof(LoggerHelper))]
    public class UsrController : ControllerBase
    {
        private readonly IUsuarioService _usuarioService;
        private readonly ILogger _logger;
        private readonly IUsuarioValidator _usuarioValidator;
        public UsrController(IUsuarioService usuarioService, ILogger<UsrController> logger, IUsuarioValidator usuarioValidator)
        {
            _usuarioService = usuarioService;
            _logger = logger;
            _usuarioValidator = usuarioValidator;
        }

        [HttpPost]
        [Route("VmCmbClv")]
        public async Task<IActionResult> VmCmbClv(AuthRequest dto)
        {
            try
            {
                return Ok(await _usuarioService.OlvidoClave(dto.Email));
            }
            catch (Exception e)
            {
                _logger.LogError(e.Message);
                throw new Exception(e.Message);
            }
        }

        [HttpPost]
        [Route("VmVldTk")]
        public async Task<IActionResult> VmVldTk(AuthRequest dto)
        {
            try
            {
                return Ok(await _usuarioService.ValidarToken(dto.Token));
            }
            catch (Exception e)
            {
                _logger.LogError(e.Message);
                throw new Exception(e.Message);
            }
        }

        [HttpPost]
        [Route("VmUpClv")]
        public async Task<IActionResult> VmUpClv(AuthRequest dto)
        {
            try
            {
                return Ok(await _usuarioService.CambioClave(dto.Token, dto.Clave));
            }
            catch (Exception e)
            {
                _logger.LogError(e.Message);
                throw new Exception(e.Message);
            }
        }

        [HttpPost]
        [Route("VmLsUsr")]
        public async Task<IActionResult> VmLsUsr()
        {
            try
            {
                var token = Request.Headers["Authorization"].ToString().Split(" ")[1];
                return Ok(await _usuarioService.ListaUsuarios(token));
            }
            catch (Exception e)
            {
                _logger.LogError(e.Message);
                throw new Exception(e.Message);
            }
        }

        [HttpPost]
        [Route("VmCrRl")]
        public async Task<IActionResult> VmCrRl(UsuarioDto dto)
        {
            try
            {
                var token = Request.Headers["Authorization"].ToString().Split(" ")[1];
                return Ok(await _usuarioService.CambioRolUsuario(dto.Id, dto.RolId, token));
            }
            catch (Exception e)
            {
                _logger.LogError(e.Message);
                throw new Exception(e.Message);
            }
        }



    }
}
