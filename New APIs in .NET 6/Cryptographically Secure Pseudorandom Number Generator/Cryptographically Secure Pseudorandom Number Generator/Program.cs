// https://twitter.com/okyrylchuk/status/1449098382111346692

using System.Security.Cryptography;

// Fills an array of 300 bytes with a cryptographically strong random sequence of values.
// GetBytes(byte[] data);
// GetBytes(byte[] data, int offset, int count)
// GetBytes(int count)
// GetBytes(Span<byte> data)
byte[] bytes = RandomNumberGenerator.GetBytes(300);


