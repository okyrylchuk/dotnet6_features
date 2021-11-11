// https://twitter.com/okyrylchuk/status/1437864086373642241

Product product = new() { Name = "Bread" };
Console.WriteLine(product.ToString());
// Output: Bread

public record Product
{
    public string Name { get; init; }

    public sealed override string ToString()
    {
        return Name;
    }
}

