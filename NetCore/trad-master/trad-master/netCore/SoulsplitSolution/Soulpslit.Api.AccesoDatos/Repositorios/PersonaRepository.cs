using Microsoft.EntityFrameworkCore;
using Soulpslit.Api.AccesoDatos.Repositorios;
using Soulsplit.Api.AccesoDatos.Contratos;
using Soulsplit.Api.AccesoDatos.Contratos.Repositorios;
using System;

namespace Soulsplit.Api.AccesoDatos.Repositorios
{
    public class PersonaRepository : SoulsplitRepository<PersonaEntity>, IPersonaRepository
    {
        protected override DbSet<PersonaEntity> DbEntity
        {
            get { return _soulsplitDbContext.Personas; }
        }
        public PersonaRepository(ISoulsplitDbContext soulsplitDbContext) : base(soulsplitDbContext)
        {
        }
    }
}
