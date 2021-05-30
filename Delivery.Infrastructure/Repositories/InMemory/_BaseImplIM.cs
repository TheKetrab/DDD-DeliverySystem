using Delivery.Generic.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Delivery.Infrastructure.Repositories.InMemory
{
    public abstract class BaseImplIM<T> : IRepository<T> where T : Entity
    {
        protected List<T> _entities = new List<T>();

        public int Count => _entities.Count;

        public void Delete(T entity)
        {
            _entities.RemoveAll(e => e.Id == entity.Id);
        }

        public void Delete(IList<T> entities)
        {
            _entities
                .RemoveAll(e => entities.AsQueryable()
                    .Any(x => x.Id == e.Id)
                );                
        }

        public void DeleteAll()
        {
            _entities.Clear();
        }

        public T Find(int entityId)
        {
            return _entities.Find(e => e.Id == entityId);
        }

        public IQueryable<T> FindAll()
        {
            return _entities.AsQueryable();
        }

        public void Insert(T entity)
        {
            _entities.Add(entity);
        }

        public void Update(T entity)
        {
            int i = _entities.FindIndex(e => e.Id == entity.Id);

            if (i < 0)
            {
                throw new Exception(string.Format(
                    "Item of given Id({0}) not found.", entity.Id));
            }

            _entities[i] = entity;
        }

        public void Update(IList<T> entities)
        {
            foreach (var e in entities)
                Update(e);
        }
    }
}
