using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using TV_Slideshow_Config_Editor.ConfigInterface;
using TV_Slideshow_Config_Editor.Logic;

namespace TV_Slideshow_Config_Editor.ConfigVisualised
{
    public partial class Sites : FlowContainer
    {
        public List<Site> CurrentSites { get; protected set; }
        public Sites(List<Site> ConfigSlice) : base("page")
        {
            this.CurrentSites = ConfigSlice;
            for (int i = 0; i < ConfigSlice.Count; i++)
            {
                var slice = ConfigSlice[i];
                var title = String_Manipulation.MakeControlTitle(i, "Site");
                var control = SiteIntoControls(title, slice);
                this.Controls.Add(control);
            }
        }

        public Site MakeSite()
        {
            var site = new Site()
            {
                duration = 0,
                height = "100%",
                url = "./",
            };
            return site;
        }

        private void SiteButtonClick(object sender, EventArgs e)
        {
            var Control = sender as Button;

            if (0 == Control.Tag as int?) RemoveParent(Control);
            else
            {
                var btnContainer = Control.Parent.Parent as ConfigContainer;
                var btnType = (Control.Tag as int?) == 1 ? 1 : 0;
                var callerIndex = GetConfigContainerIndex(btnContainer);

                var controlIndex = callerIndex + btnType;
                var newSite = MakeSite();
                var title = String_Manipulation.MakeControlTitle(controlIndex, "Site");

                var siteControls = SiteIntoControls(title, newSite);
                BindConfigControl(siteControls, newSite, CurrentSites, controlIndex);
                UpdateOtherTitles(controlIndex);
            }
        }

        private void SiteContainerRemoved(object sender, ControlEventArgs e)
        {
            if (!(e.Control is ConfigContainer removedControl))
            {
                e.Control.Dispose();
                return;
            };
            var cfgCntSubOptions = removedControl.SubOptions.Controls;
            if (!(cfgCntSubOptions[0] is ConfigString controlWithBoundSite)) return;

            var site = controlWithBoundSite.BoundObj as Site;
            CurrentSites.Remove(site);

            if (this.Controls.Count == 0)
            { // So that user can add a new site
                var addButton = new Button()
                {
                    Text = "+",
                    Font = new Font(Font.FontFamily, 18),
                    Dock = DockStyle.Fill,
                    AutoSize = true,
                    AutoSizeMode = AutoSizeMode.GrowAndShrink,
                };
                addButton.Click += NoSitesButton_Click;
                this.Controls.Add(addButton);
            }
            else UpdateOtherTitles(GetConfigContainerIndex(removedControl));
            controlWithBoundSite.Dispose();
        }

        private void NoSitesButton_Click(object sender, EventArgs e)
        {
            var c = sender as Button;
            var newSite = MakeSite();

            var title = String_Manipulation.MakeControlTitle(0, "Site");
            var siteControls = SiteIntoControls(title, newSite);

            BindConfigControl(siteControls, newSite, CurrentSites);
            c.Parent.Controls.Remove(c);
        }

        private ConfigContainer SiteIntoControls(string Title, Site site)
        {
            var container = new ConfigContainer(Title);
            var subControls = new Control[3];
            var properties = site.GetType().GetProperties();

            subControls[0] = new ConfigString("URL", properties[0], site);
            subControls[1] = new SiteHeight(site, properties[1]);
            subControls[2] = new ConfigNumber("Duration", properties[2], site);

            if (subControls[2].Controls[1].Text == "0")
                subControls[2].Controls[1].Text = "";
            container.AddControls(subControls);

            container.MakeThisDeletable(SiteButtonClick);
            this.ControlRemoved += SiteContainerRemoved;
            return container;
        }
    }
}
