using System;
using System.Collections.Generic;
using System.Reflection;
using System.Windows.Forms;
using TV_Slideshow_Config_Editor.ConfigVisualised;

namespace TV_Slideshow_Config_Editor
{
    public partial class ConfigEditor : Form
    {
        private void PopulatePages()
        {
            UpdateMenuButtonStatuses();
            foreach (var control in TabControl_MainConfig.TabPages)
            {
                var page = control as TabPage;
                page.Controls.Clear();
                GC.Collect();

                var tag = page.Tag as string;
                page.Controls.Add(GenerateTabPageContent(tag));

                // In order to set default SelectedIndex on Site ComboBoxes
                // This was needed since it didn't work when user is already on Sites TabPage
                //  - Relies on VisibleChanged event
                var pageContent = page.Controls[0];
                pageContent.Visible = false;
                pageContent.Visible = true;
            }
        }

        private Control GenerateTabPageContent(string PageTag)
        {
            Control visualisedConfigSlice = new Label() { Text = "ERROR" };
            if (Properties.Resources.ConfigDefaultsTag == PageTag)            // Defaults
                visualisedConfigSlice = new Defaults(Config.defaults);
            else if (Properties.Resources.ConfigTimeDisplayTag == PageTag)    // TimeDisplay
                visualisedConfigSlice = new TimeDisplay(Config.showTime);
            else if (Properties.Resources.ConfigSitesTag == PageTag)          // Sites
                visualisedConfigSlice = new Sites(Config.sites);
            else if (Properties.Resources.ConfigNotificationsTag == PageTag)  // Notifications
                visualisedConfigSlice = new Notifications(Config.notifications);
            return visualisedConfigSlice;
        }
    }

    struct ConfigParser
    {
        public static List<Control> ConfigObjectIntoControls(object obj)
        {
            var controls = new List<Control>();
            if (obj == null) return null;
            var objType = obj.GetType();

            foreach (var property in objType.GetProperties())
                controls.Add(ConfigObjectIntoControl(property, obj));
            return controls;
        }

        public static Control ConfigObjectIntoControl(PropertyInfo property, object obj)
        {
            var objType = property.PropertyType;
            Control control = new Label() { Text = "Error" };
            if (typeof(int) == objType)             // integer
                control = new ConfigNumber(property, obj);
            else if (typeof(string) == objType)     // string
                control = new ConfigString(property, obj);
            return control;
        }
    }
}
