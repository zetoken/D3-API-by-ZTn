using System;
using System.Runtime.Serialization;

namespace ZTn.BNet.D3.Items
{
    [DataContract]
    public class ItemValueRange
    {
        public static readonly ItemValueRange Zero = new ItemValueRange(0);
        public static readonly ItemValueRange One = new ItemValueRange(1);

        #region >> Properties

        [DataMember]
        public double min;
        [DataMember]
        public double max;

        #endregion

        #region >> Constructors

        public ItemValueRange()
        {
        }

        public ItemValueRange(ItemValueRange valueRange)
        {
            if (valueRange != null)
            {
                this.min = valueRange.min;
                this.max = valueRange.max;
            }
        }

        public ItemValueRange(double value)
        {
            this.min = value;
            this.max = value;
        }

        public ItemValueRange(double min, double max)
        {
            this.min = min;
            this.max = max;
        }

        #endregion

        #region >> Operators

        public static ItemValueRange operator +(ItemValueRange left, ItemValueRange right)
        {
            if (left == null)
                return right;
            else if (right == null)
                return left;
            else
                return new ItemValueRange(left.min + right.min, left.max + right.max);
        }

        public static ItemValueRange operator +(ItemValueRange left, double right)
        {
            if (left == null)
                return new ItemValueRange(right);
            else
                return new ItemValueRange(left.min + right, left.max + right);
        }

        public static ItemValueRange operator +(double left, ItemValueRange right)
        {
            if (right == null)
                return new ItemValueRange(left);
            else
                return new ItemValueRange(left + right.min, left + right.max);
        }

        public static ItemValueRange operator -(ItemValueRange left, ItemValueRange right)
        {
            if (left == null)
                return ItemValueRange.Zero - right;
            else if (right == null)
                return new ItemValueRange(left);
            else
                return new ItemValueRange(left.min - right.min, left.max - right.max);
        }

        public static ItemValueRange operator -(ItemValueRange left, double right)
        {
            if (left == null)
                return new ItemValueRange(0 - right);
            else
                return new ItemValueRange(left.min - right, left.max - right);
        }

        public static ItemValueRange operator -(double left, ItemValueRange right)
        {
            if (right == null)
                return new ItemValueRange(right);
            else
                return new ItemValueRange(left - right.min, left - right.max);
        }

        public static ItemValueRange operator *(ItemValueRange left, ItemValueRange right)
        {
            if (left == null)
                return Zero;
            else if (right == null)
                return Zero;
            else
                return new ItemValueRange(left.min * right.min, left.max * right.max);
        }

        public static ItemValueRange operator *(ItemValueRange left, double right)
        {
            if (left == null)
                return Zero;
            else
                return new ItemValueRange(left.min * right, left.max * right);
        }

        public static ItemValueRange operator *(double left, ItemValueRange right)
        {
            return right * left;
        }

        public static ItemValueRange operator /(ItemValueRange left, ItemValueRange right)
        {
            if (left == null)
                return Zero;
            else if (right == null)
                throw new DivideByZeroException();
            else
                return new ItemValueRange(left.min / right.min, left.max / right.max);
        }

        public static ItemValueRange operator /(ItemValueRange left, double right)
        {
            if (left == null)
                return Zero;
            else
                return new ItemValueRange(left.min / right, left.max / right);
        }

        public static ItemValueRange operator /(double left, ItemValueRange right)
        {
            if (right == null)
                throw new DivideByZeroException();
            else
                return new ItemValueRange(left / right.min, left / right.max);
        }

        #endregion
    }
}
