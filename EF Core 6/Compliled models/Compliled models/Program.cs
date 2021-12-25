// https://twitter.com/okyrylchuk/status/1459233766728155140

// CLI: dotnet ef dbcontext optimize -c ExampleContext -o CompliledModels -n CompiledModelsExample
// PMC: Optimize-DbContext -Context ExampleContext -OutputDir CompiledModels -Namespace CompiledModelsExample

using Microsoft.EntityFrameworkCore;

using ExampleContext context = new();


public class ExampleContext : DbContext
{
    public DbSet<Person> People { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder options)
    { 
        options.UseModel(CompiledModelsExample.ExampleContextModel.Instance)
        options.UseSqlServer("Server=(localdb)\\mssqllocaldb;Database=SparseColumns;Trusted_Connection=True;"); 
    }
}


public class Person
{
    public int Id { get; set; }
    public string FirstName { get; set; }
    public string LastName { get; set; }
}
