using SQLiteCrudSample;

namespace SQLiteApp
{
    internal class Program
    {
        private static void Main()
        {
            using (var db = new BloggingContext())
            {
                // 登録
                db.Add(new Blog { Url = "http://blogs.msdn.com/adonet" });
                db.SaveChanges();

                // 読み取り
                var blog = db.Blogs.OrderBy(b => b.BlogId).First();
                Console.WriteLine($"ブログを新規登録しました！　" + $"ブログID：{blog.BlogId}, ブログURL：{blog.Url}");

                // 更新
                blog.Url = "https://devblogs.microsoft.com/dotnet";
                blog.Posts.Add(new Post { Title = "Hello World", Content = "EF CoreとSQLite" });
                db.SaveChanges();
                Console.WriteLine($"ブログを更新しました！　" + $"ブログID：{blog.BlogId}, ブログURL：{blog.Url}");
                Console.WriteLine($"投稿タイトル：{blog.Posts.First().Title}, " + $"投稿内容：{blog.Posts.First().Content}");

                // 削除
                Console.WriteLine("ブログを削除しました！");
                db.Remove(blog);
                db.SaveChanges();
            }
        }
    }
}