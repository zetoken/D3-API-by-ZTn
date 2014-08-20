using System;
using ZTn.BNet.D3.Items;

namespace ZTn.BNet.D3ProfileExplorer.ExplorerLight
{
    partial class D3ItemDamageLabelControl : D3LabelControl
    {
        public D3ItemDamageLabelControl()
        {
            InitializeComponent();

            InitializeControl();
        }

        public D3ItemDamageLabelControl(Item item)
            : this()
        {
            guiDamagePerSecondValue.Text = String.Format("{0:N1}", item.Dps.Min);
            guiAttackPerSecondValue.Text = String.Format("{0:N2}", item.AttacksPerSecond.Min);
            guiDamageMin.Text = String.Format("{0:N0}", item.MinDamage.Min);
            guiDamageMax.Text = String.Format("{0:N0}", item.MaxDamage.Min);

            ReLocateControl(guiDamagePerSecondLabel, guiDamagePerSecondValue);
            ReLocateControl(guiAttackPerSecondLabel, guiAttackPerSecondValue);
            ReLocateControl(guiSeparatorLabel, guiDamageMin);
            ReLocateControl(guiDamageMax, guiSeparatorLabel);
            ReLocateControl(guiDamageLabel, guiDamageMax);
        }
    }
}