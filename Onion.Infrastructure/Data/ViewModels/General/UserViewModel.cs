using System;
using System.Collections.Generic;
using System.Text;

namespace Onion.Infrastructure.Data.ViewModels.Authtentication.General
{
    public class UserViewModel
    {
        public int UserId { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
    }
}
