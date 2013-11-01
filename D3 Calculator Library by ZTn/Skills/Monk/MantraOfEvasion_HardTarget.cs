using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ZTn.BNet.D3.Heroes;
using ZTn.BNet.D3.Items;

namespace ZTn.BNet.D3.Calculator.Skills.Monk
{
    public sealed class MantraOfEvasion_HardTarget : ID3SkillModifier
    {
        readonly double multiplier = 0.20;

        #region >> ID3SkillModifier

        /// <inheritdoc />
        public HeroClass heroClass
        {
            get { return HeroClass.Monk; }
        }

        /// <inheritdoc />
        public string slug
        {
            get { return "mantra-of-evasion-hard-target"; }
        }

        /// <inheritdoc />
        public ItemAttributes getBonus(D3Calculator calculator)
        {
            ItemAttributes attr = new ItemAttributes();

            attr.armorBonusItem = multiplier * calculator.getHeroArmor();

            return attr;
        }

        #endregion
    }
}
