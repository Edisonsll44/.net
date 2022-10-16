using System;
using Soulsplit.Api.AccesoDatos.Contratos;
using Soulsplit.Api.Utilitarios.Dto;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Soulpslit.Api.AccesoDatos.Mapeos
{
    public static class MenuMapper
    {
        public static MenuEntity Map(DtoMenu dto)
        {
            return new MenuEntity
            {
                Id = Guid.NewGuid(),
                NombrePagina = dto.Titulo,
                UrlMenu = dto.Url,
                IconoMenu = dto.Icono,
            };
        }

        public static Task<IEnumerable<DtoMenu>> Map(IEnumerable<MenuEntity> listaMenus)
        {
            IEnumerable<DtoMenu> menu = ConvertirEntidadGenerico(listaMenus);
            return Task.FromResult(menu);
        }

        static IEnumerable<DtoMenu> ConvertirEntidadGenerico(IEnumerable<MenuEntity> listaMenus, Guid idMenu = default(Guid))
        {
            IEnumerable<MenuEntity> menu = idMenu == Guid.Empty ? listaMenus.Where(d => d.PadreId is null) : listaMenus.Where(d => d.PadreId == idMenu);
            return menu?.AsEnumerable()?.OrderBy(x => x.Orden)?.Select(item => new DtoMenu()
            {
                Titulo = item.NombrePagina,
                Url = item.UrlMenu,
                Icono = item.IconoMenu,
            });
        }
    }
}
