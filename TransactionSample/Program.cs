using Microsoft.EntityFrameworkCore;
using System.Transactions;
using TransactionSample;

//var connectionString = @"Server=(localdb)\mssqllocaldb;Database=Blogging;Trusted_Connection=True";

//using var connection = new SqlConnection(connectionString);
//connection.Open();

//using var transaction = connection.BeginTransaction();
//try
//{
//    // ADO.NETでテーブルをDELETEするSQLを実行
//    var command = connection.CreateCommand();
//    command.Transaction = transaction;
//    command.CommandText = "DELETE FROM dbo.Blogs";
//    command.ExecuteNonQuery();

//    // EF CoreでテーブルにINSERTするSQLを実行
//    using (var context = new BloggingContext())
//    {
//        context.Database.GetDbConnection().Open();
//        context.Database.UseTransaction(transaction);
//        context.Blogs.Add(new Blog { Url = "http://blogs.msdn.com/dotnet" });
//        context.SaveChanges();
//    }

//    // コミット
//    transaction.Commit();
//}
//catch (Exception)
//{
//    // TODO: Handle failure
//}



using var scope = new TransactionScope(TransactionScopeAsyncFlowOption.Enabled);
{
    Console.WriteLine("トランザクション開始");

    try
    {
        // EF CoreでテーブルにINSERTするSQLを実行
        using var context = new BloggingContext();
        context.Blogs.Add(new Blog { Url = "xxx.com" });
        await context.SaveChangesAsync();

        var connection = context.Database.GetDbConnection();
        await connection.OpenAsync();

        // ADO.NETで全行をUPDATEするSQLを実行
        var command = connection.CreateCommand();
        command.CommandText = "UPDATE Blogs SET Url = 'zzz.com'";
        await command.ExecuteNonQueryAsync();

        // コミット
        scope.Complete();
    }
    catch (Exception)
    {
        // 処理中に例外が発生した場合はロールバックされる
        throw;
    }

    Console.WriteLine("トランザクション終了");
}