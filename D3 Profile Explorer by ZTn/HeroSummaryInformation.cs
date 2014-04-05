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

        public String Host;
        public BattleTag BattleTag;
        public HeroSummary HeroSummary;

        #endregion

        #region >> Constructors

        public HeroSummaryInformation(String host, BattleTag battleTag, HeroSummary heroSummary)
        {
            this.Host = host;
            this.BattleTag = battleTag;
            this.HeroSummary = heroSummary;
        }

        #endregion
    }
}
