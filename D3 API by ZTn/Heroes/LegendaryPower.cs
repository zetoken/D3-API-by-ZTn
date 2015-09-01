using System.Runtime.Serialization;

namespace ZTn.BNet.D3.Heroes
{
    public class LegendaryPower : D3Object
    {
        [DataMember]
        public string Id;

        [DataMember]
        public string Name;

        [DataMember]
        public string Icon;

        [DataMember]
        public string DisplayColor;

        [DataMember]
        public string TooltipParams;
    }
}
