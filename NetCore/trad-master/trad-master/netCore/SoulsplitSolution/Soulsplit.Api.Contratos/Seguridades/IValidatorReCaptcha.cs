namespace Soulsplit.Api.Contratos.Seguridades
{
    public interface IValidatorReCaptcha
    {
        bool ReCaptchValido(string reCaptcha);
    }
}
