using System;
using System.Collections.Generic;
using System.Text;

namespace Delivery.Generic.Interfaces
{
    public interface IQueryRepository<T>
    {
        int Count { get; }
        T Find(int id);
        IEnumerable<T> FindAll();
    }
}
