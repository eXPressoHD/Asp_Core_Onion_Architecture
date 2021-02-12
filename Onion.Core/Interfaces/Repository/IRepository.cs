using System;
using System.Collections.Generic;
using System.Text;

namespace Onion.Core.Data.Interfaces
{
    /// <summary>
    /// Basic functionality wo wir DbContext im Hintergrund benutzen
    /// </summary>
    public interface IRepository<T> where T : class
    {
        void Add(T entity);
        void Remove(Guid id);

        T GetById(Guid id);
        IEnumerable<T> Get();

        void Save();
        void Update(T entity);
    }
}
