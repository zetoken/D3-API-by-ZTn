using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;

namespace ZTn.BNet.D3ProfileExplorer.ExplorerLight
{
    partial class D3SelectableControl : UserControl
    {
        private readonly Dictionary<EventHandler, EventHandler> clickEventHandlers = new Dictionary<EventHandler, EventHandler>();
        private bool activeProfile;

        public D3SelectableControl()
        {
            InitializeComponent();
        }

        protected void InitializeControl()
        {
            MouseEnter += Control_MouseEnter;
            MouseLeave += Control_MouseLeave;

            foreach (Control control in Controls)
            {
                control.MouseEnter += Control_MouseEnter;
                control.MouseLeave += Control_MouseLeave;
            }
        }

        public Boolean ActiveProfile
        {
            get { return activeProfile; }
            set
            {
                activeProfile = value;
                UpdateControlColors(false);
            }
        }

        public new event EventHandler Click
        {
            add
            {
                EventHandler eventHandler = (s, e) => value(this, e);
                clickEventHandlers.Add(value, eventHandler);

                foreach (Control control in Controls)
                {
                    control.Click += eventHandler;
                }

                base.Click += value;
            }
            remove
            {
                EventHandler eventHandler;

                if (clickEventHandlers.TryGetValue(value, out eventHandler) == false)
                {
                    return;
                }

                foreach (Control control in Controls)
                {
                    control.Click -= eventHandler;
                }

                clickEventHandlers.Remove(value);

                base.Click -= value;
            }
        }

        private void Control_MouseEnter(object sender, EventArgs e)
        {
            UpdateControlColors(true);
        }

        private void Control_MouseLeave(object sender, EventArgs e)
        {
            UpdateControlColors(false);
        }

        private void UpdateControlColors(bool hovering)
        {
            if (hovering)
            {
                BackColor = Color.PaleGreen;
            }
            else
            {
                BackColor = ActiveProfile ? Color.LimeGreen : Color.Black;
            }
        }
    }
}
