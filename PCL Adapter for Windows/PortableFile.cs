using System.IO;

namespace ZTn.Bnet.PclAdapter
{
    public class PortableFile
    {
        public static Stream Create(string path)
        {
            return File.Create(path);
        }

        public static bool Exists(string path)
        {
            return File.Exists(path);
        }

        public static Stream Open(string path, PortableFileMode mode)
        {
            return File.Open(path, (FileMode)mode);
        }
    }
}