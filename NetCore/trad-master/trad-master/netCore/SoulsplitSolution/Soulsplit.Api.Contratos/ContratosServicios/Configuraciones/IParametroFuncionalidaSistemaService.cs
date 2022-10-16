using Soulsplit.Api.Utilitarios.Dto;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Soulsplit.Api.Contratos
{
    public interface IParametroFuncionalidaSistemaService
    {
        Task<FuncionalidadSistemaDto> ObtenerParametrosSistemaPorFuncionalidad(string nombreFuncionalidad);
        Task<DtoRespuesta> CrearParametrosSistemaPorFuncionalidad(IEnumerable<Guid> parametros, Guid idFuncionalidad);
        Task<ParametroSistemaDto> ObtenerEnlacePlan(string nombreFuncionalidad = "");
        DtoRespuesta EnviarMailContacto(PersonaDto dto);
        
    }
}
