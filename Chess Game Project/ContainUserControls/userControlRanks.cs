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
    public partial class userControlRanks : UserControl
    {
        public Label currentRank
        {
            get { return lbCurrentRank; }
            set { lbCurrentRank = value; }
        }
        public userControlRanks()
        {
            InitializeComponent();
        }
        public void copyDataIntoGridListRanks(DataGridView dtgrv)
        {
            dtGridRank.Rows.Clear();
            dtGridRank.Columns.Clear();
            dtGridRank.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dtGridRank.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dtGridRank.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;

            //xóa đi dòng cuối cùng trong dataGridView
            dtGridRank.AllowUserToAddRows = false;
            dtGridRank.RowHeadersVisible = false;
            //ngăn không cho người dùng kéo giãn
            foreach (DataGridViewColumn column in dtGridRank.Columns)
            {
                column.Resizable = DataGridViewTriState.False;
            }
            foreach (DataGridViewRow row in dtGridRank.Rows)
            {
                row.Resizable = DataGridViewTriState.False;
            }
            foreach (DataGridViewColumn column in dtgrv.Columns)
            {
                dtGridRank.Columns.Add(column.Clone() as DataGridViewColumn);
            }

            foreach (DataGridViewRow row in dtgrv.Rows)
            {
                int rowIndex = dtGridRank.Rows.Add(row.Clone() as DataGridViewRow);
                foreach (DataGridViewCell cell in row.Cells)
                {
                    dtGridRank.Rows[rowIndex].Cells[cell.ColumnIndex].Value = cell.Value;
                }
            }

            dtGridRank.ReadOnly = true;
        }
        public event EventHandler<EventArgs> btnCloseRank_click;
        private void btnCloseRank_Click(object sender, EventArgs e)
        {
            btnCloseRank_click?.Invoke(this, e);
        }
    }
}
