using Microsoft.EntityFrameworkCore;

using var context = new ExampleContext();

var blogEn = new Blog
{
    Title = "All about .NET",
    Language = "English",
    Posts = new List<Post>
        {
            new Post { Title = "Post one", Content = "Some content" },
            new Post { Title = "Post two", Content = "Some content" }
        }
};

var blogPl = new Blog
{
    Title = "Wszystko o .NET",
    Language = "Polish",
    Posts = new List<Post>
        {
            new Post { Title = "Pierwszy post", Content = "Treść" }
        }
};

context.Blogs.Add(blogEn);
context.Blogs.Add(blogPl);
await context.SaveChangesAsync();

var postsByLanguages = context.PostsByLanguages.ToList();

postsByLanguages
    .ForEach(p => Console.WriteLine($"{p.PostCount} posts in {p.Language}"));
// Output:
// 2 posts in English
// 1 posts in Polish

class Post
{
    public int Id { get; set; }
    public string Title { get; set; }
    public string Content { get; set; }
}

class Blog
{
    public int Id { get; set; }
    public string Title { get; set; }
    public string Language { get; set; }
    public ICollection<Post> Posts { get; set; }
}

class PostsByLanguage
{
    public string Language { get; set; }
    public int PostCount { get; set; }
}

class ExampleContext : DbContext
{
    public DbSet<Post> Posts { get; set; }
    public DbSet<Blog> Blogs { get; set; }
    public DbSet<PostsByLanguage> PostsByLanguages { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder
                .Entity<PostsByLanguage>()
                .HasNoKey()
                .ToInMemoryQuery(
                    () => Blogs
                        .GroupBy(c => c.Language)
                        .Select(
                            g =>
                                new PostsByLanguage
                                {
                                    Language = g.Key,
                                    PostCount = g.Sum(b => b.Posts.Count)
                                }));
    }

    protected override void OnConfiguring(DbContextOptionsBuilder options)
        => options.UseInMemoryDatabase("ToInMemoryQuery");
}


