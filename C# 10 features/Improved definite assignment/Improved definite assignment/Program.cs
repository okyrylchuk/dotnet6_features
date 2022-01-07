var example = new Example();
if ((example != null && example.TryGetValue(out SomeValue value1)) == true)
{
    var _ = value1.Id;
}

// With null conditional operator
if (example?.TryGetValue(out SomeValue value2) == true)
{
    var _ = value2.Id;
}

// With null-coalescing operator
if (example?.TryGetValue(out SomeValue value3) ?? false)
{
    var _ = value3.Id;
}

public class SomeValue
{
    public int Id { get; set; }
}

public class Example
{
    public bool TryGetValue(out SomeValue value)
    {
        value = new SomeValue();
        return true;
    }
}

