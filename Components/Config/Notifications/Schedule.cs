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
        public class NotificationsSchedule : Config_BaseProperty
        {
            public List<string> CurrentTimes { get; private set; }
            public NotificationsSchedule(PropertyInfo property, Notification notification)
                : base(property, notification)
            {

            }

            // private Config_ListProperty MakeTimeControl()
            // {
            //     var control = new Config_ListProperty();
            //     return control;
            // }
            // 
            // private Config_ListProperty MakeWeekndControl()
            // { Checkbox stuff??
            //     var control = new Config_ListProperty();
            //     return control;
            // }
        }
    }
}
