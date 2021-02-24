using Onion.Core.Domain.Dto.User;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;

namespace Onion.Application.AuthenticationServices.Interfaces
{
    public interface IMailService
    {
        void SendMail(string subject, string to, string body);
        void SendCompleteCallback(object sender, AsyncCompletedEventArgs e);
    }
}
