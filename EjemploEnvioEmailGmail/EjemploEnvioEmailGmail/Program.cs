using System;
using System.Net;
using System.Net.Mail;

namespace EjemploEnvioEmailGmail
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
            EnviarCorreo();
            Console.ReadLine();
        }

        public static void EnviarCorreo()
        {

            using var mail = new MailMessage()
            {
                From = new MailAddress("sgc@indumot.com.ec"),
                Subject = "Prueba de envio de emails desde Gmail",
                Body = "Body",
                IsBodyHtml = true
            };
            mail.To.Add("angel.santana@inpsercom.com");

            const string fromPassword = "Honda.2020";
            const string subject = "Prueba de envio de emails desde Gmail";
            const string body = "Body";

            using var smtp = new SmtpClient
            {
                Host = "smtp.gmail.com",
                Port = 587,
                EnableSsl = true,
                DeliveryMethod = SmtpDeliveryMethod.Network,
                UseDefaultCredentials = false,
                Credentials = new NetworkCredential("sgc@indumot.com.ec", fromPassword)
            };
            smtp.Send(mail);
        }
    }
}
