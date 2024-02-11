using Microsoft.EntityFrameworkCore;

namespace MySQLCrudSample
{
    internal class TodoContext : DbContext
    {
        public DbSet<Todo> Todos { get; set; }

        // 接続文字列
        readonly string connectionString = "server=localhost;database=sample_db;user=root;password=<パスワード>;";

        // MySQLのバージョン
        readonly MySqlServerVersion serverVersion = new(new Version(8, 0, 36));

        // DBコンテキストの設定
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
            => optionsBuilder.UseMySql(connectionString, serverVersion);
    }
}
