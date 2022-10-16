using Soulsplit.Api.AccesoDatos.Contratos;

namespace Soulpslit.Api.AccesoDatos.Repositorios
{
    public abstract class SoulsplitRepository<T> : BaseRepository<T> where T : class, IBaseWithIdEntity
    {
        //CRUD
        protected ISoulsplitDbContext _soulsplitDbContext
        {
            get { return _dbContext as ISoulsplitDbContext; }
        }

        public SoulsplitRepository(ISoulsplitDbContext soulsplitDbContext) : base(soulsplitDbContext) { }
    }
}
