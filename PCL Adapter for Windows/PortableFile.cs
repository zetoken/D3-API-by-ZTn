using System.IO;

namespace ZTn.Bnet.Portable.Windows
{
    internal class PortableFile : IPortableFile
    {
        /// <inheritdoc />
        public Stream Create(string path)
        {
            return File.Create(path);
        }

        /// <inheritdoc />
        public bool Exists(string path)
        {
            return File.Exists(path);
        }

        /// <inheritdoc />
        public Stream Open(string path, PortableFileMode mode)
        {
            return File.Open(path, (FileMode)mode);
        }
    }
}