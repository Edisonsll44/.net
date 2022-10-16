using System;
using Soulsplit.Api.AccesoDatos.Contratos;
using Soulsplit.Api.Utilitarios.Dto;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Soulpslit.Api.AccesoDatos.Mapeos
{
    public static class TipoCuentaMapper
    {
        public static TipoCuentaEntity Map(DtoCombo dto)
        {
            return new TipoCuentaEntity
            {
                Id = dto.Id,
                Nombre = dto.nombre,
                Codigo = dto.codigo,
            };
        }

        public static Task<IEnumerable<DtoCombo>> Map(IEnumerable<TipoCuentaEntity> listaTipoCuentas)
        {
            return Task.FromResult(listaTipoCuentas?.AsEnumerable()?.Select(x => new DtoCombo()
            {
                Id = x.Id,
                nombre = x.Nombre,
                codigo = x.Codigo
            }));
        }

    }
}
