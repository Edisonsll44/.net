using Microsoft.EntityFrameworkCore;
using Soulpslit.Api.AccesoDatos.Repositorios;
using Soulsplit.Api.AccesoDatos.Contratos;
using System;

namespace Soulsplit.Api.AccesoDatos.Repositorios
{
    public class RolRepository : SoulsplitRepository<RolEntity>, IRolRepository
    {
        protected override DbSet<RolEntity> DbEntity
        {
            get { return _soulsplitDbContext.Roles; }
        }
        public RolRepository(ISoulsplitDbContext soulsplitDbContext) : base(soulsplitDbContext)
        {
        }

        
    }
}
