using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using Newtonsoft.Json.Schema;
using System;
using System.IO;
using System.Windows.Forms;

namespace TV_Slideshow_Config_Editor
{
    public partial class ConfigEditor : Form
    {
        public JSchema Schema { get; private set; }
        public JObject ConfigJSON { get; private set; }
        public string FilePath { get; private set; }

        private void PopulatePages()
        {
            UpdateMenuButtonStatuses();
            var pagePopulations = new (JToken, FlowLayoutPanel)[]
            {
                (ConfigJSON["defaults"], Defaults_FlowPanel),
                (ConfigJSON["showTime"], TimeDisplay_FlowPanel),
                (ConfigJSON["sites"], Sites_FlowPanel),
                (ConfigJSON["notifications"], Notifications_FlowPanel)
            };

            foreach (var pagePop in pagePopulations)
            {
                var (InfoJSON, page) = pagePop;
                if (InfoJSON == null) continue;

                var controls = JSON_Parser.JSONParameterIntoControl(InfoJSON);
                page.Controls.AddRange(controls.ToArray());
            }
        }

        private void SaveFile()
        {
            var fileContent = JsonConvert.SerializeObject(this.ConfigJSON, Formatting.Indented);
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
                    var JSON = (JObject)JsonConvert.DeserializeObject(reader.ReadToEnd());
                    if (JSON.IsValid(this.Schema))
                    {
                        this.ConfigJSON = JSON; PopulatePages();
                    }
                    else MessageBox.Show("This is an improper TV Slideshow Configuration file", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void MenuFile_New_Click(object sender, EventArgs e)
        {
            this.ConfigJSON = (JObject)JsonConvert.DeserializeObject(Properties.Resources.DefaultJSON);
            PopulatePages();
        }

        private void MenuFile_SaveAs_Click(object sender, EventArgs e)
        {
            if (saveFileDialog1.ShowDialog() == DialogResult.OK)
            {
                this.FilePath = saveFileDialog1.FileName;
                SaveFile();
            }
        }

        private void MenuFile_Save_Click(object sender, EventArgs e)
        {
            SaveFile();
        }
    }
}
