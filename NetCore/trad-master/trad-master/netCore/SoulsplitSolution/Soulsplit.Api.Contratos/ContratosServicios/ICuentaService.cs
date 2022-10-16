using Soulsplit.Api.Utilitarios.Dto;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Soulsplit.Api.Contratos.ContratosServicios
{
    public interface ICuentaService
    {
        Task<DtoRespuesta> CrearCuenta(DtoCuenta dto, string token);

        Task<DtoRespuesta> ActualizarCuenta(DtoCuenta dto, string token);
        Task<IEnumerable<DtoCuenta>> ObtenerCuentas();
        Task<DtoRespuesta> EnviarMailCuenta(string token);
    }
}
