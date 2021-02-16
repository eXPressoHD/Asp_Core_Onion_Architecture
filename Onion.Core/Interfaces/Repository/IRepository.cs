using Onion.Core.Domain.Dto;
using System;
using System.Collections.Generic;
using System.Text;

namespace Onion.Core.Data.Interfaces
{
    /// <summary>
    /// Basic functionality wo wir DbContext im Hintergrund benutzen
    /// </summary>
    public interface IRepository<T> where T : BaseDto
    {
        void Add(T entity);
        void Remove(int id);

        T GetById(int id);
        IEnumerable<T> Get();

        void Save();
        void Update(T entity);
    }
}
