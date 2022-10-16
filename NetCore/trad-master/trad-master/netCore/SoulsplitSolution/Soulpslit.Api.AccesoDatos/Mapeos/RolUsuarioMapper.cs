using Soulsplit.Api.AccesoDatos.Contratos;
using Soulsplit.Api.Utilitarios.Dto;
using System;

namespace Soulsplit.Api.AccesoDatos.Mapeos
{
    public static class RolUsuarioMapper
    {
        public static RolUsuarioEntity Map(RolUsuarioDto dto)
        {
            return new RolUsuarioEntity
            {
                Id = dto.Id.ToString() == "00000000-0000-0000-0000-000000000000" ? Guid.NewGuid() : dto.Id,
                UsuarioId = dto.UsuarioId,
                RolId = dto.RolId
            };
        }

        public static RolUsuarioEntity Map(Guid usuarioId, Guid rolId)
        {
            return new RolUsuarioEntity
            {
                Id = Guid.NewGuid(),
                UsuarioId = usuarioId,
                RolId = rolId
            };
        }
    }
}