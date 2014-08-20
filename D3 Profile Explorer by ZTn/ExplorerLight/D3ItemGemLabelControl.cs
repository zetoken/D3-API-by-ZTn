using System;
using System.Linq;
using ZTn.BNet.D3.Items;

namespace ZTn.BNet.D3ProfileExplorer.ExplorerLight
{
    partial class D3ItemGemLabelControl : D3LabelControl
    {
        public D3ItemGemLabelControl()
        {
            InitializeComponent();

            InitializeControl();
        }

        public D3ItemGemLabelControl(SocketedGem socketedGem)
            : this()
        {
            guiGemEffectLabel.Text = String.Empty;

            if (socketedGem.Attributes.Primary != null && socketedGem.Attributes.Primary.Any())
            {
                foreach (var primary in socketedGem.Attributes.Primary)
                {
                    guiGemEffectLabel.Text += primary.Text;
                }
            }

            if (socketedGem.Attributes.Secondary != null && socketedGem.Attributes.Secondary.Any())
            {
                foreach (var secondary in socketedGem.Attributes.Secondary)
                {
                    guiGemEffectLabel.Text += secondary.Text;
                }
            }

            if (socketedGem.Attributes.Passive != null && socketedGem.Attributes.Passive.Any())
            {
                foreach (var passive in socketedGem.Attributes.Passive)
                {
                    guiGemEffectLabel.Text += passive.Text;
                }
            }
        }
    }
}