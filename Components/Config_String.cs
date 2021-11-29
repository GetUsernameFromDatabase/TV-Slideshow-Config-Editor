using System;
using System.Reflection;
using System.Windows.Forms;

namespace TV_Slideshow_Config_Editor.ConfigVisualised
{
    public class ConfigString : TableLayoutPanel
    {
        readonly object parentObj;
        readonly PropertyInfo property;

        public ConfigString(string LabelText, PropertyInfo property, object obj)
        {
            this.AutoSize = true;
            this.property = property;
            this.parentObj = obj;

            this.RowCount = 1;
            this.ColumnCount = 2;
            this.CellBorderStyle = TableLayoutPanelCellBorderStyle.Inset;

            var controlLabel = new Label()
            {
                Text = LabelText,
                TextAlign = System.Drawing.ContentAlignment.MiddleLeft,
            };

            var controlEdit = new MaskedTextBox()
            {
                Dock = DockStyle.Fill,
                Text = property.GetValue(obj).ToString(),

            };
            controlEdit.TextChanged += new EventHandler(Event_TextChanged);

            this.Controls.AddRange(new Control[2] { controlLabel, controlEdit });
        }

        protected void Event_TextChanged(object sender, EventArgs e)
        {
            var c = sender as MaskedTextBox;
            var value = c.Text;
            property.SetValue(parentObj, value, null);
        }
    }
}
