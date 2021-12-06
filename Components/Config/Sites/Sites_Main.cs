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
            this.ControlRemoved += SiteRemoved;
            this.NoOtherControlButton = MakeNoOtherControlButton(NoSitesButton_Click);

            this.CurrentSites = ConfigSlice;
            for (int i = 0; i < ConfigSlice.Count; i++)
            {
                var slice = ConfigSlice[i];
                var title = String_Manipulation.MakeControlTitle(i, "Site");
                var control = SiteIntoControls(title, slice);
                this.Controls.Add(control);
            }

            ShowEmptyPageControlButton_IfNeeded();
        }

        public Site MakeDefault()
        {
            var site = new Site();
            return site;
        }
        private ConfigContainer SiteIntoControls(string Title, Site site)
        {
            var container = new ConfigContainer(Title);
            var subControls = new Control[3];
            var properties = site.GetType().GetProperties();

            subControls[0] = new ConfigString("URL", properties[0], site);
            subControls[1] = new SiteHeight(properties[1], site);
            subControls[2] = new ConfigNumber("Duration", properties[2], site, true);

            container.AddControls(subControls);
            container.MakeThisDeletable(SiteButton_Click);
            return container;
        }

        private void SiteButton_Click(object sender, EventArgs e)
        {
            var Control = sender as Button;

            if (0 == Control.Tag as int?) { RemoveParent(Control); return; }
            var controlIndex = GetNewConfigContainerIndex(Control);
            var newControl = MakeDefault();
            var title = String_Manipulation.MakeControlTitle(controlIndex, "Site");

            var siteControls = SiteIntoControls(title, newControl);
            BindConfigControl(siteControls, newControl, CurrentSites, controlIndex);
            UpdateOtherTitles(controlIndex);
        }

        private void SiteRemoved(object sender, ControlEventArgs e)
        {
            var ConfigInfo = GetConfigInfo_OnControlRemoved(e);
            if (ConfigInfo == null) return;
            var (removedControl, BoundObject) = ConfigInfo;

            var site = BoundObject as Site;
            CurrentSites.Remove(site);

            if (!ShowEmptyPageControlButton_IfNeeded())
                UpdateOtherTitles(GetConfigContainerIndex(removedControl));
        }

        private void NoSitesButton_Click(object sender, EventArgs e)
        {
            var newSite = MakeDefault();
            var title = String_Manipulation.MakeControlTitle(0, "Site");
            var siteControls = SiteIntoControls(title, newSite);
            BindConfigControl(siteControls, newSite, CurrentSites);
            ShowEmptyPageControlButton_IfNeeded();
        }
    }
}
