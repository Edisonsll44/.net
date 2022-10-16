using Microsoft.AspNetCore.Mvc;
using Soulsplit.Api.Contratos.ApiCaller;
using Soulsplit.Api.ServiciosDistribuidos.Helpers;
using Soulsplit.Api.Utilitarios.Dto;
using System;
using System.Threading.Tasks;

namespace Soulsplit.Api.ServiciosDistribuidos.Controllers
{
    [Produces("application/json")]
    [Route("api/[controller]")]
    [ApiController]
    [ServiceFilter(typeof(LoggerHelper))]
    public class XtrnsController : ControllerBase
    {
        private readonly IApiCaller _apiCaller;

        public XtrnsController(IApiCaller apiCaller)
        {
            _apiCaller = apiCaller;
        }

        [HttpGet("{id}")]
        [Route("VmCntXtrn")]
        [Produces("application/json", Type = typeof(Pais))]
        public async Task<IActionResult> VmCntXtrn(long id)
        {
            try
            {
                var respuesta = await _apiCaller.GetServiceResponseById<Pais>("Ps", id);
                return Ok(respuesta);
            }
            catch (Exception e)
            {

                throw new Exception(e.Message);
            }
        }

    }
}
