using System;
using System.Reflection;
using System.Text.RegularExpressions;
using System.Windows.Forms;

namespace TV_Slideshow_Config_Editor.ConfigVisualised
{
    public class ConfigNumber : TableLayoutPanel
    {
        readonly object parentObj;
        readonly PropertyInfo property;

        public ConfigNumber(string LabelText, PropertyInfo property, object obj)
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
                AsciiOnly = true,

            };
            controlEdit.TextChanged += new EventHandler(Event_TextChanged);

            this.Controls.Add(controlLabel);
            this.Controls.Add(controlEdit);
        }

        protected void Event_TextChanged(object sender, EventArgs e)
        {
            var rgx = new Regex(@"\D");
            var c = (sender as MaskedTextBox);
            var selectionStart = c.SelectionStart;
            var textLength = c.Text.Length;

            c.Text = rgx.Replace(c.Text, "");
            c.SelectionStart = selectionStart - ((textLength > c.Text.Length) ? 1 : 0);

            int value = int.Parse(c.Text);
            property.SetValue(parentObj, value, null);
        }
    }
}
