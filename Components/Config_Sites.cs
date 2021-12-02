using Newtonsoft.Json;
using System;
using System.Reflection;
using System.Windows.Forms;
using TV_Slideshow_Config_Editor.ConfigInterface;

namespace TV_Slideshow_Config_Editor.ConfigVisualised
{
    public class Sites : FlowContainer
    {
        public Sites(Site[] ConfigSlice) : base("page")
        {
            for (int i = 0; i < ConfigSlice.Length; i++)
            {
                var slice = ConfigSlice[i];
                var title = string.Format("{0}. Site", i + 1);
                var control = SiteIntoControls(title, slice);
                this.Controls.Add(control);
            }
        }

        private ConfigContainer SiteIntoControls(string Title, Site site)
        {
            var container = new ConfigContainer(Title);
            var subControls = new Control[3];
            var properties = site.GetType().GetProperties();

            subControls[0] = new ConfigString("URL", properties[0], site);
            subControls[1] = new SiteHeight(site, properties[1]);
            subControls[2] = new ConfigNumber("Duration", properties[2], site);

            if (subControls[2].Controls[1].Text == "0")
                subControls[2].Controls[1].Text = "";
            container.AddControls(subControls);
            return container;
        }

        public class SiteHeight : Config_ComplexProperty
        {
            public SiteHeight(Site site, PropertyInfo property = null) :
                base(site, new string[2] { "Simple", "Complex" }, property)
            {
                this.parentObj = site;
                this.property = property ?? site.GetType().GetProperty("height");
                if (this.property.GetValue(parentObj) == null)
                    this.property.SetValue(parentObj, "100%");
                var propType = property.GetValue(parentObj).GetType();

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
                var originalValue = property.GetValue(parentObj); // Not needed on the last Editor
                if (property.GetValue(parentObj).GetType() != typeof(string))
                    property.SetValue(parentObj, "100%");

                var control = new ConfigString("Height", property, parentObj)
                {
                    Tag = property.GetValue(parentObj),
                };

                this.property.SetValue(parentObj, originalValue);
                return control;
            }
            private Control MakeComplexHeightEditor()
            {
                var propVal = property.GetValue(parentObj);
                var Height = typeof(string) == propVal.GetType() ? new ComplexHeight() :
                    JsonConvert.DeserializeObject<ComplexHeight>(propVal.ToString());

                property.SetValue(parentObj, Height);
                var container = new FlowContainer()
                {
                    Tag = property.GetValue(parentObj),
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
