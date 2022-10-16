using Soulsplit.Api.AccesoDatos.Contratos;
using Soulsplit.Api.AccesoDatos.Contratos.Repositorios;
using Soulsplit.Api.AccesoDatos.Mapeos;
using Soulsplit.Api.Contratos;
using Soulsplit.Api.Contratos.ContratosServicios;
using Soulsplit.Api.Utilitarios.Dto;
using Soulsplit.Api.Email;
using Soulsplit.Api.Utilitarios;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Soulsplit.Api.Contratos.Seguridad;
using Soulsplit.Api.Utilitarios.Propiedades;

namespace Soulsplit.Api.Aplicaciones.Servicios
{
    public class UsuarioService : IUsuarioService
    {
        private readonly IAuditoriaEntidadesService _auditoriaEntidadesService;
        private readonly IUsuarioRepository _usuarioRepository;
        private readonly IMensajeService _mensajeService;
        private readonly IEmailService _emailService;
        private readonly IAppConfig _appConfig;
        private readonly IRolUsuarioService _rolUsuarioService;
        private readonly ISecurityToken _securityToken;
        private readonly IRolRepository _rolRepository;
        public UsuarioService(IAuditoriaEntidadesService auditoriaEntidadesService, IUsuarioRepository usuarioRepository, IMensajeService mensajeService, IEmailService emailService, IAppConfig appConfig, IRolUsuarioService rolUsuarioService, ISecurityToken securityToken, IRolRepository rolRepository)
        {
            _auditoriaEntidadesService = auditoriaEntidadesService;
            _usuarioRepository = usuarioRepository;
            _mensajeService = mensajeService;
            _emailService = emailService;
            _appConfig = appConfig;
            _rolUsuarioService = rolUsuarioService;
            _securityToken = securityToken;
            _rolRepository = rolRepository;
        }
        public async Task<DtoRespuesta> CrearUsuario(string nombre, string apellido, string token, Guid personaId, string nombreUsuario, string email, string clave)
        {
            var usuarioMapeado = UsuarioMapper.Map(nombre, apellido, token, personaId, email, clave);
            _auditoriaEntidadesService.InsertarDatosAuditoria(usuarioMapeado, usuario: nombreUsuario);
            await _usuarioRepository.Add(usuarioMapeado);
            return await Respuesta.DevolverRespuesta("Usuario", "creado");
        }

        public async Task<DtoRespuesta> ActivarUsuario(string token)
        {
            var usuario = ObtenerUsuarioToken(token);
            if (usuario != null)
            {
                usuario.EmailConfirmado = true;
                _auditoriaEntidadesService.InsertarDatosAuditoria(usuario, usuario: usuario.NombreUsuario);
                await _usuarioRepository.Update(usuario);
                return await Respuesta.DevolverRespuesta("Usuario", "activado");
            }
            throw new Exception("Token Inválido");
        }

        public async Task<DtoRespuesta> OlvidoClave(string email)
        {
            var usuario = _usuarioRepository.GetOneOrDefault<UsuarioEntity>(x => x.Email == email);
            if (usuario != null)
            {
                if (string.IsNullOrEmpty(usuario.Token))
                {
                    usuario.Token = _securityToken.CrearToken(usuario.NombreUsuario, usuario.PersonaId, usuario.Email);
                    _auditoriaEntidadesService.ActualizarAuditoria(usuario);
                    await _usuarioRepository.Update(usuario);
                }
                MailCambioClave(usuario.Email, usuario.Token);
                return new DtoRespuesta { Bdt1 = true, Dt1 = "Email Enviado" };
            }
            throw new Exception("Usuario no existe");
        }

        public async Task<DtoRespuesta> ValidarToken(string token)
        {
            var usuario = ObtenerUsuarioToken(token);
            if (usuario != null && !string.IsNullOrEmpty(token))
            {
                return new DtoRespuesta { Bdt1 = true, Dt1 = "Token Válido" };
            }
            throw new Exception("Token Inválido");
        }

        public async Task<DtoRespuesta> CambioClave(string token, string clave)
        {
            var usuario = ObtenerUsuarioToken(token);
            if (usuario != null && !string.IsNullOrEmpty(token))
            {
                usuario.Clave = ConfiguracionUsuario.CreateMD5Hash(clave);
                _auditoriaEntidadesService.ActualizarAuditoria(usuario);
                await _usuarioRepository.Update(usuario);
                return await Respuesta.DevolverRespuesta("Usuario", "actualizado");
            }
            throw new Exception("Token Inválido");
        }

        public async Task<IEnumerable<UsuarioDto>> ListaUsuarios(string token)
        {
            var usuario = ObtenerUsuarioToken(token);
            if (usuario != null && !string.IsNullOrEmpty(token))
            {
                IEnumerable<UsuarioEntity> lista = await _usuarioRepository.GetAll();
                List<UsuarioDto> usuarios = new List<UsuarioDto>();
                if (lista?.Count() > 0)
                    return await UsuarioMapper.Map(lista);
                return usuarios;
            }
            throw new Exception("Token Inválido");
        }

        public async Task<DtoRespuesta> CambioRolUsuario(Guid usuarioId, Guid rolId, string token)
        {
            await ValidarToken(token);
            var usuario = await _usuarioRepository.GetByIdAsync<UsuarioEntity>(usuarioId);
            if (usuario != null)
            {
                try
                {
                    var rol = await _rolRepository.GetByIdAsync<RolEntity>(rolId);
                    usuario.EsAdministrador = rol.RolInstalacion;
                    _auditoriaEntidadesService.ActualizarAuditoria(usuario, token: token);
                    await _usuarioRepository.Update(usuario);
                    return await _rolUsuarioService.EditarRolUsuario(rolId, usuario.RolesUsuario.FirstOrDefault(x => x.Estado == PropiedadesAuditoria.EstadoActivo).Id, token);
                }
                catch
                {
                    throw new Exception("Rol Usuario ya asignado");
                }

            }
            throw new Exception("Usuario No Existe");
        }

        public UsuarioEntity ObtenerUsuarioToken(string token)
        {
            return _usuarioRepository.GetOneOrDefault<UsuarioEntity>(x => x.Token == token);
        }

        private void MailCambioClave(string mail, string token)
        {
            var datos = new Dictionary<string, string> {
               {"activar", _appConfig.BaseUrl + SoulSplitConstantes.RutaCambioClave + token }
            };
            _emailService.CambioClave(new Mensaje(new List<string>() { mail }, "Cambio Clave", datos));
        }



    }
}
