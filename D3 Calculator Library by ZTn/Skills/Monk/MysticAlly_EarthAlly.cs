using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ZTn.BNet.D3.Heroes;
using ZTn.BNet.D3.Items;

namespace ZTn.BNet.D3.Calculator.Skills.Monk
{
    public sealed class MysticAlly_EarthAlly : ID3SkillModifier
    {
        #region >> ID3SkillModifier

        /// <inheritdoc />
        public HeroClass heroClass
        {
            get { return HeroClass.Monk; }
        }

        /// <inheritdoc />
        public string slug
        {
            get { return "mystic-ally-earth-ally"; }
        }

        /// <inheritdoc />
        public ItemAttributes getBonus(D3Calculator calculator)
        {
            return new ItemAttributes() { hitpointsMaxPercentBonusItem = new ItemValueRange(0.10) };
        }

        #endregion
    }
}
