// https://twitter.com/okyrylchuk/status/1446552139665448960

using System;
using System.Text.Json;
using System.Text.Json.Serialization;

Product product = new()
{
    Id = 1,
    Name = "Surface Pro 7",
    Price = 550,
    Category = "Laptops"
};

JsonSerializerOptions options = new() { WriteIndented = true };
string json = JsonSerializer.Serialize(product, options);
Console.WriteLine(json);

class Product : A
{
    [JsonPropertyOrder(2)] // Serialize after Price
    public string Category { get; set; }

    [JsonPropertyOrder(1)] // Serialize after other properties that have default ordering
    public decimal Price { get; set; }

    public string Name { get; set; } // Has default ordering value of 0

    [JsonPropertyOrder(-1)] // Serialize before other properties that have default ordering
    public int Id { get; set; }
}

class A
{
    public int Test { get; set; }
}

// Output:
// {
//   "Id": 1,
//   "Name": "Surface Pro 7",
//   "Price": 550,
//   "Category": "Laptops"
// }

