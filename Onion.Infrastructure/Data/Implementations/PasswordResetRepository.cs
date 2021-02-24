using Onion.Core.Domain.Dto;
using Onion.Core.Domain.Dto.PasswortReset;
using System;
using System.Collections.Generic;
using System.Text;

namespace Onion.Infrastructure.Data.Implementations
{
    public class PasswordResetRepository : Repository<PasswordReset>, IPasswordResetRepository
    {
        public PasswordResetRepository(BaseAppContext context)
            : base(context)
        {
        }
    }
}
