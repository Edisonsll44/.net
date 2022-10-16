using Soulsplit.Api.AccesoDatos.Contratos;
using Soulsplit.Api.AccesoDatos.Mapeos;
using Soulsplit.Api.Contratos;
using Soulsplit.Api.Utilitarios.Dto;
using System;
using System.Threading.Tasks;

namespace Soulsplit.Api.Aplicaciones.Servicios
{
    public class ParametroSistemaService : IParametroSistemaService
    {
        private readonly IParametroSistemaRepository _parametroSistemaRepository;
        private readonly IAuditoriaEntidadesService _auditoriaEntidadesService;

        public ParametroSistemaService(IParametroSistemaRepository parametroSistemaRepository, IAuditoriaEntidadesService auditoriaEntidadesService)
        {
            _parametroSistemaRepository = parametroSistemaRepository;
            _auditoriaEntidadesService = auditoriaEntidadesService;
        }
        public async Task<DtoRespuesta> CrearParametroSistema(ParametroSistemaDto dto)
        {
            var parametroMapeado = ParametroGlobaMapper.Map(dto);
            _auditoriaEntidadesService.InsertarDatosAuditoria(parametroMapeado, usuario: "adm");
            await _parametroSistemaRepository.Add(parametroMapeado);
            return await Respuesta.DevolverRespuesta("Parámetros de sistema", "creado");
        }

        public Task<DtoRespuesta> EliminarParametroSistema()
        {
            throw new NotImplementedException();
        }

        public Task<DtoRespuesta> ModificarParametroSistema()
        {
            throw new NotImplementedException();
        }

    }
}
