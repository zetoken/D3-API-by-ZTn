using System.Text;

namespace ZTn.Bnet.Portable.Windows
{
    internal class PortableEncoding : IPortableEncoding
    {
        /// <inheritdoc />
        public Encoding Default
        {
            get { return Encoding.Default; }
        }
    }
}