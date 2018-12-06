using Microsoft.Extensions.DependencyInjection;
using NetCoreFramework.Infrastructure.Data.DBContext;
using NetCoreFramework.Infrastructure.Data.UnitOfWork;
using System;
using System.Collections.Generic;
using System.Text;

namespace NetCoreFramework.Infrastructure.Helpers.UoW
{
    public static class Extensions
    {
        public static void AddUoW(this IServiceCollection services)
        {
            #region Mongo UOW
            //services.AddScoped<IUnitOfWork, MongoUnitOfWork>(); 
            #endregion

            #region EF UOW
            services.AddScoped<IUnitOfWork>(_ => new EFUnitOfWork(services.BuildServiceProvider()
                          .GetService<FrameworkContext>())); 
            #endregion
        }
    }
}

