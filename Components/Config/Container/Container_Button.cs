using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Windows.Forms;

namespace TV_Slideshow_Config_Editor.ConfigVisualised
{
    public class Container_Button : Button
    {
        public Container_Button(bool left)
        {
            if (left)
            {
                Text = "<+";
                Tag = -1;
            }
            else
            {
                Text = "+>";
                Tag = 1;
            }

            AutoSize = true;
            AutoSizeMode = AutoSizeMode.GrowAndShrink;
        }

        public Container_Button(string DeleteButtonLabel)
        {
            Text = DeleteButtonLabel;
            Tag = 0;
            Dock = DockStyle.Fill;
        }
    }
}
