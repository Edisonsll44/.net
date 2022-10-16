using Soulsplit.Api.AccesoDatos.Contratos;
using Soulsplit.Api.Utilitarios.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Soulpslit.Api.AccesoDatos.Mapeos
{
    public static class PagoMapper
    {
        public static PagoEntity Map(DtoPago dto)
        {
            return new PagoEntity
            {
                Id = Guid.NewGuid(),
                Nombres = dto.Nombres,
                Identificacion = dto.Identificacion,
                TipoIdentificacion = dto.TipoIdentificacion,
                Email = dto.Email,
                UrlImagen = dto.UrlImagen,
                RespuestaCDN = dto.RespuestaCDN,
                Comprobante = dto.Comprobante,
                CuentaDeposito = dto.CuentaDeposito,
                IdTransaccional = dto.IdTransaccional,
                NumeroTarjeta = dto.NumeroTarjeta,
                RequestId = dto.RequestId,
                Referencia = dto.Referencia,
                NombreOperador = dto.NombreOperador,
                Autorizacion = dto.Autorizacion,
                Recibo = dto.Recibo,
                MetodoPago = dto.MetodoPago,
                Valor = dto.Valor,
                FechaPago = dto.FechaPago,
                FormaPagoId = dto.FormaPagoId,
            };
        }

        public static Task<IEnumerable<DtoConsultaPago>> Map(IEnumerable<PagoEntity> listaPagos, int total = 0)
        {
            return Task.FromResult(listaPagos?.AsEnumerable()?.Select(x =>
            {
                var dto = Map(x);
                dto.Total = total;
                return dto;
            }));
        }

        public static DtoConsultaPago Map(PagoEntity x)
        {
            return new DtoConsultaPago()
            {
                Id = x.Id,
                Nombres = x.Nombres,
                Identificacion = x.Identificacion,
                TipoIdentificacion = x.TipoIdentificacion,
                Email = x.Email,
                Valor = decimal.Round(x.Valor, 2, MidpointRounding.ToEven),
                FechaPago = x.FechaPago,
                Referencia = x.Referencia,
                Banco = x?.Cuenta?.Banco?.Nombre,
                TipoCuenta = x?.Cuenta?.TipoCuenta?.Nombre,
                FormaPago = x.FormaPago?.Nombre,
                CuentaDeposito = x.CuentaDeposito,
                UrlImagen = x.UrlImagen,
                Estado = x?.EstadoPago?.Nombre,
                EstadoId = x.EstadoPagoId,
                Saldo = decimal.Round(x.Persona.SaldoActual, 2, MidpointRounding.ToEven)
            };
        }

    }
}
