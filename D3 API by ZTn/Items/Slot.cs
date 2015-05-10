using System.Runtime.Serialization;

namespace ZTn.BNet.D3.Items
{
    [DataContract]
    public enum Slot
    {
        Unknown,

        [EnumMember(Value = "bracers")]
        Bracers,

        [EnumMember(Value = "chest")]
        Chest,

        [EnumMember(Value = "feet")]
        Feet,

        [EnumMember(Value = "follower-left-finger")]
        FollowerLeftFinger,

        [EnumMember(Value = "follower-left-hand")]
        FollowerLeftHand,

        [EnumMember(Value = "follower-neck")]
        FollowerNeck,

        [EnumMember(Value = "follower-right-finger")]
        FollowerRightFinger,

        [EnumMember(Value = "follower-right-hand")]
        FollowerRightHand,

        [EnumMember(Value = "hands")]
        Hands,

        [EnumMember(Value = "head")]
        Head,

        [EnumMember(Value = "left-finger")]
        LeftFinger,

        [EnumMember(Value = "left-hand")]
        LeftHand,

        [EnumMember(Value = "legs")]
        Legs,

        [EnumMember(Value = "neck")]
        Neck,

        [EnumMember(Value = "right-finger")]
        RightFinger,

        [EnumMember(Value = "right-hand")]
        RightHand,

        [EnumMember(Value = "shoulder")]
        Shoulder,

        [EnumMember(Value = "waist")]
        Waist
    }
}