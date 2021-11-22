using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

using var context = new ExampleContext();

context.Dogs.Add(new Dog { Name = "CHARLIE", Breed = Breed.Unknown });
context.Dogs.Add(new Dog { Name = "RUDY", Breed = Breed.Bulldog });
context.Dogs.Add(new Dog { Name = "MILO", Breed = Breed.Beagle });

context.SaveChanges();

// Executing DbCommand[Parameters =[@p0 = NULL(Size = 4000), @p1 = 'CHARLIE'(Size = 4000)], CommandType = 'Text', CommandTimeout = '30']
//      SET NOCOUNT ON;
// INSERT INTO[Dogs] ([Breed], [Name])
//      VALUES(@p0, @p1);

// Executing DbCommand[Parameters =[@p0 = 'Bulldog'(Size = 4000), @p1 = 'RUDY'(Size = 4000)], CommandType = 'Text', CommandTimeout = '30']
//      SET NOCOUNT ON;
// INSERT INTO[Dogs] ([Breed], [Name])
//      VALUES(@p0, @p1);

// Executing DbCommand[Parameters =[@p0 = 'Beagle'(Size = 4000), @p1 = 'MILO'(Size = 4000)], CommandType = 'Text', CommandTimeout = '30']
//      SET NOCOUNT ON;
// INSERT INTO[Dogs] ([Breed], [Name])
//      VALUES(@p0, @p1);

public class ExampleContext : DbContext
{
    public DbSet<Dog> Dogs { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder
            .Entity<Dog>()
            .Property(c => c.Breed)
            .HasConversion<BreedConverter>();
    }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder
            .EnableSensitiveDataLogging()
            .LogTo(Console.WriteLine)
            .UseSqlServer("Server=(localdb)\\mssqllocaldb;Database=EFCore6ValueConverterAllowsNulls;");
    }
}

public enum Breed
{
    Unknown,
    Beagle,
    Bulldog
}

public class Dog
{
    public int Id { get; set; }
    public string Name { get; set; }
    public Breed? Breed { get; set; }
}

public class BreedConverter : ValueConverter<Breed, string>
{
#pragma warning disable EF1001
    public BreedConverter()
        : base(
            v => v == Breed.Unknown ? null : v.ToString(),
            v => v == null ? Breed.Unknown : Enum.Parse<Breed>(v),
            convertsNulls: true)
    {
    }
#pragma warning restore EF1001
}

