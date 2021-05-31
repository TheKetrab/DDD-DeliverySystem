using Delivery.Domain.Model.Addresses;
using Delivery.Generic.Interfaces;
using NHibernate;
using NHibernate.Cfg;
using NHibernate.Hql;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Delivery.Infrastructure.Repositories.NHibernate
{
    public abstract class BaseImplNH<T> : IRepository<T> where T : Entity
    {
        protected ISession OpenSession()
        {
            return NHConnector.Instance.OpenSession();
        }

        // ABSTRACT
        public abstract string Table { get; }


        // IMPLEMENTATION
        public virtual T Find(int entityId)
        {
            using (var session = OpenSession())
            {
                return session.Get<T>(entityId);
            }
        }
        public virtual IQueryable<T> FindAll()
        {
            using (var session = OpenSession())
            {
                var query = session.CreateQuery("from " + Table);
                var result = query.List<T>();
                return result.AsQueryable();
            }
        }

        public virtual int Count
        {
            get
            {
                using (var session = OpenSession())
                    return session.QueryOver<T>().RowCount();
            }
        }

        public virtual void Delete(T entity)
        {
            using (var session = OpenSession())
                session.Delete(entity);
        }

        public virtual void Delete(IList<T> entities)
        {
            using (var session = OpenSession())
            {
                foreach (var e in entities)
                    session.Delete(e);
            }
        }

        public virtual void DeleteAll()
        {
            using (var session = OpenSession())
            {
                session.Delete("from " + Table + " e");
                session.Flush();
            }
        }

        public virtual void Insert(T entity)
        {
            using (var session = OpenSession())
            {
                session.Save(entity);
                session.Flush();
            }
        }

        public virtual void Update(T entity)
        {
            using (var session = OpenSession())
            {
                session.SaveOrUpdate(entity);
                session.Flush();
            }
        }

        public virtual void Update(IList<T> entities)
        {
            using (var session = OpenSession())
            {
                foreach (var entity in entities)
                    session.SaveOrUpdate(entity);

                session.Flush();
            }
        }


    }
}
