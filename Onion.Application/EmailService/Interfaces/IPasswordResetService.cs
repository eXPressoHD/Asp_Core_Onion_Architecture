using Onion.Infrastructure.Data.ViewModels.Authtentication.General;
using System;
using System.Collections.Generic;
using System.Text;

namespace Onion.Application.EmailService.Interfaces
{
    public interface IPasswordResetService
    {
        bool SendPasswortRecoveryForUser(UserViewModel userVm);
    }
}
