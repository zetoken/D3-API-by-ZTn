using System;
using System.Linq;
using System.Reflection;
using System.Runtime.Serialization;

namespace ZTn.BNet.D3.Helpers
{
    public static class EnumMemberHelpers
    {
        /// <summary>
        /// Returns the string defined by <see cref="EnumMemberAttribute"/> attribute of the enumeration value.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="enumValue">A field of an <see cref="Enum"/>.</param>
        /// <returns></returns>
        public static string ToEnumString<T>(this T enumValue)
        {
            var valueName = Enum.GetName(typeof(T), enumValue);
            var enumMemberAttribute = typeof(T)
                .GetRuntimeField(valueName)
                .GetCustomAttributes<EnumMemberAttribute>()
                .FirstOrDefault();

            return enumMemberAttribute == null ? "Unknown" : enumMemberAttribute.Value;
        }

        /// <summary>
        /// Returns the enumeration value having an <see cref="EnumMemberAttribute"/> attribute with value beeing <paramref name="stringValue"/>.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="stringValue"></param>
        /// <returns>A matching value of the enumeration or the default value if no match.</returns>
        public static T ParseAsEnum<T>(this string stringValue)
        {
            foreach (var name in Enum.GetNames(typeof(T)))
            {
                var enumMemberAttribute = typeof(T)
                    .GetRuntimeField(name)
                    .GetCustomAttributes<EnumMemberAttribute>()
                    .FirstOrDefault();

                if (enumMemberAttribute != null && enumMemberAttribute.Value == stringValue)
                {
                    return (T)Enum.Parse(typeof(T), name);
                }
            }

            return default(T);
        }
    }
}