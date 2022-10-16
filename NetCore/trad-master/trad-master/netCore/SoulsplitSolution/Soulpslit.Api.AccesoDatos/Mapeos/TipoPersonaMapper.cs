using Soulsplit.Api.AccesoDatos.Contratos;
using Soulsplit.Api.Utilitarios.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Soulsplit.Api.AccesoDatos.Mapeos
{
    public static class TipoPersonaMapper
    {
        public static TipoPersonaEntiy Map(TipoPersonaDto dto)
        {
            return new TipoPersonaEntiy
            {
                Id = dto.Id.ToString() == "00000000-0000-0000-0000-000000000000" ? Guid.NewGuid() : dto.Id,
                Nombre = dto.Nombre,
            };
        }

        public static Task<List<TipoPersonaDto>> Map(IEnumerable<TipoPersonaEntiy> entidades)
        {
            var tipoPersona = new List<TipoPersonaDto>();
            entidades.ToList().ForEach(entidad => tipoPersona.Add(new TipoPersonaDto
            {
                Id = entidad.Id,
                Nombre = entidad.Nombre,
            }));
            return Task.FromResult(tipoPersona);
        }
    }
}