using System;
using System.IO;
using System.Text;
#if PORTABLE
using ZTn.Bnet.Portable;

#endif

namespace ZTn.BNet.D3.DataProviders
{
    public class CacheableDataProvider : ID3DataProvider
    {
        #region >> Fields

        private readonly ID3DataProvider dataProvider;

        public FetchMode FetchMode = FetchMode.Online;

        #endregion

        #region >> Constructors

        public CacheableDataProvider(ID3DataProvider dataProvider)
            : this()
        {
            this.dataProvider = dataProvider;
        }

        public CacheableDataProvider()
        {
#if PORTABLE
            PortableDirectory.CreateDirectory(@"cache");
#else
            Directory.CreateDirectory(@"cache");
#endif
        }

        #endregion

        public String GetCachedFileName(String url)
        {
            var stringBuilder = new StringBuilder();

            var uri = new Uri(url);

            stringBuilder.Append(uri.Host + "/");

            if (uri.LocalPath.Contains("/profile/"))
            {
                // Example: http://eu.battle.net/api/d3/profile/Tok-2360 >> eu.battle.net/Tok-2360.json
                var splitted = uri.LocalPath.Split(new[] { "/profile/" }, StringSplitOptions.None);
                stringBuilder.Append(splitted[1]);
                stringBuilder.Append(".json");
            }
            else if (uri.LocalPath.Contains("/hero/"))
            {
                // Example: http://eu.battle.net/api/d3/profile/Tok-2360/hero/17023 >> eu.battle.net/Tok-2360/hero/17023.json
                var splitted = uri.LocalPath.Split(new[] { "/hero/" }, StringSplitOptions.None);
                stringBuilder.Append(splitted[1]);
                stringBuilder.Append(".json");
            }
            else if (uri.LocalPath.Contains("/item/"))
            {
                // Example: http://eu.battle.net/api/d3/data/item/Amethyst_14 >> eu.battle.net/items/Amethyst_14.json (or a hash)
                stringBuilder.Append("items/");
                var splitted = uri.LocalPath.Split(new[] { "/item/" }, StringSplitOptions.None);
                if (splitted[1].Length < 32)
                {
                    stringBuilder.Append(splitted[1]);
                    stringBuilder.Append("-");
                }
                else
                {
#if PORTABLE
                    var hash = MD5Digest.ComputeMD5(PortableEncoding.Default.GetBytes(url));
#else
                    var hash = MD5Digest.ComputeMD5(Encoding.Default.GetBytes(url));
#endif
                    foreach (var hashByte in hash)
                    {
                        stringBuilder.Append(hashByte.ToString("x2"));
                    }
                }
                stringBuilder.Append(".json");
            }
            else if (uri.LocalPath.Contains("/icons/"))
            {
                // Example: http://media.blizzard.com/d3/icons/items/small/amethyst_12_demonhunter_male.png >> media.blizzard.com/icons/items/small/amethyst_12_demonhunter_male.png
                stringBuilder.Append("icons/");
                var splitted = uri.LocalPath.Split(new[] { "/icons/" }, StringSplitOptions.None);
                stringBuilder.Append(splitted[1]);
            }
            else
            {
#if PORTABLE
                var hash = MD5Digest.ComputeMD5(PortableEncoding.Default.GetBytes(url));
#else
                var hash = MD5Digest.ComputeMD5(Encoding.Default.GetBytes(url));
#endif
                foreach (var hashByte in hash)
                {
                    stringBuilder.Append(hashByte.ToString("x2"));
                }

                stringBuilder.Append(".json");
            }

            return stringBuilder.ToString();
        }

        public virtual String GetCacheStoragePath()
        {
            return "cache/";
        }

        #region >> ID3DataProvider

        /// <inheritdoc />
        public Stream FetchData(string url)
        {
            var cachedFilePath = GetCacheStoragePath() + GetCachedFileName(url);
#if PORTABLE
            var cachedFilePathExists = PortableFile.Exists(cachedFilePath);
#else
            var cachedFilePathExists = File.Exists(cachedFilePath);
#endif

            if ((FetchMode == FetchMode.Online) ||
                ((FetchMode == FetchMode.OnlineIfMissing) && !cachedFilePathExists))
            {
                var directoryName = Path.GetDirectoryName(cachedFilePath);
                if (!String.IsNullOrWhiteSpace(directoryName))
                {
#if PORTABLE
                    PortableDirectory.CreateDirectory(directoryName);
#else
                    Directory.CreateDirectory(directoryName);
#endif
                }

                using (var binaryReader = new BinaryReader(dataProvider.FetchData(url)))
                {
#if PORTABLE
                    using (var fileStream = PortableFile.Create(cachedFilePath))
#else
                    using (var fileStream = File.Create(cachedFilePath))
#endif
                    {
                        binaryReader.BaseStream.CopyTo(fileStream);
                    }
                }
            }

#if PORTABLE
            cachedFilePathExists = PortableFile.Exists(cachedFilePath);
#else
            cachedFilePathExists = File.Exists(cachedFilePath);
#endif

            if (!cachedFilePathExists)
            {
                throw new FileNotInCacheException();
            }
#if PORTABLE
            return PortableFile.Open(cachedFilePath, PortableFileMode.Open);
#else
            return new FileStream(cachedFilePath, FileMode.Open);
#endif
        }

        /// <inheritdoc />
        public void FetchData(string url, Action<Stream> onSuccess, Action onFailure)
        {
            Stream stream;
            try
            {
                stream = FetchData(url);
            }
            catch (Exception)
            {
                onFailure();
                return;
            }

            onSuccess(stream);
        }

        #endregion
    }
}