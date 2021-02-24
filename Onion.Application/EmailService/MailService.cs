using Onion.Application.AuthenticationServices.Interfaces;
using Onion.Infrastructure.Data;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Net;
using System.Net.Mail;
using System.Text;

namespace Onion.Application.EmailService
{
    public class MailService : IMailService
    {
        public MailService()
        {
        }

        private SmtpClient PrepareNewMail()
        {
            SmtpClient client = new SmtpClient(EmailServiceConstants.MAIL_SERVER_ADDRESS, EmailServiceConstants.MAIL_SERVER_PORT);
            var login = new NetworkCredential(EmailServiceConstants.MAIL_SERVER_USER, EmailServiceConstants.MAIL_SERVER_PASSWORD);

            client.EnableSsl = EmailServiceConstants.ENABLE_SSL;
            client.DeliveryMethod = SmtpDeliveryMethod.Network;
            client.Timeout = 2000;
            client.Credentials = login;

            return client;
        }

        public void SendMail(string subject, string to, string body)
        {
            var client = PrepareNewMail();

            MailMessage msg = new MailMessage()
            {
                From = new MailAddress(EmailServiceConstants.MAIL_SERVER_USER, "Test", EmailServiceConstants.MAIL_ENCODING_FORMAT),
                Subject = subject,
                Body = body,
                BodyEncoding = EmailServiceConstants.MAIL_ENCODING_FORMAT,
                IsBodyHtml = true,
                Priority = EmailServiceConstants.MAIL_PRIORITY,
                DeliveryNotificationOptions = DeliveryNotificationOptions.OnFailure
            };

            msg.To.Add(to);
            client.SendAsync(msg, null);
        }

        void IMailService.SendCompleteCallback(object sender, AsyncCompletedEventArgs e)
        {
            if (e.Cancelled)
            {

            }
            else if (e.Error != null)
            {

            }
            else
            {

            }
        }
    }
}
