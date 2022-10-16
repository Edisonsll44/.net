using System.Collections.Generic;
using System.Threading.Tasks;

namespace Soulsplit.Api.AccesoDatos.Contratos
{
    public interface IPaisRepository : IRepositoryGenerico<PaisEntity>
    {
        Task<IEnumerable<PaisEntity>> ObtenerPaises();
    }
}
