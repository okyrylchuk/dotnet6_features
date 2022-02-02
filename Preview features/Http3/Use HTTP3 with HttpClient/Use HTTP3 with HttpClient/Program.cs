
using System.Net;

var client = new HttpClient()
{
    DefaultRequestVersion = HttpVersion.Version30,
    DefaultVersionPolicy = HttpVersionPolicy.RequestVersionExact
};

var response = await client.GetAsync("https://localhost:5001/");
Console.WriteLine($"version: {response.Version}");

