using Microsoft.EntityFrameworkCore;
using Soulpslit.Api.AccesoDatos.Repositorios;
using Soulsplit.Api.AccesoDatos.Contratos;
using Soulsplit.Api.AccesoDatos.Contratos.Repositorios;

namespace Soulsplit.Api.AccesoDatos.Repositorios
{
    public class RolUsuarioRepository : SoulsplitRepository<RolUsuarioEntity>, IRolUsuarioRepository
    {
        protected override DbSet<RolUsuarioEntity> DbEntity
        {
            get { return _soulsplitDbContext.RolesUsuario; }
        }
        public RolUsuarioRepository(ISoulsplitDbContext soulsplitDbContext) : base(soulsplitDbContext)
        {
        }


    }
}