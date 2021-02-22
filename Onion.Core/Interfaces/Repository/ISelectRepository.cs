using Onion.Core.Domain.Dto;
using System;
using System.Collections.Generic;
using System.Text;

namespace Onion.Core.Interfaces.Repository
{
    public interface ISelectRepository<T> where T : BaseDto
    {
        T GetById(int id);
        IEnumerable<T> Get();
    }
}
