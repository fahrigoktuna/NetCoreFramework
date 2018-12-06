using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;

namespace NetCoreFramework.Infrastructure.Data.Repository
{
    public class MongoRepository<T> : IRepository<T> where T : class
    {
        private readonly IMongoDatabase _database;

        public MongoRepository(IMongoDatabase database)
        {
            _database = database;
        }

        public void Add(T entity)
        {
            _database.GetCollection<T>(entity.GetType().Name).InsertOne(entity);
        }

        public T Get(System.Linq.Expressions.Expression<Func<T, bool>> p)
        {
            return _database.GetCollection<T>(typeof(T).Name).Find<T>(p).FirstOrDefault();
        }

        public IQueryable<T> GetFullList()
        {
            return _database.GetCollection<T>(typeof(T).Name).AsQueryable<T>();
        }

        public IQueryable<T> GetList(Expression<Func<T, bool>> p)
        {
            return _database.GetCollection<T>(typeof(T).Name).Find<T>(p).ToList<T>().AsQueryable<T>();
        }

        public void Update(T entity)
        {
            throw new NotImplementedException();
        }
    }
}
