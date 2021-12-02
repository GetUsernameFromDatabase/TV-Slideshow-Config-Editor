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
            this.FlowDirection = FlowDirection.TopDown;
            this.Dock = DockStyle.Fill;
            this.AutoSize = true;
            this.AutoSizeMode = AutoSizeMode.GrowAndShrink;

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

        public void InsertControl(int index, Control control)
        {
            this.Controls.Add(control);
            this.Controls.SetChildIndex(control, index);
        } 
    }
}
