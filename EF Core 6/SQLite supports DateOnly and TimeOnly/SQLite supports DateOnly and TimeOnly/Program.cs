// https://twitter.com/okyrylchuk/status/1466841625259397129

using Microsoft.EntityFrameworkCore;

using var context = new ExampleContext();

var query1 = context.People
    .Where(p => p.Birthday < new DateOnly(2000, 1, 1))
    .ToQueryString();

Console.WriteLine(query1);
// SELECT "p"."Id", "p"."Birthday", "p"."Name"
// FROM "People" AS "p"
// WHERE "p"."Birthday" < '2000-01-01'

var query2 = context.Notifications
    .Where(n => n.AllowedFrom >= new TimeOnly(8, 0) && n.AllowedTo <= new TimeOnly(16, 0))
    .ToQueryString();

Console.WriteLine(query2);
// SELECT "n"."Id", "n"."AllowedFrom", "n"."AllowedTo"
// FROM "Notifications" AS "n"
// WHERE("n"."AllowedFrom" >= '08:00:00') AND("n"."AllowedTo" <= '16:00:00')

class Person
{
    public int Id { get; set; }
    public string Name { get; set; }
    public DateOnly Birthday { get; set; }
}

class Notification
{
    public int Id { get; set; }
    public TimeOnly AllowedFrom { get; set; }
    public TimeOnly AllowedTo { get; set; }
}

class ExampleContext : DbContext
{
    public DbSet<Person> People { get; set; }
    public DbSet<Notification> Notifications { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder options)
        => options.UseSqlite(@"Data Source=Db\DateOnlyTimeOnly.db");
}

