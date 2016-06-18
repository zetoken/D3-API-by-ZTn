using System;
using System.Diagnostics;
using System.IO;
using System.Threading.Tasks;
using Newtonsoft.Json;
using ZTn.Bnet.PclAdapters;
using ZTn.BNet.D3.Annotations;

namespace ZTn.BNet.D3.Helpers
{
    public static class JsonHelpers
    {
        #region >> Obsolete methods

        /// <summary>
        /// Deserialize the object of type <typeparamref name="T"/> from the <paramref name="stream"/>.
        /// The stream is safely disposed by the method.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="stream"></param>
        /// <returns></returns>
        [Obsolete("Use CreateFromJsonStream<T>")]
        public static T GetFromJSonStream<T>(Stream stream)
        {
            var serializer = new JsonSerializer();
            T data;
            using (var streamReader = new StreamReader(stream))
            {
                data = (T)serializer.Deserialize(streamReader, typeof(T));
            }
            return data;
        }

        /// <summary>
        /// Deserialize the object of type <typeparamref name="T"/> from the <paramref name="stream"/>.
        /// Warning: the stream is not closed and must be disposed by the caller.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="stream"></param>
        /// <returns></returns>
        [Obsolete("Use CreateFromJsonPersistentStream<T>")]
        public static T GetFromJSonPersistentStream<T>(Stream stream)
        {
            var serializer = new JsonSerializer();
            return (T)serializer.Deserialize(new StreamReader(stream), typeof(T));
        }

        /// <summary>
        /// Deserialize the object of type <typeparamref name="T"/> from the <paramref name="json"/> string.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="json">Json formatted string of type <typeparamref name="T"/>.</param>
        /// <returns></returns>
        [Obsolete("Use CreateFromJsonString<T>")]
        public static T GetFromJSonString<T>(String json)
        {
            T datas;
            using (var stream = new MemoryStream(PortableEncoding.Default.GetBytes(json)))
            {
                datas = GetFromJSonStream<T>(stream);
            }
            return datas;
        }

        /// <summary>
        /// Deserialize the object of type <typeparamref name="T"/> from the file named <paramref name="fileName"/>.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="fileName">File path and name containing json formatted string of type <typeparamref name="T"/>.</param>
        /// <returns></returns>
        [Obsolete("Use CreateFromJsonFile<T>")]
        public static T GetFromJsonFile<T>(String fileName)
        {
            T datas;

            using (var fileStream = PortableFile.Open(fileName, PortableFileMode.Open))
            {
                datas = GetFromJSonStream<T>(fileStream);
            }

            return datas;
        }

        #endregion

        /// <summary>
        /// Reads (deserializes) an instance of type <typeparamref Name="T"/> from a JSON stream.
        /// The stream is safely disposed by the method.
        /// </summary>
        /// <typeparam name="T">Target instance type.</typeparam>
        /// <param name="stream">JSON source stream.</param>
        /// <returns>A new instance of <typeparamref Name="T"/> read from <paramref Name="stream"/>.</returns>
        public static T CreateFromJsonStream<T>(this Stream stream)
        {
            var serializer = new JsonSerializer { TypeNameHandling = TypeNameHandling.Auto };
            serializer.Error += (sender, args) =>
            {
                Debug.WriteLine(args.ErrorContext.Error.Message);
                args.ErrorContext.Handled = true;
            };
            T data;

            using (var streamReader = new StreamReader(stream))
            {
                data = (T)serializer.Deserialize(streamReader, typeof(T));
                JsonConvert.DeserializeObject<T>("");
            }

            return data;
        }

        /// <summary>
        /// Asynchronously reads (deserializes) an instance of type <typeparamref Name="T"/> from a JSON stream.
        /// The stream is safely disposed by the method.
        /// </summary>
        /// <typeparam name="T">Target instance type.</typeparam>
        /// <param name="stream">JSON source stream.</param>
        /// <returns>A new instance of <typeparamref Name="T"/> read from <paramref Name="stream"/>.</returns>
        public static async Task<T> CreateFromJsonStreamAsync<T>(this Stream stream)
        {
            return await Task.Run(() => stream.CreateFromJsonStream<T>()).ConfigureAwait(false);
        }

