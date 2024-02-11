using SQLServerCurdSample;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

//var builder = Host.CreateApplicationBuilder(args);

//// DbContextをDIに登録
//builder.Services.AddDbContext<TodoContext>();

//// サービスをDIに登録
//builder.Services.AddSingleton<TodoService>();

//// 登録したサービスを呼び出す
//var provider = builder.Services.BuildServiceProvider();
//var blogService = provider.GetService<TodoService>();

using (var context = new TodoContext())
{
    // ①登録
    context.Todos.Add(new Todo { Name = "C#学習", IsComplete = false });
    context.Todos.Add(new Todo { Name = "筋トレ", IsComplete = false });
    context.Todos.Add(new Todo { Name = "映画鑑賞", IsComplete = false });
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