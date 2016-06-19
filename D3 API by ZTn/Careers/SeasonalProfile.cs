using System.Runtime.Serialization;
using ZTn.BNet.D3.Progresses;

namespace ZTn.BNet.D3.Careers
{
    [DataContract]
    public class SeasonalProfile : D3Object
    {
        [DataMember(Name = "seasonId")]
        public int SeasonId { get; set; }

        [DataMember(Name = "paragonLevel")]
        public int ParagonLevel { get; set; }

        [DataMember(Name = "paragonLevelHardcore")]
        public int ParagonLevelHardcore { get; set; }

        [DataMember(Name = "kills")]
        public CareerKills Kills { get; set; }

        [DataMember(Name = "timePlayed")]
        public ClassTimePlayed TimePlayed { get; set; }

        [DataMember(Name = "highestHardcoreLevel")]
        public int HighestHardcoreLevel { get; set; }

        [DataMember(Name = "progression")]
        public CareerProgress Progression { get; set; }
    }
}