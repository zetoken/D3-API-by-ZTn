using ZTn.BNet.BattleNet;

namespace ZTn.BNet.D3ProfileExplorer.ExplorerLight
{
    partial class BNetProfileControl : D3SelectableControl
    {
        public BattleTag BattleTag
        {
            set
            {
                guiBattleTagName.Text = value.Name.ToLower();
                guiBattleTagCode.Text = "#" + value.Code;
            }
        }

        public Host Host
        {
            set { GuiProfileHost.Text = value.Url; }
        }

        public BNetProfileControl()
        {
            InitializeComponent();

            InitializeControl();
        }

        public BNetProfileControl(BattleTag battleTag, Host host)
            : this()
        {
            BattleTag = battleTag;
            Host = host;
        }
    }
}