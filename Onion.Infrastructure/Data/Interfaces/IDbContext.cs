using Onion.Core.Domain.Dto;
using Onion.Infrastructure.Data.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Onion.Core.Interfaces
{
    public interface IDbContext
    {
        IQueryable<T> GetAsNoTrackingQueryable<T>() where T : BaseEntity;
        void Add<T>(T ent) where T : BaseEntity;
        void Update<T>(T ent) where T : BaseEntity;
        void Delete<T>(T ent) where T : BaseEntity;

        void SaveChanges();
    }
}
