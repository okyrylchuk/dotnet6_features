using Microsoft.EntityFrameworkCore;

using var context = new ExampleContext();
await context.Database.EnsureDeletedAsync();
await context.Database.EnsureCreatedAsync();

var book = new Book
{
    Title = "Some book"
};
context.Books.Add(book);
await context.SaveChangesAsync();

book = context.Books.First();
await context.SaveChangesAsync();

class Book
{
    public Guid Id { get; set; }
    public string Title { get; set; }
}

class ExampleContext : DbContext
{
    public DbSet<Book> Books { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder options)
        => options
        .EnableSensitiveDataLogging()
        .LogTo(Console.WriteLine)
        .UseCosmos(
        "https://localhost:8081",
        "[key]",
        databaseName: "DiagnosticsDB");
}

