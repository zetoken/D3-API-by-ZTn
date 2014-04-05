using System.Runtime.Serialization;

namespace ZTn.BNet.D3.Heroes
{
    [DataContract]
    public enum HeroClass
    {
        Unknown,

        [EnumMember(Value = "barbarian")]
        Barbarian,

        [EnumMember(Value = "crusader")]
        Crusader,

        [EnumMember(Value = "demon-hunter")]
        DemonHunter,

        [EnumMember(Value = "monk")]
        Monk,

        [EnumMember(Value = "witch-doctor")]
        WitchDoctor,

        [EnumMember(Value = "wizard")]
        Wizard,

        [EnumMember(Value = "templar")]
        TemplarFollower,

        [EnumMember(Value = "scoundrel")]
        ScoundrelFollower,

        [EnumMember(Value = "enchantress")]
        EnchantressFollower
    }
}