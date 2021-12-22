// https://twitter.com/okyrylchuk/status/1471947488026402831

using Microsoft.EntityFrameworkCore;

using var context = new ExampleContext();

var query = context.Products
    .Where(p => Math.Abs(p.Price) == 100
    || Math.Round(p.Price) > 100)
    .ToQueryString();

Console.WriteLine(query);
// SELECT c
// FROM root c
// WHERE ((c["Discriminator"] = "Product")
// AND((ABS(c["Price"]) = 100.0)
// OR(ROUND(c["Price"]) > 100.0)))

class Product
{
    public Guid Id { get; set; }
    public string Title { get; set; }
    public decimal Price { get; set; }
}

class ExampleContext : DbContext
{
    public DbSet<Product> Products { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder options)
        => options.UseCosmos(
        "https://localhost:8081",
        "[key]",
        databaseName: "MathTranlationsDB");
}

