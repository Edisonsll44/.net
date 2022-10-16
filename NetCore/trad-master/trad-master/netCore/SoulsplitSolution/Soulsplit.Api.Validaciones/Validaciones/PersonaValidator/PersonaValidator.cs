using FluentValidation;
using Microsoft.Extensions.Localization;
using Soulsplit.Api.AccesoDatos.Contratos;
using Soulsplit.Api.AccesoDatos.Contratos.Entidades.Entidades.Configuracion;
using Soulsplit.Api.AccesoDatos.Contratos.Repositorios;
using Soulsplit.Api.Utilitarios.Dto;
using Soulsplit.Api.Utilitarios;
using Soulsplit.Api.Validaciones.Resource;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace Soulsplit.Api.Validaciones.Validaciones
{
    public class PersonaValidator : AbstractValidator<PersonaDto>, IPersonaValidator
    {
        private readonly IStringLocalizer<MensajeResource> _localizer;
        private readonly IPersonaRepository _personaRepository;
        private readonly ITipoDocumentoRepository _tipoDocumentoRepository;
        private readonly IUsuarioRepository _usuarioRepository;
        public PersonaValidator(IStringLocalizer<MensajeResource> localizer, IPersonaRepository personaRepository, ITipoDocumentoRepository tipoDocumentoRepository, IUsuarioRepository usuarioRepository)
        {
            _localizer = localizer;
            _personaRepository = personaRepository;
            _tipoDocumentoRepository = tipoDocumentoRepository;
            _usuarioRepository = usuarioRepository;
        }
        public async Task ValidarPersona(PersonaDto persona)
        {
            RuleFor(model => model.Identificacion).NotEmpty().WithMessage(string.Format(_localizer["CampoRequerido"], _localizer["Identificacion"]));
            RuleFor(model => model.Nombres).NotEmpty().WithMessage(string.Format(_localizer["CampoRequerido"], _localizer["Nombre"]));
            RuleFor(model => model.Pais).NotEmpty().WithMessage(string.Format(_localizer["CampoRequerido"], _localizer["Pais"]));
            RuleFor(x => x.Identificacion).MustAsync(async (id, cancellation) => !await ExisteIdentificacion(id)).WithMessage(x => string.Format(_localizer["RegistroDuplicado"], _localizer["Identificacion"], x.Identificacion));
            RuleFor(x => x.Identificacion).MustAsync(async (id, cancellation) => await ValidarIdentificacion(id, persona.TipoIdentificacionId)).WithMessage(x => string.Format(_localizer["IdNoValido"], _localizer["IdNoValido"], x.Identificacion));
            RuleFor(x => x.CodigoReferencia).MustAsync(async (id, cancellation) => await ExisteCodigoReferencia(id)).WithMessage(x => string.Format(_localizer["Referencia"], _localizer["Referencia"], x.CodigoReferencia));
            RuleFor(x => x.Email).MustAsync(async (id, cancellation) => !await ExisteEmail(id)).WithMessage(x => string.Format(_localizer["RegistroDuplicado"], "Email", x.Email));
            await Validar(persona);
        }

        async Task<bool> ExisteIdentificacion(string identificacion) =>
            await _personaRepository.GetExistsAsync<PersonaEntity>(x => x.Identificacion.Equals(identificacion));

        async Task<bool> ExisteCodigoReferencia(string referencia)
        {
            return string.IsNullOrEmpty(referencia) ? true : await _usuarioRepository.GetExistsAsync<UsuarioEntity>(x => x.CodigoReferencia.Equals(referencia));
        }

        async Task<bool> ExisteEmail(string email)
        {
            return await _usuarioRepository.GetExistsAsync<UsuarioEntity>(x => x.Email.Equals(email));
        }

        async Task<bool> ValidarIdentificacion(string identificacion, Guid tipoIdentificacion)
        {
            TipoIdentificacionEntity tipoDocumento = await _tipoDocumentoRepository.GetByIdAsync<TipoIdentificacionEntity>(tipoIdentificacion);
            return ConfiguracionUsuario.ValidarIdentificacion(identificacion, tipoDocumento.Nombre, tipoDocumento.Pais.NombrePais);
        }
        async Task Validar(PersonaDto persona)
        {
            var validacion = await ValidateAsync(persona);
            if (!validacion.IsValid)
                throw new Exception("Error: " + string.Join(", ", validacion?.Errors?.Select(e => e.ErrorMessage)));
        }


    }
}
