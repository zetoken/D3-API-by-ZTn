using System.IO;

namespace ZTn.Bnet.Portable
{
    public abstract class PortableFile
    {
        public static Stream Create(string path)
        {
            return PortableInjector.Resolve<IPortableFile>().Create(path);
        }

        public static bool Exists(string path)
        {
            return PortableInjector.Resolve<IPortableFile>().Exists(path);
        }

        public static Stream Open(string path, PortableFileMode mode)
        {
            return PortableInjector.Resolve<IPortableFile>().Open(path, mode);
        }
    }
}
