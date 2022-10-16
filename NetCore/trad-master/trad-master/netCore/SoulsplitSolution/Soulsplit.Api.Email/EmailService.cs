using MimeKit;
using Soulsplit.Api.Contratos;
using Soulsplit.Api.Utilitarios.Dto;
using Soulsplit.Api.Email.Properties;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Soulsplit.Api.Email
{
    public class EmailService : IEmailService
    {
        private readonly IAppConfig _appConfig;
        public EmailService(IAppConfig appConfig)
        {
            _appConfig = appConfig;
        }

        public async Task<DtoRespuesta> UsuarioOlvidoClave(Mensaje message)
        {
            var mailMessage = CreateEmailMessage(message);
            mailMessage.Body = new TextPart(MimeKit.Text.TextFormat.Html) { Text = ParseTemplate(Templates.UsuarioClaveNueva.ToString(), message.Content) };
            await SendAsync(mailMessage);
            return await Respuesta.DevolverRespuesta("Email", "enviado");
        }

        public async Task<DtoRespuesta> ActivarUsuarioNuevo(Mensaje message)
        {
            var mailMessage = CreateEmailMessage(message);
            mailMessage.Body = new TextPart(MimeKit.Text.TextFormat.Html) { Text = ParseTemplate(Templates.ActivarUsuario.ToString(), message.Content) };
            await SendAsync(mailMessage);
            return await Respuesta.DevolverRespuesta("Email", "enviado");
        }

        public async Task<DtoRespuesta> EnvioCuentas(Mensaje message)
        {
            var mailMessage = CreateEmailMessage(message);
            mailMessage.Body = new TextPart(MimeKit.Text.TextFormat.Html) { Text = ParseTemplate(Templates.EnvioCuentas.ToString(), message.Content) };
            await SendAsync(mailMessage);
            return await Respuesta.DevolverRespuesta("Email", "enviado");
        }

        public async Task<DtoRespuesta> CambioClave(Mensaje message)
        {
            var mailMessage = CreateEmailMessage(message);
            mailMessage.Body = new TextPart(MimeKit.Text.TextFormat.Html) { Text = ParseTemplate(Templates.Cambioclave.ToString(), message.Content) };
            await SendAsync(mailMessage);
            return await Respuesta.DevolverRespuesta("Email", "enviado");
        }

        public async Task<DtoRespuesta> MailContacto(Mensaje message)
        {
            var mailMessage = CreateEmailMessage(message);
            mailMessage.Body = new TextPart(MimeKit.Text.TextFormat.Html) { Text = ParseTemplate(Templates.contacto.ToString(), message.Content) };
            await SendAsync(mailMessage);
            return await Respuesta.DevolverRespuesta("Email", "enviado");
        }

        #region Métodos privados


        MimeMessage CreateEmailMessage(Mensaje mail)
        {
            var emailMessage = new MimeMessage();
            emailMessage.From.Add(new MailboxAddress(_appConfig.MailRemitente, _appConfig.MailFrom));
            emailMessage.To.AddRange(mail.To);
            emailMessage.Subject = mail.Subject;
            return emailMessage;
        }


        async Task SendAsync(MimeMessage mailMessage)
        {
            using (var client = new MailKit.Net.Smtp.SmtpClient())
            {
                try
                {
                    await client.ConnectAsync(_appConfig.MailServer, _appConfig.MailPort, MailKit.Security.SecureSocketOptions.StartTls);
                    client.AuthenticationMechanisms.Remove("XOAUTH2");
                    await client.AuthenticateAsync(_appConfig.MailUser, _appConfig.MailPassword);

                    await client.SendAsync(mailMessage);
                }
                catch (Exception ex)
                {
                    //log an error message or throw an exception or both.
                    throw ex;
                }
                finally
                {
                    await client.DisconnectAsync(true);
                    client.Dispose();
                }
            }

        }

        string ParseTemplate(string aTemplatePath, Dictionary<string, string> parameters)
        {
            try
            {
                foreach (KeyValuePair<string, string> entry in parameters)
                {
                    aTemplatePath = aTemplatePath.Replace("{" + entry.Key + "}", entry.Value);
                }
                return aTemplatePath;
            }
            catch (Exception e)
            {
                throw new Exception("Hubo un error al intentar combinar los parámetros con el template, para el envio del Email");
            }
        }
        #endregion
    }
}
