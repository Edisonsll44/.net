using FluentValidation;
using Soulsplit.Api.AccesoDatos.Contratos.Repositorios;
using Soulsplit.Api.Utilitarios.Dto;
using System;
using Soulsplit.Api.AccesoDatos.Contratos;
using System.Linq;
using Soulsplit.Api.Utilitarios.Propiedades;
using System.Threading.Tasks;
using Microsoft.Extensions.Localization;
using Soulsplit.Api.Validaciones.Resource;

namespace Soulsplit.Api.Validaciones.Validaciones
{
    public class InicioSessionValidator : AbstractValidator<AuthRequest>, IInicioSessionValidator
    {
        private readonly IUsuarioRepository _usuarioRepository;
        private readonly IStringLocalizer<MensajeResource> _localizer;
        public InicioSessionValidator(IUsuarioRepository usuarioRepository, IStringLocalizer<MensajeResource> localizer)
        {
            _usuarioRepository = usuarioRepository;
            _localizer = localizer;
        }
        public async Task ValidarDatosInicioSesion(AuthRequest credenciales)
        {
            RuleFor(x => x.Clave).NotEmpty().NotNull().MinimumLength(5).WithMessage(x => string.Format(_localizer["CampoRequerido"], "Password"));
            RuleFor(x => x.Email).NotEmpty().NotNull().MinimumLength(5).WithMessage(x => string.Format(_localizer["CampoRequerido"], "Email"));
            RuleFor(x => x.Codigo).NotEmpty().NotNull().MinimumLength(5).WithMessage(x => string.Format(_localizer["CampoRequerido"], "OTP"));
            ValidarCredencialesExistentes();
            await EjecutarValidacion(credenciales);
        }

        public async Task ValidarDatosOTP(AuthRequest credenciales)
        {
            RuleFor(x => x.Clave).NotEmpty().NotNull().MinimumLength(5).WithMessage(x => string.Format(_localizer["CampoRequerido"], "Password"));
            RuleFor(x => x.Email).NotEmpty().NotNull().MinimumLength(5).WithMessage(x => string.Format(_localizer["CampoRequerido"], "Email"));
            RuleFor(x => x.Email).MustAsync(async (o, id, cancellation) => await ValidarMailClaveAsync(id, o.Clave)).WithMessage(x => _localizer["Credenciales"]);
            RuleFor(x => x.Email).MustAsync(async (o, id, cancellation) => await ValidarUsuarioExistenteAsync(id)).WithMessage(x => string.Format(_localizer["NoRegistrado"], "Email"));
            RuleFor(x => x.Email).MustAsync(async (o, id, cancellation) => await ValidarUsuarioActivadoAsync(id, o.Clave)).WithMessage(x => _localizer["UsuarioActivo"]);
            await EjecutarValidacion(credenciales);
        }

        public async Task ValidarToken(AuthRequest usuario)
        {
            RuleFor(x => x.Token).MustAsync(async (id, cancellation) => await ExisteToken(id)).WithMessage(x => string.Format(_localizer["Token"]));
            await EjecutarValidacion(usuario);
        }

        async Task<bool> ExisteToken(string token) =>
            await _usuarioRepository.GetExistsAsync<UsuarioEntity>(x => x.Token.Equals(token));

        void ValidarCredencialesExistentes()
        {
            RuleFor(x => x.Email).Must((o, email) => { return ValidarCredenciales(email, clave: o.Clave, codigo: o.Codigo); }).WithMessage(x => string.Format(_localizer["Credenciales"]));
            RuleFor(x => x.Email).MustAsync(async (o, id, cancellation) => await ValidarUsuarioExistenteAsync(id)).WithMessage(x => string.Format(_localizer["NoRegistrado"], "Email"));
        }

        async Task<bool> ValidarUsuarioExistenteAsync(string email)
        {
            return await _usuarioRepository.GetExistsAsync<UsuarioEntity>(u => u.Persona.Email == email.Trim() && u.Estado == PropiedadesAuditoria.EstadoActivo);
        }
        bool ValidarCredenciales(string email, string clave, string codigo)
        {
            return _usuarioRepository.GetExists<UsuarioEntity>(u => u.Persona.Email == email.Trim() && u.Clave == clave.Trim() && u.CodigoOTP == codigo);
        }
        async Task<bool> ValidarMailClaveAsync(string email, string clave)
        {
            return await _usuarioRepository.GetExistsAsync<UsuarioEntity>(u => u.Persona.Email == email.Trim() && u.Clave == clave.Trim());
        }
        async Task<bool> ValidarUsuarioActivadoAsync(string email, string clave)
        {
            return await _usuarioRepository.GetExistsAsync<UsuarioEntity>(u => u.Persona.Email == email && u.Clave == clave) && await _usuarioRepository.GetExistsAsync<UsuarioEntity>(u => u.Persona.Email == email && u.EmailConfirmado);

        }
        async Task EjecutarValidacion(AuthRequest entidad)
        {
            var validacion = await ValidateAsync(entidad);
            if (!validacion.IsValid)
                throw new Exception("Error: " + string.Join(", ", validacion?.Errors?.Select(e => e.ErrorMessage)));
        }
    }
}
