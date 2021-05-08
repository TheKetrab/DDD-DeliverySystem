using System;
using System.Collections.Generic;
using System.Text;

namespace Delivery.Generic.Interfaces
{
    public interface IRepository<T>
    {
        void Insert(T item);
        void Delete(int id);
        T Find(int id);
        IEnumerable<T> FindAll();
    }
}
