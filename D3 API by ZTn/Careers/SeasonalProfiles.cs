using System.Runtime.Serialization;

namespace ZTn.BNet.D3.Careers
{
    [DataContract]
    public class SeasonalProfiles : D3Object
    {
        [DataMember(Name = "season0")]
        public SeasonalProfile Season0;

        [DataMember(Name = "season1")]
        public SeasonalProfile Season1;

        [DataMember(Name = "season2")]
        public SeasonalProfile Season2;

        [DataMember(Name = "season3")]
        public SeasonalProfile Season3;

        [DataMember(Name = "season4")]
        public SeasonalProfile Season4;
    }
}