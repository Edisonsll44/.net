using Soulsplit.Api.Utilitarios.Dto;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Soulsplit.Api.Contratos.ContratosServicios
{
    public interface IRolMenuService
    {
        Task<IEnumerable<DtoMenu>> ObtenerMenuRol(Guid idRol);
    }
}
