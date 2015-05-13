using System;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using ZTn.BNet.D3.Items;
using ZTn.BNet.D3ProfileExplorer.Helpers;

namespace ZTn.BNet.D3ProfileExplorer.ExplorerLight
{
    partial class D3ItemJewelLabelControl : D3LabelControl
    {
        private D3ItemJewelLabelControl()
        {
            InitializeComponent();

            InitializeControl();
        }

        public D3ItemJewelLabelControl(SocketedGem socketedGem)
            : this()
        {
            guiJewelEffectLabel.Text = String.Empty;

            guiJewelNameLabel.Text = socketedGem.Item.Name;
            guiJewelRankLabel.Text = socketedGem.JewelRank.ToString();

            if (socketedGem.Attributes.Primary != null && socketedGem.Attributes.Primary.Any())
            {
                foreach (var primary in socketedGem.Attributes.Primary)
                {
                    LabelHelper.ConcatOnNewLine(ref guiJewelEffectLabel, primary.Text);
                }
            }

            if (socketedGem.Attributes.Secondary != null && socketedGem.Attributes.Secondary.Any())
            {
                foreach (var secondary in socketedGem.Attributes.Secondary)
                {
                    LabelHelper.ConcatOnNewLine(ref guiJewelEffectLabel, secondary.Text);
                }
            }

            if (socketedGem.Attributes.Passive != null && socketedGem.Attributes.Passive.Any())
            {
                foreach (var passive in socketedGem.Attributes.Passive)
                {
                    LabelHelper.ConcatOnNewLine(ref guiJewelEffectLabel, passive.Text);
                }
            }
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            guiJewelEffectLabel.MaximumSize = new Size(Size.Width - Padding.Left - Padding.Right, 0);

            base.OnPaint(e);
        }
    }
}