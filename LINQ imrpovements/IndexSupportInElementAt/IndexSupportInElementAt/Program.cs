// https://twitter.com/okyrylchuk/status/1444383279847776257  

using System;
using System.Collections.Generic;
using System.Linq;

IEnumerable<int> numbers = new int[] { 1, 2, 3, 4, 5 };
int last = numbers.ElementAt(^0);
Console.WriteLine(last); // 5

