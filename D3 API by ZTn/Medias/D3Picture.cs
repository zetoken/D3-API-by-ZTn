using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace ZTn.BNet.D3.Medias
{
    public class D3Picture
    {
        public Byte[] bytes;

        public D3Picture(Stream stream)
        {
            using (MemoryStream ms = new MemoryStream())
            {
                stream.CopyTo(ms);
                bytes = ms.ToArray();
            }
        }
    }
}
