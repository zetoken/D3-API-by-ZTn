using System;
using System.IO;
using System.Text;
using System.Threading.Tasks;
using ZTn.Bnet.Portable;

namespace ZTn.BNet.D3.DataProviders
{
    public class CacheableDataProvider : ICacheableD3DataProvider
    {
        #region >> Fields

        private readonly ID3DataProvider dataProvider;

        #endregion

        #region >> Constructors

        public CacheableDataProvider(string storagePath, ID3DataProvider dataProvider)
            : this(storagePath)
        {
            this.dataProvider = dataProvider;
        }

        public CacheableDataProvider(string storagePath)
        {
            StoragePath = storagePath;
            PortableDirectory.CreateDirectory(storagePath);
        }

        #endregion

        #region >> ICacheableD3DataProvider

        /// <inheritdoc />
        public FetchMode FetchMode { get; set; } = FetchMode.Online;

        /// <inheritdoc />
        public string StoragePath { get; set; }

        /// <inheritdoc />
        public string GetCachedFileName(string url)
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
                    var hash = MD5Digest.ComputeMD5(PortableEncoding.Default.GetBytes(url));
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
                var hash = MD5Digest.ComputeMD5(PortableEncoding.Default.GetBytes(url));
                foreach (var hashByte in hash)
                {
                    stringBuilder.Append(hashByte.ToString("x2"));
                }

                stringBuilder.Append(".json");
            }

            return stringBuilder.ToString();
        }

        #endregion

        #region >> ID3DataProvider

        /// <inheritdoc />
        public Stream FetchData(string url)
        {
            var cachedFilePath = Path.Combine(StoragePath, GetCachedFileName(url));
            var cachedFilePathExists = PortableFile.Exists(cachedFilePath);

            if ((FetchMode == FetchMode.Online) ||
                ((FetchMode == FetchMode.OnlineIfMissing) && !cachedFilePathExists))
            {
                var directoryName = Path.GetDirectoryName(cachedFilePath);
                if (!String.IsNullOrWhiteSpace(directoryName))
                {
                    PortableDirectory.CreateDirectory(directoryName);
                }

                using (var binaryReader = new BinaryReader(dataProvider.FetchData(url)))
                {
                    using (var fileStream = PortableFile.Create(cachedFilePath))
                    {
                        binaryReader.BaseStream.CopyTo(fileStream);
                    }
                }
            }

            cachedFilePathExists = PortableFile.Exists(cachedFilePath);

            if (!cachedFilePathExists)
            {
                throw new FileNotInCacheException();
            }
            return PortableFile.Open(cachedFilePath, PortableFileMode.Open);
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

        /// <inheritdoc />
        public Task<Stream> FetchDataAsync(string url)
        {
            return Task.Run(() => FetchData(url));
        }

        #endregion
    }
}