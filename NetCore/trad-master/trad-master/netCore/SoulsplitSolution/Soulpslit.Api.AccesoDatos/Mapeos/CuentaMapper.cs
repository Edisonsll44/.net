using Soulsplit.Api.AccesoDatos.Contratos;
using Soulsplit.Api.Utilitarios.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Soulpslit.Api.AccesoDatos.Mapeos
{
    public static class CuentaMapper
    {
        public static CuentaEntity Map(DtoCuenta dto)
        {
            return new CuentaEntity
            {
                Id = Guid.NewGuid(),
                Nombres = dto.Nombres,
                NumeroCuenta = dto.NumeroCuenta,
                Identificacion = dto.Identificacion,
                TipoIdentificacion = dto.TipoIdentificacion,
                Email = dto.Email,
                BancoId = dto.BancoId,
                TipoCuentaId = dto.TipoCuentaId,
            };
        }

        public static Task<IEnumerable<DtoCuenta>> Map(IEnumerable<CuentaEntity> listaCuentas)
        {
            return Task.FromResult(listaCuentas?.AsEnumerable()?.Select(x => new DtoCuenta()
            {
                Id = x.Id,
                Nombres = x.Nombres,
                NumeroCuenta = x.NumeroCuenta,
                Identificacion = x.Identificacion,
                TipoIdentificacion = x.TipoIdentificacion,
                Email = x.Email,
                Banco = x?.Banco?.Nombre,
                BancoId = x.BancoId,
                TipoCuentaId = x.TipoCuentaId,
            }));
        }
    }
}
