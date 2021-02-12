using Onion.Core.Data.Interfaces;
using Onion.Core.Domain.Dto.User;
using Onion.Infrastructure.Data;
using Onion.Infrastructure.Data.Implementations;
using System;
using System.Collections.Generic;
using System.Text;

namespace Onion.Core.Interfaces.Repository
{
    public class UserRepository : Repository<User>, IUserRepository
    {
        public UserRepository(BaseAppContext context)
            : base(context)
        {
        }
    }
}
