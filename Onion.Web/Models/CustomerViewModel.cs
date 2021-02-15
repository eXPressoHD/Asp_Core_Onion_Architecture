using Onion.Core.Domain.Dto.Customer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Onion.Web.Models
{
    public class CustomerViewModel
    {
        public List<Customer> AllCustomers { get; set; }
    }
}
