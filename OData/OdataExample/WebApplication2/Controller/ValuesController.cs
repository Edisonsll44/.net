using Inpsercom.LogicaNegocio.Servicios.Core;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WebApplication2.Controller
{
    [Route("api/[controller]")]
    [ApiController]
    public class ValuesController : ControllerBase
    {
        private readonly ILogger _logger;
        private readonly IPaisService _paisService;

        public ValuesController(ILogger logger, IPaisService paisService)
        {
            _logger = logger;   
            _paisService = paisService;
        }

        public async Task<IActionResult> PruebaPais()
        {
            try
            {
                return Ok(await _paisService.ListarPaises("ACTIVO"));
            }
            catch (Exception e)
            {
                _logger.LogError(e.Message);
                throw new Exception(e.Message);
            }
        }
    }
}
