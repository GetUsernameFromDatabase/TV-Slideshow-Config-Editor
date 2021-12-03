using System;
using System.Reflection;
using System.Windows.Forms;
using TV_Slideshow_Config_Editor.Logic;

namespace TV_Slideshow_Config_Editor.ConfigVisualised
{
    public class ConfigString : Config_SimpleProperty
    {
        public ConfigString(string label, PropertyInfo property, object obj) : base(property, obj)
        {
            this.Construct(label);
        }
        public ConfigString(PropertyInfo property, object obj) : base(property, obj)
        {
            var label = String_Manipulation.CamelCaseToNormal(property.Name);
            this.Construct(label);
        }

        private void Construct(string label)
        {
            this.Controls.Add(GetLabel(label));

            var controlEdit = GetEditBox();
            controlEdit.AsciiOnly = true;
            controlEdit.TextChanged += new EventHandler(Event_TextChanged);
            this.Controls.Add(controlEdit);
        }

        protected void Event_TextChanged(object sender, EventArgs e)
        {
            var c = sender as MaskedTextBox;
            c.Text = c.Text.Trim();
            var value = c.Text;
            Property.SetValue(BoundObj, value);
        }
    }
}
