using EFCoreSample;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

var builder = Host.CreateApplicationBuilder(args);

// DbContextをDIに登録
builder.Services.AddDbContext<BloggingContext>();

// サービスをDIに登録
builder.Services.AddSingleton<BlogService>();

// 登録したサービスを呼び出す
var provider = builder.Services.BuildServiceProvider();
var blogService = provider.GetService<BlogService>();

// 登録
await blogService.Insert(new Blog { Url = "aaa.com", Rating = 10 });

// 更新
await blogService.Update(new Blog { BlogId = 2, Url = "bbb.com", Rating = 4 });

// 削除
await blogService.Delete(2);

// 読み取り
await blogService.GetAll();

Console.ReadLine();