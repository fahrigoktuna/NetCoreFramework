using NetCoreFramework.Infrastructure.Data.DBContext;
using NetCoreFramework.Infrastructure.Data.Repository;
using System;
using System.Collections.Generic;
using System.Text;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory;

namespace NetCoreFramework.Infrastructure.Data.UnitOfWork
{
    public class EFUnitOfWork : IUnitOfWork, IDisposable
    {
        private readonly FrameworkContext _dbContext;

        public EFUnitOfWork(FrameworkContext dbContext)
        {
           // Database.SetInitializer<FrameworkContext>(null);

            _dbContext = dbContext;
        }

        #region IUnitOfWork Members
        public IRepository<T> GetRepository<T>() where T : class
        {
            return new EFRepository<T>(_dbContext);
        }

        public int Commit()
        {
            return _dbContext.SaveChanges();
        }

        public void Dispose()
        {
            _dbContext.Dispose();
        }
        #endregion

    }
}
