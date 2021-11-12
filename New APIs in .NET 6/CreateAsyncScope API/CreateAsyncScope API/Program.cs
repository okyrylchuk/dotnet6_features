// https://twitter.com/okyrylchuk/status/1454856685298798595

using System;
using System.Threading.Tasks;
using Microsoft.Extensions.DependencyInjection;

await using var provider = new ServiceCollection()
        .AddScoped<Example>()
        .BuildServiceProvider();

await using (var scope = provider.CreateAsyncScope())
{
    var example = scope.ServiceProvider.GetRequiredService<Example>();
}

class Example : IAsyncDisposable
{
    public ValueTask DisposeAsync() => default;
}

