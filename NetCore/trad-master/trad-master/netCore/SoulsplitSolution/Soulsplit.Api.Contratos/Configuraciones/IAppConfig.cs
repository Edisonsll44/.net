namespace Soulsplit.Api.Contratos
{
    public interface IAppConfig
    {
        int MaximoIntentos { get; }
        int SegundosEspera { get; }
        string ServicioUrl { get; }
        string Secreto { get; }
        double TiempoCaducidad { get; }
        double CaducidadCodigo { get; }

        #region Pusher
        string Pusher_app_id { get; }
        string Pusher_key { get; }
        string Pusher_secret { get; }
        string Pusher_cluster { get; }
        #endregion
        string MailRemitente { get; }
        string MailFrom { get; }
        string MailServer { get; }
        string MailUser { get; }
        string MailPassword { get; }
        int MailPort { get; }
        string BaseUrl { get; }

        #region Aws s3
        string BucketPago { get; }
        string AccessKeyAWS { get; }
        string SecretKeyAWS { get; }
        public string RegionAWSS3 { get; }
        public string AwsBaseUrl { get; }
        #endregion

        #region ReCaptcha
        string ReCaptchaSiteKey { get; }
        #endregion

        #region Sms
        string SmsCuentaId { get; }
        string SmsToken { get; }
        string SmsServicioId { get; }
        #endregion

        #region Sms
        string TelegramChatError { get; }
        string TelegramToken { get; }
        string TelegramUrl { get; }
        #endregion

        #region NumVerify
        string NumverifySiteKey { get; }
        #endregion
    }
}
