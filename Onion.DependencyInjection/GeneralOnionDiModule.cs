using Autofac;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Onion.Application.AuthenticationServices;
using Onion.Application.AuthenticationServices.Interfaces;
using Onion.Core.Data.Interfaces;
using Onion.Core.Domain.Dto.Customer;
using Onion.Core.Interfaces;
using Onion.Core.Interfaces.Repository;
using Onion.Infrastructure.Data;
using Onion.Infrastructure.Data.Implementations;
using System;

namespace Onion.DependencyInjection
{
    public class GeneralOnionDiModule : Autofac.Module
    {
        private readonly IConfiguration _config;

        public GeneralOnionDiModule(IConfiguration config)
        {
            _config = config;
        }

        protected override void Load(ContainerBuilder builder)
        {
            //Alle dependencies
            builder.RegisterGeneric(typeof(Repository<>)).As(typeof(IRepository<>));

            //Repos
            builder.RegisterType<UserRepository>().As<IUserRepository>();
            builder.RegisterType<CustomerRepository>().As<ICustomerRepository>();
            builder.RegisterType<UserManager>().As<IUserManager>();
        }
    }
}
