using System.IO;

namespace ZTn.Bnet.PclAdapters
{
    public class PortableDirectory
    {
        /// <inheritdoc />
        public static void CreateDirectory(string path)
        {
            Directory.CreateDirectory(path);
        }
    }
}