using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Diagnostics;
using Microsoft.Extensions.Logging;
using System.Diagnostics;

namespace SQLServerCurdSample
{
    internal class TodoContext : DbContext
    {
        public DbSet<Todo> Todos { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder
                .LogTo(Console.WriteLine,  LogLevel.Information, DbContextLoggerOptions.LocalTime)
                .UseSqlServer(@"Server=(localdb)\mssqllocaldb;Database=Todo;Trusted_Connection=True");
        }

        //protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        //{
        //    optionsBuilder
        //        .LogTo(
        //            Console.WriteLine,
        //            //message => Debug.WriteLine(message),
        //            LogLevel.Information,
        //            DbContextLoggerOptions.LocalTime)
        //        //.EnableSensitiveDataLogging()
        //        .UseSqlServer(@"Server=(localdb)\mssqllocaldb;Database=Todo;Trusted_Connection=True");
        //}
    }
}
