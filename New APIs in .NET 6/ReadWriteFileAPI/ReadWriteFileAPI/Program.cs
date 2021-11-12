https://twitter.com/okyrylchuk/status/1451984264912850948

using Microsoft.Win32.SafeHandles;
using System;
using System.IO;
using System.Text;

using SafeFileHandle handle = File.OpenHandle("file.txt", access: FileAccess.ReadWrite);

// Write to file
byte[] strBytes = Encoding.UTF8.GetBytes("Hello world");
ReadOnlyMemory<byte> buffer1 = new(strBytes);
await RandomAccess.WriteAsync(handle, buffer1, 0);

// Get file length
long length = RandomAccess.GetLength(handle);

// Read from file
Memory<byte> buffer2 = new(new byte[length]);
await RandomAccess.ReadAsync(handle, buffer2, 0);
string content = Encoding.UTF8.GetString(buffer2.ToArray());
Console.WriteLine(content); // Hello world

/* Provides offset-based APIs for reading and writing files in a thread-safe manner.
public static class RandomAccess
{
    public static long GetLength(SafeFileHandle handle);
    public static int Read(SafeFileHandle handle, Span<byte> buffer, long fileOffset);
    public static long Read(SafeFileHandle handle, IReadOnlyList<Memory<byte>> buffers, long fileOffset);
    public static ValueTask<int> ReadAsync(SafeFileHandle handle, Memory<byte> buffer, long fileOffset, CancellationToken ct = default(CancellationToken));
    public static ValueTask<long> ReadAsync(SafeFileHandle handle, IReadOnlyList<Memory<byte>> buffers, long fileOffset, CancellationToken ct = default(CancellationToken));
    public static void Write(SafeFileHandle handle, ReadOnlySpan<byte> buffer, long fileOffset);
    public static void Write(SafeFileHandle handle, IReadOnlyList<ReadOnlyMemory<byte>> buffers, long fileOffset);
    public static ValueTask WriteAsync(SafeFileHandle handle, ReadOnlyMemory<byte> buffer, long fileOffset, CancellationToken ct = default(CancellationToken));
    public static ValueTask WriteAsync(SafeFileHandle handle, IReadOnlyList<ReadOnlyMemory<byte>> buffers, long fileOffset, CancellationToken ct = default(CancellationToken));
}*/

