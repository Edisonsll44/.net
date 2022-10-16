using Microsoft.EntityFrameworkCore;
using Soulsplit.Api.AccesoDatos.Contratos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Soulpslit.Api.AccesoDatos.Repositorios
{
    public class MenuRepository : SoulsplitRepository<MenuEntity>, IMenuRepository
    {
        protected override DbSet<MenuEntity> DbEntity
        {
            get { return _soulsplitDbContext.Menus; }
        }


        public MenuRepository(ISoulsplitDbContext soulsplitDbContext) : base(soulsplitDbContext)
        {
        }
    }
}
