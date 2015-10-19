using System;
using System.IO;
using System.Runtime.Serialization;
using ZTn.BNet.D3.Helpers;

namespace ZTn.BNet.D3.Artisans
{
    [DataContract]
    public class Artisan : D3Object
    {
        #region >> Fields

        [DataMember(Name = "slug")]
        public String Slug { get; set; }

        [DataMember(Name = "level")]
        public int Level { get; set; }

        [DataMember(Name = "stepCurrent")]
        public int StepCurrent { get; set; }

        [DataMember(Name = "stepMax")]
        public int StepMax { get; set; }

        #endregion

        public static Artisan CreateFromSlug(String slug)
        {
            return D3Api.GetArtisanFromSlug(slug);
        }

        public static Artisan CreateFromJSonStream(Stream stream)
        {
            return stream.CreateFromJsonStream<Artisan>();
        }

        public static Artisan CreateFromJSonString(String json)
        {
            return json.CreateFromJsonString<Artisan>();
        }

        #region >> Object

        /// <inheritdoc />
        public override string ToString()
        {
            return "[" + Slug + "]";
        }

        #endregion
    }
}