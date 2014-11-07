using System;
using ZTn.BNet.D3.Calculator.Helpers;
using ZTn.BNet.D3.Items;

namespace ZTn.BNet.D3.Calculator.Heroes
{
    public class ParagonBonus
    {
        /// <summary>
        /// Name of the attribute that will receive the bonus (a field name of <see cref="ItemAttributes"/>).
        /// </summary>
        public string AttributeName { get; private set; }

        /// <summary>
        /// Bonus increment for each paragon point.
        /// </summary>
        public ItemValueRange BonusPerPoint { get; private set; }

        /// <summary>
        /// Max paragon point in this entry (0 for infinite).
        /// </summary>
        public int MaxPoints { get; private set; }

        /// <summary>
        /// Points number set in this bonus.
        /// </summary>
        public int CurrentPoints { get; set; }

        /// <summary>
        /// Creates a new instance.
        /// </summary>
        /// <param name="attributeName">Name of the attribute that will receive the bonus (a field name of <see cref="ItemAttributes"/>).</param>
        /// <param name="bonusPerPoint">Bonus increment for each paragon point.</param>
        /// <param name="maxPoints">Max paragon point in this entry (0 for infinite).</param>
        public ParagonBonus(string attributeName, ItemValueRange bonusPerPoint, int maxPoints)
        {
            AttributeName = attributeName;
            BonusPerPoint = bonusPerPoint;
            MaxPoints = maxPoints;
        }

        /// <summary>
        /// Returns the final bonus as an <see cref="ItemAttributes"/> instance.
        /// </summary>
        /// <returns></returns>
        public ItemAttributes GetBonus()
        {
            var attr = new ItemAttributes();

            if (!String.IsNullOrEmpty(AttributeName))
            {
                attr.SetAttributeByName(AttributeName, CurrentPoints * BonusPerPoint);
            }

            return attr;
        }
    }
}
