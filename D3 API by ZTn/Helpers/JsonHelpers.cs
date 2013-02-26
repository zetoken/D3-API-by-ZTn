using System;
using System.Collections.Generic;
using System.IO;
using Newtonsoft.Json;

namespace ZTn.BNet.D3.Helpers
{
    public class JsonHelpers
    {
        public static List<T> getDataFromJSonStream<T>(Stream stream)
        {
            JsonSerializer serializer = new JsonSerializer();
            List<T> data;
            using (StreamReader streamReader = new StreamReader(stream))
            {
                data = (List<T>)serializer.Deserialize(streamReader, typeof(List<T>));
            }
            return data;
        }

        public static List<T> getDataFromJSonString<T>(String json)
        {
            List<T> datas;
            using (MemoryStream stream = new MemoryStream(System.Text.Encoding.Default.GetBytes(json)))
            {
                datas = getDataFromJSonStream<T>(stream);
            }
            return datas;
        }

        public static List<T> getDataFromJsonFile<T>(String fileName)
        {
            List<T> datas;
            using (FileStream fileStream = new FileStream(fileName, FileMode.Open))
            {
                datas = getDataFromJSonStream<T>(fileStream);
            }
            return datas;
        }
    }
}
