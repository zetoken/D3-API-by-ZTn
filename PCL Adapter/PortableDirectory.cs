namespace ZTn.Bnet.Portable
{
    public abstract class PortableDirectory
    {
        public static void CreateDirectory(string path)
        {
            PortableInjector.Resolve<IPortableDirectory>().CreateDirectory(path);
        }
    }
}