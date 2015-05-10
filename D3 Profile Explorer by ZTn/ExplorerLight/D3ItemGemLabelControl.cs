using System;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
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

            if (socketedGem.AttributesRaw.JewelRank != null)
            {
                guiGemEffectLabel.Text += Environment.NewLine + String.Format("Rank {0}", socketedGem.AttributesRaw.JewelRank.Min);
            }
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            guiGemEffectLabel.MaximumSize = new Size(Size.Width - Padding.Left - Padding.Right, 0);

            base.OnPaint(e);
        }
    }
}