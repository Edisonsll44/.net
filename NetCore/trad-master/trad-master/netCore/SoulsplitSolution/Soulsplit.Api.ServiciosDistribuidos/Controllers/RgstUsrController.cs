using AspNetCore.ReCaptcha;
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
    [Produces("application/json")]
    [Route("api/[controller]")]
    [ApiController]
    [ServiceFilter(typeof(LoggerHelper))]
    public class RgstUsrController : ControllerBase
    {
        private readonly IPersonaValidator _personaValidator;
        private readonly IPersonaService _personaService;
        private readonly ILogger _logger;
        private readonly IValidatorReCaptcha _reCaptchaService;
        public RgstUsrController(IPersonaValidator personaValidator, IPersonaService personaService, ILogger<RgstUsrController> logger, IValidatorReCaptcha reCaptchaService)
        {
            _personaValidator = personaValidator;
            _personaService = personaService;
            _logger = logger;
            _reCaptchaService = reCaptchaService;
        }

        //[ValidateReCaptcha]
        [HttpPost]
        [Route("VmRgstUsr")]
        public async Task<IActionResult> VmRgstUsr([FromBody] PersonaDto persona)
        {
            try
            {
                await _personaValidator.ValidarPersona(persona);
                //_reCaptchaService.ReCaptchValido(persona.Token);
                var personaAgregada = await _personaService.CrearPersona(persona);

                return Ok(personaAgregada);
            }
            catch (Exception e)
            {
                _logger.LogError(e.Message);
                throw new Exception(e.Message);
            }
        }

        [HttpPost]
        [Route("VmSnMl")]
        public async Task<IActionResult> VmSnMl([FromBody] PersonaDto persona)
        {
            try
            {
                var personaAgregada = await _personaService.MailBienvenida(persona.Email);
                return Ok(personaAgregada);
            }
            catch (Exception e)
            {
                _logger.LogError(e.Message);
                throw new Exception(e.Message);
            }
        }

        [HttpPut]
        [Route("VmUpUsr")]
        public async Task<IActionResult> VmUpUsr([FromBody] PersonaDto persona)
        {
            try
            {
                var token = Request.Headers["Authorization"].ToString().Split(" ")[1];
                var personaAgregada = await _personaService.ActualizarPersona(persona, token);
                return Ok(personaAgregada);
            }
            catch (Exception e)
            {
                _logger.LogError(e.Message);
                throw new Exception(e.Message);
            }
        }

        [HttpPost]
        [Route("VmLsUsr")]
        public async Task<IActionResult> VmLsUsr([FromBody] PersonaDto persona)
        {
            try
            {
                var token = Request.Headers["Authorization"].ToString().Split(" ")[1];
                var personaAgregada = await _personaService.ObtenerDatosPersona(token);
                return Ok(personaAgregada);
            }
            catch (Exception e)
            {
                _logger.LogError(e.Message);
                throw new Exception(e.Message);
            }
        }
    }

}
