using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Diagnostics;
using System.ComponentModel.DataAnnotations;

using var context = new ExampleContext();

var blog = new Blog();
context.Blogs.Add(blog);

await context.SaveChangesAsync();
// Unhandled exception. Microsoft.EntityFrameworkCore.DbUpdateException:
// Required properties '{'Title'}' are missing for the instance of entity
// type 'Blog' with the key value '{Id: 1}'.

class Blog
{
    public int Id { get; set; }

    [Required]
    public string Title { get; set; }
}

class ExampleContext : DbContext
{
    public DbSet<Blog> Blogs { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder options)
        => options
        .EnableSensitiveDataLogging()
        .LogTo(Console.WriteLine, new[] { InMemoryEventId.ChangesSaved })
        .UseInMemoryDatabase("ValidateRequiredProps");

    //  To disable the validation
    //  .UseInMemoryDatabase("ValidateRequiredProps", b => b.EnableNullChecks(false));
}


