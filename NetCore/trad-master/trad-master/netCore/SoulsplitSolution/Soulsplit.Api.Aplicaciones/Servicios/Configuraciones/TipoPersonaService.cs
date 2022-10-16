using Soulsplit.Api.AccesoDatos.Contratos;
using Soulsplit.Api.AccesoDatos.Mapeos;
using Soulsplit.Api.Contratos;
using Soulsplit.Api.Contratos.ContratosServicios.Configuraciones;
using Soulsplit.Api.Utilitarios.Dto;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Soulsplit.Api.Aplicaciones.Servicios.Configuraciones
{
    public class TipoPersonaService : ITipoPersonaService
    {
        private readonly ITipoPersonaRepository _tipoPersonaRepository;
        private readonly IAuditoriaEntidadesService _auditoriaEntidadesService;
        public TipoPersonaService(IAuditoriaEntidadesService auditoriaEntidadesService, ITipoPersonaRepository tipoPersonaRepository)
        {
            _tipoPersonaRepository = tipoPersonaRepository;
            _auditoriaEntidadesService = auditoriaEntidadesService;
        }
        public async Task<DtoRespuesta> CrearTipoPersona(TipoPersonaDto nuevoTipoPersonaapeado)
        {
            var tipoPersonaMapeado = TipoPersonaMapper.Map(nuevoTipoPersonaapeado);
            _auditoriaEntidadesService.InsertarDatosAuditoria(tipoPersonaMapeado, usuario: "adm");
            await _tipoPersonaRepository.Add(tipoPersonaMapeado);
            return await Respuesta.DevolverRespuesta("Tipo de persona", "creado");
        }

        public async Task<List<TipoPersonaDto>> ListarTipoPersonas()
        {
            var tiposPersona = await _tipoPersonaRepository.ObtenerTiposPersonas();
            return await TipoPersonaMapper.Map(tiposPersona);
        }

        public async Task<DtoRespuesta> ModificarTipoPersona(TipoPersonaDto tipoPersona)
        {
            var tipoPersonaMapeado = TipoPersonaMapper.Map(tipoPersona);
            var tipoPersonaEncontrado = await ObtenerTipoPersona(tipoPersonaMapeado.Id);
            if (tipoPersonaEncontrado != null)
            {
                _auditoriaEntidadesService.ActualizarAuditoria(tipoPersonaEncontrado, usuario: "adm");
                await _tipoPersonaRepository.Update(tipoPersonaEncontrado);
                return await Respuesta.DevolverRespuesta("País", "modificado");
            }
            throw new Exception("Pais no encontrado.");
        }
        public async Task<TipoPersonaEntiy> ObtenerTipoPersona(Guid id)
        {
            var tipoPersonaEncontrada = await _tipoPersonaRepository.Get(id);
            return tipoPersonaEncontrada;
        }
    }
}