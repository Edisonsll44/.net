using Microsoft.EntityFrameworkCore;
using Soulpslit.Api.AccesoDatos.Repositorios;
using Soulsplit.Api.AccesoDatos.Contratos;
using Soulsplit.Api.Utilitarios.Propiedades;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Soulsplit.Api.AccesoDatos.Repositorios
{
    public class TipoPersonaRepository : SoulsplitRepository<TipoPersonaEntiy>, ITipoPersonaRepository
    {
        protected override DbSet<TipoPersonaEntiy> DbEntity
        {
            get { return _soulsplitDbContext.TipoPersonas; }
        }
        public TipoPersonaRepository(ISoulsplitDbContext soulsplitDbContext) : base(soulsplitDbContext)
        {

        }

        public async Task<IEnumerable<TipoPersonaEntiy>> ObtenerTiposPersonas()
        {
            var tiposPersona = _soulsplitDbContext.TipoPersonas.Where(p => p.Estado == PropiedadesAuditoria.EstadoActivo).Select(x => x);
            return await Task.FromResult(tiposPersona);
        }
    }
}