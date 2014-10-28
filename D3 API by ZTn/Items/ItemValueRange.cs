using System;
using System.Runtime.Serialization;

namespace ZTn.BNet.D3.Items
{
    /// <summary>
    /// Represents a range of values from <see cref="Min"/> to <see cref="Max"/>.
    /// </summary>
    [DataContract]
    public class ItemValueRange : D3Object
    {
        public static readonly ItemValueRange Zero = new ItemValueRange(0);
        public static readonly ItemValueRange One = new ItemValueRange(1);

        private const double Tolerance = 0.0001;

        #region >> Properties

        [DataMember(Name = "min")]
        public double Min;

        [DataMember(Name = "max")]
        public double Max;

        #endregion

        #region >> Constructors

        public ItemValueRange()
        {
        }

        /// <summary>
        /// Creates a new <see cref="ItemValueRange"/> instance by copying fields of <paramref name="valueRange"/> (deep copy).
        /// </summary>
        /// <param name="valueRange"></param>
        public ItemValueRange(ItemValueRange valueRange)
        {
            if (valueRange != null)
            {
                Min = valueRange.Min;
                Max = valueRange.Max;
            }
        }

        /// <summary>
        /// Creates a new <see cref="ItemValueRange"/> instance using <paramref name="value"/> as Min and Max.
        /// </summary>
        /// <param name="value"></param>
        public ItemValueRange(double value)
        {
            Min = value;
            Max = value;
        }

        /// <summary>
        /// Creates a new <see cref="ItemValueRange"/> instance with given Min and Max.
        /// </summary>
        /// <param name="min"></param>
        /// <param name="max"></param>
        public ItemValueRange(double min, double max)
        {
            Min = min;
            Max = max;
        }

        #endregion

        #region >> Operators

        public static ItemValueRange operator +(ItemValueRange left, ItemValueRange right)
        {
            if (left == null)
            {
                return new ItemValueRange(right);
            }

            return right == null ? left : new ItemValueRange(left.Min + right.Min, left.Max + right.Max);
        }

        public static ItemValueRange operator +(ItemValueRange left, double right)
        {
            return left == null ? new ItemValueRange(right) : new ItemValueRange(left.Min + right, left.Max + right);
        }

        public static ItemValueRange operator +(double left, ItemValueRange right)
        {
            return right == null ? new ItemValueRange(left) : new ItemValueRange(left + right.Min, left + right.Max);
        }

        public static ItemValueRange operator -(ItemValueRange left, ItemValueRange right)
        {
            if (left == null)
            {
                return Zero - right;
            }

            return right == null
                ? new ItemValueRange(left)
                : new ItemValueRange(left.Min - right.Min, left.Max - right.Max);
        }

        public static ItemValueRange operator -(ItemValueRange left, double right)
        {
            return left == null ? new ItemValueRange(0 - right) : new ItemValueRange(left.Min - right, left.Max - right);
        }

        public static ItemValueRange operator -(double left, ItemValueRange right)
        {
            return right == null ? new ItemValueRange(left) : new ItemValueRange(left - right.Min, left - right.Max);
        }

        public static ItemValueRange operator *(ItemValueRange left, ItemValueRange right)
        {
            if (left == null)
            {
                return Zero;
            }

            return right == null ? Zero : new ItemValueRange(left.Min * right.Min, left.Max * right.Max);
        }

        public static ItemValueRange operator *(ItemValueRange left, double right)
        {
            return left == null ? Zero : new ItemValueRange(left.Min * right, left.Max * right);
        }

        public static ItemValueRange operator *(double left, ItemValueRange right)
        {
            return right * left;
        }

        public static ItemValueRange operator /(ItemValueRange left, ItemValueRange right)
        {
            if (left == null)
            {
                return Zero;
            }

            if (right == null)
            {
                throw new ArgumentNullException("right");
            }

            return new ItemValueRange(left.Min / right.Min, left.Max / right.Max);
        }

        public static ItemValueRange operator /(ItemValueRange left, double right)
        {
            return left == null ? Zero : new ItemValueRange(left.Min / right, left.Max / right);
        }

        public static ItemValueRange operator /(double left, ItemValueRange right)
        {
            if (right == null)
            {
                throw new ArgumentNullException("right");
            }

            return new ItemValueRange(left / right.Min, left / right.Max);
        }

        #endregion

        /// <inheritdoc cref="Equals(object)" />
        public bool Equals(ItemValueRange value)
        {
            if (value == null)
            {
                return false;
            }

            return Math.Abs(Min - value.Min) < Tolerance && Math.Abs(Max - value.Max) < Tolerance;
        }

        #region >> Object

        /// <inheritdoc />
        public override bool Equals(Object value)
        {
            return value != null && Equals(value as ItemValueRange);
        }

        /// <inheritdoc />
        public override int GetHashCode()
        {
            return Min.GetHashCode() ^ Max.GetHashCode();
        }

        /// <inheritdoc />
        public override string ToString()
        {
            return "[" + Min + "-" + Max + "]";
        }

        #endregion

        public static void SumIntoLeftOperand(ItemValueRange left, ItemValueRange right)
        {
            if (right == null)
            {
                return;
            }

            left.Min += right.Min;
            left.Max += right.Max;
        }

        public static void SumAsPercentOnRemainingIntoLeftOperand(ItemValueRange left, ItemValueRange right)
        {
            if (right == null)
            {
                return;
            }

            left.Min = 1 - (1 - left.Min) * (1 - right.Min);
            left.Max = 1 - (1 - left.Max) * (1 - right.Max);
        }
    }
}