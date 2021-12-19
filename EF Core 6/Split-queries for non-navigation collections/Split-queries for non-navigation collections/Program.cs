using Microsoft.EntityFrameworkCore;

using var context = new ExampleContext();

#region Populate DB
// var blog = new Blog { Name = ".NET Blog"};
// blog.Posts.Add(new Post { Title = "First .NET post" });
// blog.Posts.Add(new Post { Title = "Second Java post" });
// blog.Posts.Add(new Post { Title = "Third .NET post" });

// context.Blogs.Add(blog);

// await context.SaveChangesAsync();
#endregion

var blogsWithDotnetPosts = await context.Blogs
    .Select(b => new
    {
        b,
        Posts = b.Posts.Where(p => p.Title.Contains(".NET")),
    })
    .AsSplitQuery()
    .ToListAsync();

class Blog
{
    public int Id { get; set; }
    public string Name { get; set; }
    public ICollection<Post> Posts { get; set; } = new List<Post>();
}

class Post
{
    public int Id { get; set; }
    public string Title { get; set; }
    public Blog Blog { get; set; }
}

class ExampleContext : DbContext
{
    public DbSet<Blog> Blogs { get; set; }
    public DbSet<Post> Posts { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder options)
        => options
        .EnableSensitiveDataLogging()
        .LogTo(Console.WriteLine)
        .UseSqlServer(@"Server=(localdb)\mssqllocaldb;Database=EFCore6SplitQueries");
}
