using System;
using System.Windows.Forms;
using Newtonsoft.Json;
using Newtonsoft.Json.Schema;

namespace TV_Slideshow_Config_Editor
{
    public partial class ConfigEditor : Form
    {
        public ConfigEditor()
        {
            InitializeComponent();
            TabPage_Defaults.Tag = Properties.Resources.ConfigDefaultsTag;
            TabPage_TimeDisplay.Tag = Properties.Resources.ConfigTimeDisplayTag;
            TabPage_Sites.Tag = Properties.Resources.ConfigSitesTag;
            TabPage_Notifications.Tag = Properties.Resources.ConfigNotificationsTag;
        }

        private void UpdateMenuButtonStatuses()
        {
            TabControl_MainConfig.Enabled = MenuFile_SaveAs.Enabled =
                this.Config != null;
            MenuFile_Save.Enabled = this.FilePath != null;
        }

        // https://stackoverflow.com/a/7759951
        protected override void OnResizeBegin(EventArgs e)
        {
            SuspendLayout();
            base.OnResizeBegin(e);
        }
        protected override void OnResizeEnd(EventArgs e)
        {
            ResumeLayout();
            base.OnResizeEnd(e);
        }
        protected override CreateParams CreateParams
        { 
            // Makes all controls on creation DoubleBuffered
            // https://stackoverflow.com/a/25648710
            get
            {
                CreateParams handleParam = base.CreateParams;
                handleParam.ExStyle |= 0x02000000;   // WS_EX_COMPOSITED       
                return handleParam;
            }
        }
    }
}
