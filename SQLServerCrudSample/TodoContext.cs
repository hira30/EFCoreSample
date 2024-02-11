using Microsoft.EntityFrameworkCore;

namespace SQLServerCurdSample
{
    internal class TodoContext : DbContext
    {
        public DbSet<Todo> Todos { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(
                @"Server=(localdb)\mssqllocaldb;Database=Sample;Trusted_Connection=True");
        }
    }
}
