using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using ZTn.BNet.D3.Items;

namespace ZTn.BNet.D3.Helpers
{
    /// <summary>
    /// Helper class allowing to "deep copy" some major property types of objects:
    /// <list>
    ///     <item><see cref="Item"/></item>
    ///     <item><see cref="ItemAttributes"/></item>
    ///     <item><see cref="ItemType"/></item>
    ///     <item><see cref="ItemValueRange"/></item>
    /// </list>
    /// Copy by reference is used for other property types.
    /// </summary>
    public static class D3DeepCopy
    {
        /// <summary>
        /// Deep copy the <paramref name="source"/> instance to the <paramref name="target"/> instance using reflection.
        /// "Deep" is limited by known types of DeepCopy.
        /// Use this helper only with complex types like <see cref="Item"/> or <see cref="ItemAttributes"/>.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="source"></param>
        /// <param name="target"></param>
        public static void deepCopy<T>(this T source, T target) where T : class
        {
            foreach (PropertyInfo info in typeof(T).GetProperties())
            {
                object value = info.GetValue(source, null);
                if (value != null)
                {
                    D3DeepCopy.copyValue(info, target, (dynamic)value);
                }
            }
        }

        static void copyValue(PropertyInfo info, object target, bool value)
        {
            info.SetValue(target, value, null);
        }

        static void copyValue(PropertyInfo info, object target, double value)
        {
            info.SetValue(target, value, null);
        }

        static void copyValue(PropertyInfo info, object target, float value)
        {
            info.SetValue(target, value, null);
        }

        static void copyValue(PropertyInfo info, object target, int value)
        {
            info.SetValue(target, value, null);
        }

        /// <summary>
        /// Unknown types are not deep copied !
        /// </summary>
        /// <param name="info"></param>
        /// <param name="target"></param>
        /// <param name="value"></param>
        static void copyValue(PropertyInfo info, object target, object value)
        {
            info.SetValue(target, value, null);
        }

        static void copyValue(PropertyInfo info, object target, Item value)
        {
            info.SetValue(target, new Item(value), null);
        }

        static void copyValue(PropertyInfo info, object target, ItemAttributes value)
        {
            info.SetValue(target, new ItemAttributes(value), null);
        }

        static void copyValue(PropertyInfo info, object target, ItemType value)
        {
            info.SetValue(target, new ItemType(value), null);
        }

        static void copyValue(PropertyInfo info, object target, ItemValueRange value)
        {
            info.SetValue(target, new ItemValueRange(value), null);
        }
    }
}
