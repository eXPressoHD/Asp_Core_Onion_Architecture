using Onion.Core.Data.Interfaces;
using Onion.Core.Domain.Dto.Customer;
using System;
using System.Collections.Generic;
using System.Text;

namespace Onion.Infrastructure.Data.Implementations
{
    public class CustomerRepository : Repository<Customer>, ICustomerRepository
    {
        public CustomerRepository(BaseAppContext context)
            : base(context)
        {
        }
    }
}
