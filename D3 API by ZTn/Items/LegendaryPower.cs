using System.Runtime.Serialization;

namespace ZTn.BNet.D3.Items
{
    public class LegendaryPower : D3Object
    {
        [DataMember]
        public string Id { get; set; }

        [DataMember]
        public string Name { get; set; }

        [DataMember]
        public string Icon { get; set; }

        [DataMember]
        public string DisplayColor { get; set; }

        [DataMember]
        public string TooltipParams { get; set; }
    }
}
