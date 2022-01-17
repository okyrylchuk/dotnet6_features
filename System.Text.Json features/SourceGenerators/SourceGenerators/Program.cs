// https://twitter.com/okyrylchuk/status/1483206502274015234

using System;
using System.Text.Json;
using System.Text.Json.Serialization;

var example = new Example { Message = "Hello, world!" };
var json = JsonSerializer.Serialize(example, ExampleContext.Default.Example);
Console.WriteLine(json);
// Output:
// {
//    "Message": "Hello, world!"
// }

var deserializedExample = JsonSerializer.Deserialize<Example>(json, ExampleContext.Default.Example);
Console.WriteLine(deserializedExample.Message);
//// Output:
//// Hello, world!

internal class Example
{
    public string Message { get; set; }
}

[JsonSourceGenerationOptions(WriteIndented = true)]
[JsonSerializable(typeof(Example))]
internal partial class ExampleContext : JsonSerializerContext
{
}
