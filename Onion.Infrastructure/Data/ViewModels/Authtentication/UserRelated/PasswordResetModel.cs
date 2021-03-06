﻿using System;
using System.Collections.Generic;
using System.Text;

namespace Onion.Infrastructure.Data.ViewModels.Authtentication.UserRelated
{
    public class PasswordResetModel
    {
        public long ResetId { get; set; }
        public string Email { get; set; }
        public string TokenHash { get; set; }
        public string ExpirationDate { get; set; }
        public int TokenUsed { get; set; }
    }
}
