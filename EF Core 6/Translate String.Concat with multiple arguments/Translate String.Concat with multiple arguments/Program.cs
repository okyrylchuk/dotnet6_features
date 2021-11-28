using Microsoft.EntityFrameworkCore;

using var context = new ExampleContext();

string fullName = "SamuelLanghorneClemens";
var query = context.Blogs
    .Where(b => string.Concat(b.FirstName, b.MiddleName, b.LastName) == fullName)
    .ToQueryString();

Console.WriteLine(query);
// Output:
// DECLARE @__fullName_0 nvarchar(4000) = N'SamuelLanghorneClemens';

// SELECT[b].[Id], [b].[FirstName], [b].[LastName], [b].[MiddleName]
// FROM[Blogs] AS[b]
// WHERE(COALESCE([b].[FirstName], N'') + (COALESCE([b].[MiddleName], N'') +COALESCE([b].[LastName], N ''))) = @__fullName_0

class Blog
{
    public int Id { get; set; }
    public string FirstName { get; set; }
    public string MiddleName { get; set; }
    public string LastName { get; set; }
}

class ExampleContext : DbContext
{
    public DbSet<Blog> Blogs { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder options)
        => options.UseSqlServer(@"Server=(localdb)\mssqllocaldb;Database=EFCore6StringConcat");
}

