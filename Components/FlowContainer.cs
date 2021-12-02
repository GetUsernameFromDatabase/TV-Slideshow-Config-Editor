using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TV_Slideshow_Config_Editor
{
    public class FlowContainer : FlowLayoutPanel
    {
        public FlowContainer(string mode = "other")
        {
            this.AutoSize = true;
            this.AutoSizeMode = AutoSizeMode.GrowAndShrink;
            this.Dock = DockStyle.Fill;
            this.FlowDirection = FlowDirection.TopDown;

            switch (mode)
            {
                case "page":
                    this.AutoScroll = true;
                    this.FlowDirection = FlowDirection.LeftToRight;
                    break;
                default:
                    break;
            }
        }
    }
}
