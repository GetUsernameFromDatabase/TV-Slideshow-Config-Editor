using System;
using System.Windows.Forms;
using Newtonsoft.Json.Schema;

namespace TV_Slideshow_Config_Editor
{
    public partial class ConfigEditor : Form
    {
        public ConfigEditor()
        {
            InitializeComponent();
            this.Schema = JSchema.Parse(Properties.Resources.ConfigSchema);
        }

        private void UpdateMenuButtonStatuses()
        {
            TabControl_MainConfig.Enabled = MenuFile_SaveAs.Enabled =
                this.ConfigJSON != null;
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
    }
}
