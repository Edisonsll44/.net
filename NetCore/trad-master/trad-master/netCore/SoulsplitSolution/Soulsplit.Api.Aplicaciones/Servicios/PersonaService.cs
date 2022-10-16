using Soulsplit.Api.AccesoDatos.Contratos;
using Soulsplit.Api.AccesoDatos.Contratos.Repositorios.Configuracion;
using Soulsplit.Api.AccesoDatos.Mapeos;
using Soulsplit.Api.Contratos;
using Soulsplit.Api.Contratos.ContratosServicios;
using Soulsplit.Api.Utilitarios.Dto;
using Soulsplit.Api.Contratos.Seguridad;
using Soulsplit.Api.Email;
using Soulsplit.Api.Utilitarios;
using Soulsplit.Api.Utilitarios.Enumeraciones;
using Soulsplit.Api.Utilitarios.Enumeraciones.Configuraciones;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;
using Newtonsoft.Json;
using Soulsplit.Api.Utilitarios.Propiedades;
using Soulsplit.Api.AccesoDatos.Contratos.Repositorios;
using System.Linq;

namespace Soulsplit.Api.Aplicaciones.Servicios
{
    public class PersonaService : IPersonaService
    {
        private readonly string _bucketName;
        private readonly IPersonaRepository _personaRepository;
        private readonly IUsuarioService _usuarioService;
        private readonly ISecurityToken _securityToken;
        private readonly IUnitOfWork _unitOfWork;
        private readonly IAuditoriaEntidadesService _auditoriaEntidadesService;
        private readonly IRolUsuarioService _rolUsuarioService;
        private readonly IRolRepository _rolRepository;
        private readonly IEmailService _emailService;
        private readonly IAppConfig _appConfig;
        private readonly IReferidoPersonaService _referidoPersonaService;
        private readonly IAwsS3Service _awsS3Service;
        private readonly IPaisRepository _paisRepository;
        private readonly IUsuarioRepository _usuarioRepository;
        private readonly IRolMenuService _rolMenuService;
        public PersonaService(IPersonaRepository personaRepository,
            IAuditoriaEntidadesService auditoriaEntidadesService,
            IUsuarioService usuarioService,
            ISecurityToken securityToken,
            IUnitOfWork unitOfWork, IRolUsuarioService rolUsuarioService, IRolRepository rolRepository, IEmailService emailService, IAppConfig appConfig, IReferidoPersonaService referidoPersonaService, IAwsS3Service awsS3Service, IPaisRepository paisRepository, IUsuarioRepository usuarioRepository, IRolMenuService rolMenuService)
        {
            _auditoriaEntidadesService = auditoriaEntidadesService;
            _personaRepository = personaRepository;
            _usuarioService = usuarioService;
            _securityToken = securityToken;
            _unitOfWork = unitOfWork;
            _rolUsuarioService = rolUsuarioService;
            _rolRepository = rolRepository;
            _emailService = emailService;
            _appConfig = appConfig;
            _referidoPersonaService = referidoPersonaService;
            _awsS3Service = awsS3Service;
            _bucketName = _appConfig.BucketPago;
            _paisRepository = paisRepository;
            _usuarioRepository = usuarioRepository;
            _rolMenuService = rolMenuService;
        }

        public async Task<DtoLoginRespuesta> ActualizarPersona(PersonaDto nuevaPersona, string token)
        {
            using (var transaction = _unitOfWork.BeginTransaction())
            {
                try
                {
                    var usuario = _usuarioService.ObtenerUsuarioToken(token);
                    if (usuario != null)
                    {
                        var datosTelefono = await ValidarTelefonoAsync(nuevaPersona.Telefono, nuevaPersona.Pais);
                        usuario.Persona.Nombres = nuevaPersona.Nombres.Trim().ToUpper();
                        usuario.Persona.Apellidos = nuevaPersona.Apellidos.Trim().ToUpper();
                        usuario.Persona.Email = nuevaPersona.Email.ToLower();
                        usuario.Persona.Identificacion = nuevaPersona.Identificacion;
                        usuario.Persona.Telefono = datosTelefono.international_format;
                        usuario.Persona.TipoIdentificacionId = nuevaPersona.TipoIdentificacionId;
                        usuario.Persona.TelefonoPaisId = nuevaPersona.Pais;
                        usuario.Persona.Direccion = nuevaPersona.Direccion;
                        if (!string.IsNullOrEmpty(nuevaPersona.Clave))
                            usuario.Clave = ConfiguracionUsuario.CreateMD5Hash(nuevaPersona.Clave);
                        if (!string.IsNullOrEmpty(nuevaPersona.ImagenPerfil))
                        {
                            string data = nuevaPersona.ImagenPerfil.Split(';')[0].Split(':')[1];
                            string base64 = nuevaPersona.ImagenPerfil.Split(',')[1];
                            usuario.FotoUsuario = await _awsS3Service.CargarArchivo(base64, Guid.NewGuid().ToString(), _bucketName);
                        }
                        _auditoriaEntidadesService.ActualizarAuditoria(usuario, token: token);
                        await _usuarioRepository.Update(usuario);
                        transaction.Commit();
                        return new DtoLoginRespuesta { Id = usuario.Id, Bdt1 = true, Bdt2 = usuario.EsAdministrador, Bdt3 = usuario.EmailConfirmado, Bdt4 = usuario.VerificoCelular, Dt1 = usuario.Token, Dt2 = usuario.Persona.Nombres + ' ' + usuario.Persona.Apellidos, Dt3 = usuario.CodigoReferencia, Dt4 = usuario.FotoUsuario, Ndt1 = usuario?.Persona?.ReferidosPersona?.Count() ?? 0, Ndt2 = usuario.Persona.SaldoActual, menu = await _rolMenuService.ObtenerMenuRol(usuario.RolesUsuario.FirstOrDefault().RolId) };
                    }
                    throw new Exception("Usuario No Existe");
                }
                catch (Exception e)
                {
                    transaction.Rollback();
                    throw;
                }
            }
        }

