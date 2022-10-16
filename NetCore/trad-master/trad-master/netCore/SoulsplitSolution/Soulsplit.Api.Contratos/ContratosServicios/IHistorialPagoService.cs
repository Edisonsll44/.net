using Soulsplit.Api.Utilitarios.Dto;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Soulsplit.Api.Contratos.ContratosServicios
{
    public interface IHistorialPagoService
    {
        Task<DtoRespuesta> CrearHistorialPago(DtoHistorialPago dto);

        Task<IEnumerable<DtoHistorialPago>> ObtenerHistorialPago(Guid idPago);
    }
}
