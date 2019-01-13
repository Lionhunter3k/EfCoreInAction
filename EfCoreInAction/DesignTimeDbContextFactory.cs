using DataLayer.EfCode;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace EfCoreInAction
{
    public class DesignTimeDbContextFactory : IDesignTimeDbContextFactory<EfCoreContext>
    {
        public EfCoreContext CreateDbContext(string[] args)
        {
            IConfigurationRoot configuration = new ConfigurationBuilder()
             .SetBasePath(Directory.GetCurrentDirectory())
             .AddJsonFile("appsettings.json")
             .Build();
            var builder = new DbContextOptionsBuilder<EfCoreContext>();
            var connectionString = configuration.GetConnectionString("MySql");
            builder.UseMySql(connectionString, b => b.MigrationsAssembly("DataLayer.Migrations"));
            return new EfCoreContext(builder.Options);
        }
    }
}
