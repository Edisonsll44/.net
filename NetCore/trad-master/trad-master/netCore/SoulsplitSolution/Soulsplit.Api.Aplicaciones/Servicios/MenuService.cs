using Soulpslit.Api.AccesoDatos.Mapeos;
using Soulsplit.Api.AccesoDatos.Contratos;
using Soulsplit.Api.Contratos;
using Soulsplit.Api.Utilitarios.Dto;
using Soulsplit.Api.Utilitarios.Propiedades;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Soulsplit.Api.Aplicaciones.Servicios
{
    public class MenuService : IMenuService
    {
        private readonly IMenuRepository _menuRepository;
        private readonly IAuditoriaEntidadesService _auditoriaEntidadesService;
        public MenuService(IMenuRepository menuRepository, IAppConfig appConfig, IAuditoriaEntidadesService auditoriaEntidadesService)
        {
            _auditoriaEntidadesService = auditoriaEntidadesService;
            _menuRepository = menuRepository;
        }

        public async Task<DtoRespuesta> CrearMenu(DtoMenu dto)
        {
            var nuevoMenu = MenuMapper.Map(dto);
            _auditoriaEntidadesService.InsertarDatosAuditoria(nuevoMenu, usuario: "adm");
            nuevoMenu = await _menuRepository.Add(nuevoMenu);
            return await Respuesta.DevolverRespuesta("Menu", "creado");
        }

        public async Task<IEnumerable<DtoMenu>> ObtenerMenu()
        {
            var menu = await _menuRepository.GetAsync<MenuEntity>(x => x.Estado.Equals(PropiedadesAuditoria.EstadoActivo));
            return await MenuMapper.Map(menu);
        }
    }
}
