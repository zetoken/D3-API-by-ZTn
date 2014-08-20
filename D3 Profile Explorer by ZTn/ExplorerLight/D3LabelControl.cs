using System.Drawing;
using System.Windows.Forms;

namespace ZTn.BNet.D3ProfileExplorer.ExplorerLight
{
    partial class D3LabelControl : D3GenericControl
    {
        public D3LabelControl()
        {
            InitializeComponent();
        }

        public override Size GetPreferredSize(Size proposedSize)
        {
            var size = base.GetPreferredSize(proposedSize);

            return new Size(Parent.Width - Location.X - Parent.Padding.Right - Margin.Right, size.Height);
        }

        protected void ReLocateControl(Control current, Control previous)
        {
            current.Location = new Point(previous.Location.X + previous.Width + previous.Margin.Right + current.Margin.Left, current.Location.Y);
        }
    }
}