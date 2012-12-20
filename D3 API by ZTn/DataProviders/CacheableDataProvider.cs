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
            : this()
        {
            this.dataProvider = dataProvider;
        }

        public CacheableDataProvider()
        {
            Directory.CreateDirectory(@"cache");
        }

        #endregion

        public String getCachedFileName(String url)
        {
            StringBuilder stringBuilder = new StringBuilder();

            Uri uri = new Uri(url);
            if (uri.LocalPath.Contains("/profile/"))
            {
                String[] splitted = uri.LocalPath.Split(new String[] { "/profile/" }, StringSplitOptions.None);
                stringBuilder.Append(splitted[1]);
                stringBuilder.Append(".json");
            }
            else if (uri.LocalPath.Contains("/hero/"))
            {
                String[] splitted = uri.LocalPath.Split(new String[] { "/hero/" }, StringSplitOptions.None);
                stringBuilder.Append(splitted[1]);
                stringBuilder.Append(".json");
            }
            else if (uri.LocalPath.Contains("/item/"))
            {
                stringBuilder.Append("items/");
                String[] splitted = uri.LocalPath.Split(new String[] { "/item/" }, StringSplitOptions.None);
                if (splitted[1].Length < 32)
                {
                    stringBuilder.Append(splitted[1]);
                    stringBuilder.Append("-");
                }
                else
                {
                    using (MD5 md5 = MD5.Create())
                    {
                        Byte[] hash = md5.ComputeHash(Encoding.Default.GetBytes(url));
                        foreach (Byte hashByte in hash)
                            stringBuilder.Append(hashByte.ToString("x2"));
                    }
                }
                stringBuilder.Append(".json");
            }
            else if (uri.LocalPath.Contains("/icons/"))
            {
                stringBuilder.Append("icons/");
                String[] splitted = uri.LocalPath.Split(new String[] { "/icons/" }, StringSplitOptions.None);
                stringBuilder.Append(splitted[1]);
            }
            else
            {
                using (MD5 md5 = MD5.Create())
                {
                    Byte[] hash = md5.ComputeHash(Encoding.Default.GetBytes(url));
                    foreach (Byte hashByte in hash)
                        stringBuilder.Append(hashByte.ToString("x2"));
                }

                stringBuilder.Append(".json");
            }

            return stringBuilder.ToString();
        }

        public Stream fetchData(string url)
        {
            String cachedFilePath = "cache/" + getCachedFileName(url);


            if (online)
            {
                Directory.CreateDirectory(Path.GetDirectoryName(cachedFilePath));

                using (BinaryReader binaryReader = new BinaryReader(dataProvider.fetchData(url)))
                {
                    using (FileStream fileStream = File.Create(cachedFilePath))
                    {
                        binaryReader.BaseStream.CopyTo(fileStream);
                    }
                }
            }

            if (!File.Exists(cachedFilePath))
                throw new FileNotInCacheException();

            return new FileStream(cachedFilePath, FileMode.Open);
        }
    }
}
