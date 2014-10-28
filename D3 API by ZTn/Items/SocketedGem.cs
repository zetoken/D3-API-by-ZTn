using System.Runtime.Serialization;
using ZTn.BNet.D3.Helpers;

namespace ZTn.BNet.D3.Items
{
    [DataContract]
    public class SocketedGem : D3Object
    {
        #region >> Fields

        [DataMember]
        public ItemSummary Item { get; set; }

        [DataMember]
        public ItemAttributes AttributesRaw { get; set; }

        [DataMember]
        public ItemTextAttributes Attributes { get; set; }

        #endregion

        #region >> Constructors

        public SocketedGem()
        {
        }

        /// <summary>
        /// Creates a new instance by copying fields of <paramref name="socketedGem"/> (deep copy).
        /// </summary>
        /// <param name="socketedGem"></param>
        public SocketedGem(SocketedGem socketedGem)
        {
            socketedGem.DeepCopy(this);
        }

        public SocketedGem(Item item)
        {
            Item = item;
            Attributes = item.Attributes;
            AttributesRaw = item.AttributesRaw;
        }

        #endregion
    }
}