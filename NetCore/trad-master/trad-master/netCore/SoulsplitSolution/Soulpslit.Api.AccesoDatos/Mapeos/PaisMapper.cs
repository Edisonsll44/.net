using Soulsplit.Api.AccesoDatos.Contratos;
using Soulsplit.Api.Utilitarios.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Soulpslit.Api.AccesoDatos.Mapeos
{
    public static class PaisMapper
    {
        public static PaisEntity Map(Pais dto)
        {
            return new PaisEntity
            {
                Id = Guid.NewGuid(),
                Bandera = dto.Bandera,
                CodigoRegional = dto.CodigoRegional,
                Latitud = dto.Latitud,
                Longitud = dto.Longitud,
                NombrePais = dto.Nombre,
                Nacionalidad = dto.Nacionalidad
            };
        }

        public static Pais Map(PaisEntity entidad)
        {
            return new Pais
            {
                Id = entidad.Id,
                Bandera = entidad.Bandera,
                CodigoRegional = entidad.CodigoRegional,
                Latitud = entidad.Latitud,
                Longitud = entidad.Longitud,
                Nombre = entidad.NombrePais,
                Nacionalidad = entidad.Nacionalidad
            };
        }

        public static Task<List<Pais>> Map(IEnumerable<PaisEntity> entidades)
        {
            var paises = new List<Pais>();
            entidades.ToList().ForEach(entidad => paises.Add(new Pais
            {
                Id = entidad.Id,
                Bandera = entidad.Bandera,
                CodigoRegional = entidad.CodigoRegional,
                Latitud = entidad.Latitud,
                Longitud = entidad.Longitud,
                Nombre = entidad.NombrePais,
                Nacionalidad = entidad.Nacionalidad
            }));
            return Task.FromResult(paises);
        }
    }
}
