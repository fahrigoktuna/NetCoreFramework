using MongoDB.Driver;
using NetCoreFramework.Infrastructure.Data.Repository;
using System;
using System.Collections.Generic;
using System.Text;

namespace NetCoreFramework.Infrastructure.Data.UnitOfWork
{
    public class MongoUnitOfWork : IUnitOfWork
    {
        readonly IMongoDatabase _database;
        public MongoUnitOfWork(IMongoDatabase database)
        {
            _database = database;
        }
        public IRepository<T> GetRepository<T>() where T : class
        {
            return new MongoRepository<T>(_database);
        }

        public int Commit()
        {
            throw new NotImplementedException();
        }

        public void Dispose()
        {
            throw new NotImplementedException();
        }

    }
}
