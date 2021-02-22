using System;
using System.Collections.Generic;
using System.Text;

namespace Onion.Core.Domain.Dto
{
    public class PasswordReset : BaseDto
    {
        public long ResetId { get; set; }
        public string Email { get; set; }
        public string TokenHash { get; set; }
        public string ExpirationDate { get; set; }
        public int TokenUsed { get; set; }

        public PasswordReset()
        {
        }
    }
}
