using Soulpslit.Api.AccesoDatos.Mapeos;
using Soulsplit.Api.AccesoDatos.Contratos;
using Soulsplit.Api.Contratos;
using Soulsplit.Api.Utilitarios.Dto;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Soulsplit.Api.Aplicaciones.Servicios
{
    public class EstadoService : IEstadoService
    {
        private readonly IEstadoRepository _estadoRepository;
        private readonly IDetalleEstadoRepository _detalleEstadoRepository;
        private readonly IAuditoriaEntidadesService _auditoriaEntidadesService;
        public EstadoService(
            IEstadoRepository estadoRepository,
            IDetalleEstadoRepository detalleEstadoRepository,
            IAuditoriaEntidadesService auditoriaEntidadesService)
        {
            _estadoRepository = estadoRepository;
            _detalleEstadoRepository = detalleEstadoRepository;
            _auditoriaEntidadesService = auditoriaEntidadesService;
        }

        public async Task<DtoRespuesta> CrearEstado(DtoCombo dto)
        {
            var nuevoEstado = EstadoMapper.Map(dto);
            _auditoriaEntidadesService.InsertarDatosAuditoria(nuevoEstado, usuario: "adm");
            nuevoEstado = await _estadoRepository.Add(nuevoEstado);
            return await Respuesta.DevolverRespuesta("Estado", "creado");
        }

        public async Task<IEnumerable<DtoCombo>> ObtenerEstados()
        {
            var Estado = await _estadoRepository.GetAll();
            return await EstadoMapper.Map(Estado);
        }
        public async Task<IEnumerable<DtoCombo>> ObtenerDetallesEstado(DtoCombo dto)
        {
            var estados = _detalleEstadoRepository.ObtenerDetallesEstado(dto.Id, dto.nombre);
            return await DetalleEstadoMapper.Map(estados);
        }

        public async Task<DetalleEstadoEntity> ObtenerDetalleEstado(string cabecera, string detalle)
        {
            DetalleEstadoEntity estado = await _detalleEstadoRepository.GetOneAsync<DetalleEstadoEntity>(x => x.EstadoEnumeracion.Nombre.Equals(cabecera) && x.Nombre.Equals(detalle));
            if (estado is null)
                throw new KeyNotFoundException($"Estado:{detalle}");
            return estado;
        }

        public async Task<DetalleEstadoEntity> ObtenerDetalleEstado(Guid idEstado)
        {
            DetalleEstadoEntity estado = await _detalleEstadoRepository.GetByIdAsync<DetalleEstadoEntity>(idEstado);
            if (estado is null)
                throw new KeyNotFoundException($"Estado");
            return estado;
        }
    }
}
