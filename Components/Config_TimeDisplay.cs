using System;
using System.Windows.Forms;
using TV_Slideshow_Config_Editor.Logic;

namespace TV_Slideshow_Config_Editor.ConfigVisualised
{
    public class TimeDisplay : TabPageContent
    {
        public TimeDisplay(ConfigInterface.TimeDisplay ConfigSlice)
        {
            var controls = ConfigParser.ConfigObjectIntoControls(ConfigSlice);
            this.Controls.AddRange(controls.ToArray());
        }
    }
}
