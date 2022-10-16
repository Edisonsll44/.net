using System;
using System.Linq;

namespace Soulsplit.Api.AccesoDatos.Contratos
{
    public interface IDetalleEstadoRepository : IRepositoryGenerico<DetalleEstadoEntity>
    {
        IQueryable<DetalleEstadoEntity> ObtenerDetallesEstado(Guid idEstado = default(Guid), string cabeceraEstado = default(string));

    }
}
