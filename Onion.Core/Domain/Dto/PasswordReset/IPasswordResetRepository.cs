using Onion.Core.Data.Interfaces;
using Onion.Core.Interfaces.Repository;
using System;
using System.Collections.Generic;
using System.Text;

namespace Onion.Core.Domain.Dto.PasswortReset
{
    public interface IPasswordResetRepository : IRepository<PasswordReset>
    {
    }
}
