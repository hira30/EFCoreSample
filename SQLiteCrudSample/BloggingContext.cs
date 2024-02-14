using Microsoft.EntityFrameworkCore;

namespace SQLiteCrudSample
{
    internal class BloggingContext : DbContext
    {
        public DbSet<Blog> Blogs { get; set; }
        public DbSet<Post> Posts { get; set; }
        public string DbPath { get; }

        public BloggingContext()
        {
            // 特殊フォルダ（デスクトップ）の絶対パスを取得
            var path = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);

            // DBファイルの保存先とDBファイル名をDbPathに格納
            DbPath = $"{path}{Path.DirectorySeparatorChar}blogging.db";
        }

        // デスクトップ上にSQLiteのDBファイルが作成される
        protected override void OnConfiguring(DbContextOptionsBuilder options)
            => options.UseSqlite($"Data Source={DbPath}");
    }
}
