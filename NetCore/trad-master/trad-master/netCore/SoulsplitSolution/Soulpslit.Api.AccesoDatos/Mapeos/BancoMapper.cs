using System;
using Soulsplit.Api.AccesoDatos.Contratos;
using Soulsplit.Api.Utilitarios.Dto;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Soulpslit.Api.AccesoDatos.Mapeos
{
    public static class BancoMapper
    {
        public static BancoEntity Map(DtoCombo dto)
        {
            return new BancoEntity
            {
                Id = dto.Id,
                Nombre = dto.nombre,
                Codigo = dto.codigo,
            };
        }

        public static Task<IEnumerable<DtoCombo>> Map(IEnumerable<BancoEntity> listaBancos)
        {
            return Task.FromResult(listaBancos?.AsEnumerable()?.Select(x => new DtoCombo()
            {
                Id = x.Id,
                nombre = x.Nombre,
                codigo = x.Codigo
            }));
        }

    }
}
