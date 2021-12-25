// https://twitter.com/okyrylchuk/status/1462537786771263493

using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Diagnostics;
using System.Data.Common;

using var context = new ExampleContext();

context.Products.Add(new Product { Name = "Laptop", Price = 1000 });
context.SaveChanges();

var product = context.Products
    .FromSqlRaw("SELECT * FROM dbo.Products")
    .ToList();

/* Output:
Saving changes for ExampleContext:

SET NOCOUNT ON;
INSERT INTO[Products] ([Name], [Price])
VALUES(@p0, @p1);
SELECT[Id]
FROM[Products]
WHERE @@ROWCOUNT = 1 AND[Id] = scope_identity();


From Sql query for ExampleContext:

SELECT* FROM dbo.Products
*/

class ExampleInterceptor : DbCommandInterceptor
{
    public override InterceptionResult<DbDataReader> ReaderExecuting(DbCommand command,
        CommandEventData eventData, InterceptionResult<DbDataReader> result)
    {
        if (eventData.CommandSource == CommandSource.SaveChanges)
        {
            Console.WriteLine($"Saving changes for {eventData.Context.GetType().Name}:");
            Console.WriteLine();
            Console.WriteLine(command.CommandText);
        }

        if (eventData.CommandSource == CommandSource.FromSqlQuery)
        {
            Console.WriteLine($"From Sql query for {eventData.Context.GetType().Name}:");
            Console.WriteLine();
            Console.WriteLine(command.CommandText);
        }

        /*
        public enum CommandSource
        {
            Unknown,
            LinqQuery,
            SaveChanges,
            Migrations,
            FromSqlQuery,
            ExecuteSqlRaw,
            ValueGenerator,
            Scaffolding,
            BulkUpdate
        }*/

        return result;
    }
}

class ExampleContext : DbContext
{
    public DbSet<Product> Products { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder options)
        => options
        .UseSqlServer(@"Server=(localdb)\mssqllocaldb;Database=EFCore6CommandSource")
        .AddInterceptors(new ExampleInterceptor());
}

class Product
{
    public int Id { get; set; }
    public string Name { get; set; }
    public decimal Price { get; set; }
}

