// https://twitter.com/okyrylchuk/status/1443621672968466439

using System;
using System.Collections.Generic;
using System.Linq;

IEnumerable<int> numbers = Enumerable.Range(1, 505);
IEnumerable<int[]> chunks = numbers.Chunk(100);

foreach (int[] chunk in chunks)
{
    Console.WriteLine($"{chunk.First()}...{chunk.Last()}");
}

//  Output:
//  1...100
//  101...200
//  201...300
//  301...400
//  401...500
//  501...505

