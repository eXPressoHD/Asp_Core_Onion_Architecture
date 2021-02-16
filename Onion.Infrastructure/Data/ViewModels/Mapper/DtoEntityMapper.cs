using Onion.Core.Domain.Dto.Customer;
using Onion.Web.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Onion.Infrastructure.Data.ViewModels.Mapper
{
    public static class DtoEntityMapper
    {
        public static CustomerViewModel FromDtoToEntity(this Customer dtos)
        {
            return new CustomerViewModel()
            {
                CustomerId = dtos.CustomerId,
                FirstName = dtos.FirstName,
                LastName = dtos.LastName,
                Street = dtos.Street,
                PostalCode = dtos.PostalCode,
                City = dtos.City,
                Phone = dtos.Phone,
                Email = dtos.Email,
                AdditionalInfo = dtos.AdditionalInfo,
                DateRegisteredTimestamp = dtos.DateRegisteredTimestamp
            };
        }

        public static Customer FromEntityToDto(this CustomerViewModel vm)
        {
            return new Customer()
            {
                CustomerId = vm.CustomerId,
                FirstName = vm.FirstName,
                LastName = vm.LastName,
                Street = vm.Street,
                PostalCode = vm.PostalCode,
                City = vm.City,
                Phone = vm.Phone,
                Email = vm.Email,
                AdditionalInfo = vm.AdditionalInfo,
                DateRegisteredTimestamp = vm.DateRegisteredTimestamp
            };
        }
    }
}
