using Soulsplit.Api.Utilitarios.Dto;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Soulsplit.Api.Contratos.ContratosServicios
{
    public interface IRolService
    {
        Task<IEnumerable<RolDto>> ListarRol();
        Task<DtoRespuesta> CrearRol(RolDto nuevoRol);
        Task<DtoRespuesta> ActualizarRol(RolDto rol);
    }
}
