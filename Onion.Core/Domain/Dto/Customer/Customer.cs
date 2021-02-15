using System;
using System.Collections.Generic;
using System.Text;

namespace Onion.Core.Domain.Dto.Customer
{
    public class Customer : BaseDto
    {
        public int CustomerId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Street { get; set; }
        public string PostalCode { get; set; }
        public string City { get; set; }
        public string Phone { get; set; }
        public string Email { get; set; }
        public string AdditionalInfo { get; set; }
        public string DateRegisteredTimestamp { get; set; }

        public Customer() : base()
        {
        }

        public override string ToString()
        {
            return $"{LastName}, {FirstName}";
        }

    }
}
