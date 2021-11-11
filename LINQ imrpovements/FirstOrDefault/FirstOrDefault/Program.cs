// https://twitter.com/okyrylchuk/status/1442955912855969793

using System;
using System.Collections.Generic;
using System.Linq;

List<int> list1 = new() { 1, 2, 3 };
int item1 = list1.FirstOrDefault(i => i == 4, -1);
Console.WriteLine(item1); // -1

List<string> list2 = new() { "Item1" };
string item2 = list2.SingleOrDefault(i => i == "Item2", "Not found");
Console.WriteLine(item2); // Not found

// Also you can override the default value for LastOrDefault

