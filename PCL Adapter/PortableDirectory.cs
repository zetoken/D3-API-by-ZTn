using System;

namespace ZTn.Bnet.PclAdapters
{
    public abstract class PortableDirectory
    {
        public static void CreateDirectory(string path)
        {
            throw new NotImplementedException("Should be implemented in native library.");
        }
    }
}