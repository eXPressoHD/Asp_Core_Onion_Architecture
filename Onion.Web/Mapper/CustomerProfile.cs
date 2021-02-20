using AutoMapper;
using Onion.Core.Domain.Dto.Customer;
using Onion.Core.Domain.Dto.User;
using Onion.Infrastructure.Data.ViewModels;
using Onion.Web.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Onion.Web.Mapper
{
    public class CustomerProfile : Profile
    {
        public CustomerProfile()
        {
            CreateMap<Customer, CustomerViewModel>();
            CreateMap<User, LoginViewModel>();
        }
    }
}
