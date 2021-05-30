
namespace Delivery.Generic.Interfaces
{
    public interface IRepository<T> 
        : ICommandRepository<T>, IQueryRepository<T>
        where T : Entity
    {    }
}
