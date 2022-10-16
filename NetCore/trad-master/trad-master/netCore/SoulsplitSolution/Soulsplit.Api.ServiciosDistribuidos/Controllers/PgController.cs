using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Soulsplit.Api.Contratos.ContratosServicios;
using Soulsplit.Api.ServiciosDistribuidos.Helpers;
using Soulsplit.Api.Utilitarios.Dto;
using Soulsplit.Api.Validaciones.Validaciones;
using System;
using System.Threading.Tasks;

namespace Soulsplit.Api.ServiciosDistribuidos
{
    [Authorize]
    [Produces("application/json")]
    [Route("api/[controller]")]
    [ApiController]
    [ServiceFilter(typeof(LoggerHelper))]
    public class PgController : ControllerBase
    {
        private readonly IPagoService _pagoService;
        private readonly IPagoValidator _pagoValidator;

        public PgController(IPagoService pagoService, IPagoValidator pagoValidator)
        {
            _pagoService = pagoService;
            _pagoValidator = pagoValidator;
        }

        [HttpPost]
        [Route("VmCrt")]
        public async Task<IActionResult> VmCrt(DtoPago dto)
        {
            try
            {
                var token = Request.Headers["Authorization"].ToString().Split(" ")[1];
                await _pagoValidator.ValidarPago(dto);
                return Ok(await _pagoService.CrearPago(dto, token));
            }
            catch
            {
                throw;
            }
        }


        [HttpPost]
        [Route("VmUplF")]
        public async Task<IActionResult> VmUplF(Guid id)
        {
            try
            {
                var token = Request.Headers["Authorization"].ToString().Split(" ")[1];
                var file = Request.Form.Files.Count > 0 ? Request.Form.Files[0] : throw new System.Exception("Imagen requerida");
                return Ok(await _pagoService.CargarPago(file, id, token));
            }
            catch
            {
                throw;
            }
        }

        [AllowAnonymous]
        [HttpPost]
        [Route("VmUplFL")]
        public async Task<IActionResult> VmUplFL()
        {
            try
            {
                var file = Request.Form.Files.Count > 0 ? Request.Form.Files[0] : throw new System.Exception("Imagen requerida");
                await _pagoService.CargarPago(file);
                return Ok();
            }
            catch
            {
                throw;
            }
        }

        [HttpPost]
        [Route("VmLst")]
        public async Task<IActionResult> VmLst(DtoConsultaPago dto)
        {
            try
            {
                return Ok(await _pagoService.ObtenerPagos(dto));
            }
            catch
            {
                throw;
            }
        }

        [HttpPost]
        [Route("VmLstPs")]
        public async Task<IActionResult> VmLstPs()
        {
            try
            {
                var token = Request.Headers["Authorization"].ToString().Split(" ")[1];
                return Ok(await _pagoService.ObtenerPagosUsuario(token));
            }
            catch
            {
                throw;
            }
        }

        [HttpPost]
        [Route("VmUpPg")]
        public async Task<IActionResult> VmUpPg(DtoPagoConciliacion dto)
        {
            try
            {
                return Ok(await _pagoService.ActualizarPago(dto, Request.Headers["Authorization"].ToString().Split(" ")[1]));
            }
            catch
            {
                throw;
            }
        }
    }
}
