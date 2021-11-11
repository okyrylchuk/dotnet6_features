// https://twitter.com/okyrylchuk/status/1450562582205632516

using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

static async IAsyncEnumerable<int> GetNumbersAsync(int n)
{
    for (int i = 0; i < n; i++)
    {
        await Task.Delay(1000);
        yield return i;
    }
}
// Serialization using IAsyncEnumerable
JsonSerializerOptions options = new() { WriteIndented = true };
using Stream outputStream = Console.OpenStandardOutput();
var data = new { Data = GetNumbersAsync(5) };
await JsonSerializer.SerializeAsync(outputStream, data, options);
// Output:
// {
//    "Data": [
//      0,
//      1,
//      2,
//      3,
//      4
//  ]
// }

// Deserialization using IAsyncEnumerable
using MemoryStream memoryStream = new(Encoding.UTF8.GetBytes("[0,1,2,3,4]"));
// Wraps the UTF-8 encoded text into an IAsyncEnumerable<T> that can be used to deserialize root-level JSON arrays in a streaming manner.
await foreach (int item in JsonSerializer.DeserializeAsyncEnumerable<int>(memoryStream))
{
    Console.WriteLine(item);
}
// Output:
// 0
// 1
// 2
// 3
// 4




