// https://twitter.com/okyrylchuk/status/1437145335063883782

global using System;
global using System.Collections.Generic;
global using System.Linq;
global using System.Threading.Tasks;

List<int> list = new() { 1, 2, 3, 4 };
int sum = list.Sum();
Console.WriteLine(sum);

await Task.Delay(1000);
