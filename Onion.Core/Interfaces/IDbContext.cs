using Onion.Core.Domain.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Onion.Core.Interfaces
{
    public interface IDbContext
    {
        IQueryable<T> GetAsQueryable<T>() where T : BaseDto;
        void Add<T>(T ent) where T : BaseDto;
        void Update<T>(T ent) where T : BaseDto;
        void Delete<T>(T ent) where T : BaseDto;

        void SaveChanges();
    }
}
