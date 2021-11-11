
// https://twitter.com/okyrylchuk/status/1436398227927048193

Person person = new()
{
    Name = "Oleg",
    Location = new() { Country = "PL" }
};

if (person is { Name: "Oleg", Location.Country: "PL" })
{
    Console.WriteLine("It's me!");
}

class Person
{
    public string Name { get; set; }
    public Location Location { get; set; }
}

class Location
{
    public string Country { get; set; }
}

