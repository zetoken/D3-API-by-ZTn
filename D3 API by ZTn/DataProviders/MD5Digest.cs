using System;

namespace ZTn.BNet.D3.DataProviders
{
    /// <summary>
    /// Implementation of MD5 based on BouncyCastle C#.
    /// </summary>
    /// <remarks>
    /// Needed because System.Security.Cryptography namespace is not supported in Portable Class Library.
    /// </remarks>
    public class MD5Digest
    {
        private readonly byte[] xBuf;
        private int xBufOff;

        private long byteCount;

        // IV's
        private uint h1, h2, h3, h4;

        private readonly uint[] x = new uint[16];
        private int xOff;

        /// <summary>
        /// Creates a new instance of <see cref="MD5Digest"/>.
        /// </summary>
        public MD5Digest()
        {
            xBuf = new byte[4];
            Reset();
        }

        /// <summary>
        /// Gets the size in bytes of the MD5 hash.
        /// </summary>
        public int DigestSize
        {
            get { return 16; }
        }

        /// <summary>
        /// Computes the MD5 hash of an array of bytes.
        /// </summary>
        /// <param name="bytes"></param>
        /// <returns></returns>
        public byte[] ComputeHash(byte[] bytes)
        {
            var output = new byte[DigestSize];

            BlockUpdate(bytes, 0, bytes.Length);
            DoFinal(output, 0);

            return output;
        }

        /// <summary>
        /// Computes the MD5 hash of an array of bytes without having to explicitely create a <see cref="MD5Digest"/> instance.
        /// </summary>
        /// <param name="bytes"></param>
        /// <returns></returns>
        public static byte[] ComputeMD5(byte[] bytes)
        {
            return new MD5Digest().ComputeHash(bytes);
        }

        private void DoFinal(byte[] output, int outOff)
        {
            Finish();

            UInt32_To_LE(h1, output, outOff);
            UInt32_To_LE(h2, output, outOff + 4);
            UInt32_To_LE(h3, output, outOff + 8);
            UInt32_To_LE(h4, output, outOff + 12);

            Reset();
        }

        /// <summary>
        /// Reset the chaining variables to the IV values.
        /// </summary>
        private void Reset()
        {
            byteCount = 0;
            xBufOff = 0;
            Array.Clear(xBuf, 0, xBuf.Length);

            h1 = 0x67452301;
            h2 = 0xefcdab89;
            h3 = 0x98badcfe;
            h4 = 0x10325476;

            xOff = 0;

            for (int i = 0; i != x.Length; i++)
            {
                x[i] = 0;
            }
        }

        private void Finish()
        {
            long bitLength = (byteCount << 3);

            // add the pad bytes.
            Update(128);

            while (xBufOff != 0)
            {
                Update(0);
            }
            ProcessLength(bitLength);
            ProcessBlock();
        }

        private void Update(byte input)
        {
            xBuf[xBufOff++] = input;

            if (xBufOff == xBuf.Length)
            {
                ProcessWord(xBuf, 0);
                xBufOff = 0;
            }

            byteCount++;
        }

        private void BlockUpdate(byte[] input, int inOff, int length)
        {
            // Fill the current word
            while ((xBufOff != 0) && (length > 0))
            {
                Update(input[inOff]);
                inOff++;
                length--;
            }

            // Process whole words.
            while (length > xBuf.Length)
            {
                ProcessWord(input, inOff);

                inOff += xBuf.Length;
                length -= xBuf.Length;
                byteCount += xBuf.Length;
            }

            // Load in the remainder.
            while (length > 0)
            {
                Update(input[inOff]);

                inOff++;
                length--;
            }
        }

        private void ProcessWord(byte[] input, int inOff)
        {
            x[xOff] = LE_To_UInt32(input, inOff);

            if (++xOff == 16)
            {
                ProcessBlock();
            }
        }

        private void ProcessLength(long bitLength)
        {
            if (xOff > 14)
            {
                if (xOff == 15)
                {
                    x[15] = 0;
                }

                ProcessBlock();
            }

            for (int i = xOff; i < 14; ++i)
            {
                x[i] = 0;
            }

            x[14] = (uint)((ulong)bitLength);
            x[15] = (uint)((ulong)bitLength >> 32);
        }

