﻿using Onion.Core.Domain.Dto;
using System;
using System.Collections.Generic;
using System.Text;

namespace Onion.Core.Interfaces.Repository
{
    public interface ISaveRepository<T> where T : BaseDto
    {
        void Save();
    }
}
