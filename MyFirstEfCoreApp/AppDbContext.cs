// Copyright (c) 2016 Jon P Smith, GitHub: JonPSmith, web: http://www.thereformedprogrammer.net/
// Licensed under MIT licence. See License.txt in the project root for license information.

using Microsoft.EntityFrameworkCore;

namespace MyFirstEfCoreApp
{
    public class AppDbContext : DbContext
    {
        private const string ConnectionString =            //#A
            @"Server=192.168.0.102;Database=auth;Uid=sa;Pwd=user1234;SslMode=None";

        protected override void OnConfiguring(
            DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseMySql(ConnectionString); //#B
        }

        public DbSet<Book> Books { get; set; }
    }
    /********************************************************
    #A The connection string is used by the SQL Server database provider to find the database
    #B Using the SQL Server database provider’s UseSqlServer command sets up the options ready for creating the applications’s DBContext
     ********************************************************/
}