        private void ProcessBlock()
        {
            uint a = h1;
            uint b = h2;
            uint c = h3;
            uint d = h4;

            // Round 1 - F cycle, 16 times.
            a = RotateLeft((a + F(b, c, d) + x[0] + 0xd76aa478), S11) + b;
            d = RotateLeft((d + F(a, b, c) + x[1] + 0xe8c7b756), S12) + a;
            c = RotateLeft((c + F(d, a, b) + x[2] + 0x242070db), S13) + d;
            b = RotateLeft((b + F(c, d, a) + x[3] + 0xc1bdceee), S14) + c;
            a = RotateLeft((a + F(b, c, d) + x[4] + 0xf57c0faf), S11) + b;
            d = RotateLeft((d + F(a, b, c) + x[5] + 0x4787c62a), S12) + a;
            c = RotateLeft((c + F(d, a, b) + x[6] + 0xa8304613), S13) + d;
            b = RotateLeft((b + F(c, d, a) + x[7] + 0xfd469501), S14) + c;
            a = RotateLeft((a + F(b, c, d) + x[8] + 0x698098d8), S11) + b;
            d = RotateLeft((d + F(a, b, c) + x[9] + 0x8b44f7af), S12) + a;
            c = RotateLeft((c + F(d, a, b) + x[10] + 0xffff5bb1), S13) + d;
            b = RotateLeft((b + F(c, d, a) + x[11] + 0x895cd7be), S14) + c;
            a = RotateLeft((a + F(b, c, d) + x[12] + 0x6b901122), S11) + b;
            d = RotateLeft((d + F(a, b, c) + x[13] + 0xfd987193), S12) + a;
            c = RotateLeft((c + F(d, a, b) + x[14] + 0xa679438e), S13) + d;
            b = RotateLeft((b + F(c, d, a) + x[15] + 0x49b40821), S14) + c;

            // Round 2 - G cycle, 16 times.
            a = RotateLeft((a + G(b, c, d) + x[1] + 0xf61e2562), S21) + b;
            d = RotateLeft((d + G(a, b, c) + x[6] + 0xc040b340), S22) + a;
            c = RotateLeft((c + G(d, a, b) + x[11] + 0x265e5a51), S23) + d;
            b = RotateLeft((b + G(c, d, a) + x[0] + 0xe9b6c7aa), S24) + c;
            a = RotateLeft((a + G(b, c, d) + x[5] + 0xd62f105d), S21) + b;
            d = RotateLeft((d + G(a, b, c) + x[10] + 0x02441453), S22) + a;
            c = RotateLeft((c + G(d, a, b) + x[15] + 0xd8a1e681), S23) + d;
            b = RotateLeft((b + G(c, d, a) + x[4] + 0xe7d3fbc8), S24) + c;
            a = RotateLeft((a + G(b, c, d) + x[9] + 0x21e1cde6), S21) + b;
            d = RotateLeft((d + G(a, b, c) + x[14] + 0xc33707d6), S22) + a;
            c = RotateLeft((c + G(d, a, b) + x[3] + 0xf4d50d87), S23) + d;
            b = RotateLeft((b + G(c, d, a) + x[8] + 0x455a14ed), S24) + c;
            a = RotateLeft((a + G(b, c, d) + x[13] + 0xa9e3e905), S21) + b;
            d = RotateLeft((d + G(a, b, c) + x[2] + 0xfcefa3f8), S22) + a;
            c = RotateLeft((c + G(d, a, b) + x[7] + 0x676f02d9), S23) + d;
            b = RotateLeft((b + G(c, d, a) + x[12] + 0x8d2a4c8a), S24) + c;

            // Round 3 - H cycle, 16 times.
            a = RotateLeft((a + H(b, c, d) + x[5] + 0xfffa3942), S31) + b;
            d = RotateLeft((d + H(a, b, c) + x[8] + 0x8771f681), S32) + a;
            c = RotateLeft((c + H(d, a, b) + x[11] + 0x6d9d6122), S33) + d;
            b = RotateLeft((b + H(c, d, a) + x[14] + 0xfde5380c), S34) + c;
            a = RotateLeft((a + H(b, c, d) + x[1] + 0xa4beea44), S31) + b;
            d = RotateLeft((d + H(a, b, c) + x[4] + 0x4bdecfa9), S32) + a;
            c = RotateLeft((c + H(d, a, b) + x[7] + 0xf6bb4b60), S33) + d;
            b = RotateLeft((b + H(c, d, a) + x[10] + 0xbebfbc70), S34) + c;
            a = RotateLeft((a + H(b, c, d) + x[13] + 0x289b7ec6), S31) + b;
            d = RotateLeft((d + H(a, b, c) + x[0] + 0xeaa127fa), S32) + a;
            c = RotateLeft((c + H(d, a, b) + x[3] + 0xd4ef3085), S33) + d;
            b = RotateLeft((b + H(c, d, a) + x[6] + 0x04881d05), S34) + c;
            a = RotateLeft((a + H(b, c, d) + x[9] + 0xd9d4d039), S31) + b;
            d = RotateLeft((d + H(a, b, c) + x[12] + 0xe6db99e5), S32) + a;
            c = RotateLeft((c + H(d, a, b) + x[15] + 0x1fa27cf8), S33) + d;
            b = RotateLeft((b + H(c, d, a) + x[2] + 0xc4ac5665), S34) + c;

            // Round 4 - K cycle, 16 times.
            a = RotateLeft((a + K(b, c, d) + x[0] + 0xf4292244), S41) + b;
            d = RotateLeft((d + K(a, b, c) + x[7] + 0x432aff97), S42) + a;
            c = RotateLeft((c + K(d, a, b) + x[14] + 0xab9423a7), S43) + d;
            b = RotateLeft((b + K(c, d, a) + x[5] + 0xfc93a039), S44) + c;
            a = RotateLeft((a + K(b, c, d) + x[12] + 0x655b59c3), S41) + b;
            d = RotateLeft((d + K(a, b, c) + x[3] + 0x8f0ccc92), S42) + a;
            c = RotateLeft((c + K(d, a, b) + x[10] + 0xffeff47d), S43) + d;
            b = RotateLeft((b + K(c, d, a) + x[1] + 0x85845dd1), S44) + c;
            a = RotateLeft((a + K(b, c, d) + x[8] + 0x6fa87e4f), S41) + b;
            d = RotateLeft((d + K(a, b, c) + x[15] + 0xfe2ce6e0), S42) + a;
            c = RotateLeft((c + K(d, a, b) + x[6] + 0xa3014314), S43) + d;
            b = RotateLeft((b + K(c, d, a) + x[13] + 0x4e0811a1), S44) + c;
            a = RotateLeft((a + K(b, c, d) + x[4] + 0xf7537e82), S41) + b;
            d = RotateLeft((d + K(a, b, c) + x[11] + 0xbd3af235), S42) + a;
            c = RotateLeft((c + K(d, a, b) + x[2] + 0x2ad7d2bb), S43) + d;
            b = RotateLeft((b + K(c, d, a) + x[9] + 0xeb86d391), S44) + c;

            h1 += a;
            h2 += b;
            h3 += c;
            h4 += d;

            xOff = 0;
        }

