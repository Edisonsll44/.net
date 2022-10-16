using Soulsplit.Api.AccesoDatos.Contratos;
using Soulsplit.Api.Utilitarios.Dto;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Soulsplit.Api.Contratos
{
    public interface IEstadoService
    {
        Task<DtoRespuesta> CrearEstado(DtoCombo nuevoEstado);

        Task<IEnumerable<DtoCombo>> ObtenerEstados();

        Task<IEnumerable<DtoCombo>> ObtenerDetallesEstado(DtoCombo dto);
        Task<DetalleEstadoEntity> ObtenerDetalleEstado(string cabecera, string detalle);
        Task<DetalleEstadoEntity> ObtenerDetalleEstado(Guid idEstado);
    }
}
