using Microsoft.EntityFrameworkCore;
using Soulsplit.Api.AccesoDatos.Contratos;

namespace Soulpslit.Api.AccesoDatos.Repositorios
{
    public class TipoCuentaRepository : SoulsplitRepository<TipoCuentaEntity>, ITipoCuentaRepository
    {
        protected override DbSet<TipoCuentaEntity> DbEntity
        {
            get { return _soulsplitDbContext.TiposCuenta; }
        }


        public TipoCuentaRepository(ISoulsplitDbContext soulsplitDbContext) : base(soulsplitDbContext)
        {
        }
    }
}
