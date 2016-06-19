using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Serialization;
using ZTn.BNet.D3.Calculator.Helpers;
using ZTn.BNet.D3.Helpers;
using ZTn.BNet.D3.Items;

namespace ZTn.BNet.D3.Calculator.Gems
{
    [DataContract]
    public class KnownGems
    {
        #region >> Fields

        [DataMember(Name = "gems")]
        public List<Item> Gems;

        [IgnoreDataMember]
        private List<Item> amuletSocketedGems;

        [IgnoreDataMember]
        private List<Item> helmSocketedGems;

        [IgnoreDataMember]
        private List<Item> otherSocketedGems;

        [IgnoreDataMember]
        private List<Item> ringSocketedGems;

        [IgnoreDataMember]
        private List<Item> weaponSocketedGems;

        #endregion

        #region >> Properties

        [IgnoreDataMember]
        public List<Item> AmuletSocketedGems
        {
            get
            {
                if (amuletSocketedGems == null)
                {
                    amuletSocketedGems = FilterGems("Amulet");
                }
                return amuletSocketedGems;
            }
        }

        [IgnoreDataMember]
        public List<Item> HelmSocketedGems
        {
            get
            {
                if (helmSocketedGems == null)
                {
                    helmSocketedGems = FilterGems("Helm");
                }
                return helmSocketedGems;
            }
        }

        [IgnoreDataMember]
        public List<Item> OtherSocketedGems
        {
            get
            {
                if (otherSocketedGems == null)
                {
                    otherSocketedGems = FilterGems("Other");
                }
                return otherSocketedGems;
            }
        }

        [IgnoreDataMember]
        public List<Item> RingSocketedGems
        {
            get
            {
                if (ringSocketedGems == null)
                {
                    ringSocketedGems = FilterGems("Ring");
                }
                return ringSocketedGems;
            }
        }

        [IgnoreDataMember]
        public List<Item> WeaponSocketedGems
        {
            get
            {
                if (weaponSocketedGems == null)
                {
                    weaponSocketedGems = FilterGems("Weapon");
                }
                return weaponSocketedGems;
            }
        }

        #endregion

        #region >> Constructors

        public KnownGems(List<Item> gems)
        {
            Gems = gems;
        }

        #endregion

        public static KnownGems GetKnownGemsFromJsonFile(string fileName)
        {
            return new KnownGems(fileName.CreateFromJsonFile<List<Item>>());
        }

        public static KnownGems GetKnownGemsFromJsonStream(Stream stream)
        {
            return new KnownGems(stream.CreateFromJsonStream<List<Item>>());
        }

        private List<Item> FilterGems(string itemTypeId)
        {
            var filteredGems = new List<Item>();
            foreach (var gem in Gems)
            {
                filteredGems.AddRange(gem.SocketEffects
                   .Where(e => e.ItemTypeId == itemTypeId)
                   .Select(e => new Item
                   {
                       Id = gem.Id,
                       Attributes = e.IsAttributesFieldEmpty() ? gem.Attributes : e.Attributes,
                       AttributesRaw = gem.AttributesRaw + e.AttributesRaw,
                       Name = gem.Name,
                       Icon = gem.Icon
                   }));
            }
            return filteredGems;
        }

        public List<Item> GetGemsForItem(Item item)
        {
            return GetGemsForItemTypeId(item.Type.Id, item.Slots);
        }

        public List<Item> GetGemsForItemTypeId(string itemTypeId, Slot[] slots = null)
        {
            if (Constants.WeaponTypeIds.Any(id => itemTypeId == id))
            {
                return WeaponSocketedGems;
            }

            if (Constants.HelmTypeIds.Any(itemTypeId.Contains))
            {
                return HelmSocketedGems;
            }

            switch (itemTypeId)
            {
                case "Amulet":
                    return AmuletSocketedGems.Concat(OtherSocketedGems).ToList();
                case "Ring":
                    return RingSocketedGems.Concat(OtherSocketedGems).ToList();
            }

            return OtherSocketedGems;
        }
    }
}
