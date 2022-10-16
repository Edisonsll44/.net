using Microsoft.EntityFrameworkCore;
using Soulsplit.Api.AccesoDatos.Contratos;

namespace Soulpslit.Api.AccesoDatos.Repositorios
{
    public class AuditoriaAccesoUsuarioRepository : SoulsplitRepository<AuditoriaAccesoUsuarioEntity>, IAuditoriaAccesoUsuarioRepository
    {
        protected override DbSet<AuditoriaAccesoUsuarioEntity> DbEntity
        {
            get { return _soulsplitDbContext.AuditoriaAccesoUsuarios; }
        }


        public AuditoriaAccesoUsuarioRepository(ISoulsplitDbContext soulsplitDbContext) : base(soulsplitDbContext)
        {
        }
    }
}
