using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
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
        private const string ApiKey = "zrxxcy3qzp8jcbgrce2es4yq52ew2k7r";

        private static void Main(string[] args)
        {
            RegisterPcl.Register();

            D3Api.ApiKey = ApiKey;

            var battleTag = new BattleTag("Tok#2360");

            // WriteCareer(battleTag);
            WriteCalculation(battleTag).Wait();

            Console.WriteLine();
            Console.WriteLine("= = = = END = = = =");
            Console.ReadLine();
        }

        private static async Task<Item> GetFullItem(ItemSummary itemSummary, string itemName)
        {
            if (itemSummary == null)
            {
                return null;
            }

            Console.WriteLine($"Downloading {itemName}");

            var itemAsync = await itemSummary?.GetFullItemAsync();

            Console.WriteLine($"{itemName} downloaded");

            return itemAsync;
        }

        private static async Task WriteCalculation(BattleTag battleTag)
        {
            Console.WriteLine("= = = = Calculator of {0} = = = =", battleTag);

            Console.WriteLine("Downloading {0}", "career");
            var career = await D3Api.GetCareerFromBattleTagAsync(battleTag);
            if (career == null || career.Heroes.Length == 0)
            {
                return;
            }

            Console.WriteLine("Downloading Hero {0}/{1}", battleTag, career.Heroes[0].Name);
            var hero = await D3Api.GetHeroFromHeroIdAsync(battleTag, career.Heroes[0].Id);
            if (hero?.Items == null)
            {
                return;
            }

            var bracersTask = GetFullItem(hero.Items.Bracers, "bracers");
            var feetTask = GetFullItem(hero.Items.Feet, "feet");
            var handsTask = GetFullItem(hero.Items.Hands, "hands");
            var headTask = GetFullItem(hero.Items.Hands, "head");
            var leftFingerTask = GetFullItem(hero.Items.LeftFinger, "leftFinger");
            var legsTask = GetFullItem(hero.Items.Legs, "legs");
            var mainHandTask = GetFullItem(hero.Items.MainHand, "mainHand");
            var neckTask = GetFullItem(hero.Items.Neck, "neck");
            var offHandTask = GetFullItem(hero.Items.OffHand, "offHand");
            var rightFingerTask = GetFullItem(hero.Items.RightFinger, "rightFinger");
            var shouldersTask = GetFullItem(hero.Items.Shoulders, "shoulders");
            var torsoTask = GetFullItem(hero.Items.Torso, "torso");
            var waistTask = GetFullItem(hero.Items.Waist, "waist");

            Task.WaitAll(bracersTask, feetTask, handsTask, headTask, leftFingerTask, legsTask, mainHandTask, neckTask, offHandTask, rightFingerTask, shouldersTask, torsoTask, waistTask);

            var bracers = bracersTask.Result;
            var feet = feetTask.Result;
            var hands = handsTask.Result;
            var head = headTask.Result;
            var leftFinger = leftFingerTask.Result;
            var legs = legsTask.Result;
            var mainHand = mainHandTask.Result;
            var neck = neckTask.Result;
            var offHand = offHandTask.Result;
            var rightFinger = rightFingerTask.Result;
            var shoulders = shouldersTask.Result;
            var torso = torsoTask.Result;
            var waist = waistTask.Result;

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
            Console.WriteLine("Kills: monsters={0} / elites={1} / hardcore monsters={2}", career.Kills.Monsters, career.Kills.Elites,
                career.Kills.HardcoreMonsters);
            Console.WriteLine();
            Console.WriteLine("Heroes count: " + career.Heroes.Length);
            foreach (var heroDigest in career.Heroes)
            {
                Console.WriteLine("Hero {0}: {1} is {2} level {3} + {4} last updated {5}",
                    heroDigest.Id,
                    heroDigest.Name,
                    heroDigest.HeroClass,
                    heroDigest.Level,
                    heroDigest.ParagonLevel, heroDigest.LastUpdated);

                var heroFull = heroDigest.GetHeroFromBattleTag(battleTag);

                if (heroFull.Items.MainHand != null)
                {
                    var mainHand = Item.CreateFromTooltipParams(heroFull.Items.MainHand.TooltipParams);
                    Console.WriteLine("Hero main hand: level {0} {1} (DPS {2}-{3}) is of type {4}",
                        mainHand.ItemLevel,
                        mainHand.Name,
                        mainHand.Dps.Min, mainHand.Dps.Max,
                        mainHand.TypeName);
                }

                if (heroFull.Items.Torso != null)
                {
                    var torso = Item.CreateFromTooltipParams(heroFull.Items.Torso.TooltipParams);
                    Console.WriteLine("Hero torso: level {0} {1} (armor {2}-{3}) is of type {4}",
                        torso.ItemLevel,
                        torso.Name,
                        torso.Armor.Min, torso.Armor.Max,
                        torso.TypeName);
                }

                Console.WriteLine("Hero DPS {0}", heroFull.Stats.Damage);
            }
            Console.WriteLine();
            Console.WriteLine("Fallen Heroes count: " + career.FallenHeroes.Length);
            foreach (var heroDigest in career.FallenHeroes)
            {
                Console.WriteLine("Hero {0}: {1} is {2} level {3} + {4} ", heroDigest.Id, heroDigest.Name, heroDigest.Hardcore, heroDigest.Level,
                    heroDigest.ParagonLevel);
            }
        }
    }
}