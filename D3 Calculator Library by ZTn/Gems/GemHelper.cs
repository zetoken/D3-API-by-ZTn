using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using ZTn.BNet.D3.Calculator.Gems;
using ZTn.BNet.D3.Items;
using ZTn.BNet.D3.Calculator.Helpers;

namespace ZTn.BNet.D3.Calculator.Gems
{
    public class GemHelper
    {
        #region >> Fields

        private static KnownGems _knownGems;

        private static List<Item> _helmSocketedGems;
        private static List<Item> _otherSocketedGems;
        private static List<Item> _weaponSocketedGems;

        #endregion

        #region >> Properties

        public static KnownGems knownGems
        {
            get
            {
                if (_knownGems == null)
                    _knownGems = KnownGems.getKnownGemsFromJsonFile("d3gem.json");
                return _knownGems;
            }
        }

        public static List<Item> helmSocketedGems
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
        public static List<Item> otherSocketedGems
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
        public static List<Item> weaponSocketedGems
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

        private static List<Item> filterGems(String itemTypeId)
        {
            List<Item> filteredGems = new List<Item>();
            foreach (Item gem in knownGems.gems)
            {
                filteredGems.AddRange(gem.socketEffects
                   .Where(e => e.itemTypeId == itemTypeId)
                   .Select(e => new Item(e.attributesRaw) { name = e.attributes[0], id = gem.id }));
            }
            return filteredGems;
        }

        public static List<Item> getGemsForItemTypeId(String itemTypeId)
        {
            if (ItemHelper.weaponTypeIds.Any(id => itemTypeId == id))
                return GemHelper.weaponSocketedGems;
            else if (ItemHelper.helmTypeIds.Any(id => itemTypeId.Contains(id)))
                return GemHelper.helmSocketedGems;
            else
                return GemHelper.otherSocketedGems;
        }
    }
}
