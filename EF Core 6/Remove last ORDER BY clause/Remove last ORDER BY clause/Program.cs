// https://twitter.com/okyrylchuk/status/1465433300286197766

using Microsoft.EntityFrameworkCore;

using var context = new ExampleContext();

var query = context.Blogs
    .Include(b => b.Posts.Where(p => p.Rating > 3))
    .ToQueryString();

Console.WriteLine(query);

class Blog
{
    public int Id { get; set; }
    public string Name { get; set; }
    public ICollection<Post> Posts { get; set; }
}

class Post
{
    public int Id { get; set; }
    public string Title { get; set; }
    public int Rating { get; set; }
    public Blog Blog { get; set; }
}

class ExampleContext : DbContext
{
    public DbSet<Blog> Blogs { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder options)
        => options.UseSqlServer(@"Server=(localdb)\mssqllocaldb;Database=EFCore6RemoveLastOrderByClause");
}

