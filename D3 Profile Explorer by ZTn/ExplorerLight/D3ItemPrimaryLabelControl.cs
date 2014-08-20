using System;
using System.Drawing;
using System.Windows.Forms;
using ZTn.BNet.D3.Items;

namespace ZTn.BNet.D3ProfileExplorer.ExplorerLight
{
    sealed partial class D3ItemPrimaryLabelControl : D3LabelControl
    {
        public D3ItemPrimaryLabelControl()
        {
            InitializeComponent();

            InitializeControl();
        }

        public D3ItemPrimaryLabelControl(Item item)
            : this()
        {
            guiPrimaryValue.Text = String.Empty;

            foreach (var primary in item.Attributes.Primary)
            {
                guiPrimaryValue.Text += primary.Text + Environment.NewLine;
            }
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            guiPrimaryValue.MaximumSize = new Size(Size.Width - Padding.Left - Padding.Right, 0);

            base.OnPaint(e);
        }
    }
}