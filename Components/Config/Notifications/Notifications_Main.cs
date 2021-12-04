using System;
using System.Collections.Generic;
using System.Windows.Forms;
using TV_Slideshow_Config_Editor.ConfigInterface;
using TV_Slideshow_Config_Editor.Logic;

namespace TV_Slideshow_Config_Editor.ConfigVisualised
{
    public partial class Notifications : FlowContainer
    {
        public List<Notification> CurrentNotifications { get; protected set; }
        public Notifications(List<Notification> ConfigSlice) : base("page")
        {
            this.ControlRemoved += NotificationRemoved;
            this.NoOtherControlButton = MakeNoOtherControlButton(NoOtherControls_Click);

            this.CurrentNotifications = ConfigSlice;
            for (int i = 0; i < ConfigSlice.Count; i++)
            {
                var slice = ConfigSlice[i];
                var title = String_Manipulation.MakeControlTitle(i, "Notification");
                var control = NotificationIntoControls(title, slice);
                this.Controls.Add(control);
            }

            ShowEmptyPageControlButton_IfNeeded();
        }

        public Notification MakeDefault()
        {
            var notification = new Notification();
            return notification;
        }
        private ConfigContainer NotificationIntoControls(string Title, Notification notification)
        {
            var container = new ConfigContainer(Title);
            var subControls = new Control[4];
            var properties = notification.GetType().GetProperties();

            subControls[0] = new Label() { Text = "IN_PROGRESS" };
            subControls[1] = new ConfigString("Audio File", properties[1], notification);
            subControls[2] = new ConfigString("Message", properties[2], notification);
            subControls[3] = new ConfigNumber("Duration", properties[3], notification, true);

            container.AddControls(subControls);
            container.MakeThisDeletable(NotificationButton_Click);
            return container;
        }

        private void NotificationButton_Click(object sender, EventArgs e)
        {
            var Control = sender as Button;

            if (0 == Control.Tag as int?) { RemoveParent(Control); return; }
            var controlIndex = GetNewConfigContainerIndex(Control);
            var newControl = MakeDefault();
            var title = String_Manipulation.MakeControlTitle(controlIndex, "Notification");

            var siteControls = NotificationIntoControls(title, newControl);
            BindConfigControl(siteControls, newControl, CurrentNotifications, controlIndex);
            UpdateOtherTitles(controlIndex);
        }

        private void NotificationRemoved(object sender, ControlEventArgs e)
        {
            var ConfigInfo = GetConfigInfo_OnControlRemoved(e);
            if (ConfigInfo == null) return;
            var (removedControl, BoundObject) = ConfigInfo;

            var notification = BoundObject as Notification;
            CurrentNotifications.Remove(notification);

            if (!ShowEmptyPageControlButton_IfNeeded())
                UpdateOtherTitles(GetConfigContainerIndex(removedControl));
        }

        private void NoOtherControls_Click(object sender, EventArgs e)
        {
            var newSite = MakeDefault();
            var title = String_Manipulation.MakeControlTitle(0, "Notification");
            var siteControls = NotificationIntoControls(title, newSite);
            BindConfigControl(siteControls, newSite, CurrentNotifications);
            ShowEmptyPageControlButton_IfNeeded();
        }
    }
}
