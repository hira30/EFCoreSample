using Microsoft.EntityFrameworkCore;
using PostgreSQLCurdSample;

using (var context = new TodoContext())
{
    // ①登録
    context.Todos.Add(new Todo { Name = "プログラミング学習", IsComplete = false });
    context.Todos.Add(new Todo { Name = "掃除", IsComplete = false });
    context.Todos.Add(new Todo { Name = "買い物", IsComplete = false });
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

    // EF Core 7.0以降のみ
    // 完了フラグがfalseのレコードを全てtrueに更新
    //context.Todos.Where(t => !t.IsComplete).ExecuteUpdate(s => s.SetProperty(t => t.IsComplete, true));

    // 完了フラグがtrueのレコードを全て削除
    //await context.Todos.Where(t => t.IsComplete).ExecuteDeleteAsync();
}

Console.ReadLine();