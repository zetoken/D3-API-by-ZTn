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

        /// <summary>
        /// Creates a new instance by copying fields of <paramref name="itemType"/> (deep copy).
        /// </summary>
        /// <param name="itemType"></param>
        public ItemType(ItemType itemType)
        {
            if (itemType != null)
            {
                this.id = itemType.id;
                this.twoHanded = itemType.twoHanded;
            }
        }

        public ItemType(String id, bool twoHanded)
        {
            this.id = id;
            this.twoHanded = twoHanded;
        }

        #endregion

        #region >> Object

        /// <inheritdoc />
        public override string ToString()
        {
            return "[" + id + "]";
        }

        #endregion
    }
}
