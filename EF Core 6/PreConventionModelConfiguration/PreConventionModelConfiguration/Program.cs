// https://twitter.com/okyrylchuk/status/1458857817310388230

using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using System.Text.Json;

using ExampleContext context = new();

public class ExampleContext : DbContext
{
    public DbSet<Person> People { get; set; }
    public DbSet<Product> Products { get; set; }

    protected override void ConfigureConventions(ModelConfigurationBuilder configurationBuilder)
    {
        configurationBuilder
            .Properties<string>()
            .HaveMaxLength(500);

        configurationBuilder
            .Properties<DateTime>()
            .HaveConversion<long>();

        configurationBuilder
            .Properties<decimal>()
            .HavePrecision(12, 2);

        configurationBuilder
            .Properties<Address>()
            .HaveConversion<AddressConverter>();
    }
}


public class Product
{
    public int Id { get; set; }
    public decimal Price { get; set; }
}

public class Person
{
    public int Id { get; set; }
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public DateTime BirthDate { get; set; }
    public Address Address { get; set; }
}

public class Address
{
    public string Country { get; set; }
    public string Street { get; set; }
    public string ZipCode { get; set; }
}

public class AddressConverter : ValueConverter<Address, string>
{
    public AddressConverter()
        : base(
            v => JsonSerializer.Serialize(v, (JsonSerializerOptions)null),
            v => JsonSerializer.Deserialize<Address>(v, (JsonSerializerOptions)null))
    {
    }
}

