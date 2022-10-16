using Microsoft.EntityFrameworkCore;
using Soulsplit.Api.AccesoDatos.Contratos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Soulpslit.Api.AccesoDatos.Repositorios
{
    public class BancoRepository : SoulsplitRepository<BancoEntity>, IBancoRepository
    {
        protected override DbSet<BancoEntity> DbEntity
        {
            get { return _soulsplitDbContext.Bancos; }
        }


        public BancoRepository(ISoulsplitDbContext soulsplitDbContext) : base(soulsplitDbContext)
        {
        }
    }
}
