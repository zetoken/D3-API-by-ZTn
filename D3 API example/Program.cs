using System;
using System.Collections.Generic;
using System.Linq;
using ZTn.BNet.BattleNet;
using ZTn.BNet.D3.Calculator;
using ZTn.BNet.D3.Calculator.Helpers;
using ZTn.BNet.D3.Calculator.Skills;
using ZTn.BNet.D3.Careers;
using ZTn.BNet.D3.Heroes;
using ZTn.BNet.D3.Items;
using ZTn.Bnet.Portable.Windows;

namespace ZTn.BNet.D3.Example
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            RegisterPcl.Register();

            var battleTag = new BattleTag("Tok#2360");

            // WriteCareer(battleTag);
            WriteCalculation(battleTag);

            Console.WriteLine();
            Console.WriteLine("= = = = END = = = =");
            Console.ReadLine();
        }

        private static void WriteCalculation(BattleTag battleTag)
        {
            Console.WriteLine("= = = = Calculator of {0} = = = =", battleTag);

            Console.WriteLine("Downloading {0}", "career");
            var career = Career.CreateFromBattleTag(battleTag);
            if (career == null || career.Heroes.Length == 0)
            {
                return;
            }

            Console.WriteLine("Downloading Hero {0}/{1}", battleTag, career.Heroes[0].name);
            var hero = Hero.CreateFromHeroId(battleTag, career.Heroes[0].id);
            if (hero == null || hero.items == null)
            {
                return;
            }

            Console.WriteLine("Downloading {0}", "bracers");
            var bracers = hero.items.bracers.GetFullItem();
            Console.WriteLine("Downloading {0}", "feet");
            var feet = hero.items.feet.GetFullItem();
            Console.WriteLine("Downloading {0}", "hands");
            var hands = hero.items.hands.GetFullItem();
            Console.WriteLine("Downloading {0}", "head");
            var head = hero.items.head.GetFullItem();
            Console.WriteLine("Downloading {0}", "leftFinger");
            var leftFinger = hero.items.leftFinger.GetFullItem();
            Console.WriteLine("Downloading {0}", "legs");
            var legs = hero.items.legs.GetFullItem();
            Console.WriteLine("Downloading {0}", "mainHand");
            var mainHand = hero.items.mainHand.GetFullItem();
            Console.WriteLine("Downloading {0}", "neck");
            var neck = hero.items.neck.GetFullItem();
            Console.WriteLine("Downloading {0}", "offHand");
            var offHand = hero.items.offHand.GetFullItem();
            Console.WriteLine("Downloading {0}", "rightFinger");
            var rightFinger = hero.items.rightFinger.GetFullItem();
            Console.WriteLine("Downloading {0}", "shoulders");
            var shoulders = hero.items.shoulders.GetFullItem();
            Console.WriteLine("Downloading {0}", "torso");
            var torso = hero.items.torso.GetFullItem();
            Console.WriteLine("Downloading {0}", "waist");
            var waist = hero.items.waist.GetFullItem();

            var items = new List<Item> { bracers, feet, hands, head, leftFinger, legs, neck, rightFinger, shoulders, torso, waist }.Where(i => i != null).ToList();

            var allItems = new List<Item>(items) { mainHand, offHand }.Where(i => i != null).ToList();

            Console.WriteLine("Calculating activated set");
            foreach (var set in allItems.GetActivatedSets())
            {
                Console.WriteLine("Activated set: {0}", set.name);
            }
            var setBonus = new Item(allItems.GetActivatedSetBonus());
            items.Add(setBonus);

            var d3Calculator = new D3Calculator(hero, mainHand, offHand, items.ToArray());

            Console.WriteLine("Calculation results");
            var dps = d3Calculator.GetHeroDps(new List<ID3SkillModifier>(), new List<ID3SkillModifier>());
            Console.WriteLine("Dexterity : {0}", d3Calculator.GetHeroDexterity().Min);
            Console.WriteLine("DPS : {0}", dps.Min);
            Console.WriteLine("Attack speed: {0}", d3Calculator.GetActualAttackSpeed().Min);
        }

        private static void WriteCareer(BattleTag battleTag)
        {
            var career = Career.CreateFromBattleTag(battleTag);

            Console.WriteLine("BattleTag: " + career.BattleTag.Id);
            Console.WriteLine("Last hero played: {0}", career.LastHeroPlayed);
            Console.WriteLine("Time played on Monk is {0}", career.TimePlayed.Monk);
            Console.WriteLine("Kills: monsters={0} / elites={1} / hardcore monsters={2}", career.Kills.monsters, career.Kills.elites, career.Kills.hardcoreMonsters);
            Console.WriteLine();
            Console.WriteLine("Heroes count: " + career.Heroes.Length);
            foreach (var heroDigest in career.Heroes)
            {
                Console.WriteLine("Hero {0}: {1} is {2} level {3} + {4} last updated {5}",
                    heroDigest.id,
                    heroDigest.name,
                    heroDigest.heroClass,
                    heroDigest.level,
                    heroDigest.paragonLevel, heroDigest.lastUpdated);

                var heroFull = heroDigest.GetHeroFromBattleTag(battleTag);

                if (heroFull.items.mainHand != null)
                {
                    var mainHand = Item.CreateFromTooltipParams(heroFull.items.mainHand.TooltipParams);
                    Console.WriteLine("Hero main hand: level {0} {1} (DPS {2}-{3}) is of type {4}",
                        mainHand.ItemLevel,
                        mainHand.Name,
                        mainHand.Dps.Min, mainHand.Dps.Max,
                        mainHand.TypeName);
                }

                if (heroFull.items.torso != null)
                {
                    var torso = Item.CreateFromTooltipParams(heroFull.items.torso.TooltipParams);
                    Console.WriteLine("Hero torso: level {0} {1} (armor {2}-{3}) is of type {4}",
                        torso.ItemLevel,
                        torso.Name,
                        torso.Armor.Min, torso.Armor.Max,
                        torso.TypeName);
                }

                Console.WriteLine("Hero DPS {0}", heroFull.stats.damage);
            }
            Console.WriteLine();
            Console.WriteLine("Fallen Heroes count: " + career.FallenHeroes.Length);
            foreach (var heroDigest in career.FallenHeroes)
            {
                Console.WriteLine("Hero {0}: {1} is {2} level {3} + {4} ", heroDigest.id, heroDigest.name, heroDigest.heroClass, heroDigest.level, heroDigest.paragonLevel);
            }
        }
    }
}