using System;
using System.Collections.Generic;
using System.Text;

namespace Onion.Infrastructure.Data.ViewModels.Authtentication.UserRelated
{
    public class PasswordResetModel
    {
        public int UserId { get; set; }
        public string Password { get; set; }
        public string PasswordRepeat { get; set; }
    }
}
