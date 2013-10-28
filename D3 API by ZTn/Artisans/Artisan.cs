using System;
using System.IO;
using System.Runtime.Serialization;
using Newtonsoft.Json;
using ZTn.BNet.D3.Helpers;

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
            return JsonHelpers.getFromJSonStream<Artisan>(stream);
        }

        public static Artisan getItemFromJSonString(String json)
        {
            return JsonHelpers.getFromJSonString<Artisan>(json);
        }

        #region >> Object

        /// <inheritdoc />
        public override string ToString()
        {
            return "[" + slug + "]";
        }

        #endregion
    }
}
