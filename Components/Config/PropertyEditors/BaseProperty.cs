using System;
using System.Drawing;
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

            this.GrowStyle = TableLayoutPanelGrowStyle.AddColumns;
            this.ColumnCount = 2;
            this.RowCount = 1;
        }

        protected void ConstructEditableProperty(string label,
            Action<object, EventArgs> TextChangeEvent)
        {
            this.Controls.Add(GetLabel(label));
            var controlEdit = GetEditBox();
            controlEdit.TextChanged += new EventHandler(TextChangeEvent);
            this.Controls.Add(controlEdit);
        }

        public Label GetLabel(string LabelText = "")
        {
            return new Label()
            {
                Text = LabelText,
                TextAlign = ContentAlignment.MiddleLeft,
                Dock = DockStyle.Fill
            };
        }

        protected TextBox GetEditBox()
        {
            var editBox = new TextBox()
            {
                Dock = DockStyle.Fill,
            };
            if (this.Property != null)
                editBox.Text = this.Property.GetValue(this.BoundObj).ToString();
            return editBox;
        }
    }
}
