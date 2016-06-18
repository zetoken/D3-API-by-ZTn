using System;
using System.IO;

namespace ZTn.Bnet.PclAdapter
{
    public abstract class PortableFile
    {
        public static Stream Create(string path)
        {
            throw new NotImplementedException("Should be implemented in native library.");
        ;}

        public static bool Exists(string path)
        {
            throw new NotImplementedException("Should be implemented in native library.");
        }

        public static Stream Open(string path, PortableFileMode mode)
        {
            throw new NotImplementedException("Should be implemented in native library.");
        }
    }
}
