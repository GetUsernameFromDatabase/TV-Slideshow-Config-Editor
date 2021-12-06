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
            public string WeekDays { get; private set; }
            public NotificationsSchedule(PropertyInfo property, Notification notification)
                : base(property, notification)
            {
                var schedule = property.GetValue(notification) as Schedule;
                this.CurrentTimes = schedule.time;
                this.WeekDays = schedule.weekDays.ToUpper();
                this.Controls.Add(MakeWeekndControl());
            }

            // private Config_ListProperty MakeTimeControl()
            // {
            //     var control = new Config_ListProperty();
            //     return control;
            // }
            // 
            private Config_BaseProperty MakeWeekndControl()
            {
                var weekDays = new Config_BaseProperty();
                var label = weekDays.GetLabel("Week Days");

                var DayStrings = new string[7] { "E", "T", "K", "N", "R", "L", "P" };
                var Days = DayStrings.Select(day => MakeWeekday(day)).ToArray();

                var weekDayChoices = new FlowLayoutPanel()
                {
                    AutoSize = true,
                    AutoSizeMode = AutoSizeMode.GrowAndShrink,
                    MaximumSize = new Size(170, 0),
                };
                weekDayChoices.Controls.AddRange(Days);

                weekDays.Controls.AddRange(new Control[2] { label, weekDayChoices });
                return weekDays;
            }

            private CheckBox MakeWeekday(string Text)
            {
                var checkBox = new CheckBox()
                {
                    Text = Text,
                    AutoSize = true,
                    Checked = this.WeekDays.Contains(Text), // Assumes Text is upper
                };
                checkBox.CheckedChanged += WeekDay_CheckedChanged;
                return checkBox;
            }

            private void WeekDay_CheckedChanged(object sender, EventArgs e)
            {
                var c = sender as CheckBox;
                var day = c.Text;
                if (WeekDays.Contains(day)) WeekDays = WeekDays.Replace(day, "");
                else WeekDays += day; // Assumes Weekdays is setup correctly at start
                UpdateWeekdays();
            }

            private void UpdateWeekdays()
            {
                var schedule = Property.GetValue(BoundObj) as Schedule;
                schedule.weekDays = WeekDays;
                this.Property.SetValue(BoundObj, schedule);
            }

            private void UpdateTimes()
            {
                var schedule = Property.GetValue(BoundObj) as Schedule;
                schedule.time = CurrentTimes;
                this.Property.SetValue(BoundObj, schedule);
            }
        }
    }
}
