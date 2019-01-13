using DataLayer.EfCode;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace DataLayer.Migrations
{
    //public class MySqlContext : EfCoreContext
    //{
    //    public MySqlContext() 
    //        : base(CreateOptions())
    //    {
    //    }

    //    private static DbContextOptions<EfCoreContext> CreateOptions()
    //    {
    //        var configuration = new ConfigurationBuilder()
    //       .SetBasePath(Directory.GetCurrentDirectory())
    //       .AddJsonFile("appsettings.json")
    //       .Build();
    //        var builder = new DbContextOptionsBuilder<EfCoreContext>();
    //        var connectionString = configuration.GetConnectionString("MySql");
    //        builder.UseMySql(connectionString, b => b.MigrationsAssembly("DataLayer.Migrations"));
    //        return builder.Options;
    //    }
    //}
}
