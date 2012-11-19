using System.Runtime.Serialization;

namespace ZTn.BNet.D3.Heroes
{
    [DataContract]
    public enum HeroClass
    {
        Unknown,
        [EnumMember(Value = "barbarian")]
        Barbarian,
        [EnumMember(Value = "demon-hunter")]
        DemonHunter,
        [EnumMember(Value = "monk")]
        Monk,
        [EnumMember(Value = "witch-doctor")]
        WitchDoctor,
        [EnumMember(Value = "wizard")]
        Wizard
    }
}
