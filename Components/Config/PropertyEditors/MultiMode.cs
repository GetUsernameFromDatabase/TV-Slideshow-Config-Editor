using System;
using System.Reflection;
using System.Windows.Forms;

namespace TV_Slideshow_Config_Editor.ConfigVisualised
{
    public class Config_MultipleModeProperty : Config_BaseProperty
    {
        public Control ActiveEditor { get; protected set; }
        public Control[] AvailableEditors { get; protected set; }

        public InputModeChoice ModeChooser { get; protected set; }
        readonly protected string[] AvailableModes;
        public Config_MultipleModeProperty(string[] Modes, PropertyInfo property, object obj)
            : base(property, obj)
        {
            StyleMe();

            AvailableModes = Modes;
            this.ModeChooser = new InputModeChoice(AvailableModes);

            var Choices = ModeChooser.Choices;
            Choices.SelectionChangeCommitted += ModeChange;

            this.Controls.Add(ModeChooser);
        }
        private void StyleMe()
        {
            this.CellBorderStyle = TableLayoutPanelCellBorderStyle.Single;
            this.GrowStyle = TableLayoutPanelGrowStyle.AddRows;
            this.ColumnCount = 1;
        }

        protected void HideOtherEditors()
        {
            SuspendLayout();
            foreach (var item in AvailableEditors)
            {
                var turnedOn = item == ActiveEditor;
                item.Visible = turnedOn;
                item.Enabled = turnedOn;
            }
            ResumeLayout();
        }

        protected void ModeChange(object sender, EventArgs e)
        {
            var comboBox = sender as Config_ComboBox;
            var index = comboBox.SelectedIndex;
            if (index == -1) return;
            ChangeActiveEditor(index);
        }

        protected void ChangeActiveEditor(int index)
        {
            ActiveEditor = AvailableEditors[index];
            Property.SetValue(BoundObj, this.ActiveEditor.Tag);
            HideOtherEditors();
        }

        protected void SetDefault_SelectedIndex(object sender, EventArgs e)
        {
            var comboBox = sender as ComboBox;
            comboBox.SelectedIndex = Array.IndexOf(AvailableEditors, ActiveEditor);
        }
    }
}
