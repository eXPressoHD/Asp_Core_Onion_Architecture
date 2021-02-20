using System;
using System.Collections.Generic;
using System.Text;

namespace Onion.Core.Domain.Dto.User
{
    public class User : BaseDto
    {
        public int UserId { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }

        public User():base()
        {

        }
    }
}
