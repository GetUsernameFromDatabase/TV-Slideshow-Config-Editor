using System;
using System.Windows.Forms;

namespace TV_Slideshow_Config_Editor.ConfigVisualised
{
    public class Defaults : TabPageContent
    {
        public Defaults(ConfigInterface.Defaults ConfigSlice)
        {
            var containerDurations = new ConfigContainer("Defaults");
            var durationsControls = ConfigParser.ConfigObjectIntoControls(ConfigSlice.durations);

            containerDurations.AddControls(durationsControls);
            this.Controls.Add(containerDurations);
        }
    }
}
