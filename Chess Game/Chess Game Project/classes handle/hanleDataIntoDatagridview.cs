﻿using Chess_Game_Project.classes;
using Chess_Game_Project.ContainUserControls;
using Newtonsoft.Json.Linq;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Chess_Game_Project.classes_handle
{
    internal class hanleDataIntoDatagridview
    {
        //chứa danh sách ip của datagridview list rooms
        public static List<object> columnData = null;
        //====================================CÁC HÀM DÙNG ĐỂ HIỂN THỊ DỮ LIỆU LÊN GIAO DIỆN DATAGRIDVIEW ==================================
        public static async Task displayListMatches(DataGridView dtGridContainListRooms, string apiGetListMatches)
        {
            try
            {
                columnData = new List<object>();
                //tạo ra đối tượng để căn giữa nội dung trong từng ô
                dtGridContainListRooms.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                dtGridContainListRooms.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
                //ngăn không cho người dùng kéo giãn
                foreach (DataGridViewColumn column in dtGridContainListRooms.Columns)
                {
                    column.Resizable = DataGridViewTriState.False;
                }
                foreach (DataGridViewRow row in dtGridContainListRooms.Rows)
                {
                    row.Resizable = DataGridViewTriState.False;
                }
                dtGridContainListRooms.Rows.Clear();
                dtGridContainListRooms.Columns.Clear();

                //xóa đi dòng cuối cùng trong dataGridView
                dtGridContainListRooms.AllowUserToAddRows = false;

                dtGridContainListRooms.Columns.Add("id", "Mã phòng");
                dtGridContainListRooms.Columns.Add("roomName", "Tên phòng");
                dtGridContainListRooms.Columns.Add("ownerRoom", "Chủ phòng");
                dtGridContainListRooms.Columns.Add("Count", "Số lượng");
                dtGridContainListRooms.Columns.Add("betPoint", "Điểm cược");
                dtGridContainListRooms.Columns.Add("status", "Trạng thái");
                dtGridContainListRooms.Columns.Add("ip", "");

                dtGridContainListRooms.Columns["ip"].Visible = false;

                DataGridViewButtonColumn buttonColumn = new DataGridViewButtonColumn();
                buttonColumn.Name = "";
                buttonColumn.Text = "Tham gia";
                buttonColumn.UseColumnTextForButtonValue = true;
                dtGridContainListRooms.Columns.Add(buttonColumn);
                dtGridContainListRooms.RowHeadersVisible = false;
                dtGridContainListRooms.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;

                JToken dataToken = await manageApi.callApiUsingMethodGet(apiGetListMatches);
                if (dataToken != null)
                {
                    List<matches> list = JsonConvert.DeserializeObject<List<matches>>(dataToken.ToString());

                    foreach (matches item in list)
                    {
                        if (!(string.Equals(item.status.ToLower(), "finished") || string.Equals(item.status.ToLower(), "fighting")))
                        {
                            string[] rowData = new string[] { item._id, item.roomName, item.ownerRoom, item.count.ToString() + "/2", item.betPoints.ToString(), item.status, item.ipRoom };
                            dtGridContainListRooms.Rows.Add(rowData);
                        }
                    }

                    //sau khi thêm dữ liệu vào thì tiến hành xóa đi cột ip
                    foreach (DataGridViewRow row in dtGridContainListRooms.Rows)
                    {
                        if (row.Cells["ip"].Value != null)
                        {
                            columnData.Add(row.Cells["ip"].Value);
                        }
                    }

                    // Ẩn cột có chỉ số columnIndex trong DataGridView
                    dtGridContainListRooms.Columns.RemoveAt(6);
                    dtGridContainListRooms.ReadOnly = true;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Loi displayListMatches: " + ex.Message);
            }
        }
        public static void displayListUsers(List<infoUser> userLists, userControlLists userControlLists, infoUser user)
        {
            try
            {
                DataGridView dtAllUsers = new DataGridView();

                dtAllUsers.Rows.Clear();
                dtAllUsers.Columns.Clear();
                //xóa đi dòng cuối cùng trong dataGridView
                dtAllUsers.AllowUserToAddRows = false;

                dtAllUsers.Columns.Add("id", "ID");
                dtAllUsers.Columns.Add("userName", "Tên người dùng");
                DataGridViewButtonColumn buttonColumn1 = new DataGridViewButtonColumn();
                buttonColumn1.Name = "";
                buttonColumn1.Text = "Xem thông tin";
                buttonColumn1.UseColumnTextForButtonValue = true;
                DataGridViewButtonColumn buttonColumn2 = new DataGridViewButtonColumn();
                buttonColumn2.Name = "";
                buttonColumn2.Text = "Kết bạn";
                buttonColumn2.UseColumnTextForButtonValue = true;
                dtAllUsers.Columns.Add(buttonColumn1);
                dtAllUsers.Columns.Add(buttonColumn2);
                dtAllUsers.RowTemplate.Height = 45;
                dtAllUsers.ReadOnly = true;
                foreach (infoUser item in userLists)
                {
                    string[] rowData = new string[] { item.id, item.userName };
                    dtAllUsers.Rows.Add(rowData);
                }
                //lặp qua từng dòng dữ liệu để kiểm tra xem có nên hiển thị nút kết bạn hay không
                for (int i = 0; i < userLists.Count; i++)
                {
                    //lấy ra từng dòng dữ liệu
                    DataGridViewCell cell = dtAllUsers.Rows[i].Cells[3];    //lấy ra cái nút kết bạn
                                                                            //lấy ra giá trị id của từng user
                    string id = dtAllUsers.Rows[i].Cells[0].Value.ToString();
                    bool check = false;
                    //so sánh với từng user trong list "friend" or "waiting" của user
                    for (int j = 0; j < user.lists.Count; j++)
                    {
                        if (user.lists[j].listID.Contains(id))
                        {
                            check = true;
                            break;
                        }
                    }
                    if (check)
                    {
                        cell.Style = new DataGridViewCellStyle { Padding = new Padding(500, 0, 0, 0) };
                        cell.ReadOnly = true;
                    }
                    else
                    {
                        cell.Style = new DataGridViewCellStyle { Padding = new Padding(0, 0, 0, 0) };
                        cell.ReadOnly = false;
                    }
                }
                userControlLists.copyDataIntoGridAllUsers(dtAllUsers);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Loi displayListUsers: " + ex.Message);
            }
        }
        public static void displayListFriends(List<infoUser> userLists, userControlLists userControlLists)
        {
            try
            {
                DataGridView dtListFriends = new DataGridView();
                //xóa đi dòng cuối cùng trong dataGridView
                dtListFriends.AllowUserToAddRows = false;
                dtListFriends.Columns.Add("id", "ID");
                dtListFriends.Columns.Add("userName", "Tên người dùng");
                dtListFriends.Columns.Add("statusActive", "Trạng thái");
                DataGridViewButtonColumn buttonColumn1 = new DataGridViewButtonColumn();
                buttonColumn1.Name = "";
                buttonColumn1.Text = "Xem thông tin";
                buttonColumn1.UseColumnTextForButtonValue = true;
                DataGridViewButtonColumn buttonColumn2 = new DataGridViewButtonColumn();
                buttonColumn2.Name = "";
                buttonColumn2.Text = "Nhắn tin";
                buttonColumn2.UseColumnTextForButtonValue = true;
                DataGridViewButtonColumn buttonColumn3 = new DataGridViewButtonColumn();
                buttonColumn3.Name = "";
                buttonColumn3.Text = "Hủy kết bạn";
                buttonColumn3.UseColumnTextForButtonValue = true;
                dtListFriends.Columns.Add(buttonColumn1);
                dtListFriends.Columns.Add(buttonColumn2);
                dtListFriends.Columns.Add(buttonColumn3);
                dtListFriends.RowHeadersVisible = false;
                if (userLists != null)
                {
                    foreach (infoUser item in userLists)
                    {
                        string[] rowData = new string[] { item.id, item.userName, item.statusActive };
                        dtListFriends.Rows.Add(rowData);
                    }
                }
                //kiểm tra xem có nên hiện nút chat hay không
                for (int i = 0; i < userLists.Count; i++)
                {
                    DataGridViewCell cell = dtListFriends.Rows[i].Cells[4];
                    if (userLists[i].statusActive.ToLower() == "offline")
                    {
                        cell.Style = new DataGridViewCellStyle { Padding = new Padding(500, 0, 0, 0) };
                        cell.ReadOnly = true;
                    }
                    else if (userLists[i].statusActive.ToLower() == "online")
                    {
                        cell.Style = new DataGridViewCellStyle { Padding = new Padding(0, 0, 0, 0) };
                        cell.ReadOnly = false;
                    }
                }
                userControlLists.copyDataIntoGridListFriends(dtListFriends);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Loi displayListFriends: " + ex.Message);
            }
        }
        public static void displayListWaitingAccept(List<infoUser> userLists, userControlLists userControlLists)
        {
            try
            {
                DataGridView dtAcceptFriend = new DataGridView();
                //xóa đi dòng cuối cùng trong dataGridView
                dtAcceptFriend.AllowUserToAddRows = false;
                dtAcceptFriend.Columns.Add("id", "ID");
                dtAcceptFriend.Columns.Add("userName", "Tên người dùng");
                DataGridViewButtonColumn buttonColumn1 = new DataGridViewButtonColumn();
                buttonColumn1.Name = "";
                buttonColumn1.Text = "Chấp nhận";
                buttonColumn1.UseColumnTextForButtonValue = true;
                dtAcceptFriend.Columns.Add(buttonColumn1);
                dtAcceptFriend.RowHeadersVisible = false;
                dtAcceptFriend.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
                if (userLists != null)
                {
                    foreach (infoUser item in userLists)
                    {
                        string[] rowData = new string[] { item.id, item.userName };
                        dtAcceptFriend.Rows.Add(rowData);
                    }
                }

                userControlLists.copyDataIntoGridAcceptFriends(dtAcceptFriend);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Loi displayListWaitingAccept: " + ex.Message);
            }
        }
        public static void displayListRank(List<infoUser> userLists, infoUser user, userControlRanks rank)
        {
            try
            {
                DataGridView dtGridRank = new DataGridView();
                //chứa danh sách điểm user từ cao đến thấp
                //xóa đi dòng cuối cùng trong dataGridView
                dtGridRank.AllowUserToAddRows = false;
                List<infoUser> sortList = userLists.OrderByDescending(item => item.point).ToList();
                int currentRank = 0;

                dtGridRank.Columns.Add("userName", "Tên người dùng");
                dtGridRank.Columns.Add("point", "Điểm");
                dtGridRank.Columns.Add("currentRank", "Hạng");
                if (userLists != null)
                {

                    for (int index = 0; index < sortList.Count; index++)
                    {
                        if (sortList[index].userName == user.userName)
                            currentRank = index + 1;
                        string[] rowData = new string[] { sortList[index].userName, sortList[index].point.ToString(), (index + 1).ToString() };
                        dtGridRank.Rows.Add(rowData);
                    }
                }
                rank.currentRank.Text = currentRank.ToString();

                rank.copyDataIntoGridListRanks(dtGridRank);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Loi displayListRank: " + ex.Message);
            }
        }
        public static async Task displayListHistoryMatch(infoUser user, userControlHistory history, string apiGetUserId)
        {
            try
            {
                DataGridView dtGridViewHistory = new DataGridView();
                //xóa đi dòng cuối cùng trong dataGridView
                dtGridViewHistory.AllowUserToAddRows = false;
                dtGridViewHistory.Columns.Add("userName1", "Bạn");
                dtGridViewHistory.Columns.Add("userName2", "Người chơi");
                dtGridViewHistory.Columns.Add("result", "Kết quả");
                dtGridViewHistory.RowHeadersVisible = false;
                if (user != null)
                {
                    foreach (match item in user.matches)
                    {
                        if (string.Equals(item.status, "finished"))
                        {
                            string myUsername = user.userName;
                            string myResult = item.players[0].user == user.id ? item.players[0].resultMatch : item.players[1].resultMatch;
                            if (string.Equals(myResult, "win") || string.Equals(myResult, "lose"))
                            {
                                string difId = item.players[0].user == user.id ? item.players[1].user : item.players[0].user;
                                JToken tkData = await manageApi.callApiUsingGetMethodID(apiGetUserId + difId);
                                if (tkData != null)
                                {
                                    infoUser difUser = JsonConvert.DeserializeObject<infoUser>(tkData.ToString());
                                    string[] rowData = new string[] { myUsername, difUser.userName, myResult };
                                    dtGridViewHistory.Rows.Add(rowData);
                                }
                            }
                        }
                    }
                    history.copyDataIntoGridListHistories(dtGridViewHistory);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Loi displayListHistoryMatch: " + ex.Message);
            }
        }
        //==================================================================================================================================
    }
}