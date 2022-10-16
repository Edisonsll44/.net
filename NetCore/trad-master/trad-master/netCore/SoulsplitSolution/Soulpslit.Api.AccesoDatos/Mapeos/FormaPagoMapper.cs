using System;
using Soulsplit.Api.AccesoDatos.Contratos;
using Soulsplit.Api.Utilitarios.Dto;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Soulpslit.Api.AccesoDatos.Mapeos
{
    public static class FormaPagoMapper
    {
        public static FormaPagoEntity Map(DtoCombo dto)
        {
            return new FormaPagoEntity
            {
                Id = dto.Id,
                Nombre = dto.nombre,
                Codigo = dto.codigo,
                Componente = dto.componente
            };
        }

        public static Task<IEnumerable<DtoCombo>> Map(IEnumerable<FormaPagoEntity> listaFormaPagos)
        {
            return Task.FromResult(listaFormaPagos?.AsEnumerable()?.Select(x => new DtoCombo()
            {
                Id = x.Id,
                nombre = x.Nombre,
                codigo = x.Codigo,
                componente = x.Componente
            }));
        }

    }
}
