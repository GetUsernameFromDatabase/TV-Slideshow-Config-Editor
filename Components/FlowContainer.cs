using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using TV_Slideshow_Config_Editor.ConfigInterface;
using TV_Slideshow_Config_Editor.ConfigVisualised;
using TV_Slideshow_Config_Editor.Logic;

namespace TV_Slideshow_Config_Editor
{
    public class FlowContainer : FlowLayoutPanel
    {
        protected Button NoOtherControlButton;
        public FlowContainer(string mode = "other")
        {
            this.FlowDirection = FlowDirection.TopDown;
            this.AutoSize = true;
            this.AutoSizeMode = AutoSizeMode.GrowAndShrink;
            this.Dock = DockStyle.Fill;
            ModeStyle(mode);
        }
        private void ModeStyle(string mode)
        {
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
        protected void RemoveParent(Control control)
        {
            var btnContainer = control.Parent;
            btnContainer.Parent.Controls.Remove(btnContainer);
        }

        protected int GetConfigContainerIndex(ConfigContainer ConfigContainer)
        {
            var cfgCntIndex = this.Controls.OfType<ConfigContainer>()
                    .ToList().IndexOf(ConfigContainer);
            return cfgCntIndex;
        }

        protected void InsertControl(int index, Control control)
        {
            this.Controls.Add(control);
            this.Controls.SetChildIndex(control, index);
        }

        protected void UpdateOtherTitles(int newControlIndex)
        {
            var cfgControlCntrs = this.Controls.OfType<ConfigContainer>();
            var count = cfgControlCntrs.Count();
            if (count <= 0) return;

            for (var i = newControlIndex + 1; i < count; i++)
            {
                var container = cfgControlCntrs.ElementAt(i);
                var TitleHeader = container.GetControlFromPosition(0, 0);
                if (!(TitleHeader is Label Title)) Title = TitleHeader.Controls[1] as Label;
                Title.Text = String_Manipulation.ChangeTitleCount(Title.Text, i);
            };
        }

        protected Button MakeNoOtherControlButton(Action<object, EventArgs> buttonClickCallback)
        {
            var btn = new Button()
            {
                Text = "+",
                Font = new Font(Font.FontFamily, 18),
                Dock = DockStyle.Top,
                AutoSize = true,
                AutoSizeMode = AutoSizeMode.GrowAndShrink,
            };

            btn.Click += new EventHandler(buttonClickCallback);
            this.Controls.Add(btn);
            return btn;
        }

        protected bool ShowEmptyPageControlButton_IfNeeded()
        {
            var needed = this.Controls.Count <= 1;
            NoOtherControlButton.Enabled = needed;
            NoOtherControlButton.Visible = needed;
            return needed;
        }

        protected Tuple<ConfigContainer, object>
            GetConfigInfo_OnControlRemoved(ControlEventArgs e)
        {
            if (!(e.Control is ConfigContainer removedControl))
            {
                e.Control.Dispose();
                return null;
            };

            var BoundObject = removedControl.GetBoundConfigObject();
            if (BoundObject == null) return null;
            return new Tuple<ConfigContainer, object>(removedControl, BoundObject);
        }

        protected void BindConfigControl(Control Control, Site toConfigList,
            List<Site> ConfigList, int index = -1)
        {
            if (index != -1)
            {
                int x = NoOtherControlButton != null ? 1 : 0;
                ConfigList.Insert(index, toConfigList);
                this.InsertControl(index + x, Control);
            }
            else
            {
                ConfigList.Add(toConfigList);
                this.Controls.Add(Control);
            }
        }
        protected void BindConfigControl(Control Control, Notification toConfigList,
           List<Notification> ConfigList, int index = -1)
        {
            if (index != -1)
            {
                int x = NoOtherControlButton != null ? 1 : 0;
                ConfigList.Insert(index, toConfigList);
                this.InsertControl(index + x, Control);
            }
            else
            {
                ConfigList.Add(toConfigList);
                this.Controls.Add(Control);
            }
        }
    }
}
