using BroadwayReview.Application.Emails;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mail;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace BroadwayReview.Implementations.Emails
{
    public class SMTPEmailSender : IEmailSender
    {
        private readonly string _email;
        private readonly string _password;
        public SMTPEmailSender(string email, string password)
        {
            _email = email;
            _password = password;
        }
        public void SendEmail(Email email)
        {
            var smtp = new SmtpClient
            {
                Host = "smtp.gmail.com",
                Port = 587,
                EnableSsl = true,
                DeliveryMethod = SmtpDeliveryMethod.Network,
                Credentials = new NetworkCredential(_email, _password)
            };
            var message = new MailMessage(_email, email.To, email.Title, email.Body);
            message.IsBodyHtml = true;
            smtp.Send(message);
        }
    }
}
