using System;
using System.Text.RegularExpressions;
using System.Windows.Forms;
using Newtonsoft.Json.Linq;

namespace TV_Slideshow_Config_Editor
{
    public class JSON_String : TableLayoutPanel
    {
        public JSON_String(JProperty PropertyJSON)
        {
            this.RowCount = 1;
            this.ColumnCount = 2;
            this.AutoSize = true;

            var controlLabel = new Label()
            {
                Text = String_Manipulation.CamelCaseToNormal(PropertyJSON.Name),
                TextAlign = System.Drawing.ContentAlignment.MiddleLeft,
            };

            var controlEdit = new MaskedTextBox()
            {
                Dock = DockStyle.Fill,
                Text = (string)PropertyJSON.Value,
                Tag = PropertyJSON,

            };
            controlEdit.TextChanged += new EventHandler(Event_TextChanged);

            this.Controls.Add(controlLabel);
            this.Controls.Add(controlEdit);
        }

        protected void Event_TextChanged(object sender, EventArgs e)
        {
            var c = sender as MaskedTextBox;
            (c.Tag as JProperty).Value = c.Text;
        }
    }
}
