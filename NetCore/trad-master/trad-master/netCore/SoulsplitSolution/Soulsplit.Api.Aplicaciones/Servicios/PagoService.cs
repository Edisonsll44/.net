using Microsoft.AspNetCore.Http;
using Minio;
using Minio.Exceptions;
using Soulpslit.Api.AccesoDatos.Mapeos;
using Soulsplit.Api.AccesoDatos.Contratos;
using Soulsplit.Api.AccesoDatos.Contratos.Repositorios.Configuracion;
using Soulsplit.Api.Contratos;
using Soulsplit.Api.Contratos.ContratosServicios;
using Soulsplit.Api.Utilitarios.Dto;
using Soulsplit.Api.Utilitarios.Enumeraciones;
using Soulsplit.Api.Utilitarios.Enumeraciones.Configuraciones;
using Soulsplit.Api.Utilitarios.Propiedades;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace Soulsplit.Api.Aplicaciones.Servicios
{
    public class PagoService : IPagoService
    {
        private readonly string _bucketName;
        private readonly IAppConfig _appConfig;
        private readonly IPersonaService _personaService;
        private readonly IEstadoService _estadoService;
        private readonly IAwsS3Service _awsS3Service;
        private readonly IPagoRepository _pagoRepository;
        private readonly ICuentaRepository _cuentaRepository;
        private readonly IAuditoriaEntidadesService _auditoriaEntidadesService;
        private readonly IUnitOfWork _unitOfWork;
        private readonly IChannelService _channelService;
        public PagoService(
            IAppConfig appConfig,
            IPersonaService personaService,
            IEstadoService estadoService,
            IAwsS3Service awsS3Service,
            IPagoRepository pagoRepository,
            ICuentaRepository cuentaRepository,
            IAuditoriaEntidadesService auditoriaEntidadesService,
            IUnitOfWork unitOfWork,
            IChannelService channelService)
        {
            _appConfig = appConfig;
            _personaService = personaService;
            _estadoService = estadoService;
            _awsS3Service = awsS3Service;
            _pagoRepository = pagoRepository;
            _cuentaRepository = cuentaRepository;
            _bucketName = _appConfig.BucketPago;
            _auditoriaEntidadesService = auditoriaEntidadesService;
            _unitOfWork = unitOfWork;
            _channelService = channelService;
        }

        public async Task<DtoRespuesta> CrearPago(DtoPago dto, string token)
        {
            using (var transaction = _unitOfWork.BeginTransaction())
            {
                try
                {
                    UsuarioEntity usuario = await _auditoriaEntidadesService.ObtenerUsuario(token);

                    DetalleEstadoEntity estado = await _estadoService.ObtenerDetalleEstado(ExtensionEnum.ObtenerDescripcion(Procesos.PAGOS), ExtensionEnum.ObtenerDescripcion(EstadoPago.EN_PROCESO));
                    if (estado is null)
                        throw new ArgumentNullException("Estado proceso");


                    CuentaEntity cuenta = await _cuentaRepository.GetOneAsync<CuentaEntity>(x => x.NumeroCuenta.Equals(dto.CuentaDeposito));
                    if (cuenta is null)
                        throw new ArgumentNullException($"Número de cuenta {dto.CuentaDeposito} no encontrada");
                    string nombreImagen = Guid.NewGuid().ToString();
                    var nuevoPago = PagoMapper.Map(dto);
                    if (!string.IsNullOrEmpty(dto.ImagenComprobante))
                    {
                        string data = dto.ImagenComprobante.Split(';')[0].Split(':')[1];
                        string base64 = dto.ImagenComprobante.Split(',')[1];
                        nuevoPago.UrlImagen = await _awsS3Service.CargarArchivo(base64, nombreImagen, _bucketName);
                    }
                    nuevoPago.EstadoPagoId = estado.Id;
                    nuevoPago.PersonaId = usuario.PersonaId;
                    nuevoPago.CuentaId = cuenta.Id;

                    PersonaEntity persona = await _personaService.ObtenerPersona(usuario.PersonaId);
                    nuevoPago.Nombres = $"{persona.Nombres} { persona.Apellidos}";
                    nuevoPago.Identificacion = persona.Identificacion;
                    nuevoPago.TipoIdentificacion = persona.TipoIdentificacion.Nombre;
                    nuevoPago.Email = persona.Email;
                    _auditoriaEntidadesService.InsertarDatosAuditoria(nuevoPago, usuario: usuario.NombreUsuario);
                    nuevoPago = await _pagoRepository.Add(nuevoPago);
                    transaction.Commit();
                    nuevoPago = await _pagoRepository.GetByIdAsync<PagoEntity>(nuevoPago.Id);
                    await _channelService.Trigger(PagoMapper.Map(nuevoPago), ExtensionEnum.ObtenerDescripcion(Canales.Pagos), ExtensionEnum.ObtenerDescripcion(Eventos.CreacionPago));
                    await _channelService.Trigger(PagoMapper.Map(nuevoPago), ExtensionEnum.ObtenerDescripcion(Canales.Usuario) + usuario.Id.ToString(), ExtensionEnum.ObtenerDescripcion(Eventos.CreacionPagoUsuario));
                    return await Respuesta.DevolverRespuesta("Pago", "creado", nuevoPago.Id);
                }
                catch (Exception e)
                {
                    transaction.Rollback();
                    throw;
                }
            }
        }


        public async Task<DtoRespuesta> CargarPago(IFormFile archivo, Guid idPago, string token)
        {
            using (var transaction = _unitOfWork.BeginTransaction())
            {
                try
                {
                    UsuarioEntity usuario = await _auditoriaEntidadesService.ObtenerUsuario(token);

                    PagoEntity pago = await _pagoRepository.GetByIdAsync<PagoEntity>(idPago);
                    if (pago is null)
                        throw new Exception("Pago no encontrado");

                    string nombreImagen = archivo.FileName;
                    string imagen;
                    using (var ms = new MemoryStream())
                    {
                        await archivo.CopyToAsync(ms);
                        var fileBytes = ms.ToArray();
                        imagen = Convert.ToBase64String(ms.ToArray());
                    }
                    pago.UrlImagen = await _awsS3Service.CargarArchivo(imagen, nombreImagen, _bucketName);
                    _auditoriaEntidadesService.ActualizarAuditoria(pago, token: token);
                    await _pagoRepository.Update(pago);
                    transaction.Commit();
                    return await Respuesta.DevolverRespuesta("Pago", "actualizado");
                }
                catch (Exception e)
                {
                    transaction.Rollback();
                    throw;
                }
            }
        }

        public async Task CargarPago(IFormFile archivo, string bucketName = "nacho")
        {
            MinioClient minio = new MinioClient("186.46.95.82:60", "n4RNzQdE9cZAnpsWVc", @"Kj2~jB6s{g*'P@;?UM;Sq%LX9n6-\");
            try
            {
                // Make a bucket on the server, if not already present.
                var polic = await minio.GetPolicyAsync(bucketName);
                bool found = await minio.BucketExistsAsync(bucketName);
                if (!found)
                    await minio.MakeBucketAsync(bucketName);
                string nombreArchivo = Guid.NewGuid().ToString() + Path.GetExtension(archivo.FileName);
                var path = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot", nombreArchivo);

                using (var stream = new FileStream(path, FileMode.Create))
                {
                    await archivo.CopyToAsync(stream);
                }
                await minio.PutObjectAsync(bucketName, nombreArchivo, path, archivo.ContentType, null, null);
                if (File.Exists(path))
                    File.Delete(path);

                // Upload a file to bucket.
                Console.WriteLine("Successfully uploaded " + nombreArchivo);
            }
            catch (MinioException e)
            {
                Console.WriteLine("File Upload Error: {0}", e.Message);
            }
            catch (Exception e)
            {
                throw;
            }
        }


        public async Task<IEnumerable<DtoConsultaPago>> ObtenerPagos(DtoConsultaPago dto)
        {
            try
            {
                IEnumerable<PagoEntity> pagos = await _pagoRepository.ConsultarPagos(dto);
                return await PagoMapper.Map(pagos, dto.Total);
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }
        }

        public async Task<IEnumerable<DtoConsultaPago>> ObtenerPagosUsuario(string token)
        {
            try
            {
                UsuarioEntity usuario = await _auditoriaEntidadesService.ObtenerUsuario(token);
                IEnumerable<PagoEntity> pagos = await _pagoRepository.GetAsync<PagoEntity>(x => x.PersonaId == usuario.PersonaId && x.Estado.Equals(PropiedadesAuditoria.EstadoActivo));
                return await PagoMapper.Map(pagos.OrderByDescending(x => x.FechaCreacion));
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }
        }

        public async Task<DtoRespuesta> ActualizarPago(DtoPagoConciliacion dto, string token)
        {
            using (var transaction = _unitOfWork.BeginTransaction())
            {
                try
                {
                    UsuarioEntity usuario = await _auditoriaEntidadesService.ObtenerUsuario(token);
                    PagoEntity pago = await ObtenerPago(dto.Id);
                    DetalleEstadoEntity estado = await _estadoService.ObtenerDetalleEstado(dto.EstadoId);
                    if (estado.Nombre.Equals(ExtensionEnum.ObtenerDescripcion(EstadoPago.EN_PROCESO)))
                        throw new Exception($"Debe seleccionar el Estado {ExtensionEnum.ObtenerDescripcion(EstadoPago.APROBADO)} o {ExtensionEnum.ObtenerDescripcion(EstadoPago.RECHAZADO)}");
                    if (estado.Id == pago.EstadoPagoId)
                        throw new Exception($"El estado del pago ya se encuentra procesado {estado.Nombre}");
                    PersonaEntity persona = pago.Persona;

                    if (estado.Nombre.Equals(ExtensionEnum.ObtenerDescripcion(EstadoPago.APROBADO)))
                        persona.SaldoActual += pago.Valor;
                    else if (estado.Nombre.Equals(ExtensionEnum.ObtenerDescripcion(EstadoPago.RECHAZADO)))
                    {
                        if (pago?.HistorialPagos?.Count(x => x.Estado.Equals(PropiedadesAuditoria.EstadoActivo) && x.EstadoPago.Nombre.Equals(ExtensionEnum.ObtenerDescripcion(EstadoPago.APROBADO))) > 0)
                            persona.SaldoActual -= pago.Valor;
                    }
                    else
                        throw new Exception($"El estado {estado.Nombre} no se encuentra configurado para este proceso");

                    if (pago?.HistorialPagos?.Count(x => x.Estado.Equals(PropiedadesAuditoria.EstadoActivo)) > 0)
                        pago.HistorialPagos.ToList().ForEach(x => x.Estado = PropiedadesAuditoria.EstadoInactivo);
                    pago.EstadoPagoId = estado.Id;
                    pago.UsuarioConciliacionId = usuario.Id;
                    HistorialPagoEntity historial = new HistorialPagoEntity()
                    {
                        PagoId = pago.Id,
                        Observacion = dto.Observacion,
                        UsuarioId = usuario.Id,
                        NombreOperador = usuario.NombreUsuario,
                        EstadoPagoId = estado.Id,
                        EstadoConciliacion = estado.Nombre,
                        FechaRespuesta = DateTime.Now
                    };
                    _auditoriaEntidadesService.InsertarDatosAuditoria(historial, usuario: usuario.NombreUsuario);
                    pago.HistorialPagos.Add(historial);
                    _auditoriaEntidadesService.ActualizarAuditoria(pago, usuario: usuario.NombreUsuario);
                    await _pagoRepository.Update(pago);
                    transaction.Commit();
                    await _channelService.Trigger(PagoMapper.Map(pago), ExtensionEnum.ObtenerDescripcion(Canales.Pagos), ExtensionEnum.ObtenerDescripcion(Eventos.ActualizacionPago));
                    await _channelService.Trigger(PagoMapper.Map(pago), ExtensionEnum.ObtenerDescripcion(Canales.Usuario) + persona.Usuario.Id.ToString(), ExtensionEnum.ObtenerDescripcion(Eventos.ActualizacionPagoUsuario));
                    return await Respuesta.DevolverRespuesta("Pago", "actualizado");
                }
                catch (Exception e)
                {
                    transaction.Rollback();
                    throw;
                }
            }
        }


        async Task<PagoEntity> ObtenerPago(Guid idPago)
        {
            PagoEntity pago = await _pagoRepository.GetByIdAsync<PagoEntity>(idPago);
            if (pago is null)
                throw new Exception("Pago no encontrado");
            return pago;
        }
    }
}
