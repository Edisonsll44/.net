using Soulsplit.Api.AccesoDatos.Contratos;
using Soulsplit.Api.AccesoDatos.Contratos.Repositorios;
using Soulsplit.Api.AccesoDatos.Mapeos;
using Soulsplit.Api.Contratos;
using Soulsplit.Api.Contratos.ContratosServicios;
using Soulsplit.Api.Utilitarios;
using Soulsplit.Api.Utilitarios.Dto;
using System;
using System.Threading.Tasks;

namespace Soulsplit.Api.Aplicaciones.Servicios
{
    public class ReferidoPersonaService : IReferidoPersonaService
    {
        private readonly IAuditoriaEntidadesService _auditoriaEntidadesService;
        private readonly IReferidoPersonaRepository _referidoPersonaRepository;
        private readonly IUsuarioRepository _usuarioRepository;
        private readonly IParametroFuncionalidaSistemaService _parametroFuncionalidaSistemaService;
        public ReferidoPersonaService(IAuditoriaEntidadesService auditoriaEntidadesService, IReferidoPersonaRepository referidoPersonaRepository, IUsuarioRepository usuarioRepository, IParametroFuncionalidaSistemaService parametroFuncionalidaSistemaService)
        {
            _auditoriaEntidadesService = auditoriaEntidadesService;
            _referidoPersonaRepository = referidoPersonaRepository;
            _usuarioRepository = usuarioRepository;
            _parametroFuncionalidaSistemaService = parametroFuncionalidaSistemaService;
        }

        public async Task<DtoRespuesta> CrearReferido(string codigoReferido, Guid referidoId)
        {
            var usuario = ObtenerUsuarioPorCodigoReferencia(codigoReferido);
            if (usuario != null)
            {
                await CrearPersonaReferido(usuario, referidoId);
                return await Respuesta.DevolverRespuesta("Referido Persona", "creado");
            }
            else
            {
                var parametrosFuncionalidad = await _parametroFuncionalidaSistemaService.ObtenerParametrosSistemaPorFuncionalidad(Funcionalidades.FuncionalidadCodigoReferido);
                var usuarioEncontrado = ObtenerUsuarioPorCodigoReferencia(parametrosFuncionalidad.CodigoReferencia);
                if (usuarioEncontrado == null)
                {
                    return await Respuesta.DevolverRespuesta("Referido Persona", "creado", parametro: parametrosFuncionalidad.NombreFuncionalidad);
                }
                await CrearPersonaReferido(usuarioEncontrado, referidoId);
                return await Respuesta.DevolverRespuesta("Referido Persona", "creado", parametro: parametrosFuncionalidad.NombreFuncionalidad, datos: true);
            }
        }

        UsuarioEntity ObtenerUsuarioPorCodigoReferencia(string codigoReferido)
        => _usuarioRepository.GetOneOrDefault<UsuarioEntity>(x => x.CodigoReferencia.Equals(codigoReferido));

        async Task CrearPersonaReferido(UsuarioEntity usuario, Guid referidoId)
        {
            var referido = ReferidoPersonaMapper.Map(usuario.PersonaId, referidoId);
            _auditoriaEntidadesService.InsertarDatosAuditoria(referido);
            await _referidoPersonaRepository.Add(referido);
        }
    }
}
