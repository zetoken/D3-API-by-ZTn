using System.Windows.Forms;

namespace ZTn.BNet.D3ProfileExplorer.ExplorerLight
{
    partial class D3GenericControl : UserControl
    {
        public D3GenericControl()
        {
            InitializeComponent();
        }

        protected virtual void InitializeControl()
        {
            HookMouseEventOfChildren(this);
            HookClickEventOfChildren(this);
        }

        /// <summary>
        /// Smartly hooks Click event of children of a control to call event handler of the caller.
        /// </summary>
        protected void HookClickEventOfChildren(Control control)
        {
            foreach (Control child in control.Controls)
            {
                child.Click += (s, e) => OnClick(e);
            }
        }

        /// <summary>
        /// Smartly hooks some mouse events of children of a control to call event handlers of the caller.
        /// </summary>
        protected void HookMouseEventOfChildren(Control control)
        {
            foreach (Control child in control.Controls)
            {
                child.MouseEnter += (s, e) => OnMouseEnter(e);
                child.MouseLeave += (s, e) => OnMouseLeave(e);
            }
        }
    }
}