using Microsoft.EntityFrameworkCore;

using var context = new ExampleContext();

var query = context.Posts
    .Where(p => p.Title.ToUpper() == ".NET"
    || p.Title.ToLower() == "hello world"
    || p.Title.Length > 10)
    .ToQueryString();

// SELECT c
// FROM root c
// WHERE ((c["Discriminator"] = "Post")
// AND(((UPPER(c["Title"]) = ".NET")
// OR(LOWER(c["Title"]) = "hello world"))
// OR(LENGTH(c["Title"]) > 10)))

Console.WriteLine(query);

class Post
{
    public Guid Id { get; set; }
    public string Title { get; set; }
    public string Content { get; set; }
}

class ExampleContext : DbContext
{
    public DbSet<Post> Posts { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder options)
        => options.UseCosmos(
        "https://localhost:8081",
        "[key]",
        databaseName: "StringTranlationsDB");
}

