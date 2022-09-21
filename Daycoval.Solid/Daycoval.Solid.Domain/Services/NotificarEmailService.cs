using System;
using System.Net.Mail;

namespace Daycoval.Solid.Domain.Services
{
    public class NotificarEmailService : IEmailMessage
    {
        private const string fromEmail = "tiago.dantas@bancodaycoval.com.br";
        private const string typeClient = "servidor.smtp";
        public string Subject { get; set; }

        public void enviar(string toAddress, string message)
        {
      
            using (var msg = new MailMessage(fromEmail, toAddress))
            using (var smtp = new SmtpClient(typeClient))
            {
                msg.Subject = Subject;
                msg.Body = message;

                smtp.Send(msg);
            }  
        }
    }
}
