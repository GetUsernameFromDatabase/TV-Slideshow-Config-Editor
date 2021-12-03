using System;
using System.Windows.Forms;

namespace TV_Slideshow_Config_Editor.ConfigVisualised
{
    public class Defaults : FlowContainer
    {
        public Defaults(ConfigInterface.Defaults ConfigSlice) : base("page")
        {
            var containerDurations = new ConfigContainer("Defaults");
            var durationsControls = ConfigParser.ConfigObjectIntoControls(ConfigSlice.durations);

            containerDurations.AddControls(durationsControls);
            this.Controls.Add(containerDurations);
        }
    }
}
