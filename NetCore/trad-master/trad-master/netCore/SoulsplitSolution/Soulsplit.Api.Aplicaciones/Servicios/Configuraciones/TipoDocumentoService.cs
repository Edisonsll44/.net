using Soulsplit.Api.AccesoDatos.Contratos;
using Soulsplit.Api.AccesoDatos.Contratos.Entidades.Entidades.Configuracion;
using Soulsplit.Api.AccesoDatos.Mapeos;
using Soulsplit.Api.Contratos;
using Soulsplit.Api.Utilitarios.Dto;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Soulsplit.Api.Aplicaciones.Servicios.Configuraciones
{
    public class TipoDocumentoService : ITipoDocumentoService
    {
        private readonly ITipoDocumentoRepository _tipoDocumentoRepository;
        private readonly IAuditoriaEntidadesService _auditoriaEntidadesService;
        public TipoDocumentoService(ITipoDocumentoRepository tipoDocumentoRepository, IAuditoriaEntidadesService auditoriaEntidadesService)
        {
            _tipoDocumentoRepository = tipoDocumentoRepository;
            _auditoriaEntidadesService = auditoriaEntidadesService;
        }
        public async Task<DtoRespuesta> CrearTipoDocumento(TipoDocumentoDto nuevoTipoDocumento)
        {
            var tipoDocumentoMapeado = TipoDocumentoMapper.Map(nuevoTipoDocumento);
            _auditoriaEntidadesService.InsertarDatosAuditoria(tipoDocumentoMapeado, usuario: "adm");
            await _tipoDocumentoRepository.Add(tipoDocumentoMapeado);
            return await Respuesta.DevolverRespuesta("Tipo documento", "creado");
        }

        public async Task<List<TipoDocumentoDto>> ListarTipoDocumentos()
        {
            var tiposDocumento = await _tipoDocumentoRepository.ObtenerTiposIdentificaciones();
            return await TipoDocumentoMapper.Map(tiposDocumento);
        }

        public async Task<DtoRespuesta> ModificarTipoDocumento(TipoDocumentoDto tipoDocumento)
        {
            var documentoMapeado = TipoDocumentoMapper.Map(tipoDocumento);
            var documentoEncontrado = await ObtenerIdentificacion(documentoMapeado.Id);
            if (documentoEncontrado != null)
            {
                _auditoriaEntidadesService.ActualizarAuditoria(documentoEncontrado, usuario: "adm");
                await _tipoDocumentoRepository.Update(documentoEncontrado);
                return await Respuesta.DevolverRespuesta("País", "modificado");
            }
            throw new Exception("Pais no encontrado.");
        }
        public async Task<TipoIdentificacionEntity> ObtenerIdentificacion(Guid id)
        {
            var identificacionEncontrada = await _tipoDocumentoRepository.Get(id);
            return identificacionEncontrada;
        }
    }
}