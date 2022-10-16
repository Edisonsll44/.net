using Soulsplit.Api.AccesoDatos.Contratos;
using Soulsplit.Api.AccesoDatos.Contratos.Repositorios;
using Soulsplit.Api.AccesoDatos.Mapeos;
using Soulsplit.Api.Contratos;
using Soulsplit.Api.Contratos.ContratosServicios;
using Soulsplit.Api.Utilitarios.Dto;
using System;
using System.Threading.Tasks;

namespace Soulsplit.Api.Aplicaciones.Servicios
{
    public class RolUsuarioService : IRolUsuarioService
    {
        private readonly IRolUsuarioRepository _rolUsuarioRepository;
        private readonly IAuditoriaEntidadesService _auditoriaEntidadesService;
        public RolUsuarioService(IRolUsuarioRepository rolUsuarioRepository, IAuditoriaEntidadesService auditoriaEntidadesService)
        {
            _rolUsuarioRepository = rolUsuarioRepository;
            _auditoriaEntidadesService = auditoriaEntidadesService;
        }
        public async Task<DtoRespuesta> CrearRolUsuario(RolUsuarioDto nuevoRol)
        {
            var rolUsuarioMapeado = RolUsuarioMapper.Map(nuevoRol);
            return await CrearRolUsuario(rolUsuarioMapeado);
        }

        public async Task<DtoRespuesta> CrearRolUsuario(Guid rolId, Guid usuarioId)
        {
            var rolUsuarioMapeado = RolUsuarioMapper.Map(usuarioId, rolId);
            return await CrearRolUsuario(rolUsuarioMapeado);
        }

        public async Task<DtoRespuesta> EditarRolUsuario(Guid rolId, Guid rolusuarioId, string token)
        {
            var rolUsuario = await _rolUsuarioRepository.GetByIdAsync<RolUsuarioEntity>(rolusuarioId);
            rolUsuario.RolId = rolId;
            _auditoriaEntidadesService.ActualizarAuditoria(rolUsuario, token: token);
            await _rolUsuarioRepository.Update(rolUsuario);
            return await Respuesta.DevolverRespuesta("Rol usuario", "actualizado");
        }

        async Task<DtoRespuesta> CrearRolUsuario(RolUsuarioEntity rolUsuarioMapeado)
        {
            _auditoriaEntidadesService.InsertarDatosAuditoria(rolUsuarioMapeado, usuario: "adm");
            await _rolUsuarioRepository.Add(rolUsuarioMapeado);
            return await Respuesta.DevolverRespuesta("Rol usuario", "creado");
        }
    }
}