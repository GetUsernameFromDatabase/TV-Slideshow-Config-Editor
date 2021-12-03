using System.Windows.Forms;

namespace TV_Slideshow_Config_Editor.ConfigVisualised
{
    public class Config_ComboBox : ComboBox
    {
        public Config_ComboBox(string[] Labels)
        {
            this.DropDownStyle = ComboBoxStyle.DropDownList;
            this.DataSource = Labels;
        }
    }

    public class InputModeChoice : Config_SimpleProperty
    {
        readonly public Config_ComboBox Choices;
        public InputModeChoice(string[] modes)
        {
            this.CellBorderStyle = TableLayoutPanelCellBorderStyle.None;
            var label = this.GetLabel("Height Mode:");
            this.Choices = new Config_ComboBox(modes);
            this.Controls.AddRange(new Control[2] { label, Choices });
        }
    }
}
