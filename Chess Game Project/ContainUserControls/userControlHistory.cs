using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Chess_Game_Project.ContainUserControls
{
    public partial class userControlHistory : UserControl
    {
        public userControlHistory()
        {
            InitializeComponent();
        }
        public DataGridView dtGridView
        {
            get
            {
                return dtGridViewHistory;
            }
        }
        public void copyDataIntoGridListHistories(DataGridView dtgrv)
        {
            dtGridViewHistory.Rows.Clear();
            dtGridViewHistory.Columns.Clear();
            dtGridViewHistory.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dtGridViewHistory.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dtGridViewHistory.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;

            //xóa đi dòng cuối cùng trong dataGridView
            dtGridViewHistory.AllowUserToAddRows = false;
            dtGridViewHistory.RowHeadersVisible = false;
            //ngăn không cho người dùng kéo giãn
            foreach (DataGridViewColumn column in dtGridViewHistory.Columns)
            {
                column.Resizable = DataGridViewTriState.False;
            }
            foreach (DataGridViewRow row in dtGridViewHistory.Rows)
            {
                row.Resizable = DataGridViewTriState.False;
            }
            foreach (DataGridViewColumn column in dtgrv.Columns)
            {
                dtGridViewHistory.Columns.Add(column.Clone() as DataGridViewColumn);
            }

            foreach (DataGridViewRow row in dtgrv.Rows)
            {
                int rowIndex = dtGridViewHistory.Rows.Add(row.Clone() as DataGridViewRow);
                foreach (DataGridViewCell cell in row.Cells)
                {
                    dtGridViewHistory.Rows[rowIndex].Cells[cell.ColumnIndex].Value = cell.Value;
                }
            }

            dtGridViewHistory.ReadOnly = true;
        }
        public event EventHandler<EventArgs> btnCloseHistory_click;
        private void btnCloseHistory_Click(object sender, EventArgs e)
        {
            btnCloseHistory_click?.Invoke(this, e);
        }
    }
}
