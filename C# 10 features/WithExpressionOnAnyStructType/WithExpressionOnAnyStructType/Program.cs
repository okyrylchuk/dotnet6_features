// https://twitter.com/okyrylchuk/status/1441084950518849536    

using System;

Product potato = new() { Name = "Potato", Category = "Vegetable" };
Console.WriteLine($"{potato.Name} {potato.Category}");
// Output: Potato Vegetable

Product tomato = potato with { Name = "Tomato" };
Console.WriteLine($"{tomato.Name} {tomato.Category}");
// Output: Tomato Vegetable

struct Product
{
    public string Name { get; set; }
    public string Category { get; set; }
}

