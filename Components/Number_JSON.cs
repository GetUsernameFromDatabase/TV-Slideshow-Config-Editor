using System;
using System.Text.RegularExpressions;
using System.Windows.Forms;
using Newtonsoft.Json.Linq;

namespace TV_Slideshow_Config_Editor
{
    public class JSON_Number : TableLayoutPanel
    {
        public JSON_Number(JProperty PropertyJSON)
        {
            this.RowCount = 1;
            this.ColumnCount = 2;
            this.AutoSize = true;

            var controlLabel = new Label()
            {
                Text = Text = String_Manipulation.CamelCaseToNormal(PropertyJSON.Name),
                TextAlign = System.Drawing.ContentAlignment.MiddleLeft,
            };

            var controlEdit = new MaskedTextBox()
            {
                Dock = DockStyle.Fill,
                Text = (string)PropertyJSON.Value,
                Tag = PropertyJSON,
                AsciiOnly = true

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

            (c.Tag as JProperty).Value = int.Parse(c.Text);
        }
    }
}
