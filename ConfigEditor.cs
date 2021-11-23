using System;
using System.Text.RegularExpressions;
using System.Windows.Forms;

namespace TV_Slideshow_Config_Editor
{
    public partial class ConfigEditor : Form
    {
        public ConfigEditor()
        {
            InitializeComponent();
            TabPage_Defaults.Controls.Add(new JSONNumber("defaults.site", "Site"));
        }
    }

    public class JSONNumber : TableLayoutPanel
    {
        public JSONNumber(string locator, string label)
        {
            this.RowCount = 1;
            this.ColumnCount = 2;
            this.AutoSize = true;

            var controlLabel = new Label()
            {
                Text = label,
                TextAlign = System.Drawing.ContentAlignment.MiddleLeft,
            };

            var controlEdit = new MaskedTextBox()
            {
                Dock = DockStyle.Fill,
                AsciiOnly = true

            };
            controlEdit.TextChanged += new EventHandler(EditControl_TextChanged);

            this.Controls.Add(controlLabel);
            this.Controls.Add(controlEdit);

        }

        protected void EditControl_TextChanged(object sender, EventArgs e)
        {
            var rgx = new Regex(@"\D");
            var c = (sender as MaskedTextBox);
            var selectionStart = c.SelectionStart;
            var textLength = c.Text.Length;

            c.Text = rgx.Replace(c.Text, "");
            c.SelectionStart = selectionStart - ((textLength > c.Text.Length) ? 1 : 0);
        }
    }
}
