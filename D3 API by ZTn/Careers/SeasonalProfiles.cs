using System.Runtime.Serialization;

namespace ZTn.BNet.D3.Careers
{
    [DataContract]
    public class SeasonalProfiles : D3Object
    {
        [DataMember(Name = "season0")]
        public SeasonalProfile Season0 { get; set; }

        [DataMember(Name = "season1")]
        public SeasonalProfile Season1 { get; set; }

        [DataMember(Name = "season2")]
        public SeasonalProfile Season2 { get; set; }

        [DataMember(Name = "season3")]
        public SeasonalProfile Season3 { get; set; }

        [DataMember(Name = "season4")]
        public SeasonalProfile Season4 { get; set; }

        [DataMember(Name = "season5")]
        public SeasonalProfile Season5 { get; set; }

        [DataMember(Name = "season6")]
        public SeasonalProfile Season6 { get; set; }
    }
}