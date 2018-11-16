using Microsoft.EntityFrameworkCore;
using NetCoreFramework.Infrastructure.Data.DBContext;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;

namespace NetCoreFramework.Infrastructure.Data.Repository
{
    public class EFRepository<T> : IRepository<T> where T : class
    {
        private readonly DbContext _dbContext;
        private readonly DbSet<T> _dbSet;

        public EFRepository(FrameworkContext dbContext)
        {
            _dbContext = dbContext;
            _dbSet = dbContext.Set<T>();
        }

        public IQueryable<T> GetFullList()
        {
            return _dbSet;
        }

        public IQueryable<T> GetList(Expression<Func<T, bool>> p)
        {
            return _dbSet.Where(p);
        }

        public T Get(Expression<Func<T, bool>> p)
        {
            return _dbSet.Where(p).FirstOrDefault<T>();
        }

        public void Add(T entity)
        {
            _dbSet.Add(entity);
        }

        public void Update(T entity)
        {
            _dbSet.Attach(entity);
            _dbContext.Entry(entity).State = EntityState.Modified;
        }



    }
}
