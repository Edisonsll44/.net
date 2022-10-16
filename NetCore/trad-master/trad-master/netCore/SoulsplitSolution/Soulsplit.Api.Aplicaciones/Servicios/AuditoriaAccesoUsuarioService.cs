using Soulpslit.Api.AccesoDatos.Mapeos;
using Soulsplit.Api.AccesoDatos.Contratos;
using Soulsplit.Api.Contratos;
using Soulsplit.Api.Utilitarios.Dto;
using Soulsplit.Api.Utilitarios.Propiedades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Soulsplit.Api.Aplicaciones.Servicios
{
    public class AuditoriaAccesoUsuarioService : IAuditoriaAccesoUsuarioService
    {
        private readonly IAuditoriaAccesoUsuarioRepository _auditoriaAccesoUsuarioRepository;
        private readonly IAuditoriaEntidadesService _auditoriaEntidadesService;
        public AuditoriaAccesoUsuarioService(IAuditoriaAccesoUsuarioRepository auditoriaAccesoUsuarioRepository, IAuditoriaEntidadesService auditoriaEntidadesService)
        {
            _auditoriaEntidadesService = auditoriaEntidadesService;
            _auditoriaAccesoUsuarioRepository = auditoriaAccesoUsuarioRepository;
        }

        public async Task<DtoRespuesta> CrearAuditoriaAccesoUsuario(DtoAuditoriaAccesoUsuario dto)
        {
            await InactivarAuditoriaAccesoUsuario(dto.UsuarioId);
            var nuevaAuditoria = AuditoriaAccesoUsuarioMapper.Map(dto);
            _auditoriaEntidadesService.InsertarDatosAuditoria(nuevaAuditoria, usuario: "adm");
            nuevaAuditoria = await _auditoriaAccesoUsuarioRepository.Add(nuevaAuditoria);
            return await Respuesta.DevolverRespuesta("Auditoria", "creada");
        }

        private async Task<DtoRespuesta> InactivarAuditoriaAccesoUsuario(Guid idUsuario)
        {
            var auditorias = _auditoriaAccesoUsuarioRepository.GetAll<AuditoriaAccesoUsuarioEntity>(x => x.UsuarioId == idUsuario && x.Estado == PropiedadesAuditoria.EstadoActivo);
            if (auditorias.Any())
            {
                foreach (var item in auditorias)
                {
                    _auditoriaEntidadesService.ActualizarAuditoria(item, estado: PropiedadesAuditoria.EstadoInactivo);
                    await _auditoriaAccesoUsuarioRepository.Update(item);
                }
                return await Respuesta.DevolverRespuesta("Auditoria", "inactivada");
            }
            return new DtoRespuesta { Bdt1 = false };

        }
    }
}
