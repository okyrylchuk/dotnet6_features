using Microsoft.EntityFrameworkCore;

using var context = new ExampleContext();

var query = context.Posts
    .Where(p => p.Rating == (int)(EF.Functions.Random() * 5.0) + 1)
    .ToQueryString();

Console.WriteLine(query);
// Output:
// SELECT[p].[Id], [p].[Rating], [p].[Title]
// FROM[Posts] AS[p]
// WHERE[p].[Rating] = (CAST((RAND() * 5.0E0) AS int) + 1)

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
        => options.UseSqlServer(@"Server=(localdb)\mssqllocaldb;Database=EFCore6Random");
}
