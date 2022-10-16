using Microsoft.EntityFrameworkCore;
using Soulsplit.Api.AccesoDatos.Contratos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Soulpslit.Api.AccesoDatos.Repositorios
{
    public class FormaPagoRepository : SoulsplitRepository<FormaPagoEntity>, IFormaPagoRepository
    {
        protected override DbSet<FormaPagoEntity> DbEntity
        {
            get { return _soulsplitDbContext.FormasPago; }
        }


        public FormaPagoRepository(ISoulsplitDbContext soulsplitDbContext) : base(soulsplitDbContext)
        {
        }
    }
}
