// https://twitter.com/okyrylchuk/status/1448381745154469891

using System;
using System.Threading;

// One constructor: public PeriodicTimer(TimeSpan period)
using PeriodicTimer timer = new(TimeSpan.FromSeconds(1));

while (await timer.WaitForNextTickAsync())
{
    Console.WriteLine(DateTime.UtcNow);
}

// Output:
// 13 - Oct - 21 19:58:05 PM
// 13 - Oct - 21 19:58:06 PM
// 13 - Oct - 21 19:58:07 PM
// 13 - Oct - 21 19:58:08 PM
// 13 - Oct - 21 19:58:09 PM
// 13 - Oct - 21 19:58:10 PM
// 13 - Oct - 21 19:58:11 PM
// 13 - Oct - 21 19:58:12 PM
// ...

