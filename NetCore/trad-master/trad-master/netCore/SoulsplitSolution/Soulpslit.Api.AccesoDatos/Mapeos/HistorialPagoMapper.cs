using Soulsplit.Api.AccesoDatos.Contratos;
using Soulsplit.Api.Utilitarios.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Soulpslit.Api.AccesoDatos.Mapeos
{
    public static class HistorialPagoMapper
    {
        public static HistorialPagoEntity Map(DtoHistorialPago dto)
        {
            return new HistorialPagoEntity
            {
                Id = Guid.NewGuid(),
                Comprobante = dto.Comprobante,
                EstadoConciliacion = dto.EstadoConciliacion,
                Observacion = dto.Observacion,
                UsuarioId = dto.UsuarioId,
                EstadoPagoId = dto.EstadoPagoId,
                PagoId = dto.PagoId,
                FechaRespuesta = DateTime.Now
            };
        }

        public static Task<IEnumerable<DtoHistorialPago>> Map(IEnumerable<HistorialPagoEntity> listaHistorialPagos)
        {
            return Task.FromResult(listaHistorialPagos?.AsEnumerable()?.Select(x => new DtoHistorialPago()
            {
                Comprobante = x.Comprobante,
                EstadoConciliacion = x.EstadoConciliacion,
                Observacion = x.Observacion,
                FechaRespuesta = x.FechaRespuesta
            }));
        }
    }
}
