using System.Linq;
using ZTn.BNet.D3.Calculator.Skills.Barbarian;
using ZTn.BNet.D3.Calculator.Skills.DemonHunter;
using ZTn.BNet.D3.Calculator.Skills.Monk;
using ZTn.BNet.D3.Calculator.Skills.WitchDoctor;
using ZTn.BNet.D3.Calculator.Skills.Wizard;

namespace ZTn.BNet.D3.Calculator.Skills
{
    public class PassiveSkillModifierFactory
    {
        static readonly ID3SkillModifier[] Skills = 
        {
            new NervesOfSteel(),
            new Ruthless(),
            new ToughAsNails(),
            new WeaponsMaster(),

            new Archery(),
            new Perfectionist(),
            new SharpShooter(),
            new SteadyAim(),

            new OneWithEverything(),
            new SeizeTheInitiative(),
            new Unity(), 
            new Harmony(),

            new PierceTheVeil(),

            new UnwaveringWill(),
            new GlassCannon()
        };

        public static ID3SkillModifier GetFromSlug(string slug)
        {
            var skillModifier = Skills.FirstOrDefault(s => s.Slug == slug);

            if (skillModifier == null)
            {
                throw new UnknownSkillSlugException(slug);
            }

            return skillModifier;
        }
    }
}
