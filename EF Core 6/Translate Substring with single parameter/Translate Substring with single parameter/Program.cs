// https://twitter.com/okyrylchuk/status/1463982016840486913

using Microsoft.EntityFrameworkCore;

using var context = new ExampleContext();

context.People.Add(new Person { Name = "John" });
context.People.Add(new Person { Name = "Bred" });
context.People.Add(new Person { Name = "Ron" });
await context.SaveChangesAsync();

var result = await context.People
    .Select(a => new { Name = a.Name.Substring(1) })
    .ToListAsync();
// Translated SQL: 
// SELECT SUBSTRING([p].[Name], 1 + 1, LEN([p].[Name])) AS [Name]
// FROM [People] AS [p]

result.ForEach(p => Console.WriteLine(p.Name));
// Output:
// ohn
// red
// on

class Person
{
    public int Id { get; set; }
    public string Name { get; set; }
}

class ExampleContext : DbContext
{
    public DbSet<Person> People { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder options)
        => options.UseSqlServer(@"Server=(localdb)\mssqllocaldb;Database=EFCore6Substring");
}

