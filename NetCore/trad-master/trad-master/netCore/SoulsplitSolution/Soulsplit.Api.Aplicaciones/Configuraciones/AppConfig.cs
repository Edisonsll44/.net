using Microsoft.Extensions.Configuration;
using Soulsplit.Api.Contratos;

namespace Soulsplit.Api.Aplicaciones
{
    public class AppConfig : IAppConfig
    {
        private readonly IConfiguration _configuration;

        public AppConfig(IConfiguration configuration)
        {
            _configuration = configuration;
        }
        public int MaximoIntentos => int.Parse(_configuration.GetSection("Polly:MaxTrys").Value);

        public int SegundosEspera => int.Parse(_configuration.GetSection("Polly:TimeDelay").Value);
        public string ServicioUrl => _configuration.GetSection("ServiceUrl").Value;
        public string Secreto => _configuration.GetSection("AppSettings:Secreto").Value;
        public double CaducidadCodigo => double.Parse(_configuration.GetSection("AppSettings:CaducidadCodigo").Value);
        public double TiempoCaducidad => int.Parse(_configuration.GetSection("AppSettings:TiempoCaducidad").Value);
        #region Pusher
        public string Pusher_app_id => _configuration.GetSection("Pusher:app_id").Value;
        public string Pusher_key => _configuration.GetSection("Pusher:key").Value;
        public string Pusher_secret => _configuration.GetSection("Pusher:secret").Value;
        public string Pusher_cluster => _configuration.GetSection("Pusher:cluster").Value;
        #endregion

        #region Mail
        public string MailRemitente => _configuration.GetSection("Mailing:Remitente").Value;
        public string MailFrom => _configuration.GetSection("Mailing:From").Value;
        public string MailServer => _configuration.GetSection("Mailing:SmtpServer").Value;
        public string MailUser => _configuration.GetSection("Mailing:User").Value;
        public string MailPassword => _configuration.GetSection("Mailing:Password").Value;
        public int MailPort => int.Parse(_configuration.GetSection("Mailing:Port").Value);
        public string BaseUrl => _configuration.GetSection("Mailing:BaseUrl").Value;
        #endregion

        #region Aws s3
        public string BucketPago => _configuration.GetSection("AWS:BucketPago").Value;
        public string AccessKeyAWS => _configuration.GetSection("AWS:AccessKey").Value;
        public string SecretKeyAWS => _configuration.GetSection("AWS:SecretKey").Value;
        public string RegionAWSS3 => _configuration.GetSection("AWS:Region").Value;
        public string AwsBaseUrl => _configuration.GetSection("AWS:AwsBaseUrl").Value;
        #endregion

        #region Recaptcha
        public string ReCaptchaSiteKey => _configuration.GetSection("ReCaptcha:SiteKey").Value;
        #endregion

        #region Sms
        public string SmsCuentaId => _configuration.GetSection("Sms:accountSid").Value;
        public string SmsToken => _configuration.GetSection("Sms:token").Value;
        public string SmsServicioId => _configuration.GetSection("Sms:ServiceSid").Value;

        #endregion

        #region Sms
        public string TelegramChatError => _configuration.GetSection("Telegram:chatError").Value;
        public string TelegramToken => _configuration.GetSection("Telegram:token").Value;
        public string TelegramUrl => _configuration.GetSection("Telegram:url").Value;

        #endregion

        #region Numverify
        public string NumverifySiteKey => _configuration.GetSection("NumVerify:SiteKey").Value;
        #endregion
    }
}
