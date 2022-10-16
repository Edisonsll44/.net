using Microsoft.EntityFrameworkCore;
using Soulpslit.Api.AccesoDatos.Repositorios;
using Soulsplit.Api.AccesoDatos.Contratos;
using Soulsplit.Api.AccesoDatos.Contratos.Entidades.Entidades.Configuracion;
using Soulsplit.Api.Utilitarios.Propiedades;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Soulsplit.Api.AccesoDatos.Repositorios
{
    public class TipoDocumentoRepository : SoulsplitRepository<TipoIdentificacionEntity>, ITipoDocumentoRepository
    {
        public TipoDocumentoRepository(ISoulsplitDbContext soulsplitDbContext) : base(soulsplitDbContext)
        {
        }

        protected override DbSet<TipoIdentificacionEntity> DbEntity
        {
            get { return _soulsplitDbContext.TipoIdentificaciones; }
        }

        public async Task<IEnumerable<TipoIdentificacionEntity>> ObtenerTiposIdentificaciones()
        {
            var tiposIdentificacion = _soulsplitDbContext.TipoIdentificaciones.Where(p => p.Estado == PropiedadesAuditoria.EstadoActivo).Select(x => x);
            return await Task.FromResult(tiposIdentificacion);
        }
    }
}