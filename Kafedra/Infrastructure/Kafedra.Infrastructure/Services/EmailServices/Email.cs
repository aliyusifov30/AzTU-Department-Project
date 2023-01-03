using MailKit.Security;
using MimeKit.Text;
using MimeKit;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Net.Security;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace Kafedra.Infrastructure.Services.EmailServices
{
    public static class Email
    {
        public static void SendMail(string to, string subject, string html,string from,string password)
        {
            // create message 
            var email = new MimeMessage();
            email.From.Add(MailboxAddress.Parse("postmaster@aliyusifov.com"));
            email.To.Add(MailboxAddress.Parse(to));
            email.Subject = subject;
            email.Body = new TextPart(TextFormat.Html) { Text = html };

            ServicePointManager.ServerCertificateValidationCallback = delegate (object s, X509Certificate certificate, X509Chain chain, SslPolicyErrors sslPolicyErrors)
            {
                return true;
            };

            // send email
            using var smtp = new MailKit.Net.Smtp.SmtpClient();
            smtp.Connect("mail.aliyusifov.com", 8889, SecureSocketOptions.None);
            smtp.Authenticate(from, password);
            smtp.Send(email);
            smtp.Disconnect(true);
        }
    }
}
