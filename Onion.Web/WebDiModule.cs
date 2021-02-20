using Autofac;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Onion.Core.Data.Interfaces;
using Onion.Core.Interfaces;
using Onion.Core.Interfaces.Repository;
using Onion.Infrastructure.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Onion.Web
{
    public class WebDiModule : Module
    {
        private readonly IConfiguration _config;

        public WebDiModule(IConfiguration config)
        {
            _config = config;
        }

        protected override void Load(ContainerBuilder builder)
        {
            //Alle dependencies
            builder.Register(conf =>
            {
                return new BaseAppContext(_config["ConnectionStrings:SqlLite"]);
            }).As<IDbContext>().As<BaseAppContext>().InstancePerLifetimeScope();
        }
    }
}
