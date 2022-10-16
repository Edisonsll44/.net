using Microsoft.EntityFrameworkCore;
using Soulsplit.Api.AccesoDatos.Contratos;

namespace Soulpslit.Api.AccesoDatos.Repositorios
{
    public class CuentaRepository : SoulsplitRepository<CuentaEntity>, ICuentaRepository
    {
        protected override DbSet<CuentaEntity> DbEntity
        {
            get { return _soulsplitDbContext.Cuentas; }
        }


        public CuentaRepository(ISoulsplitDbContext soulsplitDbContext) : base(soulsplitDbContext)
        {
        }

    }
}
