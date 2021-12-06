using System;
using System.Reflection;
using System.Windows.Forms;

namespace TV_Slideshow_Config_Editor.ConfigVisualised
{
    public class Config_BaseProperty : TableLayoutPanel
    {
        public object BoundObj { get; protected set; }
        public PropertyInfo Property { get; protected set; }

        public Config_BaseProperty()
        {
            StyleMe();
        }

        public Config_BaseProperty(PropertyInfo property, object obj)
        {
            this.Property = property;
            this.BoundObj = obj;
            StyleMe();
        }

        private void StyleMe()
        {
            this.AutoSize = true;
            this.AutoSizeMode = AutoSizeMode.GrowAndShrink;
            this.Dock = DockStyle.Fill;
            this.CellBorderStyle = TableLayoutPanelCellBorderStyle.Inset;

            this.RowCount = 1;
            this.ColumnCount = 2;
            this.GrowStyle = TableLayoutPanelGrowStyle.AddColumns;
        }

        protected Label GetLabel(string LabelText = "")
        {
            return new Label()
            {
                Text = LabelText,
                TextAlign = System.Drawing.ContentAlignment.MiddleLeft,
            };
        }

        protected MaskedTextBox GetEditBox()
        {
            var editBox = new MaskedTextBox()
            {
                Dock = DockStyle.Fill,
            };
            if (this.Property != null)
                editBox.Text = this.Property.GetValue(this.BoundObj).ToString();
            return editBox;
        }
    }
}
