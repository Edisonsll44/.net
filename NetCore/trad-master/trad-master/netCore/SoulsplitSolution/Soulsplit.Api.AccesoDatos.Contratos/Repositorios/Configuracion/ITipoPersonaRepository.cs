using System.Collections.Generic;
using System.Threading.Tasks;

namespace Soulsplit.Api.AccesoDatos.Contratos
{
    public interface ITipoPersonaRepository : IRepositoryGenerico<TipoPersonaEntiy>
    {
        Task<IEnumerable<TipoPersonaEntiy>> ObtenerTiposPersonas();
    }
}