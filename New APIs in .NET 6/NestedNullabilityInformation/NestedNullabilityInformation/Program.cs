// https://twitter.com/okyrylchuk/status/1447294297364172808

using System;
using System.Reflection;

Type exampleType = typeof(Example);
PropertyInfo notNullableArrayPI = exampleType.GetProperty(nameof(Example.NotNullableArray));
PropertyInfo nullableArrayPI = exampleType.GetProperty(nameof(Example.NullableArray));

NullabilityInfoContext nullabilityInfoContext = new();

NullabilityInfo notNullableArrayNI = nullabilityInfoContext.Create(notNullableArrayPI);
Console.WriteLine(notNullableArrayNI.ReadState);              // NotNull
Console.WriteLine(notNullableArrayNI.ElementType.ReadState);  // Nullable

NullabilityInfo nullableArrayNI = nullabilityInfoContext.Create(nullableArrayPI);
Console.WriteLine(nullableArrayNI.ReadState);                // Nullable
Console.WriteLine(nullableArrayNI.ElementType.ReadState);    // Nullable

class Example
{
    public string?[] NotNullableArray { get; set; }
    public string?[]? NullableArray { get; set; }
}
