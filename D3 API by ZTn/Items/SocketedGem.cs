using System;
using System.Runtime.Serialization;
using ZTn.BNet.D3.Helpers;

namespace ZTn.BNet.D3.Items
{
    [DataContract]
    public class SocketedGem
    {
        #region >> Fields

        [DataMember]
        public ItemSummary item;
        [DataMember]
        public ItemAttributes attributesRaw;
        [DataMember]
        public String[] attributes;

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
            this.item = item;
            attributes = item.attributes;
            attributesRaw = item.attributesRaw;
        }

        #endregion
    }
}
