using System.Drawing;
using System.IO;
using System.Linq;
using ZTn.BNet.D3;
using ZTn.BNet.D3.Items;

namespace ZTn.BNet.D3ProfileExplorer.ExplorerLight
{
    partial class D3ItemControl : D3SelectableControl
    {
        public Item Item
        {
            set
            {
                UpdateItemInfo(value);
                UpdateItemPicture(value);
            }
        }

        public D3ItemControl()
        {
            InitializeComponent();
        }

        public D3ItemControl(Item item)
            : this()
        {
            Item = item;

            InitializeControl();

            HookMouseEventOfChildren(guiDescriptionPanel);
        }

        protected override sealed void InitializeControl()
        {
            base.InitializeControl();
        }

        private void UpdateItemPicture(ItemSummary item)
        {
            D3Api.GetItemIcon(item.Icon, "large",
                picture =>
                {
                    if (picture != null)
                    {
                        guiItemPicture.Image = new Bitmap(new MemoryStream(picture.Bytes));
                    }
                },
                () => { }
                );
        }

        private void UpdateItemInfo(Item item)
        {
            guiItemName.Text = item.Name;
            guiItemName.ForeColor = GetDisplayColor(item.DisplayColor);

            if (item.MinDamage != null && item.MaxDamage != null)
            {
                guiDescriptionPanel.Controls.Add(new D3ItemDamageLabelControl(item));
            }

            if (item.Armor != null)
            {
                guiDescriptionPanel.Controls.Add(new D3ItemArmorLabelControl(item));
            }

            if (item.Attributes.Primary != null && item.Attributes.Primary.Any())
            {
                guiDescriptionPanel.Controls.Add(new D3ItemPrimaryLabelControl(item));
            }

            if (item.Attributes.Secondary != null && item.Attributes.Secondary.Any())
            {
                guiDescriptionPanel.Controls.Add(new D3ItemSecondaryLabelControl(item));
            }

            if (item.Attributes.Passive != null && item.Attributes.Passive.Any())
            {
                guiDescriptionPanel.Controls.Add(new D3ItemPassiveLabelControl(item));
            }

            if (item.Gems != null && item.Gems.Any())
            {
                foreach (var gem in item.Gems)
                {
                    guiDescriptionPanel.Controls.Add(new D3ItemGemLabelControl(gem));
                }
            }
        }

        private static Color GetDisplayColor(string displayColor)
        {
            switch (displayColor)
            {
                case "blue":
                    return Color.FromArgb(0xFF, 0x79, 0x79, 0xD4);
                case "green":
                    return Color.FromArgb(0xFF, 0x8B, 0xD4, 0x42);
                case "orange":
                    return Color.FromArgb(0xFF, 0xBF, 0x64, 0x2F);
                case "white":
                    return Color.White;
                case "yellow":
                    return Color.FromArgb(0xFF, 0xF8, 0xCC, 0x35);
                default:
                    return Color.Red;
            }
        }
    }
}