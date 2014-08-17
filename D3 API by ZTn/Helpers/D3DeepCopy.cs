using System.Linq;
using System.Reflection;
using ZTn.BNet.D3.Annotations;
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
        public static void DeepCopy<T>(this T source, T target) where T : class
        {
            foreach (var info in typeof(T).GetRuntimeProperties())
            {
                var value = info.GetValue(source, null);
                if (value != null)
                {
                    CopyValue(info, target, value);
                }
            }
        }

        /// <summary>
        /// Deep copy the <paramref name="source"/> instance to a new instance using reflection.
        /// "Deep" is limited by known types of DeepCopy.
        /// Use this helper only with complex types like <see cref="Item"/> or <see cref="ItemAttributes"/>.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="source"></param>
        /// <returns></returns>
        public static T DeepClone<T>(this T source) where T : class, new()
        {
            if (source == null)
            {
                return null;
            }

            var target = new T();
            source.DeepCopy(target);

            return target;
        }

        [UsedImplicitly]
        private static void CopyValue(PropertyInfo info, object target, bool value)
        {
            info.SetValue(target, value, null);
        }

        [UsedImplicitly]
        private static void CopyValue(PropertyInfo info, object target, double value)
        {
            info.SetValue(target, value, null);
        }

        [UsedImplicitly]
        private static void CopyValue(PropertyInfo info, object target, float value)
        {
            info.SetValue(target, value, null);
        }

        [UsedImplicitly]
        private static void CopyValue(PropertyInfo info, object target, int value)
        {
            info.SetValue(target, value, null);
        }

        /// <summary>
        /// Unknown types are not deep copied !
        /// </summary>
        /// <param name="info"></param>
        /// <param name="target"></param>
        /// <param name="value"></param>
        private static void CopyValue(PropertyInfo info, object target, object value)
        {
            info.SetValue(target, value, null);
        }

        [UsedImplicitly]
        private static void CopyValue(PropertyInfo info, object target, Item value)
        {
            info.SetValue(target, new Item(value), null);
        }

        [UsedImplicitly]
        private static void CopyValue(PropertyInfo info, object target, ItemAttributes value)
        {
            info.SetValue(target, new ItemAttributes(value), null);
        }

        [UsedImplicitly]
        private static void CopyValue(PropertyInfo info, object target, ItemType value)
        {
            info.SetValue(target, new ItemType(value), null);
        }

        [UsedImplicitly]
        private static void CopyValue(PropertyInfo info, object target, ItemValueRange value)
        {
            info.SetValue(target, new ItemValueRange(value), null);
        }

        [UsedImplicitly]
        private static void CopyValue(PropertyInfo info, object target, SocketedGem[] value)
        {
            info.SetValue(target, value.Select(socketedGem => new SocketedGem(socketedGem)).ToArray(), null);
        }
    }
}