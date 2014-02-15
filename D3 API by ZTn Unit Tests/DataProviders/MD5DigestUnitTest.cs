using System.Linq;
using System.Text;
using NUnit.Framework;

namespace ZTn.BNet.D3.DataProviders
{
    [TestFixture]
    public class MD5DigestUnitTest
    {
        static readonly string[] Messages =
        {
            "",
            "a",
            "abc",
            "abcdefghijklmnopqrstuvwxyz"
        };

        static readonly string[] Digests =
        {
            "d41d8cd98f00b204e9800998ecf8427e",
            "0cc175b9c0f1b6a831c399e269772661",
            "900150983cd24fb0d6963f7d28e17f72",
            "c3fcd3d76192e4007dfb496cca67e13b"
        };

        public void ProcessMessage(int index)
        {
            var bytes = Encoding.Default.GetBytes(Messages[index]);
            var output = MD5Digest.ComputeMD5(bytes);
            Assert.AreEqual(Digests[index], output.Aggregate("", (current, b) => current + b.ToString("x2")));
        }

        [Test]
        public void Digest0()
        {
            ProcessMessage(0);
        }

        [Test]
        public void Digest1()
        {
            ProcessMessage(1);
        }

        [Test]
        public void Digest2()
        {
            ProcessMessage(2);
        }

        [Test]
        public void Digest3()
        {
            ProcessMessage(3);
        }
    }
}
