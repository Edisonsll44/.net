using Newtonsoft.Json.Linq;
using Soulsplit.Api.Contratos;
using Soulsplit.Api.Contratos.Seguridades;
using System;
using System.IO;
using System.Net;

namespace Soulsplit.Api.Aplicaciones.Seguridad
{
    public class ValidatorReCaptcha : IValidatorReCaptcha
    {
        private readonly IAppConfig _appConfig;
        /// <summary>
        /// Clase validador
        /// </summary>
        public ValidatorReCaptcha(IAppConfig appConfig)
        {
            _appConfig = appConfig;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="reCaptcha"></param>
        /// <returns></returns>
        public bool ReCaptchValido(string reCaptcha)
        {
            string apiUrl = "https://www.google.com/recaptcha/api/siteverify?secret={0}&response={1}";
            var requestUri = string.Format(apiUrl, _appConfig.ReCaptchaSiteKey, reCaptcha);
            var request = (HttpWebRequest)WebRequest.Create(requestUri);

            using (WebResponse response = request.GetResponse())
            {
                using (StreamReader stream = new StreamReader(response.GetResponseStream()))
                {
                    JObject jResponse = JObject.Parse(stream.ReadToEnd());
                    if (jResponse.Value<bool>("success"))
                    {
                        return true;
                    }
                    else
                    {
                        throw new Exception("Recaptcha no válido");
                    }
                }
            }
        }


    }
}