using System;
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

        [DataMember]
        public List<Item> gems;

        [IgnoreDataMember]
        private List<Item> _helmSocketedGems;
        [IgnoreDataMember]
        private List<Item> _otherSocketedGems;
        [IgnoreDataMember]
        private List<Item> _weaponSocketedGems;

        #endregion

        #region >> Properties

        [IgnoreDataMember]
        public List<Item> helmSocketedGems
        {
            get
            {
                if (_helmSocketedGems == null)
                {
                    _helmSocketedGems = filterGems("Helm");
                }
                return _helmSocketedGems;
            }
        }

        [IgnoreDataMember]
        public List<Item> otherSocketedGems
        {
            get
            {
                if (_otherSocketedGems == null)
                {
                    _otherSocketedGems = filterGems("All"); ;
                }
                return _otherSocketedGems;
            }
        }

        [IgnoreDataMember]
        public List<Item> weaponSocketedGems
        {
            get
            {
                if (_weaponSocketedGems == null)
                {
                    _weaponSocketedGems = filterGems("Weapon");
                }
                return _weaponSocketedGems;
            }
        }

        #endregion

        #region >> Constructors

        public KnownGems(List<Item> gems)
        {
            this.gems = gems;
        }

        #endregion

        public static KnownGems getKnownGemsFromJsonFile(String fileName)
        {
            return new KnownGems(JsonHelpers.getFromJsonFile<List<Item>>(fileName));
        }

        public static KnownGems getKnownGemsFromJsonStream(Stream stream)
        {
            return new KnownGems(JsonHelpers.getFromJSonStream<List<Item>>(stream));
        }

        private List<Item> filterGems(String itemTypeId)
        {
            List<Item> filteredGems = new List<Item>();
            foreach (Item gem in gems)
            {
                filteredGems.AddRange(gem.socketEffects
                   .Where(e => e.itemTypeId == itemTypeId)
                   .Select(e => new Item()
                   {
                       id = gem.id,
                       attributes = e.attributes,
                       attributesRaw = e.attributesRaw,
                       name = gem.name,
                       icon = gem.icon
                   }));
            }
            return filteredGems;
        }

        public List<Item> getGemsForItem(Item item)
        {
            return getGemsForItemTypeId(item.type.id);
        }

        public List<Item> getGemsForItemTypeId(String itemTypeId)
        {
            if (ItemHelper.weaponTypeIds.Any(id => itemTypeId == id))
                return weaponSocketedGems;
            else if (ItemHelper.helmTypeIds.Any(id => itemTypeId.Contains(id)))
                return helmSocketedGems;
            else
                return otherSocketedGems;
        }
    }
}
