using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using ZTn.BNet.D3.Calculator.Gems;
using ZTn.BNet.D3.Items;

namespace ZTn.BNet.D3.Calculator.Gems
{
    public class GemHelper
    {
        private static KnownGems _knownGems;

        private static List<Item> _helmSocketedGems;
        private static List<Item> _otherSocketedGems;
        private static List<Item> _weaponSocketedGems;

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
                    _helmSocketedGems = new List<Item>();
                    foreach (Item gem in knownGems.gems)
                    {
                        foreach (SocketEffect effect in gem.socketEffects)
                        {
                            if (effect.itemTypeId == "Helm")
                                _helmSocketedGems.Add(new Item(effect.attributesRaw) { name = effect.attributes[0], id = gem.id });
                        }
                    }
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
                    _otherSocketedGems = new List<Item>();
                    foreach (Item gem in knownGems.gems)
                    {
                        foreach (SocketEffect effect in gem.socketEffects)
                        {
                            if (effect.itemTypeId == "All")
                                _otherSocketedGems.Add(new Item(effect.attributesRaw) { name = effect.attributes[0], id = gem.id });
                        }
                    }
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
                    _weaponSocketedGems = new List<Item>();
                    foreach (Item gem in knownGems.gems)
                    {
                        foreach (SocketEffect effect in gem.socketEffects)
                        {
                            if (effect.itemTypeId == "Weapon")
                                _weaponSocketedGems.Add(new Item(effect.attributesRaw) { name = effect.attributes[0], id = gem.id });
                        }
                    }
                }
                return _weaponSocketedGems;
            }
        }
    }
}
