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
    public partial class userControlLists : UserControl
    {
       
        public userControlLists()
        {
            InitializeComponent();

            dtAcceptFriend.RowTemplate.Height = 45;
            dtListFriends.RowTemplate.Height = 45;
            dtAllUsers.RowTemplate.Height = 45;
        }
        public void copyData(DataGridView dtgrv, DataGridView currentDtgrv)
        {
            currentDtgrv.Rows.Clear();
            currentDtgrv.Columns.Clear();
            currentDtgrv.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            currentDtgrv.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            currentDtgrv.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;

            //xóa đi dòng cuối cùng trong dataGridView
            currentDtgrv.AllowUserToAddRows = false;
            currentDtgrv.RowHeadersVisible = false;
            //ngăn không cho người dùng kéo giãn
            foreach (DataGridViewColumn column in currentDtgrv.Columns)
            {
                column.Resizable = DataGridViewTriState.False;
            }
            foreach (DataGridViewRow row in currentDtgrv.Rows)
            {
                row.Resizable = DataGridViewTriState.False;
            }
            foreach (DataGridViewColumn column in dtgrv.Columns)
            {
                currentDtgrv.Columns.Add(column.Clone() as DataGridViewColumn);
            }

            foreach (DataGridViewRow row in dtgrv.Rows)
            {
                int rowIndex = currentDtgrv.Rows.Add(row.Clone() as DataGridViewRow);
                foreach (DataGridViewCell cell in row.Cells)
                {
                    currentDtgrv.Rows[rowIndex].Cells[cell.ColumnIndex].Value = cell.Value;
                }
            }

            currentDtgrv.ReadOnly = true;
        }
        public void copyDataIntoGridAllUsers(DataGridView dtgrv)
        {
            try
            {
                copyData(dtgrv, dtAllUsers);
            }
            catch (Exception ex)
            {
                MessageBox.Show("loi copyDataIntoGridAllUsers: " + ex.Message);
            }
        }
        public void copyDataIntoGridListFriends(DataGridView dtgrv)
        {
            try
            {
                copyData(dtgrv, dtListFriends);
            }
            catch (Exception ex)
            {
                MessageBox.Show("loi copyDataIntoGridAllUsers: " + ex.Message);
            }
        }
        public void copyDataIntoGridAcceptFriends(DataGridView dtgrv)
        {
            try
            {
                copyData(dtgrv, dtAcceptFriend);
            }
            catch (Exception ex)
            {
                MessageBox.Show("loi copyDataIntoGridAllUsers: " + ex.Message);
            }
        }
        public event EventHandler<EventArgs> btnCloseList_click;
        public event DataGridViewCellEventHandler dtAllUsers_cellContentClick;
        public event DataGridViewCellEventHandler dtListFriends_cellContentClick;
        public event DataGridViewCellEventHandler dtAcceptFriend_cellContentClick;
        public event EventHandler<EventArgs> btnFindUser_click;
        public string username
        {
            get { return txtFindUser.Text; }
        }
        public DataGridView getDtGridViewAllUsers()
        {
            return dtAllUsers;
        }
        public void hideBtnMakeFriend(string userName)
        {
            for (int row = 0; row < dtAllUsers.Rows.Count; row++)
            {
                for (int col = 0; col < dtAllUsers.Rows.Count; col++)
                {
                    DataGridViewCell cell = dtAllUsers.Rows[row].Cells["userName"];
                    if (cell.Value.ToString() == userName)
                    {
                        DataGridViewCell cellMakeFriend = dtAllUsers.Rows[row].Cells[3];
                        cellMakeFriend.Style = new DataGridViewCellStyle { Padding = new Padding(500, 0, 0, 0) };
                        cellMakeFriend.ReadOnly = true;
                        return;
                    }
                }
            }
        }
        public void showBtnMakeFriend(string userName)
        {
            for (int row = 0; row < dtAllUsers.Rows.Count; row++)
            {
                for (int col = 0; col < dtAllUsers.Rows.Count; col++)
                {
                    DataGridViewCell cell = dtAllUsers.Rows[row].Cells["userName"];
                    if (cell.Value.ToString() == userName)
                    {
                        //lay ra cot ket ban
                        DataGridViewCell cellMakeFriend = dtAllUsers.Rows[row].Cells[3];
                        cellMakeFriend.Style = new DataGridViewCellStyle { Padding = new Padding(0, 0, 0, 0) };
                        cellMakeFriend.ReadOnly = true;
                        return;
                    }
                }
            }
        }

        private void btnCloseList_Click(object sender, EventArgs e)
        {
            btnCloseList_click?.Invoke(this, e);
        }

        private void dtAllUsers_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            dtAllUsers_cellContentClick?.Invoke(sender, e);
        }

        private void btnFindUser_Click(object sender, EventArgs e)
        {
            btnFindUser_click?.Invoke(this, e);
        }

        private void dtListFriends_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            dtListFriends_cellContentClick?.Invoke(sender, e);
        }

        private void dtAcceptFriend_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            dtAcceptFriend_cellContentClick?.Invoke(sender, e);
        }
    }
}
