// https://twitter.com/okyrylchuk/status/1457054277390774277

using Microsoft.EntityFrameworkCore;

using ExampleContext context = new();

//context.People.Add(new() { Name = "Oleg" });
//context.People.Add(new() { Name = "Steve" });
//context.People.Add(new() { Name = "John" });
//await context.SaveChangesAsync();

var people = await context.People.ToListAsync();
foreach (var person in people)
{
    var personEntry = context.Entry(person);
    var validFrom = personEntry.Property<DateTime>("PeriodStart").CurrentValue;
    var validTo = personEntry.Property<DateTime>("PeriodEnd").CurrentValue;
    Console.WriteLine($"Person {person.Name} valid from {validFrom} to {validTo}");
}

// Output:
// Person Oleg valid from 06-Nov-21 17:50:39 PM to 31-Dec-99 23:59:59 PM
// Person Steve valid from 06-Nov-21 17:50:39 PM to 31-Dec-99 23:59:59 PM
// Person John valid from 06-Nov-21 17:50:39 PM to 31-Dec-99 23:59:59 PM

//var oleg = await context.People.FirstAsync(x => x.Name == "Oleg");
//context.People.Remove(oleg);
//await context.SaveChangesAsync();
var history = context
                .People
                .TemporalAll()
                .Where(e => e.Name == "Oleg")
                .OrderBy(e => EF.Property<DateTime>(e, "PeriodStart"))
                .Select(
                    p => new
                    {
                        Person = p,
                        PeriodStart = EF.Property<DateTime>(p, "PeriodStart"),
                        PeriodEnd = EF.Property<DateTime>(p, "PeriodEnd")
                    })
                .ToList();
foreach (var pointInTime in history)
{
    Console.WriteLine(
        $"Person {pointInTime.Person.Name} existed from {pointInTime.PeriodStart} to {pointInTime.PeriodEnd}");
}

// Output:
// Person Oleg existed from 06-Nov-21 17:50:39 PM to 06-Nov-21 18:11:29 PM

var removedOleg = await context
    .People
    .TemporalAsOf(history.First().PeriodStart)
    .SingleAsync(e => e.Name == "Oleg");

Console.WriteLine($"Id = {removedOleg.Id}; Name = {removedOleg.Name}");
// Output:
// Id = 1; Name = Oleg

public class ExampleContext : DbContext
{
    public DbSet<Person> People { get; set; }
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder
            .Entity<Person>()
            .ToTable("People", b => b.IsTemporal());
    }
    protected override void OnConfiguring(DbContextOptionsBuilder options)
            => options.UseSqlServer("Server=(localdb)\\mssqllocaldb;Database=TemporalTables;Trusted_Connection=True;");
}
public class Person 
{ 
    public int Id { get; set; }
    public string Name { get; set; }    
}

