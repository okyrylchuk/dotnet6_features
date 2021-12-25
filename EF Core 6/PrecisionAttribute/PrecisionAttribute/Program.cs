// https://twitter.com/okyrylchuk/status/1456378157678858242

using Microsoft.EntityFrameworkCore;

using ExampleContext context = new ExampleContext();
var test = await context.Products.ToListAsync();

class ExampleContext : DbContext
{
    public DbSet<Product> Products { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder options)
            => options.UseSqlServer("Server=(localdb)\\mssqllocaldb;Database=EFUnicodeAttribute;Trusted_Connection=True;");
}

public class Product
{
    public int Id { get; set; }

    [Precision(precision: 10, scale: 2)]
    public decimal Price { get; set; }
}
