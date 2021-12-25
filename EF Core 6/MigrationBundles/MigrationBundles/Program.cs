// https://twitter.com/okyrylchuk/status/1458539660108615686

// CLI: dotnet ef migrations bundle --project MigrationBundles
// PMC: Bundle-Migration

using Microsoft.EntityFrameworkCore;

using ExampleContext context = new();

public class ExampleContext : DbContext
{
    public DbSet<Person> People { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder options)
            => options.UseSqlServer("Server=(localdb)\\mssqllocaldb;Database=MigrationBundles;Trusted_Connection=True;");
}

public class Person
{
    public int Id { get; set; }
    public string Name { get; set; }
}


