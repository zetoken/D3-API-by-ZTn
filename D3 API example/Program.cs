using System;

using ZTn.BNet.BattleNet;
using ZTn.BNet.D3;
using ZTn.BNet.D3.Heroes;
using ZTn.BNet.D3.Items;
using ZTn.BNet.D3.Careers;
using ZTn.BNet.D3.Calculator;
using ZTn.BNet.D3.Calculator.Sets;
using System.Collections.Generic;

namespace ZTn.BNet.D3.Example
{
    class Program
    {
        static void Main(string[] args)
        {
            BattleTag battleTag = new BattleTag("Tok#2360");

            //writeCareer(battleTag);
            writeCalculation(battleTag);

            Console.WriteLine();
            Console.WriteLine("= = = = END = = = =");
            Console.ReadLine();
        }

        static void writeCalculation(BattleTag battleTag)
        {
            Console.WriteLine("= = = = Calculator of {0} = = = =", battleTag);

            Console.WriteLine("Downloading {0}", "career");
            Career career = Career.getCareerFromBattleTag(battleTag);
            if (career == null || career.heroes.Length == 0)
                return;
            Console.WriteLine("Downloading Hero {0}/{1}", battleTag, career.heroes[0].name);
            Hero hero = Hero.getHeroFromHeroId(battleTag, career.heroes[0].id);
            if (hero == null || hero.items == null)
                return;
            Console.WriteLine("Downloading {0}", "bracers");
            Item bracers = hero.items.bracers.getFullItem();
            Console.WriteLine("Downloading {0}", "feet");
            Item feet = hero.items.feet.getFullItem();
            Console.WriteLine("Downloading {0}", "hands");
            Item hands = hero.items.hands.getFullItem();
            Console.WriteLine("Downloading {0}", "head");
            Item head = hero.items.head.getFullItem();
            Console.WriteLine("Downloading {0}", "leftFinger");
            Item leftFinger = hero.items.leftFinger.getFullItem();
            Console.WriteLine("Downloading {0}", "legs");
            Item legs = hero.items.legs.getFullItem();
            Console.WriteLine("Downloading {0}", "mainHand");
            Item mainHand = hero.items.mainHand.getFullItem();
            Console.WriteLine("Downloading {0}", "neck");
            Item neck = hero.items.neck.getFullItem();
            Console.WriteLine("Downloading {0}", "offHand");
            Item offHand = hero.items.offHand.getFullItem();
            Console.WriteLine("Downloading {0}", "rightFinger");
            Item rightFinger = hero.items.rightFinger.getFullItem();
            Console.WriteLine("Downloading {0}", "shoulders");
            Item shoulders = hero.items.shoulders.getFullItem();
            Console.WriteLine("Downloading {0}", "torso");
            Item torso = hero.items.torso.getFullItem();
            Console.WriteLine("Downloading {0}", "waist");
            Item waist = hero.items.waist.getFullItem();

            List<Item> items = new List<Item>(new List<Item>() { bracers, feet, hands, head, leftFinger, legs, neck, rightFinger, shoulders, torso, waist });

            D3Calculator d3Calculator = new D3Calculator(hero, mainHand, offHand, items.ToArray());

            Console.WriteLine("Loading {0} from file", "known sets");
            KnownSets knownSets = KnownSets.getKnownSetsFromJsonFile("d3set.json");

            Console.WriteLine("Calculating set bonus");
            Item setBonus = new Item(d3Calculator.heroItemStats.getActivatedSetBonus(knownSets));
            items.Add(setBonus);

            d3Calculator = new D3Calculator(hero, mainHand, offHand, items.ToArray());

            Console.WriteLine("Calculation results");
            double dps = d3Calculator.getHeroDPS();
            Console.WriteLine("Dexterity : {0}", d3Calculator.getHeroDexterity());
            Console.WriteLine("DPS : {0}", dps);
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
