using System.Runtime.Serialization;

namespace ZTn.BNet.D3.Heroes
{
    [DataContract]
    public enum HeroGender
    {
        [EnumMember(Value = "0")]
        Male,

        [EnumMember(Value = "1")]
        Female
    }
}