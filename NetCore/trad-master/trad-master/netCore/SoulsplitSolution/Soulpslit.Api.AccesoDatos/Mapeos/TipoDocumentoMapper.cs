using Soulsplit.Api.AccesoDatos.Contratos;
using Soulsplit.Api.Utilitarios.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Soulsplit.Api.AccesoDatos.Mapeos
{
    public static class TipoDocumentoMapper
    {
        public static TipoIdentificacionEntity Map(TipoDocumentoDto dto)
        {
            return new TipoIdentificacionEntity
            {
                Id = dto.Id.ToString() == "00000000-0000-0000-0000-000000000000" ? Guid.NewGuid() : dto.Id,
                Nombre = dto.Nombre,
                LongitudMaxima = dto.LongitudMaxima,
                LongitudMinima = dto.LongitudMinima,
                AplicaNacionalidad = dto.AplicaNacionalidad,
                PaisId = dto.PaisId,
                TipoPersonaId = dto.TipoPersonaId
            };
        }

        public static Task<List<TipoDocumentoDto>> Map(IEnumerable<TipoIdentificacionEntity> entidades)
        {
            var documentos = new List<TipoDocumentoDto>();
            entidades.ToList().ForEach(entidad => documentos.Add(new TipoDocumentoDto
            {
                Id = entidad.Id,
                Nombre = entidad.Nombre,
                Algorimo = entidad.AlgoritmoValidacion,
                AplicaNacionalidad = entidad.AplicaNacionalidad,
                LongitudMaxima = entidad.LongitudMaxima,
                LongitudMinima = entidad.LongitudMinima,
            }));
            return Task.FromResult(documentos);
        }
    }
}