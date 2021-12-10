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
        // Provision throughput on the database
        modelBuilder.HasManualThroughput(2000);
        modelBuilder.HasAutoscaleThroughput(6000);

        // Provision throughput for the corresponding container
        modelBuilder
            .Entity<Post>(entityTypeBuilder =>
            {
                entityTypeBuilder.HasManualThroughput(3000);
                entityTypeBuilder.HasAutoscaleThroughput(12000);
            });
    }

    protected override void OnConfiguring(DbContextOptionsBuilder options)
        => options.UseCosmos(
        "https://localhost:8081",
        "[key]",
        databaseName: "ExampleDB");
}

