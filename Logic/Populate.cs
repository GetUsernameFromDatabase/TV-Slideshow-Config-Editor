using System;
using System.Collections.Generic;
using System.Reflection;
using System.Windows.Forms;
using TV_Slideshow_Config_Editor.ConfigVisualised;
using TV_Slideshow_Config_Editor.Logic;

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
                var tag = page.Tag as string;
                page.Controls.Add(GenerateTabPageContent(tag));
            }
        }

        private Control GenerateTabPageContent(string PageTag)
        {
            Control visualisedConfigSlice = new Label() { Text = "ERROR" };
            if (Properties.Resources.ConfigDefaultsTag == PageTag)
                visualisedConfigSlice = new ConfigVisualised.Defaults(Config.defaults);
            else if (Properties.Resources.ConfigTimeDisplayTag == PageTag)
                visualisedConfigSlice = new ConfigVisualised.TimeDisplay(Config.showTime);
            else if (Properties.Resources.ConfigSitesTag == PageTag)
                visualisedConfigSlice = new ConfigVisualised.Sites(Config.sites);
            else if (Properties.Resources.ConfigNotificationsTag == PageTag)
                visualisedConfigSlice = new ConfigVisualised.Notifications(Config.notifications);
            return visualisedConfigSlice;
        }
    }

    struct ConfigParser
    {
        public static List<Control> ConfigObjectIntoControls(object obj)
        {
            var controls = new List<Control>();
            if (obj == null) return null;

            foreach (var property in obj.GetType().GetProperties())
            {
                var objType = property.PropertyType;

                Control control = new Label() { Text = "Error" };
                if (typeof(int) == objType)
                    control = new ConfigNumber(property, obj);
                else if (typeof(string) == objType)
                    control = new ConfigString(property, obj);
                controls.Add(control);
            }
            return controls;
        }
    }


}
