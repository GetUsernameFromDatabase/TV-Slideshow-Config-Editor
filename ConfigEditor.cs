using System.Text.RegularExpressions;
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
    }
}
