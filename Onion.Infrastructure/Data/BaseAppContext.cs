using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Onion.Core.Domain.Dto;
using Onion.Core.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;

namespace Onion.Infrastructure.Data
{
    public class BaseAppContext : DbContext, IDbContext
    {
        private readonly string _connectionString;
        public BaseAppContext()
        {
        }

        public BaseAppContext(string connectionString) 
        {
            _connectionString = connectionString;
        }        

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlite(_connectionString);
        }

        public IQueryable<T> GetAsQueryable<T>() where T : BaseDto
        {
            return this.Set<T>();
        }

        public void Add<T>(T ent) where T : BaseDto
        {
            this.Set<T>().Add(ent);
        }

        public void Update<T>(T ent) where T : BaseDto
        {
            this.Set<T>().Update(ent);
        }

        public void Delete<T>(T ent) where T : BaseDto
        {
            this.Set<T>().Remove(ent);
        }

        void IDbContext.SaveChanges()
        {
            this.SaveChanges();
        }
    }
}
