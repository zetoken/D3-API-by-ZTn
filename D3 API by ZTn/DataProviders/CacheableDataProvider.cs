using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace ZTn.BNet.D3.DataProviders
{
    public class CacheableDataProvider : ID3DataProvider
    {
        #region >> Fields

        ID3DataProvider dataProvider;

        public Boolean online = true;

        #endregion

        #region >> Constructors

        public CacheableDataProvider(ID3DataProvider dataProvider)
        {
            this.dataProvider = dataProvider;
        }

        #endregion

        public String getCachedFileName(String url)
        {
            StringBuilder stringBuilder = new StringBuilder();

            using (MD5 md5 = MD5.Create())
            {
                Byte[] hash = md5.ComputeHash(Encoding.Default.GetBytes(url));
                foreach (Byte hashByte in hash)
                    stringBuilder.Append(hashByte.ToString("x2"));
            }

            stringBuilder.Append(".json");

            return stringBuilder.ToString();
        }

        public Stream fetchData(string url)
        {
            String cachedFilePath = "cache/" + getCachedFileName(url);

            if (online)
            {
                DirectoryInfo directoryInfo = Directory.CreateDirectory("cache");

                using (BinaryReader binaryReader = new BinaryReader(dataProvider.fetchData(url)))
                {
                    using (FileStream fileStream = File.Create(cachedFilePath))
                    {
                        binaryReader.BaseStream.CopyTo(fileStream);
                        fileStream.Close();
                    }
                    binaryReader.Close();
                }
            }

            if (!File.Exists(cachedFilePath))
                throw new FileNotInCacheException();

            return new FileStream(cachedFilePath, FileMode.Open);
        }
    }
}
