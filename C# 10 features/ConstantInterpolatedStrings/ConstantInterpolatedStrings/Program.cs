    
// https://twitter.com/okyrylchuk/status/1436049784104800259

const string name = "Oleg";
const string greeting = $"Hello, {name}.";

const string yolo = "YOLO";

[Obsolete($"This method is obsolote because of {yolo}")]
static void Test()
{ }

Test();
Console.WriteLine(yolo); // Output: Hello, Oleg.





