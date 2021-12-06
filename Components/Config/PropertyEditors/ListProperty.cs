using System;
using System.Collections.Generic;
using System.Reflection;
using System.Windows.Forms;

namespace TV_Slideshow_Config_Editor.ConfigVisualised
{
    public class Config_ListProperty : Config_BaseProperty
    {
        public Config_ListProperty(object obj, PropertyInfo property)
            : base(property, obj)
        {
            this.CellBorderStyle = TableLayoutPanelCellBorderStyle.Single;
            this.GrowStyle = TableLayoutPanelGrowStyle.AddRows;
            ColumnCount = 1;
        }

        public void AddControl(Control control)
        {
            var WrappedControl = WrapControlWithRemoveButton(control);
            this.Controls.Add(WrappedControl);
        }

        protected Control WrapControlWithRemoveButton(Control control)
        {
            // This assumes Label is [0] control
            var cntrlLabel = control.Controls[0] as Label;
            var newLabel = GetModifiedLabel(cntrlLabel);

            control.Controls.Remove(cntrlLabel);
            cntrlLabel.Dispose();

            control.Controls.Add(newLabel);
            control.Controls.SetChildIndex(newLabel, 0);
            return control;
        }

        protected FlowLayoutPanel GetModifiedLabel(Label control)
        {
            var newLabel = new FlowLayoutPanel()
            {
                Dock = DockStyle.Fill,
            };
            newLabel.Controls.AddRange(new Control[2] { control,
                GetModifyControlButton() });
            return newLabel;
        }

        protected Button GetModifyControlButton()
        {
            var btn = new Button()
            {
                Text = "-",
                AutoSize = true,
                AutoSizeMode = AutoSizeMode.GrowAndShrink,
            };
            btn.ControlRemoved += RemoveListPropertyControl;
            return btn;
        }

        private void RemoveListPropertyControl(object sender, ControlEventArgs e)
        {
            var btn = sender as Button;
            var listPropContainer = btn.Parent.Parent;
            listPropContainer.Parent.Controls.Remove(listPropContainer);
            listPropContainer.Dispose();
        }
    }
}
