using Microsoft.EntityFrameworkCore;
using Soulpslit.Api.AccesoDatos.Repositorios;
using Soulsplit.Api.AccesoDatos.Contratos;
using Soulsplit.Api.AccesoDatos.Contratos.Repositorios;
using System;

namespace Soulsplit.Api.AccesoDatos.Repositorios
{
    public class UsuarioRepository : SoulsplitRepository<UsuarioEntity>, IUsuarioRepository
    {
        protected override DbSet<UsuarioEntity> DbEntity
        {
            get { return _soulsplitDbContext.Usuarios; }
        }

        public UsuarioRepository(ISoulsplitDbContext soulsplitDbContext) : base(soulsplitDbContext)
        {
        }
    }
}
