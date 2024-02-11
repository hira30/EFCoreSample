using Microsoft.EntityFrameworkCore;
using MySQLCrudSample;

using (var context = new TodoContext())
{
    // ①登録
    context.Todos.Add(new Todo { Name = "MySQL学習", IsComplete = false });
    context.Todos.Add(new Todo { Name = "ランニング", IsComplete = false });
    context.Todos.Add(new Todo { Name = "料理", IsComplete = false });
    await context.SaveChangesAsync();

    // ②1件取得(Idが最も小さいレコード)
    var todo = await context.Todos.OrderBy(t => t.Id).FirstAsync();

    // ③更新
    todo.IsComplete = true;
    await context.SaveChangesAsync();

    // ④全件取得
    var todos = await context.Todos.ToListAsync();
    todos.ForEach(t => Console.WriteLine($"④ Id：{t.Id}, Name：{t.Name}　IsComplete : {t.IsComplete}"));

    // ⑤全件削除
    context.RemoveRange(todos);
    await context.SaveChangesAsync();
}

Console.ReadLine();