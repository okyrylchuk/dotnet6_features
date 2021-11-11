// https://twitter.com/okyrylchuk/status/1438582594040471555

using System;

Person me = new() { FirstName = "Oleg", LastName = "Kyrylchuk" };

// 1. Built-in formatting for display
Console.WriteLine(me);
// Output: Person { FirstName = Oleg, LastName = Kyrylchuk }

// 2. Create a new record struct using with-expression
Person otherPerson = me with { FirstName = "John" };
Console.WriteLine(otherPerson);
// Output: Person { FirstName = John, LastName = Kyrylchuk }

// 3. Value equality
Person anotherMe = new() { FirstName = "Oleg", LastName = "Kyrylchuk" };
Console.WriteLine(me == anotherMe);
// Output: True

record struct Person
{
    public string FirstName { get; init; }
    public string LastName { get; init; }
}

// 4. You can create a positional record struct
record struct Product(string Name, decimal Price);

