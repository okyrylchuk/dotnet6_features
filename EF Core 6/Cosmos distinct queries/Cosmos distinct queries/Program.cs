// https://twitter.com/okyrylchuk/status/1468704394069913612

using Microsoft.EntityFrameworkCore;

using var context = new ExampleContext();

var query = context.Posts
    .Select(p => p.Rating)
    .OrderBy(r => r)
    .Distinct()
    .ToQueryString();

Console.WriteLine(query);
// SELECT DISTINCT c["Rating"]
// FROM root c
// WHERE (c["Discriminator"] = "Post")
// ORDER BY c["Rating"]

class Post
{
    public int Id { get; set; }
    public string Title { get; set; }
    public int Rating { get; set; }
}

class ExampleContext : DbContext
{
    public DbSet<Post> Posts { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder options)
        => options.UseCosmos(
        "https://localhost:8081",
        "[key]",
        databaseName: "ExampleDB");
}

