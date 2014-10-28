using System.Runtime.Serialization;

namespace ZTn.BNet.D3.Items
{
    [DataContract]
    public class ItemTextAttribute : D3Object
    {
        [DataMember]
        public string Text { get; set; }

        [DataMember]
        public string AffixType { get; set; }

        [DataMember]
        public string Color { get; set; }
    }
}