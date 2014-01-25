using System;

namespace ZTn.BNet.D3.Calculator.Skills
{
    public class UnknownSkillSlugException : Exception
    {
        public UnknownSkillSlugException(string slug)
            : base("Unknown skill slug '" + slug + "'encountered")
        {
        }
    }
}
