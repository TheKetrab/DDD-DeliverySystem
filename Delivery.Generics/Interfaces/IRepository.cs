﻿using System;
using System.Collections.Generic;
using System.Text;

namespace Delivery.Generic.Interfaces
{
    public interface IRepository<T> : ICommandRepository<T>, IQueryRepository<T>
    {

        
    }
}
