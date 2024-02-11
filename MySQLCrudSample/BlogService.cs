using Microsoft.EntityFrameworkCore;

namespace MySQLCrudSample
{
    internal class BlogService
    {
        private readonly BloggingContext _context;

        public BlogService(BloggingContext context)
        {
            _context = context;
        }

        public async Task Insert(Blog blog) 
        {
            _context.Blogs.Add(blog);
            await _context.SaveChangesAsync();
            Console.WriteLine($"ブログを登録しました！　BlogId：{blog.BlogId}, URL：{blog.Url}");
        }

        public async Task Update(Blog blog) 
        {
            _context.Entry(blog).State = EntityState.Modified;
            await _context.SaveChangesAsync();
            Console.WriteLine($"ブログを更新しました！　BlogId：{blog.BlogId}, URL：{blog.Url}");
        }

        public async Task Delete(int blogId) 
        {
            var blog = await _context.Blogs.FindAsync(blogId);
            _context.Blogs.Remove(blog);
            await _context.SaveChangesAsync();
            Console.WriteLine($"ブログを削除しました！　BlogId：{blog.BlogId}, URL：{blog.Url}");
        }

        public async Task GetAll() 
        {
            var blogs = await _context.Blogs.AsNoTracking().ToListAsync();

            foreach (var blog in blogs)
            {
                Console.WriteLine($"BlogId：{blog.BlogId}, URL：{blog.Url}");
            }
        }

    }
}
