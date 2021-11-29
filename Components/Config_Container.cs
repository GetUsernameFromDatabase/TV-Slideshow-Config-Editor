using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Reflection;
using System.Windows.Forms;

namespace TV_Slideshow_Config_Editor.ConfigVisualised
{
    public class TabPageContent : FlowLayoutPanel
    {
        public TabPageContent()
        {
            this.FlowDirection = FlowDirection.TopDown;
            this.Dock = DockStyle.Fill;
        }
    }

    public class ConfigContainer : TableLayoutPanel
    {
        readonly FlowLayoutPanel SubOptions;
        public ConfigContainer(string TitleLabel)
        {
            this.AutoSize = true;
            this.AutoSizeMode = AutoSizeMode.GrowAndShrink;

            this.ColumnCount = 1;
            this.RowCount = 2;

            this.CellBorderStyle = TableLayoutPanelCellBorderStyle.Single;
            this.CellPaint += ConfigContainer_CellPaint;

            var Title = new Label()
            {
                Dock = DockStyle.Fill,
                Text = TitleLabel,
                TextAlign = System.Drawing.ContentAlignment.MiddleCenter,
            };
            this.SubOptions = new FlowLayoutPanel()
            {
                AutoSize = true,
                AutoSizeMode = AutoSizeMode.GrowAndShrink,
                Dock = DockStyle.Fill,

                FlowDirection = FlowDirection.TopDown,
                BorderStyle = BorderStyle.FixedSingle,
            };
            this.Controls.AddRange(new Control[2] { Title, SubOptions });
        }

        private void ConfigContainer_CellPaint(object sender, TableLayoutCellPaintEventArgs e)
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

        public void AddControls(List<Control> controls)
        {
            this.SubOptions.Controls.AddRange(controls.ToArray());
        }
    }
}
