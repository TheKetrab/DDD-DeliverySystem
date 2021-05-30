using System.Linq;

namespace Delivery.Generic.Interfaces
{
    public interface IQueryRepository<T> where T : Entity
    {
        int Count { get; }
        T Find(int entityId);
        IQueryable<T> FindAll();
    }
}
