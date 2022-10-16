using Soulsplit.Api.Utilitarios.Dto;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Soulsplit.Api.Contratos
{
    public interface ITipoCuentaService
    {
        Task<IEnumerable<DtoCombo>> ObtenerTipoCuentas();
    }
}
