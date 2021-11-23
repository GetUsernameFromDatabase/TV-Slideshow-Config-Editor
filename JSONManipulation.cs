using System;
using System.Windows.Forms;
using Newtonsoft.Json.Linq;

namespace TV_Slideshow_Config_Editor
{
    public partial class ConfigEditor : Form
    {
        public JObject ConfigJSON { get; private set; }
    }
}
