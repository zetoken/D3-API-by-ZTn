using System;
using System.Drawing;
using System.Windows.Forms;
using ZTn.BNet.D3.Items;

namespace ZTn.BNet.D3ProfileExplorer.ExplorerLight
{
    partial class D3ItemPassiveLabelControl : D3LabelControl
    {
        public D3ItemPassiveLabelControl()
        {
            InitializeComponent();

            InitializeControl();
        }

        public D3ItemPassiveLabelControl(Item item)
            : this()
        {
            guiPassiveValue.Text = String.Empty;

            foreach (var passive in item.Attributes.Passive)
            {
                guiPassiveValue.Text += passive.Text + Environment.NewLine;
            }
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            guiPassiveValue.MaximumSize = new Size(Size.Width - Padding.Left - Padding.Right, 0);

            base.OnPaint(e);
        }
    }
}