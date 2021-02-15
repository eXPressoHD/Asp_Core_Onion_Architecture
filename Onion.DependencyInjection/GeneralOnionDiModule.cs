using Autofac;
using Microsoft.Extensions.Configuration;
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
        }
    }
}
