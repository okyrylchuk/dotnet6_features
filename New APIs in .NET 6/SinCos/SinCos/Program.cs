// https://twitter.com/okyrylchuk/status/1453828375735373825

using System;

// New methods SinCos, ReciprocalEstimate and ReciprocalSqrtEstimate

// Simultaneously computes Sin and Cos
(double sin, double cos) = Math.SinCos(1.57);
Console.WriteLine($"Sin = {sin}\nCos = {cos}");

// Computes an approximate of 1 / x
double recEst = Math.ReciprocalEstimate(5);
Console.WriteLine($"Reciprocal estimate = {recEst}");

// Computes an approximate of 1 / Sqrt(x)
double recSqrtEst = Math.ReciprocalSqrtEstimate(5);
Console.WriteLine($"Reciprocal sqrt estimate = {recSqrtEst}");

// New overloads

// Min, Max, Abs, Clamp and Sign supports nint and nuint
(nint a, nint b) = (5, 10);
nint min = Math.Min(a, b);
nint max = Math.Max(a, b);
nint abs = Math.Abs(a);
nint clamp = Math.Clamp(abs, min, max);
nint sign = Math.Sign(a);
Console.WriteLine($"Min = {min}\nMax = {max}\nAbs = {abs}");
Console.WriteLine($"Clamp = {clamp}\nSign = {sign}");

// DivRem variants return a tuple
(int quotient, int remainder) = Math.DivRem(2, 7);
Console.WriteLine($"Quotient = {quotient}\nRemainder = {remainder}");

// Output:
// Sin = 0.9999996829318346
// Cos = 0.0007963267107331026
// Reciprocal estimate = 0.2
// Reciprocal sqrt estimate = 0.4472135954999579
// Min = 5
// Max = 10
// Abs = 5
// Clamp = 5
// Sign = 1
// Quotient = 0
// Remainder = 2

