using Soulsplit.Api.AccesoDatos.Contratos;
using Soulsplit.Api.Utilitarios.Dto;
using System;

namespace Soulsplit.Api.AccesoDatos.Mapeos
{
    public static class ReferidoPersonaMapper
    {
        public static ReferidosPersonaEntity Map(Guid personaId, Guid referidoId)
        {
            return new ReferidosPersonaEntity
            {
                FechaIngreso = DateTime.Now,
                PersonaId = personaId,
                ReferidoId = referidoId
            };
        }

        public static ReferidoPersonaDto Map(ReferidosPersonaEntity entidad)
        {
            return new ReferidoPersonaDto
            {
                Id = entidad.Id,
                FechaIngreso = entidad.FechaIngreso,
                PersonaId = entidad.PersonaId,
                ReferidoId = entidad.ReferidoId
            };
        }

    }
}
