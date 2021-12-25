// https://twitter.com/okyrylchuk/status/1466522030531088387

using Microsoft.EntityFrameworkCore;
using System.Text.Json;

using var context = new ExampleContext();

var query = context.People
    .Where(e => EF.Functions.Contains(e.FullName, "Oleg"))
    .ToQueryString();

Console.WriteLine(query);
// SELECT[p].[Id], [p].[FullName]
// FROM[People] AS[p]
// WHERE CONTAINS([p].[FullName], N'Oleg')

class Person
{
    public int Id { get; set; }
    public FullName FullName { get; set; }
}

public class FullName
{
    public string FirstName { get; set; }
    public string LastName { get; set; }
}

class ExampleContext : DbContext
{
    public DbSet<Person> People { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Person>()
            .Property(x => x.FullName)
            .HasConversion(
                    v => JsonSerializer.Serialize(v, (JsonSerializerOptions)null),
                    v => JsonSerializer.Deserialize<FullName>(v, (JsonSerializerOptions)null));
    }

    protected override void OnConfiguring(DbContextOptionsBuilder options)
        => options.UseSqlServer(@"Server=(localdb)\mssqllocaldb;Database=EFCore6Contains");
}

