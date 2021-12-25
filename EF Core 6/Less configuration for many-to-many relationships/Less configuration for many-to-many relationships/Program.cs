// https://twitter.com/okyrylchuk/status/1460366722351915010

using Microsoft.EntityFrameworkCore;

using var context = new BloggingContext();

public class BloggingContext : DbContext
{
    public DbSet<Post> Posts { get; set; }
    public DbSet<Tag> Tags { get; set; }
    public DbSet<PostTag> PostTags { get; set; }
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Post>()
            .HasMany(p => p.Tags)
            .WithMany(t => t.Posts)
            .UsingEntity<PostTag>();
    }
    protected override void OnConfiguring(DbContextOptionsBuilder options)
        => options.UseSqlServer("Server=(localdb)\\mssqllocaldb;Database=EFCore6Many2Many;Trusted_Connection=True;");
}
public class Post
{
    public int Id { get; set; }
    public string Name { get; set; }
    public List<Tag> Tags { get; set; } = new List<Tag>();
}
public class Tag
{
    public int Id { get; set; }
    public string Text { get; set; }
    public List<Post> Posts { get; set; } = new List<Post>();
}
public class PostTag
{
    public int PostId { get; set; }
    public int TagId { get; set; }
    public DateTime AddedDate { get; set; }
}