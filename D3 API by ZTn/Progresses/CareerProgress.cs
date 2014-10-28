using System.Runtime.Serialization;

namespace ZTn.BNet.D3.Progresses
{
    [DataContract]
    public class CareerProgress : D3Object
    {
        #region >> Fields

        [DataMember]
        public bool Act1;

        [DataMember]
        public bool Act2;

        [DataMember]
        public bool Act3;

        [DataMember]
        public bool Act4;

        [DataMember]
        public bool Act5;

        #endregion
    }
}