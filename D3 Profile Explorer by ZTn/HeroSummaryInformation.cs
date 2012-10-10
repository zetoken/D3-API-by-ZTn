using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ZTn.BNet.BattleNet;
using ZTn.BNet.D3.Heroes;

namespace ZTn.BNet.D3ProfileExplorer
{
    class HeroSummaryInformation
    {
        #region >> Fields

        public String host;
        public BattleTag battleTag;
        public HeroSummary heroSummary;

        #endregion

        #region >> Constructors

        public HeroSummaryInformation(String host, BattleTag battleTag, HeroSummary heroSummary)
        {
            this.host = host;
            this.battleTag = battleTag;
            this.heroSummary = heroSummary;
        }

        #endregion
    }
}
