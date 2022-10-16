using Soulsplit.Api.AccesoDatos.Contratos;
using Soulsplit.Api.Utilitarios.Dto;
using System;

namespace Soulsplit.Api.AccesoDatos.Mapeos
{
    public static class RolMenuMapper
    {
        public static RolMenuEntity Map(RolMenuDto dto)
        {
            return new RolMenuEntity
            {
                Id = dto.Id.ToString() == "00000000-0000-0000-0000-000000000000" ? Guid.NewGuid() : dto.Id,
                MenuId = dto.MenuId,
                RolId = dto.RolId
            };
        }
    }
}
