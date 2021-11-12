// https://twitter.com/okyrylchuk/status/1447653470123798540

using System;

ExampleMethod(null);

void ExampleMethod(object param)
{
    ArgumentNullException.ThrowIfNull(param);

    // Do something
}

