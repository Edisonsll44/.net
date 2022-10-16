using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.HttpOverrides;
using Microsoft.Extensions.DependencyInjection;
using Soulpslit.Api.AccesoDatos.Repositorios;
using Soulsplit.Api.AccesoDatos.Contratos;
using Soulsplit.Api.AccesoDatos.Contratos.Entidades.Entidades.Configuracion;
using Soulsplit.Api.AccesoDatos.Contratos.Repositorios;
using Soulsplit.Api.AccesoDatos.Contratos.Repositorios.Configuracion;
using Soulsplit.Api.AccesoDatos.Repositorios;
using Soulsplit.Api.Aplicaciones;
using Soulsplit.Api.Aplicaciones.ApiCaller;
using Soulsplit.Api.Aplicaciones.Configuraciones;
using Soulsplit.Api.Aplicaciones.Seguridad;
using Soulsplit.Api.Aplicaciones.Servicios;
using Soulsplit.Api.Aplicaciones.Servicios.Configuraciones;
using Soulsplit.Api.Contratos;
using Soulsplit.Api.Contratos.ApiCaller;
using Soulsplit.Api.Contratos.ContratosServicios;
using Soulsplit.Api.Contratos.Seguridad;
using Soulsplit.Api.Contratos.Seguridades;
using Soulsplit.Api.Email;
using Soulsplit.Api.Validaciones.Validaciones;

namespace Soulsplit.Api.ResolucionDependencia
{
    public static class IoCRegister
    {
        public static IServiceCollection AddRegistration(this IServiceCollection services)
        {
            AddRegisterRepositories(services);
            AddRegisterServices(services);
            AddRegisterValidations(services);
            AddRegisterOtherServices(services);
            return services;
        }
        static IServiceCollection AddRegisterRepositories(this IServiceCollection services)
        {
            services.AddTransient<ICuentaRepository, CuentaRepository>();
            services.AddTransient<ITipoCuentaRepository, TipoCuentaRepository>();
            services.AddTransient<IDetalleEstadoRepository, DetalleEstadoRepository>();
            services.AddTransient<IEstadoRepository, EstadoRepository>();
            services.AddTransient<IFormaPagoRepository, FormaPagoRepository>();
            services.AddTransient<IBancoRepository, BancoRepository>();
            services.AddTransient<IPagoRepository, PagoRepository>();
            services.AddTransient<IHistorialPagoRepository, HistorialPagoRepository>();
            services.AddTransient<IMenuRepository, MenuRepository>();
            services.AddTransient<IPersonaRepository, PersonaRepository>();
            services.AddTransient<IPaisRepository, PaisRepository>();
            services.AddTransient<IUsuarioRepository, UsuarioRepository>();
            services.AddTransient<IParametroSistemaRepository, ParametroSistemaRepository>();
            services.AddTransient<IFuncionalidadSistemaRepository, FuncionalidadSistemaRepository>();
            services.AddTransient<IParametroFuncionalidaSistemaRepository, ParametroFuncionalidaSistemaRepository>();
            services.AddTransient<IRolRepository, RolRepository>();
            services.AddTransient<IRolMenuRepository, RolMenuRepository>();
            services.AddTransient<IRolUsuarioRepository, RolUsuarioRepository>();
            services.AddTransient<ITipoDocumentoRepository, TipoDocumentoRepository>();
            services.AddTransient<ITipoCuentaRepository, TipoCuentaRepository>();
            services.AddTransient<IReferidoPersonaRepository, ReferidoPersonaRepository>();
            services.AddTransient<IAuditoriaAccesoUsuarioRepository, AuditoriaAccesoUsuarioRepository>();
            return services;
        }

        static IServiceCollection AddRegisterServices(this IServiceCollection services)
        {
            services.AddTransient<ICuentaService, CuentaService>();
            services.AddTransient<ITipoCuentaService, TipoCuentaService>();
            services.AddTransient<IBancoService, BancoService>();
            services.AddTransient<IEstadoService, EstadoService>();
            services.AddTransient<IFormaPagoService, FormaPagoService>();
            services.AddTransient<IPagoService, PagoService>();
            services.AddTransient<IHistorialPagoService, HistorialPagoService>();
            services.AddTransient<IMenuService, MenuService>();
            services.AddTransient<IPaisService, PaisService>();
            services.AddTransient<IPersonaService, PersonaService>();
            services.AddTransient<IUsuarioService, UsuarioService>();
            services.AddTransient<IAutenticacionService, AutenticacionService>();
            services.AddTransient<IParametroSistemaService, ParametroSistemaService>();
            services.AddTransient<IFuncionalidadSistemaService, FuncionalidadSistemaService>();
            services.AddTransient<IParametroFuncionalidaSistemaService, ParametroFuncionalidaSistemaService>();
            services.AddTransient<IRolService, RolService>();
            services.AddTransient<IRolMenuService, RolMenuService>();
            services.AddTransient<IRolUsuarioService, RolUsuarioService>();
            services.AddTransient<ITipoDocumentoService, TipoDocumentoService>();
            services.AddTransient<IReferidoPersonaService, ReferidoPersonaService>();
            services.AddTransient<IAuditoriaAccesoUsuarioService, AuditoriaAccesoUsuarioService>();
            return services;
        }

        static IServiceCollection AddRegisterOtherServices(this IServiceCollection services)
        {
            services.AddTransient<IAppConfig, AppConfig>();
            services.AddTransient<IUnitOfWork, UnitOfWork>();
            services.AddTransient<IApiCaller, ApiCaller>();
            services.AddTransient<ISecurityToken, SecurityToken>();
            services.AddTransient<IAuditoriaEntidadesService, AuditoriaEntidadesService>();
            services.AddTransient<IAwsS3Service, AwsS3Service>();
            services.AddTransient<IAwsS3Helper, AwsS3Helper>();
            services.AddTransient<IEmailService, EmailService>();
            services.AddTransient<IMensajeService, MensajeService>();
            services.AddTransient<IChannelService, ChannelService>();
            services.AddTransient<IValidatorReCaptcha, ValidatorReCaptcha>();
            services.Configure<ForwardedHeadersOptions>(options =>
            {
                options.ForwardedHeaders = ForwardedHeaders.XForwardedFor | ForwardedHeaders.XForwardedProto;
            });
            services.AddLocalization(x => x.ResourcesPath = "");

            return services;
        }
        static IServiceCollection AddRegisterValidations(this IServiceCollection services)
        {
            services.AddTransient<IInicioSessionValidator, InicioSessionValidator>();
            services.AddTransient<IPagoValidator, PagoValidator>();
            services.AddTransient<IPersonaValidator, PersonaValidator>();
            services.AddTransient<IUsuarioValidator, UsuarioValidator>();
            return services;
        }
    }
}
