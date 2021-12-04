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
    public partial class Notifications
    {
        public class NotificationsSchedule : Config_ComplexProperty
        {
            public List<string> CurrentTimes { get; private set; }
            public NotificationsSchedule(Site site, PropertyInfo property = null) :
                base(site, new string[2] { "Simple", "Complex" }, property)
            {
                
            }
        }
    }
}
