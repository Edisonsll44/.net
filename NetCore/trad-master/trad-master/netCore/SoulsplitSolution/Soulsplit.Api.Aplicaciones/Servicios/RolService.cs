using Soulsplit.Api.AccesoDatos.Contratos;
using Soulsplit.Api.AccesoDatos.Mapeos;
using Soulsplit.Api.Contratos;
using Soulsplit.Api.Contratos.ContratosServicios;
using Soulsplit.Api.Utilitarios.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Soulsplit.Api.Aplicaciones.Servicios
{
    public class RolService: IRolService
    {
        private readonly IRolRepository _rolRepository;
        private readonly IAuditoriaEntidadesService _auditoriaEntidadesService;

        public RolService(IRolRepository rolRepository, IAuditoriaEntidadesService auditoriaEntidadesService)
        {
            _rolRepository = rolRepository;
            _auditoriaEntidadesService = auditoriaEntidadesService;
        }

        public async Task<DtoRespuesta> CrearRol(RolDto nuevoRol)
        {
            var rolMapeado = RolMapper.Map(nuevoRol);
            _auditoriaEntidadesService.InsertarDatosAuditoria(rolMapeado, usuario: "adm");
            await _rolRepository.Add(rolMapeado);
            return await Respuesta.DevolverRespuesta("Rol", "creado");
        }

        public async Task<DtoRespuesta> ActualizarRol(RolDto rol)
        {
            var rolMapeado = RolMapper.Map(rol);
            var rolEncontrado = await ObtenerRol(rolMapeado.Id);
            if (rolEncontrado != null)
            {
                _auditoriaEntidadesService.ActualizarAuditoria(rolEncontrado, usuario: "adm");
                await _rolRepository.Update(rolEncontrado);
                return await Respuesta.DevolverRespuesta("Rol", "modificado");
            }
            throw new Exception("Rol no encontrado.");
        }

        public async Task<IEnumerable<RolDto>> ListarRol()
        {
            IEnumerable<RolEntity> lista = await _rolRepository.GetAll();
            List<RolDto> roles = new List<RolDto>();
            if (lista?.Count() > 0)
                return await RolMapper.Map(lista);
            return roles;
        }

        private async Task<RolEntity> ObtenerRol(Guid id)
        {
            var rolEncontrado = await _rolRepository.Get(id);
            return rolEncontrado;
        }
    }
}
