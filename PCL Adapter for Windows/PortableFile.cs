using System.IO;

namespace ZTn.Bnet.PclAdapter
{
    public class PortableFile
    {
        /// <inheritdoc />
        public static Stream Create(string path)
        {
            return File.Create(path);
        }

        /// <inheritdoc />
        public static bool Exists(string path)
        {
            return File.Exists(path);
        }

        /// <inheritdoc />
        public static Stream Open(string path, PortableFileMode mode)
        {
            return File.Open(path, (FileMode)mode);
        }
    }
}