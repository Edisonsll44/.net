using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Soulsplit.Api.Contratos.ContratosServicios;
using Soulsplit.Api.Utilitarios.Dto;
using Soulsplit.Api.Contratos.Seguridades;
using Soulsplit.Api.Validaciones.Validaciones;
using System;
using System.Threading.Tasks;
using Soulsplit.Api.ServiciosDistribuidos.Helpers;

namespace Soulsplit.Api.ServiciosDistribuidos.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [ServiceFilter(typeof(LoggerHelper))]
    public class AttctnController : ControllerBase
    {
        private readonly ILogger _logger;
        private readonly IInicioSessionValidator _inicioSessionValidator;
        private readonly IAutenticacionService _autenticacionService;
        private readonly IChannelService _channelService;
        public AttctnController(ILogger<AttctnController> logger, IAutenticacionService autenticacionService, IInicioSessionValidator inicioSessionValidator, IChannelService channelService)
        {
            _logger = logger;
            _inicioSessionValidator = inicioSessionValidator;
            _autenticacionService = autenticacionService;
            _channelService = channelService;
        }
        [HttpPost("VmLggn")]
        public async Task<IActionResult> VmLggn([FromBody] AuthRequest modelo)
        {
            try
            {
                await _inicioSessionValidator.ValidarDatosInicioSesion(modelo);
                var autenticado = await _autenticacionService.AutenticarUsuario(modelo.Email.ToLower(), modelo.Clave, modelo.Codigo);
                //await _channelService.Trigger("prueba", "feed", "new_feed");
                return Ok(autenticado);
            }
            catch (Exception e)
            {
                _logger.LogError(e.Message);
                return BadRequest(e.Message);
            }
        }

        [HttpPost]
        [Route("VmSndTp")]
        public async Task<IActionResult> VmSndTp([FromBody] AuthRequest modelo)
        {
            try
            {
                await _inicioSessionValidator.ValidarDatosOTP(modelo);
                var otp = await _autenticacionService.EnviarOTP(modelo.Email.ToLower(), modelo.Clave);
                return Ok(otp);
            }
            catch (Exception e)
            {
                _logger.LogError(e.Message);
                if (e.Message.Equals("Error: Su usuario debe estar activado para continuar, desea recibir un mail para activar su usuario?"))
                    return StatusCode(502, e.Message);
                throw new Exception(e.Message.Replace("Su usuario debe estar activado para continuar, desea recibir un mail para activar su usuario?", ""));
            }
        }

        [HttpPost]
        [Route("VmActUsr")]
        public async Task<IActionResult> VmActUsr([FromBody] AuthRequest usuario)
        {

            try
            {
                await _inicioSessionValidator.ValidarToken(usuario);
                var user = await _autenticacionService.ActivarUsuario(usuario.Token);
                return Ok(user);
            }
            catch (Exception e)
            {
                _logger.LogError(e.Message);
                throw new Exception(e.Message);
            }
        }

        [HttpPost]
        [Route("VmLgOut")]
        public async Task<IActionResult> VmLgOut([FromBody] AuthRequest usuario)
        {

            try
            {
                var user = await _autenticacionService.CerrarSessionActiva(usuario.Token);
                return Ok(user);
            }
            catch (Exception e)
            {
                _logger.LogError(e.Message);
                throw new Exception(e.Message);
            }
        }
    }
}
