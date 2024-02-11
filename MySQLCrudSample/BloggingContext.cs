using Microsoft.EntityFrameworkCore;

namespace MySQLCrudSample
{
    internal class BloggingContext : DbContext
    {
        public DbSet<Blog> Blogs { get; set; }
        public DbSet<Post> Posts { get; set; }

        // 接続文字列
        readonly string connectionString = "server=localhost;database=my_db;user=root;password=1234;";

        // MySQLのバージョン
        readonly MySqlServerVersion serverVersion = new(new Version(8, 3));

        // DBコンテキストの設定
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
            => optionsBuilder.UseMySql(connectionString, serverVersion);
    }
}
