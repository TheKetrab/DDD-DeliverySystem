using Dapper;
using Delivery.Generic.Interfaces;
using System;
using System.Collections.Generic;
using Delivery.Generic.Utils;
using System.Linq;
using System.Text;

namespace Delivery.Infrastructure.Repositories.MsSql
{
    public abstract class BaseImplMsSql<T> : IRepository<T> where T : Entity
    {
        // ABSTRACT
        public abstract string Table { get; }
        public abstract void Insert(T entity);

        public abstract void Update(T entity);

        public abstract void Update(IList<T> entities);


        // IMPLEMENTATION
        public int Count
        {
            get
            {
                int cnt = MsSqlConnector.Instance.Connection.ExecuteScalar<int>(
                    "SELECT COUNT(*) FROM " + Table);

                return cnt;
            }
        }

        public void Delete(T entity)
        {
            MsSqlConnector.Instance.Connection.Execute(
                "DELETE * FROM " + Table + " WHERE Id = @id", new { id = entity.Id });
        }

        public void Delete(IList<T> entities)
        {  
            string ids = string.Join(",",entities.Cast(x => x.Id.ToString()));

            MsSqlConnector.Instance.Connection.Execute(
                "DELETE * FROM " + Table + " WHERE Id IN (" + ids + ")");
        }

        public void DeleteAll()
        {
            MsSqlConnector.Instance.Connection.Execute(
                "DELETE * FROM " + Table);
        }

        public virtual T Find(int entityId)
        {
            T e = MsSqlConnector.Instance.Connection.QuerySingle<T>(
                "SELECT * FROM " + Table + " WHERE Id = @id", new { id = entityId });

            return e;
        }
        public virtual IQueryable<T> FindAll()
        {
            var res = MsSqlConnector.Instance.Connection
                .Query<T>("SELECT * FROM " + Table).AsQueryable();

            return res;
        }

    }
}
