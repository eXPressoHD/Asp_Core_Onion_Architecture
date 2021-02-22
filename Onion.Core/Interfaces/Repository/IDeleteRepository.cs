using Onion.Core.Domain.Dto;
using System;
using System.Collections.Generic;
using System.Text;

namespace Onion.Core.Interfaces.Repository
{
    public interface IDeleteRepository<T> where T : BaseDto
    {
        void Remove(T element);
        void RemoveById(int id);
    }
}
