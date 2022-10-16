using Microsoft.AspNetCore.Http;
using System;
using System.Threading.Tasks;

namespace Soulsplit.Api.Aplicaciones.Servicios
{
    public interface IMensajeService
    {
        Task EnviarSms(string codigoPais, string telefono, string mensaje);
        Task EnviarLogError(string body, string mensaje, Exception error, HttpRequest request);

    }
}
