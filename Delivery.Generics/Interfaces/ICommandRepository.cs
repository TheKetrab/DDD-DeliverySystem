using System;
using System.Collections.Generic;
using System.Text;

namespace Delivery.Generic.Interfaces
{
    public interface ICommandRepository<T>
    {
        void Insert(T item);
        void Delete(int id);
        void DeleteAll();
    }
}
