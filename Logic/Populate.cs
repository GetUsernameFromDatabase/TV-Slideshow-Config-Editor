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
            if (PageTag == Properties.Resources.ConfigDefaultsTag)
                visualisedConfigSlice = new ConfigVisualised.Defaults(Config.defaults);
            else if (PageTag == Properties.Resources.ConfigTimeDisplayTag)
                visualisedConfigSlice = new ConfigVisualised.TimeDisplay(Config.showTime);
            else if (PageTag == Properties.Resources.ConfigSitesTag)
                visualisedConfigSlice = new ConfigVisualised.Sites(Config.sites);
            else if (PageTag == Properties.Resources.ConfigNotificationsTag)
                visualisedConfigSlice = new ConfigVisualised.Notifications(Config.notifications);
            return visualisedConfigSlice;
        }
    }

    struct ConfigParser
    {
        public static IEnumerator<PropertyInfo> GetEnumerator(object obj)
        {
            foreach (var property in obj.GetType().GetProperties())
            {
                yield return property;
            }
        }

        public static List<Control> ConfigObjectIntoControls(object obj)
        {
            var controls = new List<Control>();
            if (obj == null) return null;

            var objEnum = ConfigParser.GetEnumerator(obj);
            while (objEnum.MoveNext())
            {
                var crnt = objEnum.Current;
                var label = String_Manipulation.CamelCaseToNormal(crnt.Name);
                var objType = objEnum.Current.PropertyType;

                Control control = new Label() { Text = "Error" };
                if (objType == typeof(int))
                    control = new ConfigNumber(label, crnt, obj);
                else if (objType == typeof(string))
                    control = new ConfigString(label, crnt, obj);
                controls.Add(control);
            }
            return controls;
        }


    }


}
