using System;

using ZTn.BNet.BattleNet;
using ZTn.BNet.D3;
using ZTn.BNet.D3.Heroes;
using ZTn.BNet.D3.Items;
using ZTn.BNet.D3.Careers;

namespace ZTn.BNet.D3.Example
{
    class Program
    {
        static void Main(string[] args)
        {
            BattleTag battleTag = new BattleTag("Tok#2360");

            writeCareer(battleTag);
        }

        static void writeCareer(BattleTag battleTag)
        {
            Career career = Career.getCareerFromBattleTag(battleTag);

            Console.WriteLine("BattleTag: " + career.battleTag.id);
            Console.WriteLine("Last hero played: {0}", career.lastHeroPlayed);
            Console.WriteLine("Time played on Monk is {0}", career.timePlayed.monk);
            Console.WriteLine("Kills: monsters={0} / elites={1} / hardcore monsters={2}", career.kills.monsters, career.kills.elites, career.kills.hardcoreMonsters);
            Console.WriteLine();
            Console.WriteLine("Heroes count: " + career.heroes.Length);
            foreach (HeroSummary heroDigest in career.heroes)
            {
                Console.WriteLine("Hero {0}: {1} is {2} level {3} + {4} last updated {5}",
                    heroDigest.id,
                    heroDigest.name,
                    heroDigest.heroClass,
                    heroDigest.level,
                    heroDigest.paragonLevel, heroDigest.lastUpdated);

                Hero heroFull = heroDigest.getHeroFromBattleTag(battleTag);

                Item mainHand = Item.getItemFromTooltipParams(heroFull.items.mainHand.tooltipParams);
                Console.WriteLine("Hero main hand: level {0} {1} (DPS {2}-{3}) salvages into {4} different components",
                    mainHand.itemLevel,
                    mainHand.name,
                    mainHand.dps.min, mainHand.dps.max,
                    mainHand.salvage.Length);

                Item torso = Item.getItemFromTooltipParams(heroFull.items.torso.tooltipParams);
                Console.WriteLine("Hero torso: level {0} {1} (armor {2}-{3}) salvages into {4} different components",
                    torso.itemLevel,
                    torso.name,
                    torso.armor.min, torso.armor.max,
                    torso.salvage.Length);
                Console.WriteLine("Hero DPS {0}", heroFull.stats.damage);

            }
            Console.WriteLine();
            Console.WriteLine("Fallen Heroes count: " + career.fallenHeroes.Length);
            foreach (HeroSummary heroDigest in career.fallenHeroes)
            {
                Console.WriteLine("Hero {0}: {1} is {2} level {3} + {4} ", heroDigest.id, heroDigest.name, heroDigest.heroClass, heroDigest.level, heroDigest.paragonLevel);
            }
        }
    }
}
