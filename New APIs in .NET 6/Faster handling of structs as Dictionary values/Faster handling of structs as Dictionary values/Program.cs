// https://twitter.com/okyrylchuk/status/1454126098959196161

using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;

Dictionary<int, MyStruct> dictionary = new()
{
    { 1, new MyStruct { Count = 100 } }
};

int key = 1;
ref MyStruct value = ref CollectionsMarshal.GetValueRefOrNullRef(dictionary, key);
// Returns Unsafe.NullRef<TValue>() if it doesn't exist; check using Unsafe.IsNullRef(ref value)
if (!Unsafe.IsNullRef(ref value))
{
    Console.WriteLine(value.Count); // Output: 100

    // Mutate in-place
    value.Count++;
    Console.WriteLine(value.Count); // Output: 101
}

struct MyStruct
{
    public int Count { get; set; }
}
