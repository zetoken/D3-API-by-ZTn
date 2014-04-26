using System.Text;

namespace ZTn.Bnet.Portable
{
    public class PortableEncoding
    {
        public static Encoding Default
        {
            get
            {
                return PortableInjector.Resolve<IPortableEncoding>().Default;
            }
        }
    }
}