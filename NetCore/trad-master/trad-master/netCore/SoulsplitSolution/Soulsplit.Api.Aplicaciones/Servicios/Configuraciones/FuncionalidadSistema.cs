using Soulsplit.Api.AccesoDatos.Contratos;
using Soulsplit.Api.AccesoDatos.Mapeos;
using Soulsplit.Api.Contratos;
using Soulsplit.Api.Utilitarios.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Soulsplit.Api.Aplicaciones.Servicios
{
    public class FuncionalidadSistemaService : IFuncionalidadSistemaService
    {
        private readonly IFuncionalidadSistemaRepository _funcionalidadSistemaRepository;
        private readonly IAuditoriaEntidadesService _auditoriaEntidadesService;
        private readonly IParametroFuncionalidaSistemaService _parametroFuncionalidaSistemaService;

        public FuncionalidadSistemaService(IFuncionalidadSistemaRepository funcionalidadSistemaRepository, IAuditoriaEntidadesService auditoriaEntidadesService, IParametroFuncionalidaSistemaService parametroFuncionalidaSistemaService)
        {
            _parametroFuncionalidaSistemaService = parametroFuncionalidaSistemaService;
            _funcionalidadSistemaRepository = funcionalidadSistemaRepository;
            _auditoriaEntidadesService = auditoriaEntidadesService;
        }
        public async Task<DtoRespuesta> CrearFuncionalidadSistema(FuncionalidadSistemaDto dto)
        {
            try
            {
                var funcionalidadMapeada = FuncionalidadMapper.Map(dto);
                _auditoriaEntidadesService.InsertarDatosAuditoria(funcionalidadMapeada, usuario: "adm");
                await _funcionalidadSistemaRepository.Add(funcionalidadMapeada);
                return await VerificarFuncionalidadParametrosGlobales(dto.ParametrosSistema, funcionalidadMapeada.Id);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.ToString());
            }
        }

        async Task<DtoRespuesta> VerificarFuncionalidadParametrosGlobales(IEnumerable<ParametroSistemaDto> parametrosGlobales, Guid funcionalidadId)
        {
            if (parametrosGlobales.Any())
            {
                List<Guid> parametros = new();
                parametrosGlobales.ToList().ForEach(d => parametros.Add(d.Id));
                return await _parametroFuncionalidaSistemaService.CrearParametrosSistemaPorFuncionalidad(parametros, funcionalidadId);
            }
            return await Respuesta.DevolverRespuesta("Funcionalidad", "creada");
        }

        public Task<DtoRespuesta> EliminarFuncionalidadSistema()
        {
            throw new NotImplementedException();
        }

        public Task<DtoRespuesta> ModificarFuncionalidadSistema()
        {
            throw new NotImplementedException();
        }
    }
}
