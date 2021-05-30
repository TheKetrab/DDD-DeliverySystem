using System.Collections.Generic;

namespace Delivery.Generic.Interfaces
{
    public interface ICommandRepository<T> where T : Entity
    {
        void Insert(T entity);

        void Update(T entity);
        void Update(IList<T> entities);

        void Delete(T entity);
        void Delete(IList<T> entities);
        void DeleteAll();
    }
}
