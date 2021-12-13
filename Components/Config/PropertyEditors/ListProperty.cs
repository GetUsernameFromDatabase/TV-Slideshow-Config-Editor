using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Drawing;
using System.Windows.Forms;

namespace TV_Slideshow_Config_Editor.ConfigVisualised
{
    public class Config_ListProperty : TableLayoutPanel
    {
        public Func<DataGridViewRow, Color> RowCheck { get; private set; }
        public DataGridView DataDisplay { get; }
        public List<string> CurrentList;

        public Config_ListProperty(string Title, List<string> StartingList,
            Func<DataGridViewRow, Color> rowCheck = null)
        {
            CurrentList = StartingList;
            RowCheck = rowCheck;

            this.DataDisplay = MakeDataGridView(Title);
            var DataManipulator = MakeDataManipulatorButtons();

            this.Controls.AddRange(new Control[2] { DataDisplay, DataManipulator });
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

        public void UpdateCurrentList()
        {

            var dt = DataDisplay.DataSource as DataTable;
            CurrentList.Clear();
            foreach (DataRow row in dt.Rows)
            {
                var item = row.ItemArray[0] as string;
                if (item != "") CurrentList.Add(item);
            }
        }

        protected DataTable MakeDataTable(string TableName, (string, Type)[] Columns)
        {
            DataTable dt = new DataTable(TableName);
            foreach (var Column in Columns)
            {
                var (columnHeader, columnType) = Column;
                dt.Columns.Add(columnHeader, columnType);
            }

            DisallowNullOnAll(dt);
            return dt;
        }

        protected void DisallowNullOnAll(DataTable dt)
        {
            for (int i = 0; i < dt.Columns.Count; i++)
            {
                var column = dt.Columns[i];
                column.AllowDBNull = false;
            }
        }

        private void DataTable_RowChanged(object sender, DataRowChangeEventArgs e)
        {
            UpdateCurrentList();
        }

        protected DataGridView MakeDataGridView(string Title)
        {
            var TableInitInfo = new (string, Type)[1] { (Title, typeof(string)) };
            DataTable dt = MakeDataTable(Title, TableInitInfo);
            dt.Columns[0].AllowDBNull = false;
            foreach (var item in CurrentList)
                dt.Rows.Add(item);

            var ctrl = new ListProperty_DataGridView(dt);
            if (RowCheck != null) ctrl.RowPrePaint += DataTable_RowPrePaint;
            // Should be After binding DataTable with DataGridView
            dt.RowChanged += DataTable_RowChanged;
            return ctrl;
        }

        private void DataTable_RowPrePaint(object sender, DataGridViewRowPrePaintEventArgs e)
        {
            var c = sender as DataGridView;
            var row = c.Rows[e.RowIndex];

            row.DefaultCellStyle.BackColor = RowCheck(row);
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
            foreach (var item in DataDisplay.SelectedRows)
            {
                var row = item as DataGridViewRow;
                if (row.Index < DataDisplay.RowCount - 1)
                    DataDisplay.Rows.Remove(row);
            }
        }
    }

    public class ListProperty_DataGridView : DataGridView
    {
        public ListProperty_DataGridView(DataTable dt)
        {
            Dock = DockStyle.Fill;
            Height = 70; // Weird but required
            ScrollBars = ScrollBars.Both;
            SelectionMode = DataGridViewSelectionMode.FullRowSelect;

            AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            AllowUserToResizeColumns = false;
            AllowUserToResizeRows = false;
            DataSource = dt;
        }
    }
}
