using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TV_Slideshow_Config_Editor.ConfigVisualised
{
    public class Config_SimpleProperty : TableLayoutPanel
    {
        public object parentObj { get; protected set; }
        public PropertyInfo property { get; protected set; }

        public Config_SimpleProperty()
        {
            StyleMe();
        }

        public Config_SimpleProperty(PropertyInfo property, object obj)
        {
            this.property = property;
            this.parentObj = obj;
            StyleMe();
        }

        private void StyleMe()
        {
            this.AutoSize = true;
            this.AutoSizeMode = AutoSizeMode.GrowAndShrink;
            this.Dock = DockStyle.Fill;
            this.CellBorderStyle = TableLayoutPanelCellBorderStyle.Inset;

            this.RowCount = 1;
            this.ColumnCount = 2;
            this.GrowStyle = TableLayoutPanelGrowStyle.AddColumns;
        }

        protected Label GetLabel(string LabelText = "")
        {
            return new Label()
            {
                Text = LabelText,
                TextAlign = System.Drawing.ContentAlignment.MiddleLeft,
            };
        }

        protected MaskedTextBox GetEditBox()
        {
            var editBox = new MaskedTextBox()
            {
                Dock = DockStyle.Fill,
            };
            if (this.property != null)
                editBox.Text = this.property.GetValue(this.parentObj).ToString();
            return editBox;
        }
    }

    public class Config_ComplexProperty : Config_SimpleProperty
    {
        public Control ActiveEditor { get; protected set; }
        public Control[] AvailableEditors { get; protected set; }

        public InputModeChoice ModeChooser { get; protected set; }
        readonly protected string[] AvailableModes;
        public Config_ComplexProperty(object obj, string[] Modes, PropertyInfo property) 
            : base(property, obj)
        {
            this.CellBorderStyle = TableLayoutPanelCellBorderStyle.Single;
            this.GrowStyle = TableLayoutPanelGrowStyle.AddRows;
            ColumnCount = 1;

            AvailableModes = Modes;
            this.ModeChooser = new InputModeChoice(AvailableModes);

            var Choices = ModeChooser.Choices;
            // This is a hacky way to get it to work -
            // would like the following method to occure only once
            Choices.SelectionChangeCommitted += ModeChange;
            this.Controls.Add(ModeChooser);
        }

        protected void HideOtherEditors()
        {
            foreach (var item in AvailableEditors)
            {
                var turnedOn = item == ActiveEditor;
                item.Visible = turnedOn;
                item.Enabled = turnedOn;
            }
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
            property.SetValue(parentObj, this.ActiveEditor.Tag);
            HideOtherEditors();
        }

        protected void SetDefault_SelectedIndex(object sender, EventArgs e)
        {
            var comboBox = sender as ComboBox;
            comboBox.SelectedIndex = Array.IndexOf(AvailableEditors, ActiveEditor);
        }
    }
}
