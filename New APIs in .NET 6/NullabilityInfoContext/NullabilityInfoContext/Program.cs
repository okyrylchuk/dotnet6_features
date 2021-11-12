// https://twitter.com/okyrylchuk/status/1446893764694380548

using System;
using System.Reflection;

var example = new Example();
var nullabilityInfoContext = new NullabilityInfoContext();
foreach (var propertyInfo in example.GetType().GetProperties())
{
    var nullabilityInfo = nullabilityInfoContext.Create(propertyInfo);
    Console.WriteLine($"{propertyInfo.Name} property is {nullabilityInfo.WriteState}");
}

// Output:
// Name property is Nullable
// Value property is NotNull

class Example
{
    public string? Name { get; set; }
    public string Value { get; set; }
}

