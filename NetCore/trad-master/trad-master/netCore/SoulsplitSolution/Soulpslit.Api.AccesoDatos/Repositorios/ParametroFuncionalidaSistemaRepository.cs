using Microsoft.EntityFrameworkCore;
using Soulpslit.Api.AccesoDatos.Repositorios;
using Soulsplit.Api.AccesoDatos.Contratos;
using Soulsplit.Api.AccesoDatos.Contratos.Repositorios;

namespace Soulsplit.Api.AccesoDatos.Repositorios
{
    public class ParametroFuncionalidaSistemaRepository : SoulsplitRepository<FuncionalidadParametroSistemaEntity>, IParametroFuncionalidaSistemaRepository
    {
        
        public ParametroFuncionalidaSistemaRepository(ISoulsplitDbContext soulsplitDbContext) : base(soulsplitDbContext)
        {
        }

        protected override DbSet<FuncionalidadParametroSistemaEntity> DbEntity
        {
            get { return _soulsplitDbContext.FuncionalidadesParametroSistema; }
        }
    }
}
