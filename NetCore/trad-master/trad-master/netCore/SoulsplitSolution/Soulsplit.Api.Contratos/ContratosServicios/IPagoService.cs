using Microsoft.AspNetCore.Http;
using Soulsplit.Api.Utilitarios.Dto;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Soulsplit.Api.Contratos.ContratosServicios
{
    public interface IPagoService
    {
        Task<DtoRespuesta> CrearPago(DtoPago dto, string token);
        Task<DtoRespuesta> CargarPago(IFormFile archivo, Guid idPago, string token);

        Task CargarPago(IFormFile archivo, string bucketName = "nacho");
        Task<IEnumerable<DtoConsultaPago>> ObtenerPagos(DtoConsultaPago dto);
        Task<IEnumerable<DtoConsultaPago>> ObtenerPagosUsuario(string token);
        Task<DtoRespuesta> ActualizarPago(DtoPagoConciliacion dto, string token);
    }
}
