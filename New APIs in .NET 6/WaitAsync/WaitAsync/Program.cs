// https://twitter.com/okyrylchuk/status/1453477054364651528

using System;
using System.Threading.Tasks;

Task operationTask = DoSomethingLongAsync();

await operationTask.WaitAsync(TimeSpan.FromSeconds(5));

async Task DoSomethingLongAsync()
{
    Console.WriteLine("DoSomethingLongAsync started.");
    await Task.Delay(TimeSpan.FromSeconds(10));
    Console.WriteLine("DoSomethingLongAsync ended.");
}

// Output:
// DoSomethingLongAsync started.
// Unhandled exception.System.TimeoutException: The operation has timed out.

