namespace ZTn.Bnet.Portable.Windows
{
    public class RegisterPcl
    {
        public static void Register()
        {
            PortableInjector.Register<IPortableDirectory>(new PortableDirectory());
            PortableInjector.Register<IPortableEncoding>(new PortableEncoding());
            PortableInjector.Register<IPortableFile>(new PortableFile());
        }
    }
}
