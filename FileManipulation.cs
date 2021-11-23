using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.IO;
using System.Windows.Forms;

namespace TV_Slideshow_Config_Editor
{
    public partial class ConfigEditor : Form
    {
        public string filePath { get; private set; }

        private void MenuFile_Open_Click(object sender, EventArgs e)
        {
            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                //Get the path of specified file
                this.filePath = openFileDialog1.FileName;
                var fileStream = openFileDialog1.OpenFile();

                //Read the contents of the file into a stream
                using (StreamReader reader = new StreamReader(fileStream))
                    this.ConfigJSON = (JObject)JsonConvert.DeserializeObject(reader.ReadToEnd());

                MenuFile_Save.Enabled = MenuFile_SaveAs.Enabled = true;
                Console.WriteLine(this.ConfigJSON.GetValue("defaults"));
            }
        }

        private void SaveFile()
        {
            var fileContent = JsonConvert.SerializeObject(this.ConfigJSON, Formatting.Indented);
            using (StreamWriter file = new StreamWriter(this.filePath))
                file.Write(fileContent);
        }

        private void MenuFile_SaveAs_Click(object sender, EventArgs e)
        {
            if (saveFileDialog1.ShowDialog() == DialogResult.OK)
            {
                // Code to write the stream goes here.
                this.filePath = saveFileDialog1.FileName;
                SaveFile();
            }
        }

        private void MenuFile_Save_Click(object sender, EventArgs e)
        {
            SaveFile();
        }
    }
}
