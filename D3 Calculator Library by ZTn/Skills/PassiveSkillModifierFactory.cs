using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ZTn.BNet.D3.Heroes;

namespace ZTn.BNet.D3.Calculator.Skills
{
    public class PassiveSkillModifierFactory
    {
        static List<ID3SkillModifier> skills = new List<ID3SkillModifier>()
        {
            new Skills.Barbarian.NervesOfSteel(),
            new Skills.Barbarian.Ruthless(),
            new Skills.Barbarian.ToughAsNails(),
            new Skills.Barbarian.WeaponsMaster(),

            new Skills.DemonHunter.Archery(),
            new Skills.DemonHunter.Perfectionist(),
            new Skills.DemonHunter.SharpShooter(),
            new Skills.DemonHunter.SteadyAim(),

            new Skills.Monk.OneWithEverything(),
            new Skills.Monk.SeizeTheInitiative(),

            new Skills.WitchDoctor.PierceTheVeil(),

            new Skills.Wizard.GalvanizingWard(),
            new Skills.Wizard.GlassCannon()
        };

        public static ID3SkillModifier getFromSlug(string slug)
        {
            ID3SkillModifier skillModifier = skills.FirstOrDefault(s => s.slug == slug);

            if (skillModifier == null)
            {
                throw new UnknownSkillSlugException(slug);
            }

            return skillModifier;
        }
    }
}
