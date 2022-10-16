using Microsoft.EntityFrameworkCore;
using Soulsplit.Api.AccesoDatos.Contratos;

namespace Soulpslit.Api.AccesoDatos.Repositorios
{
    public class HistorialPagoRepository : SoulsplitRepository<HistorialPagoEntity>, IHistorialPagoRepository
    {
        protected override DbSet<HistorialPagoEntity> DbEntity
        {
            get { return _soulsplitDbContext.HistorialPagos; }
        }


        public HistorialPagoRepository(ISoulsplitDbContext soulsplitDbContext) : base(soulsplitDbContext)
        {
        }

    }
}
