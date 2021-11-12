// https://twitter.com/okyrylchuk/status/1449838369660362752

using System;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Net.Http.Json;
using System.Threading.Tasks;

var userHandlers = new[]
{
    "users/okyrylchuk",
    "users/jaredpar",
    "users/davidfowl"
};

using HttpClient client = new()
{
    BaseAddress = new Uri("https://api.github.com"),
};
client.DefaultRequestHeaders.UserAgent.Add(new ProductInfoHeaderValue("DotNet", "6"));

ParallelOptions options = new()
{
    MaxDegreeOfParallelism = 3
};
await Parallel.ForEachAsync(userHandlers, options, async (uri, token) =>
{
    var user = await client.GetFromJsonAsync<GitHubUser>(uri, token);
    Console.WriteLine($"Name: {user.Name}\nBio: {user.Bio}\n");
});

public class GitHubUser
{
    public string Name { get; set; }
    public string Bio { get; set; }
}

// Output:
// Name: David Fowler
// Bio: Partner Software Architect at Microsoft on the ASP.NET team, Creator of SignalR
// 
// Name: Oleg Kyrylchuk
// Bio: Software developer | Dotnet | C# | Azure
// 
// Name: Jared Parsons
// Bio: Developer on the C# compiler



