// https://twitter.com/okyrylchuk/status/1451579097155465218

using System.Runtime.InteropServices;

unsafe
{
    byte* buffer = (byte*)NativeMemory.Alloc(100);

    NativeMemory.Free(buffer);

    /* This class contains methods that are mainly used to manage native memory.
    public static class NativeMemory
    {
        public unsafe static void* AlignedAlloc(nuint byteCount, nuint alignment);
        public unsafe static void AlignedFree(void* ptr);
        public unsafe static void* AlignedRealloc(void* ptr, nuint byteCount, nuint alignment);
        public unsafe static void* Alloc(nuint byteCount);
        public unsafe static void* Alloc(nuint elementCount, nuint elementSize);
        public unsafe static void* AllocZeroed(nuint byteCount);
        public unsafe static void* AllocZeroed(nuint elementCount, nuint elementSize);
        public unsafe static void Free(void* ptr);
        public unsafe static void* Realloc(void* ptr, nuint byteCount);
    }*/
}



