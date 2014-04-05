using System.Runtime.Serialization;

namespace ZTn.BNet.D3.Items
{
    [DataContract]
    public class ItemTextAttribute
    {
        [DataMember]
        public string Text { get; set; }

        [DataMember]
        public string AffixType { get; set; }

        [DataMember]
        public string Color { get; set; }
    }
}