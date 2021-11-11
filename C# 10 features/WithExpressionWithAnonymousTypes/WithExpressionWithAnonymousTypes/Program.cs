// https://twitter.com/okyrylchuk/status/1442584364450209805    

using System;

var potato = new { Name = "Potato", Category = "Vegetable" };
Console.WriteLine($"{potato.Name} {potato.Category}");
// Output: Potato Vegetable

var onion = potato with { Name = "Onion" };
Console.WriteLine($"{onion.Name} {onion.Category}");
// Output: Onion Vegetable



