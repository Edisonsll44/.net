using Soulsplit.Api.AccesoDatos.Contratos;
using Soulsplit.Api.Utilitarios.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Soulsplit.Api.AccesoDatos.Mapeos
{
    public static class FuncionalidadMapper
    {
        public static FuncionalidadEntity Map(FuncionalidadSistemaDto dto)
        {
            return new FuncionalidadEntity
            {
                Id = dto.Id.ToString() == "00000000-0000-0000-0000-000000000000" ? Guid.NewGuid() : dto.Id,
                NombreFuncionalidad = dto.NombreFuncionalidad,
            };
        }

        public static FuncionalidadSistemaDto MapEntity(FuncionalidadParametroSistemaEntity entity)
        {
            return new FuncionalidadSistemaDto
            {
                NombreFuncionalidad = entity.ParametroSistema.Valor1,
                CodigoReferencia = entity.ParametroSistema.Valor3
            };
        }
    }

    public static class ParametroGlobaMapper
    {
        public static ParametroSistemaEntity Map(ParametroSistemaDto dto)
        {
            return new ParametroSistemaEntity
            {
                Id = dto.Id.ToString() == "00000000-0000-0000-0000-000000000000" ? Guid.NewGuid() : dto.Id,
                NombreParametro = dto.NombreParametro,
                Valor1 = dto.Valor1,
                Valor2 = dto.Valor2,
                Valor3 = dto.Valor3
            };
        }

        public static Task<ParametroSistemaDto> Map(ParametroSistemaEntity dto)
        {
            var parametro = new ParametroSistemaDto
            {
                Id = dto.Id.ToString() == "00000000-0000-0000-0000-000000000000" ? Guid.NewGuid() : dto.Id,
                NombreParametro = dto.NombreParametro,
                Valor1 = dto.Valor1,
                Valor2 = dto.Valor2,
                Valor3 = dto.Valor3
            };
            return Task.FromResult(parametro);
        }
    }

    public static class FuncionalidadParametroGlobaMapper
    {
        public static IEnumerable<FuncionalidadParametroSistemaEntity> Map(IEnumerable<Guid> parametrosIds, Guid funcionalidadId)
        {
            var funcionalidadesSistena = new List<FuncionalidadParametroSistemaEntity>();
            parametrosIds.ToList().ForEach(f => funcionalidadesSistena.Add(new FuncionalidadParametroSistemaEntity
            {
                Id = Guid.NewGuid(),
                FuncionalidadId = funcionalidadId,
                ParametroSistemaId = f
            }));
            return funcionalidadesSistena;
        }

        public static FuncionalidadSistemaDto Map(IEnumerable<FuncionalidadParametroSistemaEntity> dto)
        {
            return new FuncionalidadSistemaDto
            {
                Id = dto.FirstOrDefault().Funcionalidad.Id,
                NombreFuncionalidad = dto.FirstOrDefault().Funcionalidad.NombreFuncionalidad,
                //ParametrosSistema = dto.FirstOrDefault().ParametroSistema
            };
        }
    }
}
