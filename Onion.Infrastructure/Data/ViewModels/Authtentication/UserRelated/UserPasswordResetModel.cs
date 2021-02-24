using System;
using System.Collections.Generic;
using System.Text;

namespace Onion.Infrastructure.Data.ViewModels.Authtentication.UserRelated
{
    public class UserPasswordResetModel
    {
        public string TokenHash { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public string PasswordRepeat { get; set; }
    }
}
