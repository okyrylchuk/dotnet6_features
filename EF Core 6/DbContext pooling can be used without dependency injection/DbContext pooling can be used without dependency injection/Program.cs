// https://twitter.com/okyrylchuk/status/1462162703867420678

using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;

var options = new DbContextOptionsBuilder<ExampleContext>()
    .UseSqlServer(@"Server=(localdb)\mssqllocaldb;Database=EFCore6Playground")
    .Options;

var factory = new PooledDbContextFactory<ExampleContext>(options);

using var context1 = factory.CreateDbContext();
Console.WriteLine($"Created DbContext with ID {context1.ContextId}");
// Output: Created DbContext with ID e49db9b7-a0b0-4b54-8d0d-2cbd6c4cece7:1

using var context2 = factory.CreateDbContext();
Console.WriteLine($"Created DbContext with ID {context2.ContextId}");
// Output: Created DbContext with ID b5a35bcb-270d-40f1-b668-5f76da1f35ad:1

class ExampleContext : DbContext
{
    public ExampleContext(DbContextOptions<ExampleContext> options)
        : base(options)
    {
    }
}

