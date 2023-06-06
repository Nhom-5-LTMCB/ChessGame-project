using Chess_Game_Project.classes;
using Chess_Game_Project.ContainUserControls;
using Newtonsoft.Json.Linq;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Net.NetworkInformation;
using System.Net.Sockets;
using System.Net;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Web.UI.WebControls;
using System.Windows.Forms;
using System.Web.UI;
using Guna.UI2.WinForms;
using System.Runtime.Remoting.Contexts;
using Chess_Game_Project.classes_handle;
using System.Xml.Linq;
using Chess_Game_Project.manageUsers;

namespace Chess_Game_Project
{
    public partial class LobbyInterface : Form
    {
        #region apiPath
        private string apiGetListMatches = "https://chessmates.onrender.com/api/v1/matches";
        private string apiCreateRoom = "https://chessmates.onrender.com/api/v1/matches/add";
        private string apiGetUser = "https://chessmates.onrender.com/api/v1/users/edit/";
        private string apiGetAllUser = "https://chessmates.onrender.com/api/v1/users";
        private string apiGetUserId = "https://chessmates.onrender.com/api/v1/users/";
        private string apiMakeFriend = "https://chessmates.onrender.com/api/v1/listFriends/add";
        private string apiGetAllListFriend = "https://chessmates.onrender.com/api/v1/listFriends";
        private string apiUpdaStatusFriend = "https://chessmates.onrender.com/api/v1/listFriends/edit/";
        private string apiDeleteFriend = "https://chessmates.onrender.com/api/v1/listFriends/delete/";
        private string apiAddUserIntoMatch = "https://chessmates.onrender.com/api/v1/matches/edit/addOrSubUser/";
        #endregion

        #region infoUser
        private infoUser user;
        private string linkAvatar;
        private string ipAddress = "172.30.181.248";
        private string myIpAddress = "";
        private string difUsernameUser = "";
        #endregion

        #region variables
        public static LobbyInterface showInter = null;
        private string parentDirectory;
        private TcpClient client = null;

        private Thread rcvDataThread = null;
        private userControlChatOne chat = null;
        private enum setting
        {
            createRoom = 0,
            makeFriend = 1,
            acceptFriend = 2,
            joinRoom = 3,
            chatOne = 4,
            chatMulti = 5,
            logout = 6,
            unFriend = 7
        }
        public static int posY = 0;

        userControlLists userControlLists = null;
        userControlHistory history = null;
        userControlRanks rank = null;
        userControlCreateRoom createRoom = null;
        #endregion

        //============================================  CÁC HÀM XỬ LÝ RIÊNG BIỆT =========================================================
        private async void LobbyInterface_Load(object sender, EventArgs e)
        {
            handleLoadInterface.loadInterFace(this, pnlCoverPage, pnlContent);
            ptbAvatarPage.Size = this.Size;
            pnlContent.Parent = ptbAvatarPage;
            ptbAvatarPage.BackgroundImage = System.Drawing.Image.FromFile("Resources\\loginAvt.jpg");
            ptbAvatarPage.BackgroundImageLayout = ImageLayout.Stretch;
            pnlContent.BringToFront();

            lbUserName.Text = user.userName;
            lbScore.Text = user.point.ToString();
            if (user.linkAvatar == "")
                user.linkAvatar = "defaultAvatar.jpg";
            ptboxAvatar.Image = System.Drawing.Image.FromFile($"{parentDirectory}\\" + user.linkAvatar);
            ptboxAvatar.SizeMode = PictureBoxSizeMode.Zoom;

            pnlContainsIcon.Parent = pnlMultiChats;
            pnlMultiChatFrame.Parent = pnlMultiChats;
            pnlContainsIcon.BringToFront();

            await hanleDataIntoDatagridview.displayListMatches(dtGridContainListRooms, apiGetListMatches);
        }
        private void calLocationChildPanel(System.Windows.Forms.Panel parent, System.Windows.Forms.UserControl child)
        {
            // Tính toán vị trí để đặt Panel con vào giữa Panel cha
            int childX = (parent.Width - child.Width) / 2;
            int childY = (parent.Height - child.Height) / 2;


            // Đặt Anchor để Panel con giữa trung tâm Panel cha khi Panel cha thay đổi kích thước
            child.Anchor = AnchorStyles.None;
            parent.Dock = DockStyle.Fill;
            child.BringToFront();
            // Đặt vị trí cho Panel con
            child.Location = new Point(childX, childY);
            parent.Controls.Add(child);
        }

