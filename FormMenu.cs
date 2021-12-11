using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using Newtonsoft.Json.Schema;
using System;
using System.IO;
using System.Windows.Forms;
using TV_Slideshow_Config_Editor.ConfigInterface;

namespace TV_Slideshow_Config_Editor
{
    public partial class ConfigEditor : Form
    {
        public JSchema Schema { get; private set; } = JSchema.Parse(Properties.Resources.ConfigSchema);
        readonly static public JsonSerializerSettings SerializerSettings = new JsonSerializerSettings
        {
            NullValueHandling = NullValueHandling.Ignore,
            DateTimeZoneHandling = DateTimeZoneHandling.Utc,
        };
        public Configurations Config { get; private set; }
        public string FilePath { get; private set; }

        private void SaveFile()
        {
            var fileContent = JsonConvert.SerializeObject(this.Config,
                Formatting.Indented, SerializerSettings);
            using (StreamWriter file = new StreamWriter(this.FilePath))
                file.Write(fileContent);
        }

        private void MenuFile_Open_Click(object sender, EventArgs e)
        {
            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                this.FilePath = openFileDialog1.FileName;
                var fileStream = openFileDialog1.OpenFile();

                using (StreamReader reader = new StreamReader(fileStream))
                {
                    var fileContent = reader.ReadToEnd();
                    if (JObject.Parse(fileContent).IsValid(this.Schema))
                    {
                        var JSON = JsonConvert.DeserializeObject<Configurations>(
                            fileContent, SerializerSettings
                        );
                        this.Config = JSON;
                        PopulatePages();
                    }
                    else MessageBox.Show("This is an improper TV Slideshow Configuration file",
                        "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void MenuFile_New_Click(object sender, EventArgs e)
        {
            var source = Properties.Resources.DefaultJSON;
            this.Config = JsonConvert.DeserializeObject<Configurations>(source,
                SerializerSettings);
            PopulatePages();
        }

        private void MenuFile_SaveAs_Click(object sender, EventArgs e)
        {
            if (saveFileDialog1.ShowDialog() == DialogResult.OK)
            {
                this.FilePath = saveFileDialog1.FileName;
                UpdateMenuButtonStatuses();
                SaveFile();
            }
        }

        private void MenuFile_Save_Click(object sender, EventArgs e)
        {
            SaveFile();
        }
    }
}
