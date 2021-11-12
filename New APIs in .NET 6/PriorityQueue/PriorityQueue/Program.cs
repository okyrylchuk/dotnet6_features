// https://twitter.com/okyrylchuk/status/1450191916012904450

using System;
using System.Collections.Generic;

PriorityQueue<string, int> priorityQueue = new();

priorityQueue.Enqueue("Second", 2);
priorityQueue.Enqueue("Fourth", 4);
priorityQueue.Enqueue("Third 1", 3);
priorityQueue.Enqueue("Third 2", 3);
priorityQueue.Enqueue("First", 1);

while (priorityQueue.Count > 0)
{
    string item = priorityQueue.Dequeue();
    Console.WriteLine(item);
}

// Output:
// First
// Second
// Third 2
// Third 1
// Fourth




