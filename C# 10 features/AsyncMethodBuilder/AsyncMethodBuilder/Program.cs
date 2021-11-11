// https://twitter.com/okyrylchuk/status/1440774491961913345

using System.Runtime.CompilerServices;

class Example
{
    [AsyncMethodBuilder(typeof(AsyncVoidMethodBuilder))]
    public void ExampleMethod()
    {
    }
}

