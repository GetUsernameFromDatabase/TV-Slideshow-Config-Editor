using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Windows.Forms;

namespace TV_Slideshow_Config_Editor.ConfigVisualised
{
    public class Config_ListProperty : TableLayoutPanel
    {
        public DataGridView DataGridView { get; }
        public List<string> CurrentList;

        public Config_ListProperty(string Title, List<string> StartingList)
        {
            CurrentList = StartingList;
            this.DataGridView = MakeDataGridView(Title);

            var DataManipulator = MakeDataManipulatorButtons();
            this.Controls.AddRange(new Control[2] { DataGridView, DataManipulator });
            StyleMe();
        }

        protected void StyleMe()
        {
            this.Dock = DockStyle.Fill;
            this.AutoSize = true;
            this.AutoSizeMode = AutoSizeMode.GrowAndShrink;

            this.RowCount = 1;
            this.ColumnCount = 2;
            this.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100));
            this.ColumnStyles.Add(new ColumnStyle(SizeType.AutoSize));
        }

        protected DataGridView MakeDataGridView(string Title)
        {
            DataTable dt = new DataTable(Title);
            dt.Columns.Add(Title, typeof(string));
            for (int i = 0; i < dt.Columns.Count; i++)
            {
                var column = dt.Columns[i];
                column.AllowDBNull = false;
            }

            foreach (var item in CurrentList)
                dt.Rows.Add(item);
            var ctrl = new DataGridView()
            {
                DataSource = dt,
                Dock = DockStyle.Fill,
                Height = 70, // Weird but required
                ScrollBars = ScrollBars.Both,
                AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill,
                AllowUserToResizeColumns = false,
                AllowUserToResizeRows = false,
                SelectionMode = DataGridViewSelectionMode.FullRowSelect,
            };
            return ctrl;
        }

        protected FlowContainer MakeDataManipulatorButtons()
        {
            var cntr = new FlowContainer();
            cntr.Controls.Add(MakeRemoveButton());
            return cntr;
        }

        protected Button MakeRemoveButton()
        {
            var removeBtn = new Button()
            {
                Text = "-",
                Font = new Font(Font.FontFamily, 13),
                Size = new Size(32, 32),
                TextAlign = ContentAlignment.TopCenter,
                Padding = new Padding(0),
            };
            removeBtn.Click += RemoveButton_Click;
            return removeBtn;
        }

        private void RemoveButton_Click(object sender, EventArgs e)
        {
            foreach (var item in DataGridView.SelectedRows)
            {
                var row = item as DataGridViewRow;
                if (row.Index < DataGridView.RowCount - 1)
                    DataGridView.Rows.Remove(row);
            }
        }
    }
}
