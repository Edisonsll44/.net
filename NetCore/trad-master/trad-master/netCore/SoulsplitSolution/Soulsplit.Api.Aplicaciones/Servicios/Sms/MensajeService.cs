using Microsoft.AspNetCore.Http;
using Soulsplit.Api.Contratos;
using System;
using System.Net.Http;
using System.Threading.Tasks;
using Twilio;
using Twilio.Rest.Api.V2010.Account;
using Twilio.Types;

namespace Soulsplit.Api.Aplicaciones.Servicios
{
    public class MensajeService : IMensajeService
    {

        private readonly IAppConfig _appConfig;

        public MensajeService(IAppConfig appConfig)
        {
            _appConfig = appConfig;
        }


        public async Task EnviarSms(string codigoPais, string telefono, string mensaje)
        {
            var accountSid = _appConfig.SmsCuentaId;
            var authToken = _appConfig.SmsToken;
            TwilioClient.Init(accountSid, authToken);

            var messageOptions = new CreateMessageOptions(new PhoneNumber("whatsapp:" + telefono));
            //messageOptions.MessagingServiceSid = _appConfig.SmsServicioId;
            //messageOptions.MessagingServiceSid = _appConfig.SmsServicioId;
            messageOptions.From = new PhoneNumber("whatsapp:+14155238886");
            messageOptions.Body = mensaje;
            var repuesta = await MessageResource.CreateAsync(messageOptions);
            //if (!repuesta.Status.ToString().Equals("accepted") || repuesta.Status.ToString().Equals("queued"))
            //    throw new Exception($"Mensaje no enviado status:{repuesta.Status}");
        }


        public async Task EnviarLogError(string body, string mensaje, Exception error, HttpRequest request)
        {
            var host = request?.Host;
            var path = request?.Path;
            var metodo = request?.Method;
            var contentType = request?.ContentType;
            mensaje += $"Metodo:{ metodo}\n" +
                       $"ContentType:{contentType}\n" +
                       $"Path:{path}\n" +
                       $"Host:{host}\n" +
                       $"Body:{body}\n";
            string url = _appConfig.TelegramUrl;
            string token = _appConfig.TelegramToken;
            string mensajeError = mensaje + ($"Error:\n{error?.Message?.Trim()}{error?.InnerException?.Message}");
            string chatId = _appConfig.TelegramChatError;
            try
            {
                using (var httpClient = new HttpClient())
                {
                    var res = await httpClient.GetAsync($"{url}{token}/sendMessage?text={mensajeError}&chat_id={chatId}");
                }
            }
            catch (Exception ex)
            {
            }

        }



    }
}
