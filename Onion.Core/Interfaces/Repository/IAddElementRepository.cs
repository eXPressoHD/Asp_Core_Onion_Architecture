using Onion.Core.Domain.Dto;
using System;
using System.Collections.Generic;
using System.Text;

namespace Onion.Core.Interfaces.Repository
{
    public interface IAddElementRepository<T> where T : BaseDto
    {
        void AddElement(T element);
        void Save();
    }
}
