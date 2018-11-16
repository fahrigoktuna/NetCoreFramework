using NetCoreFramework.Infrastructure.Data.Repository;
using System;
using System.Collections.Generic;
using System.Text;

namespace NetCoreFramework.Infrastructure.Data.UnitOfWork
{
    public interface IUnitOfWork : IDisposable
    {
        IRepository<T> GetRepository<T>() where T : class;
        int Commit();
    }
}
