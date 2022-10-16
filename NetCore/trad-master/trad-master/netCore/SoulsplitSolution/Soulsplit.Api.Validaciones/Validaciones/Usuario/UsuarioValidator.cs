using FluentValidation;
using Microsoft.Extensions.Localization;
using Soulsplit.Api.AccesoDatos.Contratos;
using Soulsplit.Api.AccesoDatos.Contratos.Repositorios;
using Soulsplit.Api.Utilitarios.Dto;
using Soulsplit.Api.Validaciones.Resource;
using System.Linq;
using System.Threading.Tasks;

namespace Soulsplit.Api.Validaciones.Validaciones
{
    public class UsuarioValidator : AbstractValidator<UsuarioDto>, IUsuarioValidator
    {
        private readonly IStringLocalizer<MensajeResource> _localizer;
        private readonly IUsuarioRepository _usuarioRepository;

        public UsuarioValidator(IStringLocalizer<MensajeResource> localizer, IUsuarioRepository usuarioRepository)
        {
            _localizer = localizer;
            _usuarioRepository = usuarioRepository;
        }

        public async Task ValidarUsuario(UsuarioDto usuario)
        {
            RuleFor(x => x.Token).MustAsync(async (id, cancellation) => await ExisteToken(id)).WithMessage(x => string.Format(_localizer["Token"], _localizer["Token"], x.Token));
            await Validar(usuario);
        }

        async Task<bool> ExisteToken(string token) =>
            await _usuarioRepository.GetExistsAsync<UsuarioEntity>(x => x.Token.Equals(token));

        async Task Validar(UsuarioDto usuario)
        {
            var validacion = await ValidateAsync(usuario);
            if (!validacion.IsValid)
                throw new System.FormatException("Error: " + string.Join(", ", validacion?.Errors?.Select(e => e.ErrorMessage)));
        }
    }
}
