// https://twitter.com/okyrylchuk/status/1456667325671825412

using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

using ExampleContext context = new ExampleContext();
var test = await context.Products.ToListAsync();

class ExampleContext : DbContext
{
    public DbSet<Product> Products { get; set; }
}
public class ProductConfiguration : IEntityTypeConfiguration<Product>
{
    public void Configure(EntityTypeBuilder<Product> builder)
    {
        builder.Property(p => p.Name).HasMaxLength(250);
        builder.Property(p => p.Price).HasPrecision(10, 2);
    }
}
[EntityTypeConfiguration(typeof(ProductConfiguration))]
public class Product
{
    public int Id { get; set; }
    public decimal Price { get; set; }
    public string Name { get; set; }
}
