using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using System;
using System.Collections.Generic;
using System.Text;

namespace NetCoreFramework.Infrastructure.Data.DBContext
{
    public class DesignTimeDbContextFactory : IDesignTimeDbContextFactory<FrameworkContext>
    {
        public FrameworkContext CreateDbContext(string[] args)
        {
            
            var builder = new DbContextOptionsBuilder<FrameworkContext>();
            var connectionString = "Server=localhost;Database=NetCoreFramework;Trusted_Connection=True;MultipleActiveResultSets=true";
            builder.UseSqlServer(connectionString);
            
            return new FrameworkContext(builder.Options);
        }
    }
}
