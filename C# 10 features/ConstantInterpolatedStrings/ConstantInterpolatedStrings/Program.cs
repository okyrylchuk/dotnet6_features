
// https://twitter.com/okyrylchuk/status/1436049784104800259

const string name = "Oleg";
const string greeting = $"Hello, {name}.";

[Obsolete($"This method is obsolete because of {greeting}")]
static void Test()
{ }

Test();
Console.WriteLine(greeting); // Output: Hello, Oleg.