        private async Task handleLogOutRoom()
        {
            try
            {
                apiGetUser += user.id;
                //cập nhật trạng thái thành offline
                var data = new
                {
                    userName = user.userName,
                    gmail = user.gmail,
                    linkAvatar = user.linkAvatar == "defaultAvatar.jpg" ? "defaultAvatar.jpg" : user.linkAvatar,
                    statusActive = "offline",
                };
                JToken tkData = await manageApi.callApiUsingMethodPut(data, apiGetUser);
                if (tkData != null)
                {
                    //gửi thông điệp logout lên server
                    string message = (int)setting.logout + "*" + user.userName + "," + user.id;
                    handleChat.sendData(client, message);

                    client = null;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Loi handleLogOutRoom: " + ex.Message);
            }

        }
        private void loopChildPanel(System.Windows.Forms.UserControl child)
        {
            foreach (System.Windows.Forms.UserControl childControl in pnlContainsChild.Controls.OfType<System.Windows.Forms.UserControl>())
            {
                if (childControl == child)
                {
                    pnlContainsChild.Show();
                    childControl.Show();
                }
                else
                {
                    childControl.Hide();
                }
            }
        }
        private static NetworkInterface GetWifiInterface()
        {
            NetworkInterface[] interfaces = NetworkInterface.GetAllNetworkInterfaces();

            foreach (NetworkInterface networkInterface in interfaces)
            {
                if (networkInterface.NetworkInterfaceType == NetworkInterfaceType.Wireless80211 &&
                    networkInterface.OperationalStatus == OperationalStatus.Up)
                {
                    return networkInterface;
                }
            }

            return null;
        }
        private static IPAddress GetWifiIPv4Address(NetworkInterface wifiInterface)
        {
            IPInterfaceProperties properties = wifiInterface.GetIPProperties();

            foreach (UnicastIPAddressInformation ip in properties.UnicastAddresses)
            {
                if (ip.Address.AddressFamily == System.Net.Sockets.AddressFamily.InterNetwork)
                {
                    return ip.Address;
                }
            }

            return null;
        }
        //=================================================================================================================================

        //============================================  HÀM KHỞI TẠO MẶC ĐỊNH =============================================================
        public LobbyInterface()
        {
            InitializeComponent();
            CheckForIllegalCrossThreadCalls = false;

            dtGridContainListRooms.RowTemplate.Height = 45;

            int childX = (pnlCoverPage.Width - pnlContainsChild.Width) / 2;
            int childY = (pnlCoverPage.Height - pnlContainsChild.Height) / 2;
            pnlContainsChild.Location = new Point(childX, childY);

            pnlCoverPage.Controls.Add(pnlContainsChild);
            pnlContainsChild.BringToFront();

            pnlContainsChild.AutoSize = false;
            pnlContainsChild.Hide();
            pnlContainsChild.Anchor = AnchorStyles.None;
            pnlContainsChild.Dock = DockStyle.Fill;

            int childX1 = (pnlContainsChild.Width - pnlChatOne.Width) / 2;
            int childY1 = (pnlContainsChild.Height - pnlChatOne.Height) / 2;
            pnlChatOne.Anchor = AnchorStyles.None;
            pnlContainsChild.Dock = DockStyle.Fill;
            pnlChatOne.Location = new Point(childX1, childY1);

            pnlContainsChild.Controls.Add(pnlChatOne);
            pnlChatOne.Hide();
            pnlChatOne.BringToFront();


            userControlLists = new userControlLists();
            userControlLists.btnCloseList_click += UserControlLists_btnCloseList_click;
            userControlLists.dtAcceptFriend_cellContentClick += UserControlLists_dtAcceptFriend_cellContentClick1; ;
            userControlLists.dtAllUsers_cellContentClick += UserControlLists_dtAllUsers_cellContentClick1; ;
            userControlLists.dtListFriends_cellContentClick += UserControlLists_dtListFriends_cellContentClick1; ;
            userControlLists.btnFindUser_click += UserControlLists_btnFindUser_click; ;
            history = new userControlHistory();
            history.btnCloseHistory_click += History_btnCloseHistory_click;
            rank = new userControlRanks();
            rank.btnCloseRank_click += Rank_btnCloseRank_click;
            createRoom = new userControlCreateRoom();
            createRoom.btnCloseCreateRoom_click += CreateRoom_btnCloseCreateRoom_click;
            createRoom.btnAcceptCreateRoom_click += CreateRoom_btnAcceptCreateRoom_click;
            calLocationChildPanel(pnlContainsChild, userControlLists);
            calLocationChildPanel(pnlContainsChild, rank);
            calLocationChildPanel(pnlContainsChild, history);
            calLocationChildPanel(pnlContainsChild, createRoom);

            pnlContainsIcon.Hide();


            pnlMultiChatFrame.AutoScroll = true;
        }
        public LobbyInterface(infoUser user) : this()
        {
            ////lấy ra ipv4 bên trong máy
            NetworkInterface wifiInterface = GetWifiInterface();
            if (wifiInterface != null)
            {
                IPAddress ipv4 = GetWifiIPv4Address(wifiInterface);

                if (ipv4 != null)
                    this.myIpAddress = ipv4.ToString();
            }
            client = new TcpClient();
            client.Connect(IPAddress.Parse(ipAddress), 8081);
            rcvDataThread = new Thread(new ThreadStart(rcvData));
            rcvDataThread.Start();

            parentDirectory = Directory.GetParent(Application.StartupPath)?.Parent?.FullName + "\\Images";
            this.user = user;
            lbUserName.Text = user.userName;
            lbScore.Text = user.point.ToString();
            ptboxAvatar.Image = System.Drawing.Image.FromFile($"{parentDirectory}\\" + user.linkAvatar);
            ptboxAvatar.SizeMode = PictureBoxSizeMode.Zoom;
            showInter = this;

            //gửi thông điệp login lên server
            string message = user.userName;
            handleChat.sendData(client, message);

        }
        //=================================================================================================================================


        //============================================ CÁC HÀM DÙNG ĐỂ GỬI VÀ NHẬN DỮ LIỆU =================================================
        public async void rcvData()
        {
            try
            {
                while (true)
                {
                    NetworkStream stream = client.GetStream();

                    byte[] data = new byte[1024 * 500];
                    int length = stream.Read(data, 0, data.Length);
                    if (length == 0) return;
                    string message = Encoding.UTF8.GetString(data, 0, length);
                    string[] listMsg = message.Split('*');
                    switch (int.Parse(listMsg[0]))
                    {
                        case 0:
                            //tiến hành cập nhật lại danh sách phòng chơi
                            await hanleDataIntoDatagridview.displayListMatches(dtGridContainListRooms, apiGetListMatches);
                            break;
                        case 1:
                            JToken tkData = await manageApi.callApiUsingGetMethodID(apiGetUserId + user.id);
                            if (tkData != null)
                            {
                                this.user = JsonConvert.DeserializeObject<infoUser>(tkData.ToString());

                                string[] lstUsers = listMsg[1].Split(':');
                                userControlLists.hideBtnMakeFriend(lstUsers[1]);
                                List<infoUser> lists = await handleGetLists.getListUser("waiting", user, apiGetUserId);
                                hanleDataIntoDatagridview.displayListWaitingAccept(lists, userControlLists);
                            }
                            break;
                        case 2:
                            JToken tkData1 = await manageApi.callApiUsingGetMethodID(apiGetUserId + user.id);
                            if (tkData1 != null)
                            {
                                this.user = JsonConvert.DeserializeObject<infoUser>(tkData1.ToString());

                                //cập nhật lại danh sách tất cả user
                                await handleGetLists.getListAllUser(user.id, apiGetAllUser, userControlLists, user);

                                List<infoUser> lists1 = await handleGetLists.getListUser("friend", user, apiGetUserId);
                                hanleDataIntoDatagridview.displayListFriends(lists1, userControlLists);

                                Action myAction = () =>
                                {
                                    createChatOneFrame.createChatBetweenClientAndClient(apiGetUserId, user, chat);
                                };

                                // Sử dụng phương thức Invoke để thực thi đoạn mã trên luồng giao diện người dùng
                                if (this.InvokeRequired)
                                    this.Invoke(myAction);
                                else
                                    myAction();
                            }
                            break;
                        case 3:
                            player.players = 2;
                            break;
                        case 4:
                            //tiến hành lấy ra nội dung dạng "content, linkAvatar, difUsername"
                            string[] lstMsg = listMsg[1].Split(':');
                            string difUsername = lstMsg[0].Substring(0, lstMsg[0].Length - 3);

                            foreach (userControlChatOne userControlChatOne in createChatOneFrame.listChats)
                            {
                                if (userControlChatOne.Tag.ToString().Contains(user.userName) && userControlChatOne.Tag.ToString().Contains(difUsername))
                                {
                                    chat = userControlChatOne;
                                    if (listMsg[1].Contains("(1)"))
                                    {
                                        handleChat.writeDataChatOne(null, lstMsg[2], lstMsg[1], 1, difUsername, chat.pnlChatOne, this, chat.pos, user.userName, parentDirectory, chat);
                                    }
                                    else
                                    {
                                        string imageData = lstMsg[1];
                                        byte[] convertedBytes = Convert.FromBase64String(imageData);
                                        // Chuyển đổi mảng byte thành hình ảnh
                                        using (MemoryStream stream1 = new MemoryStream(convertedBytes))
                                        {
                                            System.Drawing.Image image = System.Drawing.Image.FromStream(stream1);
                                            handleChat.writeDataChatOne(image, lstMsg[2], "", 2, difUsername, chat.pnlChatOne, this, chat.pos, user.userName, parentDirectory, chat);
                                        }
                                    }
                                    break;
                                }
                            }
                            break;
                        case 5:
                            string[] msg = listMsg[1].Split(':');
                            string[] lsts = msg[1].Split(',');
                            if (listMsg[1].Contains("(1)"))
                                handleChat.writeData(null, lsts[1], lsts[0], 1, msg[0].Substring(0, msg[0].Length - 3), pnlMultiChatFrame, this, posY, user.userName, parentDirectory, pnlContainsIcon);
                            else
                            {
                                string imageData = lsts[0];
                                byte[] convertedBytes = Convert.FromBase64String(imageData);
                                // Chuyển đổi mảng byte thành hình ảnh
                                using (MemoryStream stream1 = new MemoryStream(convertedBytes))
                                {
                                    System.Drawing.Image image = System.Drawing.Image.FromStream(stream1);
                                    handleChat.writeData(image, lsts[1], "", 2, msg[0].Substring(0, msg[0].Length - 3), pnlMultiChatFrame, this, posY, user.userName, parentDirectory, pnlContainsIcon);
                                }
                            }
                            break;
                        case 6: //xử lý log out
                                //lấy id nhận về 
                            string id = listMsg[1].Split(',')[1];
                            string username = listMsg[1].Split(',')[0];
                            //kiểm tra xem trong danh sách bạn bè xem có user này không
                            bool check = false;
                            foreach (listFriends item in user.lists)
                            {
                                if (item.status == "friend")
                                {
                                    if (item.listID.Contains(id))
                                    {
                                        check = true;
                                        break;
                                    }
                                }
                            }
                            if (check)
                            {
                                List<infoUser> lst = await handleGetLists.getListUser("friend", user, apiGetUserId);
                                if (lst != null)
                                {
                                    hanleDataIntoDatagridview.displayListFriends(lst, userControlLists);

                                    //tiến hành xóa đi phòng chat của user này 
                                    await handleGetLists.getListFriends(apiGetUserId, user);
                                }

                                foreach (userControlChatOne control in createChatOneFrame.listChats)
                                {
                                    if (control.Tag.ToString().Contains(user.userName) && control.Tag.ToString().Contains(username))
                                    {
                                        createChatOneFrame.listChats.Remove(control);
                                        break;
                                    }
                                }
                            }
                            break;
                        case 7:
                            JToken tkData2 = await manageApi.callApiUsingGetMethodID(apiGetUserId + user.id);
                            if (tkData2 != null)
                            {
                                this.user = JsonConvert.DeserializeObject<infoUser>(tkData2.ToString());

                                string[] lstUsers1 = listMsg[1].Split(':');
                                userControlLists.showBtnMakeFriend(lstUsers1[1]);
                                List<infoUser> lists2 = await handleGetLists.getListUser("friend", user, apiGetUserId);
                                hanleDataIntoDatagridview.displayListFriends(lists2, userControlLists);
                            }

                            break;
                    }
                }
            }
            catch (Exception ex)
            {
                await handleLogOutRoom();
                Login.showFormAgain.Show();
            }
        }
        private void btnSendIcon_Click(object sender, EventArgs e)
        {
            handleChat.displayListIconsIntoInterface(pnlContainsIcon, 7);
            foreach (System.Windows.Forms.Button btnChat in handleChat.buttonListIcons)
                btnChat.Click += BtnChat_Click;
        }

        private void BtnChat_Click(object sender, EventArgs e)
        {
            System.Windows.Forms.Button btn = (System.Windows.Forms.Button)sender;
            string path = btn.Text;


            //tiến hành gửi dữ liệu đi
            byte[] imageBytes = File.ReadAllBytes(path);
            string message = (int)setting.chatMulti + "*" + user.userName + "(2):" + Convert.ToBase64String(imageBytes) + "," + user.linkAvatar; ;
            handleChat.sendData(client, message);

            handleChat.writeData(System.Drawing.Image.FromFile(path), user.linkAvatar, "", 2, user.userName, pnlMultiChatFrame, this, posY, user.userName, parentDirectory, pnlContainsIcon);
        }
        private void Chat_btnSendMsgChatOne_click(object sender, EventArgs e)
        {
            if (chat != null)
            {
                if (chat.TextBox.Text != "")
                {
                    if (chat.TextBox.Text.Length < 100)
                    {
                        //tiến hành gửi dữ liệu đi
                        string message = (int)setting.chatOne + "*" + user.userName + "(1):" + chat.TextBox.Text.Trim() + ":" + user.linkAvatar + ":" + difUsernameUser;
                        handleChat.sendData(client, message);
                        handleChat.writeDataChatOne(null, user.linkAvatar, chat.TextBox.Text.Trim(), 1, user.userName, chat.pnlChatOne, this, chat.pos, user.userName, parentDirectory, chat);
                    }
                    else
                    {
                        MessageBox.Show("Bạn chỉ được phép nhập tối đa 100 ký tự");
                    }
                    chat.TextBox.Clear();
                }
            }
        }
        private void BtnChatOne_Click(object sender, EventArgs e)
        {
            System.Windows.Forms.Button btn = (System.Windows.Forms.Button)sender;
            string path = btn.Text;


            //tiến hành gửi dữ liệu đi
            byte[] imageBytes = File.ReadAllBytes(path);
            string message = (int)setting.chatOne + "*" + user.userName + "(2):" + Convert.ToBase64String(imageBytes) + ":" + user.linkAvatar + ":" + difUsernameUser;
            handleChat.sendData(client, message);

            handleChat.writeDataChatOne(System.Drawing.Image.FromFile(path), user.linkAvatar, "", 2, user.userName, chat.pnlChatOne, this, chat.pos, user.userName, parentDirectory, chat);
            chat.containsIcon.Hide();
            chat.listIcons.Clear();
        }
        private void Chat_btnSendIconChatOne_click(object sender, EventArgs e)
        {
            if (chat != null)
            {
                handleChat.displayListIconsIntoInterface(chat.containsIcon, 5);
                foreach (System.Windows.Forms.Button btnChat in handleChat.buttonListIcons)
                    btnChat.Click += BtnChatOne_Click;
            }
        }
        private void btnSendMessage_Click(object sender, EventArgs e)
        {
            if (txtSendMessage.Text != "")
            {
                if (txtSendMessage.Text.Length < 100)
                {
                    //tiến hành gửi dữ liệu đi
                    string message = (int)setting.chatMulti + "*" + user.userName + "(1):" + txtSendMessage.Text.Trim() + "," + user.linkAvatar;
                    handleChat.sendData(client, message);
                    handleChat.writeData(null, user.linkAvatar, txtSendMessage.Text.Trim(), 1, user.userName, pnlMultiChatFrame, this, posY, user.userName, parentDirectory, pnlContainsIcon);
                    if (pnlContainsIcon.Visible)
                    {
                        pnlContainsIcon.Hide();
                    }
                }
                else
                {
                    MessageBox.Show("Bạn chỉ được phép nhập tối đa 100 ký tự");
                }
                txtSendMessage.Clear();
            }
        }
        //==================================================================================================================================


        //========================================= HÀM DÙNG ĐỂ THAO TÁC VỚI SỰ KIỆN BẤM VÀO DATAGRIDVIEW ==================================
        private async void dtGridContainListRooms_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                if (e.RowIndex >= 0 && e.ColumnIndex >= 0)
                {
                    DataGridView dataGridView = (DataGridView)sender;

                    if (e.ColumnIndex == 6)
                    {
                        if (dataGridView.Rows[e.RowIndex].Cells["Count"].Value.ToString() == "2/2")
                        {
                            MessageBox.Show("Phòng đã đầy, vui lòng chọn phòng khác");
                            return;
                        }
                        else
                        {
                            if (user.point < int.Parse(dataGridView.Rows[e.RowIndex].Cells["betPoint"].Value.ToString()))
                            {
                                MessageBox.Show("Điểm của bạn không đủ để tham gia phòng chơi này");
                                return;
                            }
                            else
                            {
                                MessageBox.Show("Tham gia thành công");
                                //tạo và tham gia vào phòng
                                string idMatch = dataGridView.Rows[e.RowIndex].Cells["id"].Value.ToString();
                                //tiến hành lấy ra mã phòng khi click vào
                                JToken tkData = await manageApi.callApiUsingMethodPut(new { option = "adduser", id = user.id }, apiAddUserIntoMatch + idMatch);
                                if (tkData != null)
                                {
                                    matches match = JsonConvert.DeserializeObject<matches>(tkData.ToString());

                                    //lặp qua để kiếm ra id của chủ phòng
                                    string id = "";
                                    foreach (matchPlayer match1 in match.players)
                                    {
                                        if (match1.user != user.id)
                                        {
                                            id = match1.user;
                                            break;
                                        }
                                    }
                                    JToken userPlayer = await manageApi.callApiUsingGetMethodID(apiGetUserId + id);

                                    if (userPlayer != null)
                                    {
                                        infoUser difUser = JsonConvert.DeserializeObject<infoUser>(userPlayer.ToString());
                                        //gửi sự kiện tới server và cập nhật lại biến user.players lên 2 đơn vị
                                        string message = (int)setting.joinRoom + "*" + difUser.userName;
                                        handleChat.sendData(client, message);
                                        MatchInterface player = new MatchInterface(myIpAddress, hanleDataIntoDatagridview.columnData[e.RowIndex].ToString(), idMatch, hanleDataIntoDatagridview.columnData[e.RowIndex].ToString(), false, false, 1, match.betPoints, difUser, user);  //chủ phòng sẽ là cờ trắng
                                        player.Show();
                                        this.Hide();
                                    }
                                }
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Loi dtGridContainListRooms_CellContentClick: " + ex.Message);
            }
        }
        private async void UserControlLists_dtListFriends_cellContentClick1(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                if (e.RowIndex >= 0 && e.ColumnIndex >= 0)
                {
                    DataGridView dataGridView = (DataGridView)sender;
                    if (e.ColumnIndex == 3) //xem thông tin người chơi
                    {
                        string apiPath = apiGetUserId + dataGridView.Rows[e.RowIndex].Cells["id"].Value.ToString();
                        JToken tkData = await manageApi.callApiUsingGetMethodID(apiPath);
                        if (tkData != null)
                        {
                            infoUser user = JsonConvert.DeserializeObject<infoUser>(tkData.ToString());

                            InfoUserInterface infoUser = new InfoUserInterface(user, false);
                            infoUser.Show();

                            this.Hide();
                        }
                    }
                    else if (e.ColumnIndex == 4)
                    {
                        pnlChatOne.Controls.Clear();
                        foreach (userControlChatOne userControl in createChatOneFrame.listChats)
                        {
                            if (userControl.Tag.ToString().Contains(user.userName) && userControl.Tag.ToString().Contains(dataGridView.Rows[e.RowIndex].Cells["userName"].Value.ToString()))
                            {
                                pnlChatOne.Show();
                                foreach (System.Windows.Forms.UserControl userControl1 in createChatOneFrame.listChats)
                                    userControl1.Hide();
                                chat = userControl;
                                if (!userControl.eventActive)
                                {
                                    chat.btnSendMsgChatOne_click += Chat_btnSendMsgChatOne_click;
                                    chat.btnSendIconChatOne_click += Chat_btnSendIconChatOne_click;
                                    chat.btnCloseForm_click += Chat_btnCloseForm_click;
                                    userControl.eventActive = true;
                                }
                                difUsernameUser = dataGridView.Rows[e.RowIndex].Cells["userName"].Value.ToString();
                                pnlChatOne.Controls.Add(chat);
                                chat.Show();
                                break;
                            }
                        }
                    }
                    else if (e.ColumnIndex == 5)
                    {
                        //gọi tới api danh sách đợi
                        JToken tkData = await manageApi.callApiUsingMethodGet(apiGetAllListFriend);
                        if (tkData != null)
                        {
                            List<listFriends> listFriends = JsonConvert.DeserializeObject<List<listFriends>>(tkData.ToString());
                            string id1 = user.id;
                            string id2 = dataGridView.Rows[e.RowIndex].Cells[0].Value.ToString();
                            string difUsername = dataGridView.Rows[e.RowIndex].Cells["userName"].Value.ToString();
                            string newId = "";
                            foreach (listFriends item in listFriends)
                            {
                                if (item.listID.Contains(id1) && item.listID.Contains(id2))
                                {
                                    newId = item._id;
                                    break;
                                }
                            }
                            if (newId != "")
                            {
                                //gọi tới API 
                                HttpClient httpClient = new HttpClient();
                                string apiPath = apiDeleteFriend + newId;
                                //tiến hành lấy ra _id thỏa mãn
                                await httpClient.DeleteAsync(apiPath);

                                //cập nhật lại danh sách
                                //làm mới lại danh sách khi có phần tử mới được thêm vào
                                string apiPath1 = apiGetUserId + user.id;
                                JToken tkData2 = await manageApi.callApiUsingGetMethodID(apiPath1);
                                if (tkData2 != null)
                                {
                                    this.user = JsonConvert.DeserializeObject<infoUser>(tkData2.ToString());

                                    //gửi sự kiện lên server để reload lại form
                                    string message = (int)setting.unFriend + "*" + dataGridView.Rows[e.RowIndex].Cells[1].Value.ToString() + ":" + user.userName;
                                    //xóa dòng đó khỏi dữ liệu
                                    dataGridView.Rows.RemoveAt(e.RowIndex);
                                    handleChat.sendData(client, message);

                                    //cập nhật lại danh sách tất cả người dùng
                                    await handleGetLists.getListAllUser(user.id, apiGetAllUser, userControlLists, user);

                                    //xóa bạn bè thì cũng coi như mất luồng chat 
                                    foreach (userControlChatOne control in createChatOneFrame.listChats)
                                    {
                                        if (control.Tag.ToString().Contains(user.userName) && control.Tag.ToString().Contains(difUsername))
                                        {
                                            createChatOneFrame.listChats.Remove(control);
                                            break;
                                        }
                                    }
                                }
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Loi UserControlLists_dtListFriends_cellContentClick1: " + ex.Message);
            }
        }
        private async void UserControlLists_dtAllUsers_cellContentClick1(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                if (e.RowIndex >= 0 && e.ColumnIndex >= 0)
                {
                    DataGridView dataGridView = (DataGridView)sender;
                    if (e.ColumnIndex == 2) //xem thông tin người chơi
                    {
                        string apiPath = apiGetUserId + dataGridView.Rows[e.RowIndex].Cells["id"].Value.ToString();
                        JToken tkData = await manageApi.callApiUsingGetMethodID(apiPath);
                        if (tkData != null)
                        {
                            infoUser user = JsonConvert.DeserializeObject<infoUser>(tkData.ToString());

                            InfoUserInterface infoUser = new InfoUserInterface(user, false);
                            infoUser.Show();

                            this.Hide();
                        }
                    }
                    else if (e.ColumnIndex == 3) // kết bạn
                    {
                        var data = new
                        {
                            id_user1 = user.id,
                            id_user2 = dataGridView.Rows[e.RowIndex].Cells["id"].Value.ToString()
                        };
                        JToken tkData = await manageApi.callApiUsingMethodPost(data, apiMakeFriend);
                        if (tkData != null)
                        {
                            DataGridViewCell cell = dataGridView.Rows[e.RowIndex].Cells[e.ColumnIndex];
                            cell.Style = new DataGridViewCellStyle { Padding = new Padding(500, 0, 0, 0) };
                            cell.ReadOnly = true;
                            dataGridView.Update();
                            //gửi sự kiện lên server để reload lại form
                            string message = (int)setting.makeFriend + "*" + dataGridView.Rows[e.RowIndex].Cells["userName"].Value.ToString() + ":" + user.userName;
                            handleChat.sendData(client, message);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Loi UserControlLists_dtAllUsers_cellContentClick1: " + ex.Message);
            }
        }
        private async void UserControlLists_dtAcceptFriend_cellContentClick1(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                if (e.RowIndex >= 0 && e.ColumnIndex >= 0)
                {
                    DataGridView dataGridView = (DataGridView)sender;
                    if (e.ColumnIndex == 2) // chấp nhận lời mời
                    {
                        //gọi tới api danh sách đợi
                        JToken tkData = await manageApi.callApiUsingMethodGet(apiGetAllListFriend);
                        if (tkData != null)
                        {
                            List<listFriends> listFriends = JsonConvert.DeserializeObject<List<listFriends>>(tkData.ToString());
                            string id1 = user.id;
                            string id2 = dataGridView.Rows[e.RowIndex].Cells[0].Value.ToString();
                            string newId = "";
                            foreach (listFriends item in listFriends)
                            {
                                if (item.listID.Contains(id1) && item.listID.Contains(id2))
                                {
                                    newId = item._id;
                                    break;
                                }
                            }

                            if (newId != "")
                            {
                                //chấp nhận kết bạn
                                string apiPath = apiUpdaStatusFriend + newId;
                                var data = new { };
                                JToken tkData1 = await manageApi.callApiUsingMethodPut(data, apiPath);

                                if (tkData1 != null)
                                {

                                    //gửi sự kiện lên server để reload lại form
                                    string message = (int)setting.acceptFriend + "*" + dataGridView.Rows[e.RowIndex].Cells[1].Value.ToString();

                                    //xóa dòng đó khỏi dữ liệu
                                    dataGridView.Rows.RemoveAt(e.RowIndex);

                                    //cập nhật lại danh sách
                                    //làm mới lại danh sách khi có phần tử mới được thêm vào
                                    string apiPath1 = apiGetUserId + user.id;
                                    JToken tkData2 = await manageApi.callApiUsingGetMethodID(apiPath1);
                                    if (tkData2 != null)
                                    {
                                        this.user = JsonConvert.DeserializeObject<infoUser>(tkData2.ToString());
                                        handleChat.sendData(client, message);
                                        //cập nhật lại danh sách bạn bè
                                        List<infoUser> getFriends = await handleGetLists.getListUser("friend", user, apiGetUserId);
                                        hanleDataIntoDatagridview.displayListFriends(getFriends, userControlLists);

                                        createChatOneFrame.createChatBetweenClientAndClient(apiGetUserId, user, chat);
                                    }
                                }
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("loi UserControlLists_dtAcceptFriend_cellContentClick1: " + ex.Message);
            }
        }

        //==================================================================================================================================

        //========================================= cÁC HÀM ĐỂ THỰC HIỆN CHỨC NĂNG TƯƠNG TÁC VỚI CÁC NÚT ===================================
        private void btnContainInfoUser_Click(object sender, EventArgs e)
        {
            //ẩn giao diện chính đi
            this.Hide();
            InfoUserInterface info = new InfoUserInterface(user, true);
            info.Show();
        }
        private async void btnLogout_Click(object sender, EventArgs e)
        {
            await handleLogOutRoom();
            Login.showFormAgain.Show();

            //xóa danh sách chat
            createChatOneFrame.listChats.Clear();
            rcvDataThread.Abort();
            //tiến hành đóng form lại
            this.Close();
        }
        private async void btnRank_Click(object sender, EventArgs e)
        {
            JToken tkData = await manageApi.callApiUsingMethodGet(apiGetAllUser);
            List<infoUser> users = JsonConvert.DeserializeObject<List<infoUser>>(tkData.ToString());
            hanleDataIntoDatagridview.displayListRank(users, user, rank);

            loopChildPanel(rank);
        }
        private async void btnListFriend_Click(object sender, EventArgs e)
        {
            try
            {
                await handleGetLists.getListAllUser(user.id, apiGetAllUser, userControlLists, user);

                List<infoUser> getFriends = await handleGetLists.getListUser("friend", user, apiGetUserId);

                hanleDataIntoDatagridview.displayListFriends(getFriends, userControlLists);
                getFriends.Clear();
                getFriends = await handleGetLists.getListUser("waiting", user, apiGetUserId);
                hanleDataIntoDatagridview.displayListWaitingAccept(getFriends, userControlLists);


                loopChildPanel(userControlLists);

                createChatOneFrame.createChatBetweenClientAndClient(apiGetUserId, user, chat);
            }
            catch (Exception ex)
            {
                MessageBox.Show("loi btnListFriend_Click: " + ex.Message);
            }
        }
        private async void btnHistory_Click(object sender, EventArgs e)
        {
            JToken tkData = await manageApi.callApiUsingGetMethodID(apiGetUserId + user.id);
            if (tkData != null)
            {
                infoUser myUser = JsonConvert.DeserializeObject<infoUser>(tkData.ToString());
                await hanleDataIntoDatagridview.displayListHistoryMatch(myUser, history, apiGetUserId);
                loopChildPanel(history);
            }
        }
        private async void btnRandomRoom_Click(object sender, EventArgs e)
        {
            try
            {
                string apiPath = apiGetListMatches;
                JToken tkdata = await manageApi.callApiUsingMethodGet(apiPath);
                if (tkdata != null)
                {
                    List<matches> listsOfMatches = JsonConvert.DeserializeObject<List<matches>>(tkdata.ToString());
                    List<string> idList = new List<string>();
                    foreach (string id in idList)
                    {
                        foreach (matches matchItem in listsOfMatches)
                        {
                            if (matchItem.status == "waiting")
                            {
                                idList.Add(matchItem._id);//matchid
                            }
                        }
                    }
                    Random random = new Random();
                    string RandomID = idList[random.Next(0, idList.Count)];

                    matches match = new matches();
                    match._id = RandomID;

                    this.Hide();
                    //MatchInterface admin = new MatchInterface(2000, 1000, match._id, match.ipRoom, false, false, 1, match.betPoints, user.linkAvatar, user.point, user.userName, user.id);
                    //admin.Show();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Không tìm thấy phòng", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private async void UserControlLists_btnFindUser_click(object sender, EventArgs e)
        {
            //nếu người dùng bấm tìm kiếm thì hiển thị lại giao diện dtAllUsers
            string apiUrl = apiGetAllUser + userControlLists.username.Trim() != "" ? apiGetAllUser + "?userName=" + userControlLists.username.Trim() : "";
            JToken tokenData = await manageApi.callApiUsingGetMethodID(apiUrl);
            if (tokenData != null)
            {
                List<infoUser> userLists = JsonConvert.DeserializeObject<List<infoUser>>(tokenData.ToString());
                //hiển thị danh sách user này lên datagridView
                hanleDataIntoDatagridview.displayListUsers(userLists, userControlLists, user);
            }
        }
        private void btnCreateRoom_Click(object sender, EventArgs e)
        {
            loopChildPanel(createRoom);
        }
        private void Chat_btnCloseForm_click(object sender, EventArgs e)
        {
            pnlChatOne.Hide();
            loopChildPanel(userControlLists);
        }
        private async void CreateRoom_btnAcceptCreateRoom_click(object sender, EventArgs e)
        {
            if (string.Equals(createRoom.name.Trim(), "") || string.Equals(createRoom.betpoint.Trim(), ""))
            {
                MessageBox.Show("Thông tin nhập vào không được bỏ trống");
            }
            else
            {
                try
                {
                    int betPoint = int.Parse(createRoom.betpoint.Trim());
                    if (betPoint == 0)
                    {
                        MessageBox.Show("Vui lòng nhập điểm cược lớn hơn 0");
                        return;
                    }
                    if (betPoint > user.point)
                    {
                        MessageBox.Show("Bạn không đủ điểm để đặt mức cược này, vui lòng nhập điểm cược khác");
                        return;
                    }
                    var data = new
                    {
                        id = user.id,
                        betPoints = betPoint,
                        roomName = createRoom.name.Trim(),
                        ownerRoom = user.userName,
                        ipRoom = myIpAddress
                    };
                    JToken tkData = await manageApi.callApiUsingMethodPost(data, apiCreateRoom);
                    if (tkData != null)
                    {
                        MessageBox.Show("Tạo phòng thành công");
                        await hanleDataIntoDatagridview.displayListMatches(dtGridContainListRooms, apiGetListMatches);
                        matches match = JsonConvert.DeserializeObject<matches>(tkData.ToString());
                        string message = (int)setting.createRoom + "*" + user.userName;
                        handleChat.sendData(client, message);

                        //tạo và tham gia vào phòng
                        this.Hide();
                        MatchInterface admin = new MatchInterface(myIpAddress, null, match._id, myIpAddress, true, true, 0, betPoint, null, user);  //chủ phòng sẽ là cờ trắng
                        admin.Show();

                        pnlContainsChild.Hide();
                    }
                    else
                    {
                        MessageBox.Show("Tạo phòng thất bại, vui lòng thực hiện lại");
                        return;
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Điểm cược không hợp lệ, vui lòng nhập lại");
                }
            }
        }
        private void CreateRoom_btnCloseCreateRoom_click(object sender, EventArgs e)
        {
            pnlContainsChild.Hide();
            createRoom.Hide();
        }
        private void Rank_btnCloseRank_click(object sender, EventArgs e)
        {
            pnlContainsChild.Hide();
            rank.Hide();
        }
        private void History_btnCloseHistory_click(object sender, EventArgs e)
        {
            pnlContainsChild.Hide();
            history.Hide();
        }
        private void UserControlLists_btnCloseList_click(object sender, EventArgs e)
        {
            pnlContainsChild.Hide();
            rank.Hide();
            if (pnlChatOne.Visible)
            {
                pnlChatOne.Hide();
            }
        }
        private async void LobbyInterface_FormClosed(object sender, FormClosedEventArgs e)
        {
            await handleLogOutRoom();
        }
        //==================================================================================================================================
    }
}
