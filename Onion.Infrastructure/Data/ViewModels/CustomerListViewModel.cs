using Onion.Core.Domain.Dto.Customer;
using Onion.Infrastructure.Data.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Onion.Web.Models
{
    public class CustomerListViewModel : BaseEntity
    {
        public List<CustomerViewModel> AllCustomers { get; set; }
    }
}
