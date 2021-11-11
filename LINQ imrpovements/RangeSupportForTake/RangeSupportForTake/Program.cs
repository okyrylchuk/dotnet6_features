// https://twitter.com/okyrylchuk/status/1444748092692123652

using System;
using System.Collections.Generic;
using System.Linq;

IEnumerable<int> numbers = new int[] { 1, 2, 3, 4, 5 };

IEnumerable<int> taken1 = numbers.Take(2..4);
foreach (int i in taken1)
    Console.WriteLine(i);
// Output:
// 3
// 4

IEnumerable<int> taken2 = numbers.Take(..3);
foreach (int i in taken2)
    Console.WriteLine(i);
// Output:
// 1
// 2
// 3

IEnumerable<int> taken3 = numbers.Take(3..);
foreach (int i in taken3)
    Console.WriteLine(i);
// Output:
// 4
// 5


