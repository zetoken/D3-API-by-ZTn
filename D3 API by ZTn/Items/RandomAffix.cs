using System.Runtime.Serialization;

namespace ZTn.BNet.D3.Items
{
    [DataContract]
    public class RandomAffix
    {
        [DataMember]
        public Affix[] OneOf { get; set; }
    }
}