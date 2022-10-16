using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Soulsplit.Api.Contratos;
using Soulsplit.Api.Utilitarios.Dto;
using System;
using System.Threading.Tasks;

namespace Soulsplit.Api.ServiciosDistribuidos
{
    [Produces("application/json")]
    [Route("api/[controller]")]
    [ApiController]
    public class MnController : ControllerBase
    {
        private readonly IMenuService _menuService;
        private readonly ILogger _logger;

        public MnController(IMenuService menuService, ILogger<MnController> logger)
        {
            _menuService = menuService;
            _logger = logger;
        }

        [HttpPost]
        [Route("VmCrt")]
        public async Task<IActionResult> VmCrt(DtoMenu menu)
        {
            try
            {
                return Ok(await _menuService.CrearMenu(menu));
            }
            catch (Exception e)
            {
                _logger.LogError(e.Message);
                throw new Exception(e.Message);
            }
        }

        [HttpPost]
        [Route("VmLst")]
        [ResponseCache(Duration = 24000)]
        public async Task<IActionResult> VmLst()
        {
            try
            {
                return Ok(await _menuService.ObtenerMenu());
            }
            catch (Exception e)
            {
                _logger.LogError(e.Message);
                throw new Exception(e.Message);
            }
        }

    }
}
