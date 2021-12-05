using Microsoft.EntityFrameworkCore;

using var context = new ExampleContext();

class Person
{
    public int Id { get; set; }
    public string Name { get; set; }
}

class ExampleContext : DbContext
{
    public DbSet<Person> People { get; set; }

    // 60 seconds as the default timeout for commands created by connection
    protected override void OnConfiguring(DbContextOptionsBuilder options)
        => options.UseSqlite("Data Source=Test.db;Command Timeout=60");
}

