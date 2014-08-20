using ZTn.BNet.BattleNet;
using ZTn.BNet.D3.Heroes;

namespace ZTn.BNet.D3ProfileExplorer.ExplorerLight
{
    internal class D3HeroContainer
    {
        public BattleTag BattleTag { get; set; }

        public Host Host { get; set; }

        public HeroSummary HeroSummary { get; set; }

        public D3HeroContainer(HeroSummary heroSummary, BattleTag battleTag, Host host)
        {
            HeroSummary = heroSummary;
            BattleTag = battleTag;
            Host = host;
        }
    }
}