using System.Collections.Generic;
using System.Threading.Tasks;

namespace Soulsplit.Api.AccesoDatos.Contratos.Entidades.Entidades.Configuracion
{
    public interface ITipoDocumentoRepository : IRepositoryGenerico<TipoIdentificacionEntity>
    {
        Task<IEnumerable<TipoIdentificacionEntity>> ObtenerTiposIdentificaciones();
    }
}