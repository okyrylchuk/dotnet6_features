// https://twitter.com/okyrylchuk/status/1438926317383294982

using System;

Person person = new() { Name = "Oleg" };

Console.WriteLine(person.Id + " " + person.Name);
// Output: 0cc6caac-d061-4f46-9301-c7cc2a012e47 Oleg

struct Person
{
    public Guid Id { get; init; } = Guid.NewGuid();
    public string Name { get; set; }
}

