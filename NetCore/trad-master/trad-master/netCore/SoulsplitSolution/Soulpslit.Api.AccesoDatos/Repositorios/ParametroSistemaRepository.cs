using Microsoft.EntityFrameworkCore;
using Soulpslit.Api.AccesoDatos.Repositorios;
using Soulsplit.Api.AccesoDatos.Contratos;
using Soulsplit.Api.AccesoDatos.Contratos.Repositorios;

namespace Soulsplit.Api.AccesoDatos.Repositorios
{
    public class ParametroSistemaRepository : SoulsplitRepository<ParametroSistemaEntity>, IParametroSistemaRepository
    {
        protected override DbSet<ParametroSistemaEntity> DbEntity
        {
            get { return _soulsplitDbContext.ParametrosSistema; }
        }
        public ParametroSistemaRepository(ISoulsplitDbContext soulsplitDbContext) : base(soulsplitDbContext)
        {
        }
    }
}
