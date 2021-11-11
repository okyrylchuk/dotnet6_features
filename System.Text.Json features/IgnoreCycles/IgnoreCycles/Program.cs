// https://twitter.com/okyrylchuk/status/1445842793578962947

using System;
using System.Collections.Generic;
using System.Text.Json;
using System.Text.Json.Serialization;

Category dotnet = new()
{
    Name = ".NET 6",
};
Category systemTextJson = new()
{
    Name = "System.Text.Json",
    Parent = dotnet
};
dotnet.Children.Add(systemTextJson);

JsonSerializerOptions options = new()
{
    ReferenceHandler = ReferenceHandler.IgnoreCycles,
    WriteIndented = true
};

string dotnetJson = JsonSerializer.Serialize(dotnet, options);
Console.WriteLine($"{dotnetJson}");

public class Category
{
    public string Name { get; set; }
    public Category Parent { get; set; }
    public List<Category> Children { get; set; } = new();
}

// Output:
// {
//   "Name": ".NET 6",
//   "Parent": null,
//   "Children": [
//     {
//       "Name": "System.Text.Json",
//       "Parent": null,
//       "Children": []
//     }
//   ]
// }