        #region >> MD5 algorithm constants

        // Round 1 left rotates
        private const int S11 = 7;
        private const int S12 = 12;
        private const int S13 = 17;
        private const int S14 = 22;

        // Round 2 left rotates
        private const int S21 = 5;
        private const int S22 = 9;
        private const int S23 = 14;
        private const int S24 = 20;

        // Round 3 left rotates
        private const int S31 = 4;
        private const int S32 = 11;
        private const int S33 = 16;
        private const int S34 = 23;

        // Round 4 left rotates
        private const int S41 = 6;
        private const int S42 = 10;
        private const int S43 = 15;
        private const int S44 = 21;

        #endregion

        #region >> MD5 basic functions

        /// <summary>
        /// Rotate <paramref name="x"/> left <paramref name="n"/> bits.
        /// </summary>
        /// <param name="x"></param>
        /// <param name="n"></param>
        /// <returns></returns>
        private static uint RotateLeft(uint x, int n)
        {
            return (x << n) | (x >> (32 - n));
        }

        /// <summary>
        /// Basic MD5 "F" functions.
        /// </summary>
        /// <param name="u"></param>
        /// <param name="v"></param>
        /// <param name="w"></param>
        /// <returns></returns>
        private static uint F(uint u, uint v, uint w)
        {
            return (u & v) | (~u & w);
        }

        /// <summary>
        /// Basic MD5 "G" functions.
        /// </summary>
        /// <param name="u"></param>
        /// <param name="v"></param>
        /// <param name="w"></param>
        /// <returns></returns>
        private static uint G(uint u, uint v, uint w)
        {
            return (u & w) | (v & ~w);
        }

        /// <summary>
        /// Basic MD5 "H" functions.
        /// </summary>
        /// <param name="u"></param>
        /// <param name="v"></param>
        /// <param name="w"></param>
        /// <returns></returns>
        private static uint H(uint u, uint v, uint w)
        {
            return u ^ v ^ w;
        }

        /// <summary>
        /// Basic MD5 "K" functions.
        /// </summary>
        /// <param name="u"></param>
        /// <param name="v"></param>
        /// <param name="w"></param>
        /// <returns></returns>
        private static uint K(uint u, uint v, uint w)
        {
            return v ^ (u | ~w);
        }

        #endregion

        private static void UInt32_To_LE(uint n, byte[] bs, int off)
        {
            bs[off] = (byte)(n);
            bs[off + 1] = (byte)(n >> 8);
            bs[off + 2] = (byte)(n >> 16);
            bs[off + 3] = (byte)(n >> 24);
        }

        private static uint LE_To_UInt32(byte[] bs, int off)
        {
            return bs[off]
                   | (uint)bs[off + 1] << 8
                   | (uint)bs[off + 2] << 16
                   | (uint)bs[off + 3] << 24;
        }
    }
}