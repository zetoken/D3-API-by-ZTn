using System.IO;
using System.Text;
using Newtonsoft.Json;

namespace ZTn.BNet.D3.DataProviders
{
    /// <summary>
    /// Fake <see cref="ID3DataProvider"/> fecthing an empty <typeparamref name="T"/> instance.
    /// </summary>
    public class FakeDataProvider<T> : ID3DataProvider where T : class, new()
    {
        #region >> ID3DataProvider

        /// <inheritdoc />
        public Stream fetchData(string url)
        {
            var responseObject = new T();

            var json = JsonConvert.SerializeObject(responseObject);

            return new MemoryStream(Encoding.Default.GetBytes(json));
        }

        #endregion
    }
}