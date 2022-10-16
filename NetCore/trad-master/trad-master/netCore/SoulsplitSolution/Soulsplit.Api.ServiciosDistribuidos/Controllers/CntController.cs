using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Soulsplit.Api.Contratos.ContratosServicios;
using Soulsplit.Api.ServiciosDistribuidos.Helpers;
using Soulsplit.Api.Utilitarios.Dto;
using System.Threading.Tasks;

namespace Soulsplit.Api.ServiciosDistribuidos
{
    [Authorize]
    [Produces("application/json")]
    [Route("api/[controller]")]
    [ApiController]
    [ServiceFilter(typeof(LoggerHelper))]
    public class CntController : ControllerBase
    {
        private readonly ICuentaService _CuentaService;

        public CntController(ICuentaService CuentaService)
        {
            _CuentaService = CuentaService;
        }

        [HttpPost]
        [Route("VmCrt")]
        public async Task<IActionResult> VmCrt(DtoCuenta dto)
        {
            try
            {
                var token = Request.Headers["Authorization"].ToString().Split(" ")[1];
                return Ok(await _CuentaService.CrearCuenta(dto, token));
            }
            catch
            {
                throw;
            }
        }



        [HttpPost]
        [Route("VmUp")]
        public async Task<IActionResult> VmUp(DtoCuenta dto)
        {
            try
            {
                var token = Request.Headers["Authorization"].ToString().Split(" ")[1];
                return Ok(await _CuentaService.ActualizarCuenta(dto, token));
            }
            catch
            {
                throw;
            }
        }

        [HttpPost]
        [Route("VmLst")]
        public async Task<IActionResult> VmLst()
        {
            try
            {
                return Ok(await _CuentaService.ObtenerCuentas());
            }
            catch
            {
                throw;
            }
        }

        [HttpPost]
        [Route("VmSndMl")]
        public async Task<IActionResult> VmSndMl()
        {
            try
            {
                var token = Request.Headers["Authorization"].ToString().Split(" ")[1];
                return Ok(await _CuentaService.EnviarMailCuenta(token));
            }
            catch
            {
                throw;
            }
        }


    }
}
