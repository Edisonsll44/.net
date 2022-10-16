using Soulpslit.Api.AccesoDatos.Mapeos;
using Soulsplit.Api.AccesoDatos.Contratos;
using Soulsplit.Api.Contratos;
using Soulsplit.Api.Contratos.ContratosServicios;
using Soulsplit.Api.Email;
using Soulsplit.Api.Utilitarios.Dto;
using Soulsplit.Api.Utilitarios.Enumeraciones;
using Soulsplit.Api.Utilitarios.Propiedades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Soulsplit.Api.Aplicaciones.Servicios
{
    public class CuentaService : ICuentaService
    {
        private readonly ICuentaRepository _cuentaRepository;
        private readonly IAuditoriaEntidadesService _auditoriaEntidadesService;
        private readonly IEmailService _emailService;
        public CuentaService(
            ICuentaRepository cuentaRepository,
            IAuditoriaEntidadesService auditoriaEntidadesService, IEmailService emailService)
        {
            _cuentaRepository = cuentaRepository;
            _auditoriaEntidadesService = auditoriaEntidadesService;
            _emailService = emailService;
        }

        public async Task<DtoRespuesta> CrearCuenta(DtoCuenta dto, string token)
        {
            try
            {
                UsuarioEntity usuario = await _auditoriaEntidadesService.ObtenerUsuario(token);
                CuentaEntity cuenta = CuentaMapper.Map(dto);
                _auditoriaEntidadesService.InsertarDatosAuditoria(cuenta, token);
                await _cuentaRepository.Add(cuenta);
                return await Respuesta.DevolverRespuesta("Cuenta", "creada");
            }
            catch (Exception e)
            {
                throw;
            }
        }



        public async Task<DtoRespuesta> ActualizarCuenta(DtoCuenta dto, string token)
        {
            try
            {
                CuentaEntity cuenta = await _cuentaRepository.GetByIdAsync<CuentaEntity>(dto.Id);
                if (cuenta is null)
                    throw new Exception("Cuenta no encontrada");
                UsuarioEntity usuario = await _auditoriaEntidadesService.ObtenerUsuario(token);

                if (dto.Accion == (int)Acciones.Modificar)
                {
                    cuenta.BancoId = dto.BancoId;
                    cuenta.TipoCuentaId = dto.TipoCuentaId;
                    cuenta.TipoIdentificacion = dto.TipoIdentificacion;
                    cuenta.Identificacion = dto.Identificacion;
                    cuenta.Nombres = dto.Nombres;
                    cuenta.NumeroCuenta = dto.NumeroCuenta;
                    cuenta.Email = dto.Email;
                }
                else if (dto.Accion == (int)Acciones.Eliminar)
                    cuenta.Estado = PropiedadesAuditoria.EstadoInactivo;
                else if (dto.Accion == (int)Acciones.Reactivar)
                    cuenta.Estado = PropiedadesAuditoria.EstadoActivo;
                else
                    throw new Exception("Actualización no realizada");
                _auditoriaEntidadesService.ActualizarAuditoria(cuenta, token: token);
                await _cuentaRepository.Update(cuenta);
                return await Respuesta.DevolverRespuesta("Cuenta", "actualizada");
            }
            catch (Exception e)
            {
                throw;
            }
        }

        public async Task<IEnumerable<DtoCuenta>> ObtenerCuentas()
        {
            try
            {
                IEnumerable<CuentaEntity> Cuentas = await _cuentaRepository.GetAsync<CuentaEntity>(x => x.Estado.Equals(PropiedadesAuditoria.EstadoActivo));
                return await CuentaMapper.Map(Cuentas);
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }
        }

        public async Task<DtoRespuesta> EnviarMailCuenta(string token)
        {
            UsuarioEntity usuario = await _auditoriaEntidadesService.ObtenerUsuario(token);
            var cuentas = await ObtenerCuentas();
            string cuentasString = string.Empty;
            foreach (var item in cuentas?.AsEnumerable())
            {
                cuentasString += string.Format("Cuenta: {0}, Banco: {1}, Identificación: {2}, Nombres: {3}, Email: {4} \n <br/>", item.NumeroCuenta, item.Banco, item.Identificacion, item.Nombres, item.Email);
            }
            return await MailCuenta(usuario.Email, cuentasString);
        }

        private async Task<DtoRespuesta> MailCuenta(string mail, string cuentas)
        {
            var datos = new Dictionary<string, string> {
                {"cuentas", cuentas.ToString() }
            };
            return await _emailService.EnvioCuentas(new Mensaje(new List<string>() { mail }, "Cuentas Depósito SoulSplit", datos));
        }
    }
}
