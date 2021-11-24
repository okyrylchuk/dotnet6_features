using Microsoft.EntityFrameworkCore;

using var context = new ExampleContext();

var query = context.Entities
                    .Where(e => string.IsNullOrWhiteSpace(e.Property))
                    .ToQueryString();

Console.WriteLine(query);
// Output:
// SELECT [e].[Id], [e].[Property]
// FROM [Entities] AS[e]
// WHERE [e].[Property] IS NULL OR ([e].[Property] = N'')

class Entity
{
    public int Id { get; set; }
    public string Property { get; set; }
}

class ExampleContext : DbContext
{
    public DbSet<Entity> Entities { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder options)
        => options.UseSqlServer(@"Server=(localdb)\mssqllocaldb;Database=EFCore6IsNullOrWhiteSpace");
}