        public Task<DtoRespuesta> BuscarPersonas(string nombres = "", string identificacion = "")
        {
            throw new NotImplementedException();
        }

        public async Task<DtoRespuesta> CrearPersona(PersonaDto nuevaPersona, string token = "")
        {
            using (var transaction = _unitOfWork.BeginTransaction())
            {
                try
                {
                    var datosTelefono = await ValidarTelefonoAsync(nuevaPersona.Telefono, nuevaPersona.Pais);
                    nuevaPersona.Telefono = datosTelefono.international_format;
                    var personaMapeada = PersonaMapper.Map(nuevaPersona);
                    string nombre = personaMapeada.Nombres.Split(" ")[0], apellido = personaMapeada.Apellidos.Split(" ")[0] + Guid.NewGuid().ToString()?.ToUpper().Substring(0, 3);
                    var usuario = ConfiguracionUsuario.CrearUsuario(nombre, apellido);
                    _auditoriaEntidadesService.InsertarDatosAuditoria(personaMapeada, token: token, usuario: usuario);
                    await _personaRepository.Add(personaMapeada);
                    token = _securityToken.CrearToken(usuario, personaMapeada.Id, personaMapeada.Email);
                    await _usuarioService.CrearUsuario(nombre, apellido, token, personaMapeada.Id, usuario, personaMapeada.Email, nuevaPersona.Clave);
                    var respuesta = await _referidoPersonaService.CrearReferido(nuevaPersona.CodigoReferencia, personaMapeada.Id);
                    var rol = respuesta.Bdt1 ? ExtensionEnum.ObtenerDescripcion(Roles.USUARIO) : ExtensionEnum.ObtenerDescripcion(Roles.ADMINISTRADOR);
                    await _rolUsuarioService.CrearRolUsuario(_rolRepository.GetOneOrDefault<RolEntity>(x => x.NombreRol.Equals(rol)).Id, personaMapeada.Usuario.Id);
                    MailBienvenida(nuevaPersona.Email, token, urlReferencia: respuesta.Dt2);
                    transaction.Commit();
                    return await Respuesta.DevolverRespuesta("Persona", "creada");
                }
                catch (Exception e)
                {
                    transaction.Rollback();
                    throw;
                }
            }
        }

        public Task<DtoRespuesta> EliminarPersona(long idPersona)
        {
            throw new NotImplementedException();
        }

        public Task<DtoRespuesta> ReactivarPersona(long idPersona)
        {
            throw new NotImplementedException();
        }

        public async Task<PersonaEntity> ObtenerPersona(Guid idPersona)
        {
            PersonaEntity persona = await _personaRepository.GetByIdAsync<PersonaEntity>(idPersona);
            if (persona is null)
                throw new Exception("Persona no encontrada");
            return persona;
        }

        public async Task<PersonaDto> ObtenerDatosPersona(string token)
        {
            var usuario = _usuarioService.ObtenerUsuarioToken(token);
            if (usuario != null)
            {
                usuario.Persona.Telefono = usuario.Persona.Telefono.Replace('+' + _paisRepository.GetByIdAsync<PaisEntity>(usuario.Persona.TelefonoPaisId).Result.CodigoRegional, string.Empty);
                return PersonaMapper.Map(usuario.Persona);
            }
            throw new Exception("Usuario No Existe");
        }

        public async Task<DtoRespuesta> MailBienvenida(string mail)
        {
            var persona = await _personaRepository.GetOneAsync<PersonaEntity>(x => x.Email == mail && x.Estado == PropiedadesAuditoria.EstadoActivo);
            if (persona != null)
            {
                var datos = new Dictionary<string, string> {
                {"usuario", persona.Usuario.Email },
                 { "link", null},
                {"activar", _appConfig.BaseUrl + SoulSplitConstantes.RutaActivarUsuario + persona.Usuario.Token }
                };
                return await _emailService.ActivarUsuarioNuevo(new Mensaje(new List<string>() { mail }, "Bienvenido a SoulSplit", datos));
            }
            else
            {
                throw new Exception("Email no Registrado");
            }

        }

        private void MailBienvenida(string mail, string token, string urlReferencia)
        {
            var datos = new Dictionary<string, string> {
                {"usuario", mail },
                { "link", urlReferencia},
                {"activar", _appConfig.BaseUrl + SoulSplitConstantes.RutaActivarUsuario + token }
            };
            _emailService.ActivarUsuarioNuevo(new Mensaje(new List<string>() { mail }, "Bienvenido a SoulSplit", datos));
        }

        private async Task<NumVerifyDto> ValidarTelefonoAsync(string telefono, Guid idPais)
        {
            var pais = await _paisRepository.GetByIdAsync<PaisEntity>(idPais);
            string URL = SoulSplitConstantes.UrlValidacionTelefono;
            string urlParameters = string.Format(SoulSplitConstantes.ParametrosValidacionTelefono, _appConfig.NumverifySiteKey, telefono, pais.CodigoPais);
            HttpClient client = new HttpClient();
            client.BaseAddress = new Uri(URL);
            HttpResponseMessage response = client.GetAsync(urlParameters).Result;
            NumVerifyDto dataObjects = JsonConvert.DeserializeObject<NumVerifyDto>(response.Content.ReadAsStringAsync().Result);
            if (dataObjects.valid)
            {
                return dataObjects;
            }
            else
            {
                throw new Exception("Número Inválido");
            }
        }

    }
}
