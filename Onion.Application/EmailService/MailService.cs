using Onion.Application.AuthenticationServices.Interfaces;
using Onion.Infrastructure.Data;
using System;
using System.Collections.Generic;
using System.Text;

namespace Onion.Application.EmailService
{
    public class MailService : IMailService
    {
        private readonly BaseAppContext _context;

        public MailService(BaseAppContext context)
        {
            _context = context;
        }

        public void SendMail()
        {
        }
    }
}
