// https://twitter.com/okyrylchuk/status/1449419872627159040

using System;
using System.IO;
using System.Text;
using System.Text.Json;

JsonWriterOptions writerOptions = new() { Indented = true, };

using MemoryStream stream = new();
using Utf8JsonWriter writer = new(stream, writerOptions);

writer.WriteStartObject();
writer.WriteStartArray("customJsonFormatting");
foreach (double result in new double[] { 10.2, 10 })
{
    writer.WriteStartObject();
    writer.WritePropertyName("value");
    writer.WriteRawValue(FormatNumberValue(result), skipInputValidation: true);
    writer.WriteEndObject();
}
writer.WriteEndArray();
writer.WriteEndObject();
writer.Flush();

string json = Encoding.UTF8.GetString(stream.ToArray());
Console.WriteLine(json);

static string FormatNumberValue(double numberValue)
{
    return numberValue == Convert.ToInt32(numberValue)
        ? numberValue.ToString() + ".0"
        : numberValue.ToString();
}

// Output:
// {
//    "customJsonFormatting": [
//      {
//        "value": 10.2
//      },
//      {
//        "value": 10.0
//      }
//  ]
// }



