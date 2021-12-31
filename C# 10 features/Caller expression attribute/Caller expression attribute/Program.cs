// https://twitter.com/okyrylchuk/status/1476926159078182912

using System.Runtime.CompilerServices;

void TestMethod(object obj, [CallerArgumentExpression("obj")] string? message = null)
{
    Console.WriteLine("Expression is " + message);
}

TestMethod(new object());
TestMethod("hello");
TestMethod(1 + 2 + 3);
TestMethod(() => { });

// Output: 
// Expression is new object()
// Expression is "hello"
// Expression is 1 + 2 + 3
// Expression is () => { }

