using System.IO;

namespace ZTn.Bnet.Portable
{
    public interface IPortableFile
    {
        Stream Create(string path);

        bool Exists(string path);

        Stream Open(string path, PortableFileMode mode);
    }
}