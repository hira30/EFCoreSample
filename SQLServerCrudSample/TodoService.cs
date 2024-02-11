using Microsoft.EntityFrameworkCore;

namespace SQLServerCurdSample
{
    internal class TodoService
    {
        private readonly TodoContext _context;

        public TodoService(TodoContext context)
        {
            _context = context;
        }

        public async Task Insert(Todo todo) 
        {
            _context.Todos.Add(todo);
            await _context.SaveChangesAsync();
            Console.WriteLine($"ブログを登録しました！　Id：{todo.Id}, Name：{todo.Name}");
        }

        public async Task Update(Todo todo) 
        {
            _context.Entry(todo).State = EntityState.Modified;
            await _context.SaveChangesAsync();
            Console.WriteLine($"ブログを更新しました！　Id：{todo.Id}, Name：{todo.Name}");
        }

        public async Task Delete(int todoId) 
        {
            var todo = await _context.Todos.FindAsync(todoId);
            _context.Todos.Remove(todo);
            await _context.SaveChangesAsync();
            Console.WriteLine($"ブログを削除しました！　Id：{todo.Id}, Name：{todo.Name}");
        }

        public async Task GetAll() 
        {
            var todos = await _context.Todos.AsNoTracking().ToListAsync();

            foreach (var todo in todos)
            {
                Console.WriteLine($"Id：{todo.Id}, Name：{todo.Name}");
            }
        }

    }
}
