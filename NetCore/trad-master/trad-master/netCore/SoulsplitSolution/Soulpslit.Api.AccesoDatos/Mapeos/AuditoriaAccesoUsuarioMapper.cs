using System;
using Soulsplit.Api.AccesoDatos.Contratos;
using Soulsplit.Api.Utilitarios.Dto;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Soulpslit.Api.AccesoDatos.Mapeos
{
    public static class AuditoriaAccesoUsuarioMapper
    {
        public static AuditoriaAccesoUsuarioEntity Map(DtoAuditoriaAccesoUsuario dto)
        {
            return new AuditoriaAccesoUsuarioEntity
            {
                Id = dto.Id,
                CodigoConfirmacion = dto.CodigoConfirmacion,
                FechaIngreso = dto.FechaIngreso,
                UsuarioId = dto.UsuarioId
            };
        }

        public static Task<IEnumerable<DtoAuditoriaAccesoUsuario>> Map(IEnumerable<AuditoriaAccesoUsuarioEntity> listaAuditoria)
        {
            return Task.FromResult(listaAuditoria?.AsEnumerable()?.Select(x => new DtoAuditoriaAccesoUsuario()
            {
                Id = x.Id,
                CodigoConfirmacion = x.CodigoConfirmacion,
                FechaIngreso = x.FechaIngreso ?? DateTime.MinValue,
                UsuarioId = x.UsuarioId
            }));
        }

    }
}
