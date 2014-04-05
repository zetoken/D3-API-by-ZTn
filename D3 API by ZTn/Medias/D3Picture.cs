using System;
using System.IO;

namespace ZTn.BNet.D3.Medias
{
    /// <summary>
    /// Represents a picture retrieved from battle.net servers.
    /// </summary>
    public class D3Picture
    {
        public Byte[] Bytes { get; set; }

        /// <summary>
        /// Creates a new empty <see cref="D3Picture"/> instance.
        /// </summary>
        public D3Picture()
        {
        }

        /// <summary>
        /// Creates a new <see cref="D3Picture"/> instance from a <see cref="Stream"/>.
        /// </summary>
        /// <param name="stream"></param>
        public D3Picture(Stream stream)
        {
            using (var ms = new MemoryStream())
            {
                stream.CopyTo(ms);
                Bytes = ms.ToArray();
            }
        }
    }
}