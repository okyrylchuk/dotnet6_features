// https://twitter.com/okyrylchuk/status/1459624577441705984

using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations.Schema;

using ExampleContext context = new();

public class ExampleContext : DbContext
{
    public DbSet<Employee> Employees { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder options)
    {
        options.UseSqlServer("Server=(localdb)\\mssqllocaldb;Database=ColumnOrder;Trusted_Connection=True;");
    }
}

public class EntityBase
{
    [Column(Order = 1)]
    public int Id { get; set; }
    [Column(Order = 99)]
    public DateTime UpdatedOn { get; set; }
    [Column(Order = 98)]
    public DateTime CreatedOn { get; set; }
}
public class Person : EntityBase
{
    [Column(Order = 2)]
    public string FirstName { get; set; }
    [Column(Order = 3)]
    public string LastName { get; set; }
    public ContactInfo ContactInfo { get; set; }
}
public class Employee : Person
{
    [Column(Order = 4)]
    public string Position { get; set; }
    [Column(Order = 5)]
    public string Department { get; set; }
}
[Owned]
public class ContactInfo
{
    [Column(Order = 10)]
    public string Email { get; set; }
    [Column(Order = 11)]
    public string Phone { get; set; }
}
