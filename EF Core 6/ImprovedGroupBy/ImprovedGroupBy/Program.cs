// https://twitter.com/okyrylchuk/status/1472260549027282947

using Microsoft.EntityFrameworkCore;

using var context = new ExampleContext();

var query = context.People
    .GroupBy(p => p.FirstName)
    .Select(g => g.OrderBy(e => e.FirstName)
                  .ThenBy(e => e.LastName)
                  .FirstOrDefault())
    .ToQueryString();

Console.WriteLine(query);
// SELECT[t0].[Id], [t0].[FirstName], [t0].[LastName]
// FROM (
// SELECT[p].[FirstName]
//    FROM [People] AS [p]
//    GROUP BY [p].[FirstName]
// ) AS[t]
// LEFT JOIN(
//    SELECT[t1].[Id], [t1].[FirstName], [t1].[LastName]
//    FROM (
//        SELECT[p0].[Id], [p0].[FirstName], [p0].[LastName],
//        ROW_NUMBER() OVER(PARTITION BY [p0].[FirstName]
//        ORDER BY [p0].[FirstName], [p0].[LastName]) AS[row]
//        FROM[People] AS[p0]
//    ) AS[t1]
//    WHERE[t1].[row] <= 1
// ) AS[t0] ON[t].[FirstName] = [t0].[FirstName]

class Person
{
    public int Id { get; set; }
    public string FirstName { get; set; }
    public int LastName { get; set; }
}

class ExampleContext : DbContext
{
    public DbSet<Person> People { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder options)
        => options.UseSqlServer(@"Server=(localdb)\mssqllocaldb;Database=EFCore6GroupBy");
}

