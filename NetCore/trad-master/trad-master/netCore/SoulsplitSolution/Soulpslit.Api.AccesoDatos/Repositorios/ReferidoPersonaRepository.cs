using Microsoft.EntityFrameworkCore;
using Soulpslit.Api.AccesoDatos.Repositorios;
using Soulsplit.Api.AccesoDatos.Contratos;
using Soulsplit.Api.AccesoDatos.Contratos.Repositorios;
using System;

namespace Soulsplit.Api.AccesoDatos.Repositorios
{
    public class ReferidoPersonaRepository : SoulsplitRepository<ReferidosPersonaEntity>, IReferidoPersonaRepository
    {
        protected override DbSet<ReferidosPersonaEntity> DbEntity
        {
            get { return _soulsplitDbContext.ReferidosPersona; }
        }

        public ReferidoPersonaRepository(ISoulsplitDbContext soulsplitDbContext) : base(soulsplitDbContext)
        {
        }
    }
}