        /// <summary>
        /// Reads (deserializes) an instance of type <typeparamref Name="T"/> from a JSON stream.
        /// Warning: the stream is not closed and must be disposed by the caller.
        /// </summary>
        /// <typeparam name="T">Target instance type.</typeparam>
        /// <param name="stream">JSON source stream.</param>
        /// <returns>A new instance of <typeparamref Name="T"/> read from <paramref Name="stream"/>.</returns>
        public static T CreateFromJsonPersistentStream<T>(this Stream stream)
        {
            var serializer = new JsonSerializer { TypeNameHandling = TypeNameHandling.Auto };

            var streamReader = new StreamReader(stream);
            var data = (T)serializer.Deserialize(streamReader, typeof(T));

            return data;
        }

        /// <summary>
        /// Reads (deserializes) an instance of type <typeparamref Name="T"/> from a JSON string.
        /// </summary>
        /// <typeparam name="T">Target instance type.</typeparam>
        /// <param name="json">JSON source string.</param>
        /// <returns>A new instance of <typeparamref Name="T"/> read from <paramref Name="json"/>.</returns>
        public static T CreateFromJsonString<T>(this string json)
        {
            T data;

            using (var stream = new MemoryStream(PortableEncoding.Default.GetBytes(json)))
            {
                data = CreateFromJsonStream<T>(stream);
            }

            return data;
        }

        /// <summary>
        /// Reads (deserializes) an instance of type <typeparamref Name="T"/> from a JSON file.
        /// </summary>
        /// <typeparam name="T">Target instance type.</typeparam>
        /// <param name="fileName">JSON source path and filename.</param>
        /// <returns>A new instance of <typeparamref Name="T"/> read from <paramref Name="fileName"/>.</returns>
        public static T CreateFromJsonFile<T>([NotNull] this string fileName)
        {
            if (fileName == null)
            {
                throw new ArgumentNullException(nameof(fileName));
            }
            T data;

            using (var fileStream = PortableFile.Open(fileName, PortableFileMode.Open))
            {
                data = CreateFromJsonStream<T>(fileStream);
            }

            return data;
        }

        /// <summary>
        /// Writes (serializes) an instance to a JSON file.
        /// </summary>
        /// <param name="instance"></param>
        /// <param name="fileName"></param>
        public static void WriteToJsonFile(this object instance, string fileName)
        {
            instance.WriteToJsonFile(fileName, false);
        }

        /// <summary>
        /// Writes (serializes) an instance to a JSON file.
        /// </summary>
        /// <param name="instance"></param>
        /// <param name="fileName"></param>
        /// <param name="indented"></param>
        public static void WriteToJsonFile(this object instance, string fileName, bool indented)
        {
            var formatting = (indented ? Formatting.Indented : Formatting.None);

            var serializer = new JsonSerializer { TypeNameHandling = TypeNameHandling.Auto, Formatting = formatting };

            using (var streamWriter = new StreamWriter(PortableFile.Open(fileName, PortableFileMode.OpenOrCreate)))
            {
                serializer.Serialize(streamWriter, instance);
            }
        }

        /// <summary>
        /// Asynchronously writes (serializes) an instance to a JSON file.
        /// </summary>
        /// <param name="instance"></param>
        /// <param name="fileName"></param>
        /// <param name="indented"></param>
        public static async Task WriteToJsonFileAsync(this object instance, string fileName, bool indented)
        {
            await Task.Run(() => instance.WriteToJsonFile(fileName, indented));
        }

        /// <summary>
        /// Writes (serializes) an instance to a json string.
        /// </summary>
        /// <param name="instance"></param>
        public static string WriteToJsonString(this object instance)
        {
            return instance.WriteToJsonString(false);
        }

        /// <summary>
        /// Writes (serializes) an instance to a json string.
        /// </summary>
        /// <param name="instance"></param>
        /// <param name="indented"></param>
        public static string WriteToJsonString(this object instance, bool indented)
        {
            var formatting = (indented ? Formatting.Indented : Formatting.None);

            return JsonConvert.SerializeObject(instance, new JsonSerializerSettings { TypeNameHandling = TypeNameHandling.Auto, Formatting = formatting });
        }
    }
}