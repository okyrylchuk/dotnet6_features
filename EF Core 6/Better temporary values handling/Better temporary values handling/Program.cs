// https://twitter.com/okyrylchuk/status/1463258586356846599

using Microsoft.EntityFrameworkCore;

using var context = new ExampleContext();

Blog blog = new Blog { Id = -5 };
context.Add(blog).Property(p => p.Id).IsTemporary = true;

var post1 = new Post { Id = -1 };
var post1IdEntry = context.Add(post1).Property(e => e.Id).IsTemporary = true;
post1.BlogId = blog.Id;

var post2 = new Post();
var post2IdEntry = context.Add(post2).Property(e => e.Id).IsTemporary = true;
post2.BlogId = blog.Id;

Console.WriteLine($"Blog explicitly set temporary ID = {blog.Id}");
Console.WriteLine($"Post 1 explicitly set temporary ID = {post1.Id} and FK to Blog = {post1.BlogId}");
Console.WriteLine($"Post 2 generated temporary ID = {post2.Id} and FK to Blog = {post2.BlogId}");

// Output:
// Blog explicitly set temporary ID = -5
// Post 1 explicitly set temporary ID = -1 and FK to Blog = -5
// Post 2 generated temporary ID = -2147482647 and FK to Blog = -5

class Blog
{
    public int Id { get; set; }
}

class Post
{
    public int Id { get; set; }
    public int BlogId { get; set; }
}

class ExampleContext : DbContext
{
    public DbSet<Blog> Blogs { get; set; }
    public DbSet<Post> Posts { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder options)
        => options.UseSqlServer(@"Server=(localdb)\mssqllocaldb;Database=EFCore6TempValues");
}

