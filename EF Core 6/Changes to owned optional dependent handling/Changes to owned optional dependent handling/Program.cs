using Microsoft.EntityFrameworkCore;

#region Warning example
using var context = new ExampleContext();
var person = new Person
{
    FirstName = "Oleg",
    LastName = "Kyrylchuk",
    Address = new Address()
};
context.People.Add(person);
await context.SaveChangesAsync();

class Person
{
    public int Id { get; set; }
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public Address Address { get; set; }
}

class Address
{
    public string City { get; set; }
    public string Street { get; set; }
    public string PostalCode { get; set; }
}

class ExampleContext : DbContext
{
    public DbSet<Person> People { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder
            .Entity<Person>()
            .OwnsOne(p => p.Address);
    }

    protected override void OnConfiguring(DbContextOptionsBuilder options)
        => options
        .EnableSensitiveDataLogging()
        .LogTo(Console.WriteLine)
        .UseSqlServer(@"Server=(localdb)\mssqllocaldb;Database=EFCore6OwnedDependentHandling");
}
#endregion

#region Creating model error example
//using var context = new ExampleContext();
//var person = new Person
//{
//    FirstName = "Oleg",
//    LastName = "Kyrylchuk",
//    ContactInfo = new ContactInfo()
//};
//context.People.Add(person);
//await context.SaveChangesAsync();

//class Person
//{
//    public int Id { get; set; }
//    public string FirstName { get; set; }
//    public string LastName { get; set; }
//    public ContactInfo ContactInfo { get; set; }
//}

//class ContactInfo
//{
//    public string Phone { get; set; }
//    public Address Address { get; set; }
//}

//class Address
//{
//    public string City { get; set; }
//    public string Street { get; set; }
//    public string PostalCode { get; set; }
//}

//class ExampleContext : DbContext
//{
//    public DbSet<Person> People { get; set; }

//    protected override void OnModelCreating(ModelBuilder modelBuilder)
//    {
//        modelBuilder
//            .Entity<Person>()
//            .OwnsOne(p => p.ContactInfo)
//            .OwnsOne(p => p.Address);
//    }

//    protected override void OnConfiguring(DbContextOptionsBuilder options)
//        => options.UseSqlServer(@"Server=(localdb)\mssqllocaldb;Database=EFCore6OwnedDependentHandling");
//}
#endregion

