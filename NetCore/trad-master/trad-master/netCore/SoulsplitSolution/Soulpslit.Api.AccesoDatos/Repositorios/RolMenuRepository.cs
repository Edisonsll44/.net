using Microsoft.EntityFrameworkCore;
using Soulpslit.Api.AccesoDatos.Repositorios;
using Soulsplit.Api.AccesoDatos.Contratos;

namespace Soulsplit.Api.AccesoDatos.Repositorios
{
    public class RolMenuRepository : SoulsplitRepository<RolMenuEntity>, IRolMenuRepository
    {
        protected override DbSet<RolMenuEntity> DbEntity
        {
            get { return _soulsplitDbContext.RolesMenu; }
        }
        public RolMenuRepository(ISoulsplitDbContext soulsplitDbContext) : base(soulsplitDbContext)
        {
        }
    }
}
