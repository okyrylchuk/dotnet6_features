// https://twitter.com/okyrylchuk/status/1464710554652708866

using Microsoft.EntityFrameworkCore;

using var context = new ExampleContext();

var query = context.People
    .Where(u => EF.Functions.Like(u.PhoneNumber.ToString(), "%368%"))
    .ToQueryString();

Console.WriteLine(query);
// Query:
// SELECT "p"."Id", "p"."Name", "p"."PhoneNumber"
// FROM "People" AS "p"
// WHERE CAST("p"."PhoneNumber" AS TEXT) LIKE '%368%'

class Person
{
    public int Id { get; set; }
    public string Name { get; set; }
    public long PhoneNumber { get; set; }
}

class ExampleContext : DbContext
{
    public DbSet<Person> People { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder options)
        => options.UseSqlite("Data Source=:memory:");
}