using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Diagnostics;
using Microsoft.Extensions.Logging;

namespace SQLServerCrudSample
{
    public class BlogContext : DbContext
    {
        public DbSet<Blog> Blogs { get; set; }
        public DbSet<Post> Posts { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder
                .LogTo(Console.WriteLine, LogLevel.Information, DbContextLoggerOptions.LocalTime)
                .UseSqlServer(
                @"Server=(localdb)\mssqllocaldb;Database=Blog;Trusted_Connection=True");
        }
    }

    // Blog : Post = 1 : N
    public class Blog
    {
        public int BlogId { get; set; }
        public string? Url { get; set; }
        public int Rating { get; set; }

        //　ナビゲーションプロパティ（Entity間のリレーションを表す）
        public List<Post> Posts { get; set; } = [];
    }

    public class Post
    {
        public int PostId { get; set; }
        public string? Title { get; set; }
        public string? Content { get; set; }
        
        // 外部キー
        public int BlogId { get; set; }
        // ナビゲーションプロパティ
        public Blog Blog { get; set; } = new();
    }
}
