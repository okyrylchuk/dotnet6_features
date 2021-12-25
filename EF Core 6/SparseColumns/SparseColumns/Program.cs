// https://twitter.com/okyrylchuk/status/1457448466326622212

using Microsoft.EntityFrameworkCore;

using ExampleContext context = new();

public class ExampleContext : DbContext
{
    public DbSet<Person> People { get; set; }
    public DbSet<Employee> Employees { get; set; }
    public DbSet<User> Users { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder
            .Entity<User>()
            .Property(e => e.Login)
            .IsSparse();

        modelBuilder
            .Entity<Employee>()
            .Property(e => e.Position)
            .IsSparse();
    }
    
    protected override void OnConfiguring(DbContextOptionsBuilder options)
            => options.UseSqlServer("Server=(localdb)\\mssqllocaldb;Database=SparseColumns;Trusted_Connection=True;");
}

public class Person
{
    public int Id { get; set; }
    public string Name { get; set; }
}
public class User : Person
{
    public string Login { get; set; }
}
public class Employee : Person
{
    public string Position { get; set; }
}

