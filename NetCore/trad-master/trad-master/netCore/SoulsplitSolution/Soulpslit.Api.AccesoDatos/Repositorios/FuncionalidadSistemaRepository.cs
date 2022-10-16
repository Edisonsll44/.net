using Microsoft.EntityFrameworkCore;
using Soulpslit.Api.AccesoDatos.Repositorios;
using Soulsplit.Api.AccesoDatos.Contratos;

namespace Soulsplit.Api.AccesoDatos.Repositorios
{
    public class FuncionalidadSistemaRepository : SoulsplitRepository<FuncionalidadEntity>, IFuncionalidadSistemaRepository
    {
        protected override DbSet<FuncionalidadEntity> DbEntity
        {
            get { return _soulsplitDbContext.Funcionalidades; }
        }

        public FuncionalidadSistemaRepository(ISoulsplitDbContext soulsplitDbContext) : base(soulsplitDbContext)
        {
        }

       
    }
}
