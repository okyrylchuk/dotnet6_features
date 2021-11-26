using Microsoft.EntityFrameworkCore;

using var context = new ExampleContext();

var query = context.Blogs
    .TagWithCallSite()
    .OrderBy(b => b.CreationDate)
    .Take(10)
    .ToQueryString();

Console.WriteLine(query);
// SQL Query:
// DECLARE @__p_0 int = 10;

// --File: D:\EFCore6\TagWithCallSite\TagWithCallSite\Program.cs:6

// SELECT TOP(@__p_0) [b].[Id], [b].[CreationDate], [b].[Name]
// FROM[Blogs] AS[b]
// ORDER BY[b].[CreationDate]

class Blog
{
    public int Id { get; set; }
    public string Name { get; set; }
    public DateTime CreationDate { get; set; }
}

class ExampleContext : DbContext
{
    public DbSet<Blog> Blogs { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder options)
        => options.UseSqlServer(@"Server=(localdb)\mssqllocaldb;Database=EFCore6TagWithCallSite");
}