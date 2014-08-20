using System;
using System.Drawing;
using System.Windows.Forms;
using ZTn.BNet.D3.Items;

namespace ZTn.BNet.D3ProfileExplorer.ExplorerLight
{
    partial class D3ItemSecondaryLabelControl : D3LabelControl
    {
        public D3ItemSecondaryLabelControl()
        {
            InitializeComponent();

            InitializeControl();
        }

        public D3ItemSecondaryLabelControl(Item item)
            : this()
        {
            guiSecondaryValue.Text = String.Empty;

            foreach (var secondary in item.Attributes.Secondary)
            {
                guiSecondaryValue.Text += secondary.Text + Environment.NewLine;
            }
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            guiSecondaryValue.MaximumSize = new Size(Size.Width - Padding.Left - Padding.Right, 0);

            base.OnPaint(e);
        }
    }
}