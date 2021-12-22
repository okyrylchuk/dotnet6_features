// https://twitter.com/okyrylchuk/status/1468340638131400706

using Microsoft.EntityFrameworkCore;

using var context = new ExampleContext();

var query = context.Posts
    .FromSqlRaw("SELECT * FROM Posts")
    .ToQueryString();

Console.WriteLine(query);
// SELECT c
// FROM (
//    SELECT * FROM Posts
// ) c

class Post
{
    public int Id { get; set; }
    public string Title { get; set; }
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

