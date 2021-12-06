using System;
using System.Reflection;
using System.Text.RegularExpressions;
using System.Windows.Forms;
using TV_Slideshow_Config_Editor.Logic;

namespace TV_Slideshow_Config_Editor.ConfigVisualised
{
    public class ConfigNumber : Config_BaseProperty
    {
        public ConfigNumber(string label, PropertyInfo property, object obj,
            bool nullTheZero = false) : base(property, obj)
        {
            this.Construct(label);

            if (!nullTheZero) return;
            var TextEditor = this.Controls[1];
            if (TextEditor.Text == "0") TextEditor.Text = "";
        }
        public ConfigNumber(PropertyInfo property, object obj) : base(property, obj)
        {
            var label = String_Manipulation.CamelCaseToNormal(property.Name);
            this.Construct(label);
        }

        private void Construct(string label)
        {
            this.Controls.Add(GetLabel(label));

            var controlEdit = GetEditBox();
            controlEdit.AsciiOnly = true;
            controlEdit.TextChanged += Event_TextChanged;
            this.Controls.Add(controlEdit);
        }

        protected void Event_TextChanged(object sender, EventArgs e)
        {
            var rgx = new Regex(@"\D");
            var c = sender as MaskedTextBox;
            var selectionStart = c.SelectionStart;
            var textLength = c.Text.Length;

            c.Text = rgx.Replace(c.Text, "");
            // In order to keep the cursor at the same place
            c.SelectionStart = selectionStart - ((textLength > c.Text.Length) ? 1 : 0);

            if (int.TryParse(c.Text, out int value))
                Property.SetValue(BoundObj, value);
            else Property.SetValue(BoundObj, null);

        }
    }
}
