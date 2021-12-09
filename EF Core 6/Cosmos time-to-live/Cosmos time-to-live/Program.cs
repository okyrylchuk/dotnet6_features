using Microsoft.EntityFrameworkCore;

using var context = new ExampleContext();

class Post
{
    public int Id { get; set; }
    public string Title { get; set; }
    public int Rating { get; set; }
}

class ExampleContext : DbContext
{
    public DbSet<Post> Posts { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder
            .Entity<Post>(entityTypeBuilder =>
            {
                entityTypeBuilder.HasDefaultTimeToLive(100);
                entityTypeBuilder.HasAnalyticalStoreTimeToLive(200);
            });
    }

    protected override void OnConfiguring(DbContextOptionsBuilder options)
        => options.UseCosmos(
        "https://localhost:8081",
        "[key]",
        databaseName: "ExampleDB");
}