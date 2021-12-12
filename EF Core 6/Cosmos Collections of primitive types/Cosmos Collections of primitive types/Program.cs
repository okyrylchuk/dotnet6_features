using Microsoft.EntityFrameworkCore;

using var context = new ExampleContext();
await context.Database.EnsureDeletedAsync();
await context.Database.EnsureCreatedAsync();

var book = new Book
{
    Title = "Some book",
    Quotes = new List<string> { "Some quote" },
    Notes = new Dictionary<string, string>
        {
            { "12", "Some note"},
            { "234", "Another note"}
        }
};
context.Books.Add(book);
await context.SaveChangesAsync();

book = context.Books.First();
book.Quotes.Add("New quote");
book.Notes["12"] = "Updated note";
await context.SaveChangesAsync();

class Book
{
    public Guid Id { get; set; }
    public string Title { get; set; }
    public IList<string> Quotes { get; set; }
    public IDictionary<string, string> Notes { get; set; }
}

class ExampleContext : DbContext
{
    public DbSet<Book> Books { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder options)
        => options.UseCosmos(
        "https://localhost:8081",
        "[key]",
        databaseName: "ExampleDB");
}

