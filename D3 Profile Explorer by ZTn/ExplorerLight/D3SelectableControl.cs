using System;
using System.Drawing;

namespace ZTn.BNet.D3ProfileExplorer.ExplorerLight
{
    partial class D3SelectableControl : D3GenericControl
    {
        private bool isHighlighted;

        public D3SelectableControl()
        {
            InitializeComponent();
        }

        protected override void InitializeControl()
        {
            base.InitializeControl();

            MouseEnter += Control_MouseEnter;
            MouseLeave += Control_MouseLeave;
        }

        public Boolean IsHighlighted
        {
            get { return isHighlighted; }
            set
            {
                isHighlighted = value;
                UpdateControlColors(false);
            }
        }

        private void Control_MouseEnter(object sender, EventArgs e)
        {
            UpdateControlColors(true);
        }

        private void Control_MouseLeave(object sender, EventArgs e)
        {
            // Checks if the mouse leaves the control surface but stays in the control rectangle
            if (!ClientRectangle.Contains(PointToClient(MousePosition)))
            {
                UpdateControlColors(false);
            }
        }

        private void UpdateControlColors(bool hovering)
        {
            if (hovering)
            {
                BackColor = Color.PaleGreen;
            }
            else
            {
                BackColor = IsHighlighted ? Color.LimeGreen : Color.Black;
            }
        }
    }
}