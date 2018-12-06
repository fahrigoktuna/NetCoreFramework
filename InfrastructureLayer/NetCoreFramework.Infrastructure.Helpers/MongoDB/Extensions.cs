using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Text;
using MongoDB.Driver;

namespace NetCoreFramework.Infrastructure.Helpers.MongoDB
{
    public static class Extensions
    {
        public static void AddMongoDbContext(this IServiceCollection services, IConfiguration configuration)
        {
            var options = new MongoDbOptions();
            var section = configuration.GetSection("mongodb");
            section.Bind(options);

            IMongoDatabase _database = null;
            var client = new MongoClient(options.ConnectionString);
            if (client != null)
                _database = client.GetDatabase(options.Database);
            services.AddSingleton<IMongoDatabase>(_ => _database);
        }
    }
}
