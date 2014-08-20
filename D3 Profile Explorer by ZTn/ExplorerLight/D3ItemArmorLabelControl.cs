using System;
using ZTn.BNet.D3.Items;

namespace ZTn.BNet.D3ProfileExplorer.ExplorerLight
{
    partial class D3ItemArmorLabelControl : D3LabelControl
    {
        public D3ItemArmorLabelControl()
        {
            InitializeComponent();

            InitializeControl();
        }

        public D3ItemArmorLabelControl(Item item)
            : this()
        {
            guiArmorValue.Text = String.Format("{0:N0}", item.Armor.Min);

            ReLocateControl(guiArmorLabel, guiArmorValue);
        }
    }
}