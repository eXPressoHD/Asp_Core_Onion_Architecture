using System;
using System.Collections.Generic;
using System.Net.Mail;
using System.Text;

namespace Onion.Application.EmailService
{
    public static class EmailServiceConstants
    {
        public const string MAIL_SERVER_ADDRESS = "smtp.gmail.com"; //Default google smtp
        public const int MAIL_SERVER_PORT = 587; //Default port
        public const bool ENABLE_SSL = true;        

        public const string MAIL_SERVER_USER = "user"; //Emailsender goes here!
        public const string MAIL_SERVER_PASSWORD = "pw"; //Pw goes here!

        public static readonly Encoding MAIL_ENCODING_FORMAT = Encoding.UTF8;
        public static readonly MailPriority MAIL_PRIORITY = MailPriority.Normal;
    }
}
