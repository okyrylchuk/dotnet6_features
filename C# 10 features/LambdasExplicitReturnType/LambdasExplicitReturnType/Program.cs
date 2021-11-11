// https://twitter.com/okyrylchuk/status/1440050213175975936

Test<int>();

var l1 = string () => string.Empty;
var l2 = int () => 0;
var l3 = static void () => { };

void Test<T>()
{
    var l4 = T () => default;
}


