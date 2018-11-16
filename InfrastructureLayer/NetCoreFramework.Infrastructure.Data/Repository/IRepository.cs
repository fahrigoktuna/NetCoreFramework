using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;

namespace NetCoreFramework.Infrastructure.Data.Repository
{
    public interface IRepository<T> where T : class
    {
        IQueryable<T> GetFullList();
        IQueryable<T> GetList(Expression<Func<T, bool>> p);
        T Get(Expression<Func<T, bool>> p);

        void Add(T entity);
        void Update(T entity);
    }
}
