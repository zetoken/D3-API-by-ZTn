using System.IO;

namespace ZTn.Bnet.PclAdapter
{
    public class PortableDirectory
    {
        public static void CreateDirectory(string path)
        {
            Directory.CreateDirectory(path);
        }
    }
}