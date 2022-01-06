using System.Runtime.CompilerServices;
using System.Text;

var example = new Example();

example.Print($"ExampleInterpolatedStringHandler invoked - DateTime {DateTime.Now}");
Console.WriteLine();
example.Print($"ExampleInterpolatedStringHandler invoked - Decimal {100.5m}");
Console.WriteLine();
example.Print("It doesn't invoke the interpolated string handler, because argument is a string");

public class Example
{
    public void Print(string str)
    {
        Console.WriteLine(str);
    }

    public void Print(ExampleInterpolatedStringHandler builder)
    {
        Console.WriteLine(builder.GetFormattedText());
    }
}

[InterpolatedStringHandler]
public ref struct ExampleInterpolatedStringHandler
{
    private readonly StringBuilder _builder;

    public ExampleInterpolatedStringHandler(int literalLength, int formattedCount)
    {
        _builder = new StringBuilder(literalLength);
        Console.WriteLine($"Literal length: {literalLength}, formattedCount: {formattedCount}");
    }

    public void AppendLiteral(string s)
    {
        Console.WriteLine($"AppendLiteral called: {s}");
        _builder.Append(s);
    }

    public void AppendFormatted<T>(T t)
    {
        Console.WriteLine($"AppendFormatted called: {t} is of type {typeof(T)}");
        _builder.Append(t?.ToString());
    }

    internal string GetFormattedText() => _builder.ToString();
}

