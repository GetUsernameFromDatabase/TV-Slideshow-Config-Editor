using System;
using System.Reflection;
using System.Windows.Forms;
using TV_Slideshow_Config_Editor.Logic;

namespace TV_Slideshow_Config_Editor.ConfigVisualised
{
    public class ConfigString : Config_BaseProperty
    {

        public ConfigString(string label, PropertyInfo property, object obj) : base(property, obj)
        {
            this.ConstructEditableProperty(label, TextChanged_Property);
        }
        public ConfigString(PropertyInfo property, object obj) : base(property, obj)
        {
            var label = String_Manipulation.CamelCaseToNormal(property.Name);
            this.ConstructEditableProperty(label, TextChanged_Property);
        }

        protected void TextChanged_Property(object sender, EventArgs e)
        {
            var c = sender as TextBox;
            c.Text = c.Text.Trim();
            var value = c.Text;
            Property.SetValue(BoundObj, value);
        }
    }
}
