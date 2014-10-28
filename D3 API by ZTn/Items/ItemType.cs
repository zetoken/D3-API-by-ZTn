using System;

namespace ZTn.BNet.D3.Items
{
    public class ItemType : D3Object
    {
        #region >> Properties

        public String Id;
        public bool TwoHanded;

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
                Id = itemType.Id;
                TwoHanded = itemType.TwoHanded;
            }
        }

        public ItemType(String id, bool twoHanded)
        {
            Id = id;
            TwoHanded = twoHanded;
        }

        #endregion

        #region >> Object

        /// <inheritdoc />
        public override string ToString()
        {
            return "[" + Id + "]";
        }

        #endregion
    }
}