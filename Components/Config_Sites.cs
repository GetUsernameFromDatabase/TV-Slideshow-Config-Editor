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
    public partial class Sites : FlowContainer
    {
        public List<Site> CurrentSites { get; protected set; }
        public Sites(List<Site> ConfigSlice) : base("page")
        {
            this.CurrentSites = ConfigSlice;
            for (int i = 0; i < ConfigSlice.Count; i++)
            {
                var slice = ConfigSlice[i];
                // TODO: make it take into account adding/removing sites
                var title = string.Format("{0}. Site", i + 1);
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

        private void BindSite(Site site, Control control, int index = -1)
        {
            if (index != -1)
            {
                this.CurrentSites.Insert(index, site);
                this.InsertControl(index, control);
            }
            else
            {
                this.CurrentSites.Add(site);
                this.Controls.Add(control);
            }
        }

        private void SiteButtonClick(object sender, EventArgs e)
        {
            var c = sender as Button;

            if (0 == c.Tag as int?)
            {
                var btnContainer = c.Parent as ConfigContainer;
                btnContainer.Parent.Controls.Remove(btnContainer);
            }
            else
            {
                var btnContainer = c.Parent.Parent as ConfigContainer;
                var index = this.Controls.IndexOf(btnContainer);

                var newSite = MakeSite();
                var siteControls = SiteIntoControls("NAAA", newSite);

                var btnType = (c.Tag as int?) == 1 ? 1 : 0;
                BindSite(newSite, siteControls, index + btnType);
            }
        }

        private void SiteContainerRemoved(object sender, ControlEventArgs e)
        {
            if (!(e.Control is ConfigContainer removedControl)) return;
            var controlWithBoundSite = removedControl.SubOptions.Controls[0] as ConfigString;

            var site = controlWithBoundSite.BoundObj as Site;
            CurrentSites.Remove(site);
            Console.WriteLine(this.Controls.Count);
            if (this.Controls.Count == 0)
            {
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
        }

        private void NoSitesButton_Click(object sender, EventArgs e)
        {
            var c = sender as Button;
            var newSite = MakeSite();
            var siteControls = SiteIntoControls("NAAA", newSite);

            BindSite(newSite, siteControls);
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
