// https://twitter.com/okyrylchuk/status/1466166218990272516

using Microsoft.EntityFrameworkCore;

using var context = new ExampleContext();

var query = context.Posts
    .Where(p => EF.Functions.FreeText(EF.Property<string>(p, "Content"), "Searching text"))
    .ToQueryString();

Console.WriteLine(query);
// SELECT[p].[Id], [p].[Content], [p].[Title]
// FROM[Posts] AS[p]
// WHERE FREETEXT([p].[Content], N'Searching text')

class Post
{
    public int Id { get; set; }
    public string Title { get; set; }
    public byte[] Content { get; set; }
}

class ExampleContext : DbContext
{
    public DbSet<Post> Posts { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Post>()
            .Property(x => x.Content)
            .HasColumnType("varbinary(max)");
    }

    protected override void OnConfiguring(DbContextOptionsBuilder options)
        => options.UseSqlServer(@"Server=(localdb)\mssqllocaldb;Database=EFCore6FlexibleTextSearch");
}

