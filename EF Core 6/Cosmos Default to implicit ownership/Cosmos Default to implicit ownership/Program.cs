// https://twitter.com/okyrylchuk/status/1470874807239680009

using Microsoft.EntityFrameworkCore;

using var context = new ExampleContext();
await context.Database.EnsureDeletedAsync();
await context.Database.EnsureCreatedAsync();

var blog = new Blog
{
    Id = Guid.NewGuid(),
    Name = "Oleg's Blog",
    NavBarItems = new List<NavBarItem>
        {
            new NavBarItem { Name = "Home", Url = "/home" },
            new NavBarItem { Name = "About", Url = "/about" }
        },
    Posts = new List<Post>
        {
            new Post
            {
                Title = "Hello World",
                Content = "Content",
                Tags = new List<Tag>
                {
                    new Tag { Name = "Tag1" },
                    new Tag { Name = "Tag2" }
                }
            }
        }
};

context.Add(blog);
await context.SaveChangesAsync();

class Blog
{
    public Guid Id { get; set; }
    public string Name { get; set; }

    public IList<NavBarItem> NavBarItems { get; set; }
    public IList<Post> Posts { get; set; }
}

class NavBarItem
{
    public string Name { get; set; }
    public string Url { get; set; }
}

class Post
{
    public string Title { get; set; }
    public string Content { get; set; }
    public IList<Tag> Tags { get; set; }
}

class Tag
{
    public string Name { get; set; }
}

class ExampleContext : DbContext
{
    public DbSet<Blog> Blogs { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Blog>()
            .HasPartitionKey(e => e.Name);
    }

    protected override void OnConfiguring(DbContextOptionsBuilder options)
        => options.UseCosmos(
        "https://localhost:8081",
        "[key]",
        databaseName: "ImplicitOwnershipsDB");
}

