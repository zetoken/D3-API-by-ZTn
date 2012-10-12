using ZTn.BNet.D3.Items;

namespace ZTn.BNet.D3.Calculator.Skills.Monk
{
    public class OneWithEverything : D3SkillModifier
    {
        public override ItemAttributes getBonus(D3Calculator calculator)
        {
            ItemAttributes stuff = calculator.heroStuff.attributesRaw;
            ItemAttributes attr = new ItemAttributes();

            double maxResist = 0;

            double resistanceArcane = calculator.getHeroResistance_Arcane();
            if (resistanceArcane > maxResist) maxResist = resistanceArcane;

            double resistanceCold = calculator.getHeroResistance_Cold();
            if (resistanceCold > maxResist) maxResist = resistanceCold;

            double resistanceFire = calculator.getHeroResistance_Fire();
            if (resistanceFire > maxResist) maxResist = resistanceFire;

            double resistanceLightning = calculator.getHeroResistance_Lightning();
            if (resistanceLightning > maxResist) maxResist = resistanceLightning;

            double resistancePhysical = calculator.getHeroResistance_Physical();
            if (resistancePhysical > maxResist) maxResist = resistancePhysical;

            double resistancePoison = calculator.getHeroResistance_Poison();
            if (resistancePoison > maxResist) maxResist = resistancePoison;

            double resistanceAll = calculator.getHeroResistance_All();

            if (stuff.resistance_Arcane != null)
                attr.resistance_Arcane = ItemValueRange.Zero - stuff.resistance_Arcane;
            if (stuff.resistance_Cold != null)
                attr.resistance_Cold = ItemValueRange.Zero - stuff.resistance_Cold;
            if (stuff.resistance_Fire != null)
                attr.resistance_Fire = ItemValueRange.Zero - stuff.resistance_Fire;
            if (stuff.resistance_Lightning != null)
                attr.resistance_Lightning = ItemValueRange.Zero - stuff.resistance_Lightning;
            if (stuff.resistance_Physical != null)
                attr.resistance_Physical = ItemValueRange.Zero - stuff.resistance_Physical;
            if (stuff.resistance_Poison != null)
                attr.resistance_Poison = ItemValueRange.Zero - stuff.resistance_Poison;
            if (stuff.resistanceAll != null)
                attr.resistanceAll = new ItemValueRange(maxResist - calculator.getHeroResistance_All());

            return attr;
        }
    }
}
