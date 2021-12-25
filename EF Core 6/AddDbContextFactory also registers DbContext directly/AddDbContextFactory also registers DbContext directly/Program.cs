// https://twitter.com/okyrylchuk/status/1461784381886980096

using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

var serviceProvider = new ServiceCollection()
        .AddDbContextFactory<ExampleContext>(builder => 
            builder.UseSqlServer(@"Server=(localdb)\mssqllocaldb;Database = EFCore6Playground")) 
        .BuildServiceProvider();
var factory = serviceProvider.GetService<IDbContextFactory<ExampleContext>>();

using (var context = factory.CreateDbContext())
{
    // Contexts obtained from the factory must be explicitly disposed
}

using (var scope = serviceProvider.CreateScope())
{
    var context = scope.ServiceProvider.GetService<ExampleContext>();
    // Context is disposed when the scope is disposed
}

class ExampleContext : DbContext
{ }