using System.Runtime.Serialization;
using ZTn.BNet.D3.Progresses;

namespace ZTn.BNet.D3.Careers
{
    [DataContract]
    public class SeasonalProfile
    {
        [DataMember(Name = "seasonId")]
        public int SeasonId;

        [DataMember(Name = "paragonLevel")]
        public int ParagonLevel;

        [DataMember(Name = "paragonLevelHardcore")]
        public int ParagonLevelHardcore;

        [DataMember(Name = "kills")]
        public CareerKills Kills;

        [DataMember(Name = "timePlayed")]
        public ClassTimePlayed TimePlayed;

        [DataMember(Name = "highestHardcoreLevel")]
        public int HighestHardcoreLevel;

        [DataMember(Name = "progression")]
        public CareerProgress Progression;
    }
}