using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Reflection;
using System.Windows.Forms;
using TV_Slideshow_Config_Editor.ConfigInterface;

namespace TV_Slideshow_Config_Editor.ConfigVisualised
{
    public partial class Sites
    {
        public class SiteHeight : Config_ComplexProperty
        {
            public SiteHeight(Site site, PropertyInfo property = null) :
                base(site, new string[2] { "Simple", "Complex" }, property)
            {
                this.BoundObj = site;
                this.Property = property ?? site.GetType().GetProperty("height");
                if (this.Property.GetValue(BoundObj) == null)
                    this.Property.SetValue(BoundObj, "100%");
                var propType = property.GetValue(BoundObj).GetType();

                // Making editors modifies the property value
                var SimpleHeight = MakeSimpleHeightEditor();
                var ComplexHeight = MakeComplexHeightEditor();
                AvailableEditors = new Control[2] { SimpleHeight, ComplexHeight };

                // Hides unecessary editor and changes property value back
                ChangeActiveEditor(typeof(string) == propType ? 0 : 1);
                var heightChooser = ModeChooser.Choices;
                heightChooser.VisibleChanged += SetDefault_SelectedIndex;

                this.Controls.Add(ModeChooser);
                this.Controls.AddRange(AvailableEditors);
            }

            private Control MakeSimpleHeightEditor()
            {
                var originalValue = Property.GetValue(BoundObj); // Not needed on the last Editor
                if (Property.GetValue(BoundObj).GetType() != typeof(string))
                    Property.SetValue(BoundObj, "100%");

                var control = new ConfigString("Height", Property, BoundObj)
                {
                    Tag = Property.GetValue(BoundObj),
                };

                this.Property.SetValue(BoundObj, originalValue);
                return control;
            }
            private Control MakeComplexHeightEditor()
            {
                var propVal = Property.GetValue(BoundObj);
                var Height = typeof(string) == propVal.GetType() ? new ComplexHeight() :
                    JsonConvert.DeserializeObject<ComplexHeight>(propVal.ToString());

                Property.SetValue(BoundObj, Height);
                var container = new FlowContainer()
                {
                    Tag = Property.GetValue(BoundObj),
                };

                var controls = ConfigParser.ConfigObjectIntoControls(container.Tag);
                container.Controls.AddRange(controls.ToArray());
                return container;
            }

            [System.Diagnostics.CodeAnalysis.SuppressMessage("Style",
                "IDE1006:Naming Styles", Justification = "JSON Object")]
            private class ComplexHeight
            {
                public string singleColumn { get; set; } = "100%";
                public string multiColumn { get; set; } = "100%";
            }
        }
    }
}
