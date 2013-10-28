using System;
using System.Collections.Generic;
using System.IO;
using Newtonsoft.Json;

namespace ZTn.BNet.D3.Helpers
{
    public sealed class JsonHelpers
    {
        /// <summary>
        /// Deserialize the object of type <typeparamref name="T"/> from the <paramref name="stream"/>.
        /// The stream is safely disposed by the method.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="stream"></param>
        /// <returns></returns>
        public static T getFromJSonStream<T>(Stream stream)
        {
            JsonSerializer serializer = new JsonSerializer();
            T data;
            using (StreamReader streamReader = new StreamReader(stream))
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
        public static T getFromJSonPersistentStream<T>(Stream stream)
        {
            JsonSerializer serializer = new JsonSerializer();
            return (T)serializer.Deserialize(new StreamReader(stream), typeof(T));
        }

        /// <summary>
        /// Deserialize the object of type <typeparamref name="T"/> from the <paramref name="json"/> string.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="json">Json formatted string of type <typeparamref name="T"/>.</param>
        /// <returns></returns>
        public static T getFromJSonString<T>(String json)
        {
            T datas;
            using (MemoryStream stream = new MemoryStream(System.Text.Encoding.Default.GetBytes(json)))
            {
                datas = getFromJSonStream<T>(stream);
            }
            return datas;
        }

        /// <summary>
        /// Deserialize the object of type <typeparamref name="T"/> from the file named <paramref name="fileName"/>.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="fileName">File path and name containing json formatted string of type <typeparamref name="T"/>.</param>
        /// <returns></returns>
        public static T getFromJsonFile<T>(String fileName)
        {
            T datas;
            using (FileStream fileStream = new FileStream(fileName, FileMode.Open))
            {
                datas = getFromJSonStream<T>(fileStream);
            }
            return datas;
        }

        /// <summary>
        /// Writes (serializes) an instance to a new json formatted file.
        /// </summary>
        /// <param name="instance"></param>
        /// <param name="fileName"></param>
        public static void writeToJsonFile(Object instance, String fileName)
        {
            JsonSerializer serializer = new JsonSerializer() { Formatting = Formatting.Indented };

            using (StreamWriter streamWriter = new StreamWriter(fileName))
            {
                serializer.Serialize(streamWriter, instance);
            }
        }

        #region >> Deprecated methods

        [Obsolete("Deprecated - Prefer JsonHelpers.getFromJSonStream<T>(Stream)")]
        public static List<T> getDataFromJSonStream<T>(Stream stream)
        {
            return getFromJSonStream<List<T>>(stream);
        }

        [Obsolete("Deprecated - Prefer JsonHelpers.getFromJSonString<T>(String)")]
        public static List<T> getDataFromJSonString<T>(String json)
        {
            return getFromJSonString<List<T>>(json);
        }

        [Obsolete("Deprecated - Prefer JsonHelpers.getFromJSonFile<T>(String)")]
        public static List<T> getDataFromJsonFile<T>(String fileName)
        {
            return getFromJsonFile<List<T>>(fileName);
        }

        #endregion
    }
}
