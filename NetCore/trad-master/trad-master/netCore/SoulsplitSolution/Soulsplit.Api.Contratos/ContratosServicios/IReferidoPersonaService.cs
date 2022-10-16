using Soulsplit.Api.Utilitarios.Dto;
using System;
using System.Threading.Tasks;

namespace Soulsplit.Api.Contratos.ContratosServicios
{
    public interface IReferidoPersonaService
    {
        Task<DtoRespuesta> CrearReferido(string codigoReferido, Guid referido);
    }
}
