using Soulsplit.Api.AccesoDatos.Contratos;
using Soulsplit.Api.AccesoDatos.Mapeos;
using Soulsplit.Api.Contratos;
using Soulsplit.Api.Utilitarios.Dto;
using Soulsplit.Api.Email;
using Soulsplit.Api.Utilitarios.Enumeraciones;
using Soulsplit.Api.Utilitarios.Enumeraciones.Configuraciones;
using Soulsplit.Api.Utilitarios.Propiedades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Soulsplit.Api.Aplicaciones.Servicios
{
    public class ParametroFuncionalidaSistemaService : IParametroFuncionalidaSistemaService
    {
        private readonly IParametroFuncionalidaSistemaRepository _parametroFuncionalidaSistemaRepository;
        private readonly IParametroSistemaRepository _parametroSistemaRepository;
        private readonly IAuditoriaEntidadesService _auditoriaEntidadesService;
        private readonly IEmailService _emailService;
        public ParametroFuncionalidaSistemaService(IParametroFuncionalidaSistemaRepository parametroFuncionalidaSistemaRepository, IAuditoriaEntidadesService auditoriaEntidadesService, IParametroSistemaRepository parametroSistemaRepository, IEmailService emailService)
        {
            _parametroFuncionalidaSistemaRepository = parametroFuncionalidaSistemaRepository;
            _auditoriaEntidadesService = auditoriaEntidadesService;
            _parametroSistemaRepository = parametroSistemaRepository;
            _emailService = emailService;
        }
        public async Task<DtoRespuesta> CrearParametrosSistemaPorFuncionalidad(IEnumerable<Guid> parametros, Guid idFuncionalidad)
        {
            var parametrosPorFuncionalidad = FuncionalidadParametroGlobaMapper.Map(parametros, idFuncionalidad);
            parametrosPorFuncionalidad.ToList().ForEach(p => _auditoriaEntidadesService.InsertarDatosAuditoria(p, usuario: "adm"));
            await _parametroFuncionalidaSistemaRepository.CreateRange(parametrosPorFuncionalidad);
            return await Respuesta.DevolverRespuesta("Parámetros por funcionalidad", "creados");
        }

        public async Task<FuncionalidadSistemaDto> ObtenerParametrosSistemaPorFuncionalidad(string nombreFuncionalidad)
        {
            var parametrosFuncionalidad = await _parametroFuncionalidaSistemaRepository.GetAsync<FuncionalidadParametroSistemaEntity>(p => p.Funcionalidad.NombreFuncionalidad == nombreFuncionalidad && p.Funcionalidad.Estado == PropiedadesAuditoria.EstadoActivo);
            var parametro = await ActualizarContador(parametrosFuncionalidad);
            return FuncionalidadMapper.MapEntity(entity: parametro);
        }

        async Task<FuncionalidadParametroSistemaEntity> ActualizarContador(IEnumerable<FuncionalidadParametroSistemaEntity> parametrosFuncionalidad)
        {
            var parametroInicial = Convert.ToInt32(parametrosFuncionalidad.ToList()[0].ParametroSistema.Valor2);
            var parametroFinal = Convert.ToInt32(parametrosFuncionalidad.ToList()[1].ParametroSistema.Valor2);
            if (parametroInicial == parametroFinal)
            {
                var acumulador = parametroFinal + 1;
                parametrosFuncionalidad.ToList()[0].ParametroSistema.Valor2 = acumulador.ToString();
                await _parametroSistemaRepository.Update(parametrosFuncionalidad.ToList()[0].ParametroSistema);
                return parametrosFuncionalidad.ToList()[0];
            }
            if (parametroInicial > parametroFinal)
            {
                var acumulador = parametroFinal + 1;
                parametrosFuncionalidad.ToList()[1].ParametroSistema.Valor2 = acumulador.ToString();
                await _parametroSistemaRepository.Update(parametrosFuncionalidad.ToList()[1].ParametroSistema);
                return parametrosFuncionalidad.ToList()[1];
            }
            return null;
        }


        public async Task<ParametroSistemaDto> ObtenerEnlacePlan(string nombreFuncionalidad = "")
        {
            var parametrosFuncionalidad = _parametroFuncionalidaSistemaRepository.GetAll<FuncionalidadParametroSistemaEntity>(p => p.Funcionalidad.NombreFuncionalidad == nombreFuncionalidad && p.Funcionalidad.Estado == PropiedadesAuditoria.EstadoActivo);
            var url = parametrosFuncionalidad.OrderBy(x => x.ParametroSistema.Valor2).First();
            await ModificarParametroSistema(url.ParametroSistema);
            return await ParametroGlobaMapper.Map(url.ParametroSistema);

        }

        public DtoRespuesta EnviarMailContacto(PersonaDto dto)
        {
            var listaParametros = new List<FuncionalidadesParametroSistemaDto>();
            var parametrosFuncionalidad = _parametroFuncionalidaSistemaRepository.GetAll<FuncionalidadParametroSistemaEntity>(p => p.Funcionalidad.NombreFuncionalidad == ExtensionEnum.ObtenerDescripcion(Funcionalidades.EmailContacto) && p.Funcionalidad.Estado == PropiedadesAuditoria.EstadoActivo);
            MailContacto(dto, parametrosFuncionalidad.FirstOrDefault().ParametroSistema.Valor1);
            return new DtoRespuesta { Bdt1 = true, Dt1 = "En breve se contactarán con usted" };

        }

        private async Task<DtoRespuesta> ModificarParametroSistema(ParametroSistemaEntity parametro)
        {
            var numeroConsultas = int.Parse(parametro.Valor2) + 1;
            parametro.Valor2 = numeroConsultas.ToString();
            _auditoriaEntidadesService.ActualizarAuditoria(parametro, usuario: "adm");
            await _parametroSistemaRepository.Update(parametro);
            return await Respuesta.DevolverRespuesta("Parámetro", "modificado");
        }

        private void MailContacto(PersonaDto dto, string mailEnvio)
        {
            var datos = new Dictionary<string, string> {
                {"nombre", dto.Nombres + ' ' + dto.Apellidos },
                {"telefono", dto.Telefono },
                {"email", dto.Email }
            };
            _emailService.MailContacto(new Mensaje(new List<string>() { mailEnvio }, "Formulario Contacto", datos));
        }
    }
}
