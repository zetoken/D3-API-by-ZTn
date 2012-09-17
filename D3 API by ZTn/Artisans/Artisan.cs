using System;
using System.IO;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Json;

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
            DataContractJsonSerializer jsSerializer = new DataContractJsonSerializer(typeof(Artisan));
            Artisan artisan = (Artisan)jsSerializer.ReadObject(stream);
            return artisan;
        }

        public static Artisan getItemFromJSonString(String json)
        {
            return getArtisanFromJSonStream(new MemoryStream(System.Text.Encoding.Default.GetBytes(json)));
        }
    }
}
