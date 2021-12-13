using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Windows.Forms;

namespace TV_Slideshow_Config_Editor.ConfigVisualised
{
    public class ConfigContainer : TableLayoutPanel
    {
        readonly public FlowLayoutPanel SubOptions;
        private object BoundObject;

        public ConfigContainer(string TitleLabel)
        {
            StyleMe();
            var Title = new Label()
            {
                Dock = DockStyle.Fill,
                Text = TitleLabel,
                TextAlign = ContentAlignment.MiddleCenter,
            };
            this.SubOptions = new FlowContainer()
            {
                BorderStyle = BorderStyle.FixedSingle,
            };
            this.Controls.AddRange(new Control[2] { Title, SubOptions });
        }
        private void StyleMe()
        {
            this.AutoSize = true;
            this.AutoSizeMode = AutoSizeMode.GrowAndShrink;

            this.ColumnCount = 1;
            this.RowCount = 2;

            this.CellBorderStyle = TableLayoutPanelCellBorderStyle.Single;
            this.CellPaint += PaintCellBorders;
        }

        public void MakeThisDeletable(Action<object, EventArgs> buttonClickCallback)
        {
            var Label = this.Controls[0] as Label;
            var Header = new TableLayoutPanel()
            {
                ColumnCount = 3,
                RowCount = 1,
                Dock = DockStyle.Fill,
                AutoSize = true,
                AutoSizeMode = AutoSizeMode.GrowAndShrink,
            };

            var buttonLeft = new Container_Button(true);
            buttonLeft.Click += new EventHandler(buttonClickCallback);
            var buttonRight = new Container_Button(false);
            buttonRight.Click += new EventHandler(buttonClickCallback);

            Header.Controls.AddRange(new Control[3] { buttonLeft, Label, buttonRight });
            Header.ColumnStyles.Add(new ColumnStyle(SizeType.AutoSize));
            Header.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100));
            Header.ColumnStyles.Add(new ColumnStyle(SizeType.AutoSize));

            var buttonDelete = new Container_Button("DELETE");
            buttonDelete.Click += new EventHandler(buttonClickCallback);

            // this.Controls.Remove(Label);
            this.Controls.Add(Header, 0, 0);
            this.Controls.Add(buttonDelete);
            RowCount += 1;
        }

        private void PaintCellBorders(object sender, TableLayoutCellPaintEventArgs e)
        {
            var panel = sender as TableLayoutPanel;
            e.Graphics.SmoothingMode = SmoothingMode.HighQuality;
            var rectangle = e.CellBounds;
            using (var pen = new Pen(Color.Black, 0))
            {
                pen.Alignment = PenAlignment.Center;
                pen.DashStyle = DashStyle.Solid;

                if (e.Row == (panel.RowCount - 1))
                    rectangle.Height -= 1;
                if (e.Column == (panel.ColumnCount - 1))
                    rectangle.Width -= 1;

                e.Graphics.DrawRectangle(pen, rectangle);
            }
        }

        public object GetBoundConfigObject()
        {
            if (BoundObject != null) return BoundObject;
            foreach (var item in SubOptions.Controls)
            {
                if (item is ConfigString strCfgControl)
                    BoundObject = strCfgControl.BoundObj;
                else if (item is ConfigNumber intCfgControl)
                    BoundObject = intCfgControl.BoundObj;
                else continue;
                // If correct control was found continue is not triggered
                return BoundObject;
            }
            return null;
        }

        public void AddControls(List<Control> controls)
        {
            this.SubOptions.Controls.AddRange(controls.ToArray());
        }
        public void AddControls(Control[] controls)
        {
            this.SubOptions.Controls.AddRange(controls);
        }
    }
}
