using BroadwayReview.Application.Emails;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BroadwayReview.Implementations.Emails
{
    public class FakeEmailSender : IEmailSender
    {
        public void SendEmail(Email email)
        {
            Console.WriteLine("Email sent to: " + email.To);
            Console.WriteLine("Title: " + email.Title);
        }
    }
}
