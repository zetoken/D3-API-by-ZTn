using System.Runtime.Serialization;

namespace ZTn.BNet.D3.Items
{
    [DataContract]
    public class ItemTextAttributes
    {
        [DataMember]
        public ItemTextAttribute[] Primary { get; set; }

        [DataMember]
        public ItemTextAttribute[] Secondary { get; set; }

        [DataMember]
        public ItemTextAttribute[] Passive { get; set; }
    }
}