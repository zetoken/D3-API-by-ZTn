using ZTn.BNet.BattleNet;

namespace ZTn.BNet.D3ProfileExplorer.ExplorerLight
{
    internal class D3ProfileContainer
    {
        public BattleTag BattleTag { get; set; }

        public Host Host { get; set; }

        public D3ProfileContainer(BattleTag battleTag, Host host)
        {
            BattleTag = battleTag;
            Host = host;
        }
    }
}