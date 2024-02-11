using Microsoft.EntityFrameworkCore;

namespace PostgreSQLCurdSample
{
    internal class TodoContext : DbContext
    {
        public DbSet<Todo> Todos { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
            => optionsBuilder.UseNpgsql("Host=localhost;Database=sample_db;Username=postgres;Password=1234;");
    }
}