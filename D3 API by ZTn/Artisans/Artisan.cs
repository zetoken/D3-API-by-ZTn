using System;
using System.IO;
using System.Runtime.Serialization;
using Newtonsoft.Json;

namespace ZTn.BNet.D3.Artisans
{
    [DataContract]
    public class Artisan
    {
        #region >> Fields

        [DataMember]
        public String slug;
        [DataMember]
        public String name;
        [DataMember]
        public String portrait;
        [DataMember]
        public ArtisanTraining training;

        #endregion

        public static Artisan getArtisanFromSlug(String slug)
        {
            return D3Api.getArtisanFromSlug(slug);
        }

        public static Artisan getArtisanFromJSonStream(Stream stream)
        {
            JsonSerializer serializer = new JsonSerializer();
            using (StreamReader streamReader = new StreamReader(stream))
            {
                return (Artisan)serializer.Deserialize(streamReader, typeof(Artisan));
            }
        }

        public static Artisan getItemFromJSonString(String json)
        {
            Artisan artisan;
            using (MemoryStream stream = new MemoryStream(System.Text.Encoding.Default.GetBytes(json)))
            {
                artisan = getArtisanFromJSonStream(stream);
            }
            return artisan;
        }
    }
}
