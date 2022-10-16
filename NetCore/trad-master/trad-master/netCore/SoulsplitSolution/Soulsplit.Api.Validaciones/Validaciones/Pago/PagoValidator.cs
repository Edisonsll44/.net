using FluentValidation;
using Microsoft.Extensions.Localization;
using Soulsplit.Api.AccesoDatos.Contratos;
using Soulsplit.Api.Utilitarios.Dto;
using Soulsplit.Api.Utilitarios.Propiedades;
using Soulsplit.Api.Validaciones.Resource;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace Soulsplit.Api.Validaciones.Validaciones
{
    public class PagoValidator : AbstractValidator<DtoPago>, IPagoValidator
    {
        private readonly IStringLocalizer<MensajeResource> _localizer;
        private readonly ICuentaRepository _cuentaRepository;
        private readonly IFormaPagoRepository _formaPagoRepository;
        public PagoValidator(
            IStringLocalizer<MensajeResource> localizer,
            ICuentaRepository cuentaRepository,
            IFormaPagoRepository formaPagoRepository
            )
        {
            _localizer = localizer;
            _formaPagoRepository = formaPagoRepository;
            _cuentaRepository = cuentaRepository;
        }
        public async Task ValidarPago(DtoPago pago)
        {
            //RuleFor(model => model.ImagenComprobante).NotEmpty().WithMessage(string.Format(_localizer["CampoRequerido"], _localizer["Identificacion"]));
            RuleFor(model => model.Valor).Must(m => m > 0).WithMessage(string.Format(_localizer["ValorMayor"], _localizer["Valor"]));
            RuleFor(model => model.FechaPago).GreaterThan(DateTime.MinValue);
            RuleFor(model => model.CuentaDeposito).NotEmpty();
            RuleFor(x => x.CuentaDeposito).MustAsync(async (numeroCuenta, cancellation) => await ExisteCuenta(numeroCuenta)).WithMessage(string.Format(_localizer["NoRegistrado"], _localizer["Cuenta"]));
            RuleFor(x => x.FormaPagoId).MustAsync(async (id, cancellation) => await ExisteFormaPago(id)).WithMessage(string.Format(_localizer["NoRegistrado"], _localizer["FormaPago"]));
            await Validar(pago);
        }


        async Task<bool> ExisteCuenta(string numeroCuenta) =>
           await _cuentaRepository.GetExistsAsync<CuentaEntity>(x => x.NumeroCuenta == numeroCuenta && x.Estado.Equals(PropiedadesAuditoria.EstadoActivo));
        async Task<bool> ExisteFormaPago(Guid idFormaPago) =>
                 await _formaPagoRepository.GetExistsAsync<FormaPagoEntity>(x => x.Id == idFormaPago && x.Estado.Equals(PropiedadesAuditoria.EstadoActivo));


        async Task Validar(DtoPago entidad)
        {
            var validacion = await ValidateAsync(entidad);
            if (!validacion.IsValid)
                throw new System.FormatException("Error: " + string.Join(", ", validacion?.Errors?.Select(e => e.ErrorMessage)));
        }
    }
}
