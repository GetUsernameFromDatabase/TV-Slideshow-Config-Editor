using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
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
            private Schedule Schedule { get; set; }
            public NotificationsSchedule(PropertyInfo property, Notification notification)
                : base(property, notification)
            {
                var PropValue = Property.GetValue(notification);
                this.Schedule = PropValue as Schedule;
                if (Schedule == null)
                {
                    PropValue = ParseImportedSchedule(PropValue);
                    Property.SetValue(notification, PropValue);
                    Schedule = Property.GetValue(notification) as Schedule;
                }

                this.GrowStyle = TableLayoutPanelGrowStyle.AddRows;
                this.ColumnCount = 1;
                this.RowCount = 2;

                var timeControl = MakeTimeControl();
                var wkndControl = MakeWeekndControl();
                this.Controls.AddRange(new Control[2] { timeControl, wkndControl });
            }

            private object ParseImportedSchedule(object property)
            {
                var SchedType = property.GetType();
                if (typeof(string) == SchedType)
                    property = new Schedule() { times = new List<string>() { (string)property } };
                else if (typeof(JArray) == SchedType)
                {
                    var time = (property as JArray).ToObject<List<string>>();
                    property = new Schedule() { times = time };
                }
                else
                { // JsonSerializationException
                    var schedule = property as JObject;
                    var WDPropName = "weekDays";
                    try
                    {
                        var weekDays = schedule.GetValue(WDPropName).ToObject<string[]>();
                        var weekDaysAsString = string.Join("", weekDays);
                        schedule[WDPropName] = weekDaysAsString; 
                    }
                    catch (JsonSerializationException) { } // Intended case: Couldn't conver to string[]
                    catch (ArgumentNullException) { } // Intended case: "weekDays" was null
                    schedule[WDPropName] = schedule[WDPropName].ToObject<string>().ToUpper();
                    property = JsonConvert.DeserializeObject<Schedule>(schedule.ToString());
                }
                return property;
            }

            private Config_ListProperty MakeTimeControl()
            {
                var control = new Config_ListProperty("Time", Schedule.times);
                return control;
            }

            private Config_BaseProperty MakeWeekndControl()
            {
                var weekDays = new Config_BaseProperty();
                var label = weekDays.GetLabel("Week Days");

                var DayStrings = new string[7] { "E", "T", "K", "N", "R", "L", "P" };
                var Days = DayStrings.Select(day => MakeWeekday(day)).ToArray();

                var weekDayChoices = new FlowLayoutPanel()
                {
                    Size = new Size(158, 44),
                };
                weekDayChoices.Controls.AddRange(Days);

                weekDays.Controls.AddRange(new Control[2] { label, weekDayChoices });
                return weekDays;
            }

            private CheckBox MakeWeekday(string Text)
            {
                var days = Schedule.weekDays;
                var checkBox = new CheckBox()
                {
                    Text = Text,
                    AutoSize = true,
                    Checked = days.Contains(Text), // Assumes Text is upper
                };
                checkBox.CheckedChanged += WeekDay_CheckedChanged;
                return checkBox;
            }

            private void WeekDay_CheckedChanged(object sender, EventArgs e)
            {
                var c = sender as CheckBox;
                var day = c.Text;
                var days = Schedule.weekDays;

                if (days.Contains(day)) days = days.Replace(day, "");
                else days += day; // Assumes Weekdays is setup correctly at start
                Schedule.weekDays = days;
            }
        }
    }
}
