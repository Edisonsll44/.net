using Microsoft.EntityFrameworkCore;
using Soulsplit.Api.AccesoDatos.Contratos;
using Soulsplit.Api.Utilitarios.Propiedades;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Soulpslit.Api.AccesoDatos.Repositorios
{
    public class PaisRepository : SoulsplitRepository<PaisEntity>, IPaisRepository
    {
        protected override DbSet<PaisEntity> DbEntity
        {
            get { return _soulsplitDbContext.Paises; }
        }

        public PaisRepository(ISoulsplitDbContext soulsplitDbContext) : base(soulsplitDbContext)
        {
        }

        public async Task<IEnumerable<PaisEntity>> ObtenerPaises()
        {
            var paises = _soulsplitDbContext.Paises.Where(p => p.Estado == PropiedadesAuditoria.EstadoActivo).Select(x => x);
            return await Task.FromResult(paises);
        }
    }
}
