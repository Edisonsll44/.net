using Soulsplit.Api.AccesoDatos.Contratos;
using Soulsplit.Api.AccesoDatos.Contratos.Repositorios;
using Soulsplit.Api.Aplicaciones.Servicios;
using Soulsplit.Api.Contratos;
using Soulsplit.Api.Contratos.ContratosServicios;
using Soulsplit.Api.Utilitarios.Dto;
using Soulsplit.Api.Contratos.Seguridad;
using Soulsplit.Api.Contratos.Seguridades;
using Soulsplit.Api.Utilitarios;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace Soulsplit.Api.Aplicaciones.Seguridad
{
    public class AutenticacionService : IAutenticacionService
    {
        private readonly IUsuarioRepository _usuarioRepository;
        private readonly IAuditoriaEntidadesService _auditoriaEntidadesService;
        private readonly ISecurityToken _securityToken;
        private readonly IMensajeService _mensajeService;
        private readonly IAuditoriaAccesoUsuarioService _auditoriaAccesoUsuarioService;
        private readonly IRolMenuService _rolMenuService;

        #region MétodosPublicos
        public AutenticacionService(IUsuarioRepository usuarioRepository,
            IAuditoriaEntidadesService auditoriaEntidadesService,
            ISecurityToken securityToken,
            IMensajeService mensajeService,
            IAuditoriaAccesoUsuarioService auditoriaAccesoUsuarioService,
            IRolMenuService rolMenuService)
        {
            _usuarioRepository = usuarioRepository;
            _auditoriaEntidadesService = auditoriaEntidadesService;
            _securityToken = securityToken;
            _mensajeService = mensajeService;
            _auditoriaAccesoUsuarioService = auditoriaAccesoUsuarioService;
            _rolMenuService = rolMenuService;
        }
        public async Task<DtoRespuesta> ActivarUsuario(string token)
        {
            var usuarioEncontrado = _usuarioRepository.GetOneOrDefault<UsuarioEntity>(u => u.Token.Equals(token));
            if (usuarioEncontrado != null)
            {
                usuarioEncontrado.EmailConfirmado = true;
                _auditoriaEntidadesService.ActualizarAuditoria(usuarioEncontrado, token: token);
                await _usuarioRepository.Update(usuarioEncontrado);
                return await Respuesta.DevolverRespuesta("Sessión", "creada");
            }
            throw new Exception("Token Inválido");
        }

        public async Task<DtoLoginRespuesta> AutenticarUsuario(string correo, string clave, string codigo)
        {
            var usuarioEncontrado = await _usuarioRepository.GetOneAsync<UsuarioEntity>(u => u.Persona.Email == correo && u.Clave == clave);
            if (usuarioEncontrado is not null)
            {
                if (!usuarioEncontrado.EmailConfirmado)
                {
                    throw new Exception("No ha activado aún su cuenta, por favor revise su correo");
                }
                if (usuarioEncontrado.Bloqueado)
                {
                    throw new Exception("Su usuario se encuentra bloqueado");
                }
                usuarioEncontrado.Token = _securityToken.CrearToken(usuarioEncontrado.NombreUsuario, usuarioEncontrado.Id, correo);
                usuarioEncontrado.VerificoCelular = true;
                await ActualizarUsuarioAsync(usuarioEncontrado, true, 0, usuarioEncontrado.CodigoOTP);
                return new DtoLoginRespuesta { Id = usuarioEncontrado.Id, Bdt1 = true, Bdt2 = usuarioEncontrado.EsAdministrador, Bdt3 = usuarioEncontrado.EmailConfirmado, Bdt4 = usuarioEncontrado.VerificoCelular, Dt1 = usuarioEncontrado.Token, Dt2 = usuarioEncontrado.Persona.Nombres + ' ' + usuarioEncontrado.Persona.Apellidos, Dt3 = usuarioEncontrado.CodigoReferencia, Dt4 = usuarioEncontrado.FotoUsuario, Ndt1 = usuarioEncontrado?.Persona?.ReferidosPersona?.Count() ?? 0, Ndt2 = usuarioEncontrado.Persona.SaldoActual, menu = await _rolMenuService.ObtenerMenuRol(usuarioEncontrado.RolesUsuario.FirstOrDefault().RolId) };
             }
            return new DtoLoginRespuesta() { Dt1 = "Error Usuario no encontrado" };
        }

        public async Task<DtoRespuesta> CerrarSessionActiva(string correo, string clave)
        {
            var usuarioEncontrado = _usuarioRepository.GetOneOrDefault<UsuarioEntity>(u => u.Persona.Email == correo && u.Clave == clave);
            if (usuarioEncontrado != null)
            {
                usuarioEncontrado.SesionActiva = false;
                usuarioEncontrado.Token = string.Empty;
                _auditoriaEntidadesService.ActualizarAuditoria(usuarioEncontrado, usuario: usuarioEncontrado.NombreUsuario);
                await _usuarioRepository.Update(usuarioEncontrado);
                return await Respuesta.DevolverRespuesta("Sessión", "cerrada");
            }
            return await Respuesta.DevolverRespuesta("Error", "Usuario no encontrado");
        }
        public async Task<DtoRespuesta> CerrarSessionActiva(string token)
        {
            var usuarioEncontrado = _usuarioRepository.GetOneOrDefault<UsuarioEntity>(u => u.Token == token);
            if (usuarioEncontrado != null)
            {
                usuarioEncontrado.SesionActiva = false;
                usuarioEncontrado.Token = string.Empty;
                _auditoriaEntidadesService.ActualizarAuditoria(usuarioEncontrado, usuario: usuarioEncontrado.NombreUsuario);
                await _usuarioRepository.Update(usuarioEncontrado);
                return await Respuesta.DevolverRespuesta("Sessión", "cerrada");
            }
            return await Respuesta.DevolverRespuesta("Error", "USuario no encontrado");
        }

        public async Task<DtoRespuesta> EnviarOTP(string mail, string clave)
        {
            var usuario = _usuarioRepository.GetOneOrDefault<UsuarioEntity>(x => x.Email == mail && x.Clave == clave);
            var otp = ConfiguracionUsuario.GenerarCodigoRandomico(5);
            await _mensajeService.EnviarSms(usuario.Persona.TelefonoPais.CodigoRegional, usuario.Persona.Telefono, String.Format("SOULSPLIT NOTIFICA CODIGO TOKEN SOLICITADO {0}", otp));
            await ActualizarUsuarioAsync(usuario, usuario.SesionActiva, usuario.NumeroIntentos ?? 0, otp);
            await _auditoriaAccesoUsuarioService.CrearAuditoriaAccesoUsuario(new DtoAuditoriaAccesoUsuario { CodigoConfirmacion = otp, FechaIngreso = new DateTime(), UsuarioId = usuario.Id });
            return await Respuesta.DevolverRespuesta("Usuario", "OTP Enviado");
        }
        #endregion

        #region MétodosPrivados

        async Task<DtoRespuesta> ActualizarUsuarioAsync(UsuarioEntity usuarioEncontrado, bool sessionActiva = false, short numeroIntentos = 0, string otp = "")
        {
            usuarioEncontrado.NumeroIntentos = numeroIntentos;
            usuarioEncontrado.SesionActiva = sessionActiva;
            usuarioEncontrado.CodigoOTP = otp;
            _auditoriaEntidadesService.ActualizarAuditoria(usuarioEncontrado, token: usuarioEncontrado.Token);
            await _usuarioRepository.Update(usuarioEncontrado);
            return await Respuesta.DevolverRespuesta("Usuario autenticado", "Usuario autenticado correctamente");
        }
        #endregion
    }
}
