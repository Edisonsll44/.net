using Soulsplit.Api.AccesoDatos.Contratos;
using Soulsplit.Api.Utilitarios.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Soulsplit.Api.AccesoDatos.Mapeos
{
    public static class RolMapper
    {
        public static RolEntity Map(RolDto dto)
        {
            return new RolEntity
            {
                Id = dto.Id.ToString() == "00000000-0000-0000-0000-000000000000" ? Guid.NewGuid() : dto.Id,
                NombreRol = dto.NombreRol,
                RolInstalacion = dto.RolInstalacion
            };
        }

        public static Task<List<RolDto>> Map(IEnumerable<RolEntity> entidades)
        {
            var roles = new List<RolDto>();
            entidades.ToList().ForEach(entidad => roles.Add(new RolDto
            {
                Id = entidad.Id,
                NombreRol = entidad.NombreRol
            }));
            return Task.FromResult(roles);
        }
    }
}
