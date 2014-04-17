using System.Runtime.Serialization;

namespace ZTn.BNet.D3.Items
{
    [DataContract]
    public class Affix
    {
        [DataMember]
        public ItemTextAttributes Attributes { get; set; }

        [DataMember]
        public ItemAttributes AttributesRaw { get; set; }
    }
}