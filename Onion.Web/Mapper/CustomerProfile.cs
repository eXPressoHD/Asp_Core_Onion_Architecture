using AutoMapper;
using Onion.Core.Domain.Dto;
using Onion.Core.Domain.Dto.Customer;
using Onion.Core.Domain.Dto.User;
using Onion.Infrastructure.Data.ViewModels;
using Onion.Infrastructure.Data.ViewModels.Authtentication.General;
using Onion.Infrastructure.Data.ViewModels.Authtentication.UserRelated;

namespace Onion.Web.Mapper
{
    public class CustomerProfile : Profile
    {
        public CustomerProfile()
        {
            //Customers
            CreateMap<Customer, CustomerViewModel>();
            CreateMap<CustomerViewModel, Customer>();

            //Users/Login
            CreateMap<User, LoginViewModel>();

            //User/ViewModel
            CreateMap<UserViewModel, User>();
            CreateMap<User, UserViewModel>();

            //PasswordReset
            CreateMap<PasswordReset, PasswordResetModel>();
            CreateMap<PasswordResetModel, PasswordReset>();

        }
    }
}
