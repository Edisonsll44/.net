using Microsoft.EntityFrameworkCore;
using Soulsplit.Api.AccesoDatos.Contratos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Soulpslit.Api.AccesoDatos.Repositorios
{
    public class EstadoRepository : SoulsplitRepository<EstadoEnumeracionEntity>, IEstadoRepository
    {
        protected override DbSet<EstadoEnumeracionEntity> DbEntity
        {
            get { return _soulsplitDbContext.EstadosEnumeracion; }
        }


        public EstadoRepository(ISoulsplitDbContext soulsplitDbContext) : base(soulsplitDbContext)
        {
        }
    }
}
