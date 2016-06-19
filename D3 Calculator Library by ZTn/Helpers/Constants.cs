using System.Reflection;
using ZTn.BNet.D3.Helpers;
using ZTn.BNet.D3.Items;

namespace ZTn.BNet.D3.Calculator.Helpers
{
    public static class Constants
    {
        static Constants()
        {
            HelmTypeIds = LoadFromJsonResourceFile<string[]>("typeid-helms.json");
            WeaponTypeIds = LoadFromJsonResourceFile<string[]>("typeid-weapons.json");
            DamageResists = LoadFromJsonResourceFile<string[]>("damage-resists.json");
            DamagePrefixes = LoadFromJsonResourceFile<string[]>("damage-prefixes.json");
        }

        public static Item BlankWeapon => new Item(new ItemAttributes());

        public static Item NakedHandWeapon => new Item(new ItemAttributes { attacksPerSecondItem = ItemValueRange.One });

        public static readonly string[] DamagePrefixes;

        public static readonly string[] DamageResists;

        public static readonly string[] WeaponTypeIds;

        public static readonly string[] HelmTypeIds;

        private static T LoadFromJsonResourceFile<T>(string filename)
        {
            using (var stream = typeof(D3Calculator).GetTypeInfo().Assembly.GetManifestResourceStream($"{typeof(D3Calculator).Namespace}.Resources.{filename}"))
            {
                return stream.CreateFromJsonStream<T>();
            }
        }
    }
}