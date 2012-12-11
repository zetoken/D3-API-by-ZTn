using System;

namespace ZTn.BNet.D3.Items
{
    public class ItemType
    {
        #region >> Properties

        public String id;
        public bool twoHanded;

        #endregion

        #region >> Constructors

        public ItemType()
            : this(String.Empty, false)
        {
        }

        public ItemType(String id, bool twoHanded)
        {
            this.id = id;
            this.twoHanded = twoHanded;
        }

        #endregion
    }
}
