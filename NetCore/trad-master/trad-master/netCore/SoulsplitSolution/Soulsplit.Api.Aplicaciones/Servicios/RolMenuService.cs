using Soulpslit.Api.AccesoDatos.Mapeos;
using Soulsplit.Api.AccesoDatos.Contratos;
using Soulsplit.Api.AccesoDatos.Mapeos;
using Soulsplit.Api.Contratos;
using Soulsplit.Api.Contratos.ContratosServicios;
using Soulsplit.Api.Utilitarios.Dto;
using Soulsplit.Api.Utilitarios.Enumeraciones;
using Soulsplit.Api.Utilitarios.Propiedades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Soulsplit.Api.Aplicaciones.Servicios
{
    public class RolMenuService : IRolMenuService
    {
        private readonly IRolMenuRepository _rolMenuRepository;
        private readonly IAuditoriaEntidadesService _auditoriaEntidadesService;

        public RolMenuService(IRolMenuRepository rolMenuRepository, IAuditoriaEntidadesService auditoriaEntidadesService)
        {
            _rolMenuRepository = rolMenuRepository;
            _auditoriaEntidadesService = auditoriaEntidadesService;
        }
        public async Task<DtoRespuesta> CrearRolMenu(RolMenuDto nuevoRolMenu)
        {
            var rolMenuMapeado = RolMenuMapper.Map(nuevoRolMenu);
            _auditoriaEntidadesService.InsertarDatosAuditoria(rolMenuMapeado, usuario: "adm");
            await _rolMenuRepository.Add(rolMenuMapeado);
            return await Respuesta.DevolverRespuesta("Rol menú", "creado");
        }

        public async Task<DtoRespuesta> ActualizarRolMenu(RolMenuDto rolMenu)
        {
            var rolMenuMapeado = RolMenuMapper.Map(rolMenu);
            var rolMenuEncontrado = await ObtenerRolMenu(rolMenuMapeado.Id);
            if (rolMenuEncontrado != null)
            {
                _auditoriaEntidadesService.ActualizarAuditoria(rolMenuEncontrado, usuario: "adm");
                await _rolMenuRepository.Update(rolMenuEncontrado);
                return await Respuesta.DevolverRespuesta("Rol", "modificado");
            }
            throw new Exception("Rol no encontrado.");
        }

        public async Task<DtoRespuesta> EliminarRolMenu(Guid idRol, int accion)
        {
            var rolesMenusEncontrados = ObtenerRolesMenus(idRol);
            if (rolesMenusEncontrados.Any())
            {
                if (accion == (int)OperacionesBdd.Eliminar)
                {
                    AgregarAuditoria(rolesMenusEncontrados, PropiedadesAuditoria.EstadoInactivo);
                }
                else
                {
                    AgregarAuditoria(rolesMenusEncontrados, PropiedadesAuditoria.EstadoActivo);
                }
                ActualizarRolesMenus(rolesMenusEncontrados);
                return await Respuesta.DevolverRespuesta("País", accion == (int)OperacionesBdd.Eliminar ? "eliminado" : "re activado");
            }
            throw new Exception("Pais no encontrado.");
        }

        public async Task<IEnumerable<DtoMenu>> ObtenerMenuRol(Guid idRol)
        {
            IEnumerable<RolMenuEntity> lista = await _rolMenuRepository.GetAsync<RolMenuEntity>(t => t.RolId == idRol && t.Estado == PropiedadesAuditoria.EstadoActivo);
            List<DtoMenu> menu = new List<DtoMenu>();
            if (lista?.Count() > 0)
                return await MenuMapper.Map(lista.Select(m => m.Menu).Distinct());
            return menu;

        }


        private IEnumerable<RolMenuEntity> ObtenerRolesMenus(Guid idRol)
        {
            return _rolMenuRepository.GetAll<RolMenuEntity>(t => t.RolId == idRol && t.Estado == PropiedadesAuditoria.EstadoActivo);
        }

        private async Task<RolMenuEntity> ObtenerRolMenu(Guid id)
        {
            var rolMenuEncontrado = await _rolMenuRepository.Get(id);
            return rolMenuEncontrado;
        }

        void AgregarAuditoria(IEnumerable<RolMenuEntity> rolesMenu, string estado)
        {
            rolesMenu.ToList().ForEach(f => _auditoriaEntidadesService.ActualizarAuditoria(entidad: f, estado: estado, usuario: "adm"));
        }

        void ActualizarRolesMenus(IEnumerable<RolMenuEntity> rolesMenu)
        {
            rolesMenu.ToList().ForEach(f => _rolMenuRepository.Update(f));
        }
    }
}
