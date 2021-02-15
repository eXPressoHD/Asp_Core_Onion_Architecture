using Onion.Core.Data.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Onion.Infrastructure.Data.Implementations
{
    public class Repository<T> : IRepository<T> where T : class
    {
        //DbContext injection
        private readonly BaseAppContext _context;

        //Constructor zum injection in Klasse des Kontextes
        public Repository(BaseAppContext context)
        {
            _context = context;
        }

        public void Add(T entity)
        {
            _context.Set<T>().Add(entity);
        }

        public IEnumerable<T> Get()
        {
            return _context.Set<T>().ToList();
        }

        public T GetById(int id)
        {
            return _context.Set<T>().Find(id);
        }

        public void Update(T entity)
        {           
            _context.Set<T>().Update(entity);
        }

        public void Remove(int id)
        {
            var type = _context.Set<T>().Find(id);
            _context.Remove(type);
        }

        public void Save()
        {
            _context.SaveChanges();
        }        
    }
}
