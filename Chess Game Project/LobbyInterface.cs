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
using static System.Windows.Forms.VisualStyles.VisualStyleElement.StartPanel;
using System.Runtime.Remoting.Contexts;
using Chess_Game_Project.classes_handle;
using System.Xml.Linq;

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
        private string ipAddress = "172.20.49.96";
        private string myIpAddress = "";
        private string difUsernameUser = "";
        #endregion

        #region variables
        public static LobbyInterface showInter = null;
        private string parentDirectory;
        private int iconNumbers = 29;
        private TcpClient client = null;
        private List<System.Windows.Forms.Button> buttonListIcons = new List<System.Windows.Forms.Button>();
        private System.Windows.Forms.Button oldButton = new System.Windows.Forms.Button()
        {
            Height = 0,
            Width = 0
        };
        private button btn = new button();
        private Thread rcvDataThread = null;
        private userControlChatOne chat = null;
        private List<userControlChatOne> listChats = new List<userControlChatOne>();
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
        public int posY = 0;

        userControlLists userControlLists = null;
        userControlHistory history = null;
        userControlRanks rank = null;
        userControlCreateRoom createRoom = null;
        #endregion

        //chứa danh sách ip của datagridview list rooms
        List<object> columnData = null;
        //============================================  CÁC HÀM XỬ LÝ RIÊNG BIỆT =========================================================
        private async void LobbyInterface_Load(object sender, EventArgs e)
        {
            try
            {
                // Thiết lập kích thước form
                int screenWidth = Screen.PrimaryScreen.Bounds.Width;
                int screenHeight = Screen.PrimaryScreen.Bounds.Height;
                int formWidth = (int)(screenWidth * 0.8);
                int formHeight = (int)(screenHeight * 0.8);
                this.Size = new Size(formWidth, formHeight);

                // Đặt vị trí của form để nằm chính giữa màn hình
                int left = (screenWidth - formWidth) / 2;
                int top = (screenHeight - formHeight) / 2;
                this.Location = new Point(left, top);
                pnlCoverPage.Size = this.Size;
                ptbAvatarPage.Size = this.Size;
                // Đưa Panel vào chính giữa màn hình
                pnlContent.Location = new Point((pnlCoverPage.Width - pnlContent.Width) / 2,
                                            (pnlCoverPage.Height - pnlContent.Height) / 2);
                pnlContent.BackColor = Color.Transparent;
                pnlContent.Parent = ptbAvatarPage;
                this.TransparencyKey = Color.Empty;

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

                await displayListMatches();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Loi LobbyInterface_Load: " + ex.Message);
            }
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
                    sendData(message);

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

        private async Task<List<string>> getListFriends()
        {
            try
            {
                JToken tkData = await manageApi.callApiUsingGetMethodID(apiGetUserId + user.id);
                if (tkData != null)
                {
                    infoUser info = JsonConvert.DeserializeObject<infoUser>(tkData.ToString());
                    List<string> arraysUserName = new List<string>();
                    foreach (listFriends lists in info.lists)
                    {
                        if (lists.status == "friend")
                        {
                            List<string> listIds = lists.listID;
                            string id = listIds[0] == user.id ? listIds[1] : listIds[0];
                            JToken tkInfo = await manageApi.callApiUsingGetMethodID(apiGetUserId + id);
                            if (tkInfo != null)
                            {
                                infoUser difUser = JsonConvert.DeserializeObject<infoUser>(tkInfo.ToString());
                                if (difUser.statusActive == "online")
                                    arraysUserName.Add(difUser.userName);
                            }
                        }
                    }
                    return arraysUserName;
                }
                return null;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Loi getListFriends: " + ex.Message);
                return null;
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
            sendData(message);

        }
        //=================================================================================================================================


        //============================================  HÀM DÙNG ĐỂ LẤY RA DANH SÁCH NGƯỜI DÙNG ============================================

        public async Task getListAllUser()
        {
            try
            {
                string apiPath = apiGetAllUser;
                JToken tokenData = await manageApi.callApiUsingMethodGet(apiPath);
                if (tokenData != null)
                {
                    List<infoUser> userLists = JsonConvert.DeserializeObject<List<infoUser>>(tokenData.ToString());
                    foreach (infoUser item in userLists)
                    {
                        if (item.id == user.id)
                        {
                            userLists.Remove(item);
                            break;
                        }
                    }
                    //hiển thị danh sách tất cả user lên datagridView
                    displayListUsers(userLists);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Loi getListAllUser: " + ex.Message);
            }
        }
        public async Task<List<infoUser>> getListUser(string status)
        {
            try
            {
                List<infoUser> lists = new List<infoUser>();
                foreach (listFriends item in user.lists)
                {
                    //tiến hành lấy ra listID
                    List<string> listid = item.listID;
                    string apiPath = "";
                    if (status == "waiting")
                    {
                        if (listid[0] != user.id)
                            apiPath = apiGetUserId + listid[0];
                        else
                            continue;
                    }
                    else if (status == "friend")
                    {
                        string id = "";
                        foreach (string item1 in listid)
                            if (item1 != user.id) id = item1;
                        apiPath = apiGetUserId + id;
                    }
                    JToken tkData = await manageApi.callApiUsingGetMethodID(apiPath);
                    if (tkData != null)
                    {
                        infoUser friend = JsonConvert.DeserializeObject<infoUser>(tkData.ToString());
                        if (item.status.ToLower() == status)
                            lists.Add(friend);
                    }
                    else
                    {
                        return null;
                    }
                }
                return lists;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Loi getListUser: " + ex.Message);
                return null;
            }
        }
        //==================================================================================================================================

        //============================================ CÁC HÀM DÙNG ĐỂ GỬI VÀ NHẬN DỮ LIỆU =================================================
        public void sendData(string msg)
        {
            try
            {
                if (client != null)
                {
                    NetworkStream stream = client.GetStream();
                    byte[] data = Encoding.UTF8.GetBytes(msg);
                    stream.Write(data, 0, data.Length);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Loi sendData: " + ex.Message);
            }
        }
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
                            await displayListMatches();
                            break;
                        case 1:
                            JToken tkData = await manageApi.callApiUsingGetMethodID(apiGetUserId + user.id);
                            if (tkData != null)
                            {
                                this.user = JsonConvert.DeserializeObject<infoUser>(tkData.ToString());

                                string[] lstUsers = listMsg[1].Split(':');
                                userControlLists.hideBtnMakeFriend(lstUsers[1]);
                                List<infoUser> lists = await getListUser("waiting");
                                displayListWaitingAccept(lists);
                            }
                            break;
                        case 2:
                            JToken tkData1 = await manageApi.callApiUsingGetMethodID(apiGetUserId + user.id);
                            if (tkData1 != null)
                            {
                                this.user = JsonConvert.DeserializeObject<infoUser>(tkData1.ToString());

                                //cập nhật lại danh sách tất cả user
                                //await getListAllUser();

                                List<infoUser> lists1 = await getListUser("friend");
                                displayListFriends(lists1);

                                Action myAction = () =>
                                {
                                    createChatBetweenClientAndClient();
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

                            foreach (userControlChatOne userControlChatOne in listChats)
                            {
                                if (userControlChatOne.Tag.ToString().Contains(user.userName) && userControlChatOne.Tag.ToString().Contains(difUsername))
                                {
                                    chat = userControlChatOne;
                                    if (listMsg[1].Contains("(1)"))
                                    {
                                        writeDataChatOne(null, lstMsg[2], lstMsg[1], 1, difUsername, chat.pnlChatOne, chat.pos);
                                    }
                                    else
                                    {
                                        string imageData = lstMsg[1];
                                        byte[] convertedBytes = Convert.FromBase64String(imageData);
                                        // Chuyển đổi mảng byte thành hình ảnh
                                        using (MemoryStream stream1 = new MemoryStream(convertedBytes))
                                        {
                                            System.Drawing.Image image = System.Drawing.Image.FromStream(stream1);
                                            writeDataChatOne(image, lstMsg[2], "", 2, difUsername, chat.pnlChatOne, chat.pos);
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
                                writeData(null, lsts[1], lsts[0], 1, msg[0].Substring(0, msg[0].Length - 3), pnlMultiChatFrame);
                            else
                            {
                                string imageData = lsts[0];
                                byte[] convertedBytes = Convert.FromBase64String(imageData);
                                // Chuyển đổi mảng byte thành hình ảnh
                                using (MemoryStream stream1 = new MemoryStream(convertedBytes))
                                {
                                    System.Drawing.Image image = System.Drawing.Image.FromStream(stream1);
                                    writeData(image, lsts[1], "", 2, msg[0].Substring(0, msg[0].Length - 3), pnlMultiChatFrame);
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
                                List<infoUser> lst = await getListUser("friend");
                                if (lst != null)
                                {
                                    displayListFriends(lst);

                                    //tiến hành xóa đi phòng chat của user này 
                                    await getListFriends();
                                }

                                foreach (userControlChatOne control in listChats)
                                {
                                    if (control.Tag.ToString().Contains(user.userName) && control.Tag.ToString().Contains(username))
                                    {
                                        listChats.Remove(control);
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
                                List<infoUser> lists2 = await getListUser("friend");
                                displayListFriends(lists2);
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
        private void writeData(System.Drawing.Image imgContent, string linkAvt, string msg, int mode, string userName, Guna2Panel pnl)
        {
            try
            {
                if (mode == 1)
                {
                    if (msg.Trim() == "")
                        return;
                    MethodInvoker invoker = new MethodInvoker(delegate
                    {
                        pnl.AutoScroll = false;
                        userControlContentChatMessage userControl = new userControlContentChatMessage();
                        userControl.addUsernameAndImage($"{parentDirectory}\\{linkAvt}", userName, user.userName);
                        int userControlWidth = pnl.Width * 70 / 100;
                        userControl.Location = new Point(0, posY);
                        userControl.Size = new Size(userControlWidth, userControl.Height);
                        pnl.Controls.Add(userControl);
                        userControl.content = msg;
                        userControl.addMesageIntoFrame(userControlWidth);
                        posY += userControl.Height;
                        pnl.ScrollControlIntoView(userControl);
                        pnl.AutoScroll = true;
                        pnl.HorizontalScroll.Visible = false;
                    });
                    this.Invoke(invoker);
                }
                else
                {
                    MethodInvoker invoker = new MethodInvoker(delegate
                    {
                        pnl.AutoScroll = false;
                        userControlContentChatIcon userControl = new userControlContentChatIcon();
                        userControl.addUsernameAndImage($"{parentDirectory}\\{linkAvt}", userName, imgContent, user.userName);
                        userControl.Location = new Point(0, posY);
                        pnl.Controls.Add(userControl);
                        posY += userControl.Height;
                        pnl.ScrollControlIntoView(userControl);

                        pnlContainsIcon.Hide();
                        buttonListIcons.Clear();

                        pnl.AutoScroll = true;
                        pnl.HorizontalScroll.Visible = false;
                    });
                    this.Invoke(invoker);
                }
            }
            catch (Exception ex)
            {

            }
        }
        private void writeDataChatOne(System.Drawing.Image imgContent, string linkAvt, string msg, int mode, string userName, Guna2Panel pnl, int posY)
        {
            try
            {
                if (mode == 1)
                {
                    if (msg.Trim() == "")
                        return;
                    MethodInvoker invoker = new MethodInvoker(delegate
                    {
                        pnl.AutoScroll = false;
                        userControlContentChatMessage userControl = new userControlContentChatMessage();
                        userControl.addUsernameAndImage($"{parentDirectory}\\{linkAvt}", userName, user.userName);
                        int userControlWidth = pnl.Width * 70 / 100;
                        userControl.Location = new Point(0, posY);
                        userControl.Size = new Size(userControlWidth, userControl.Height);
                        pnl.Controls.Add(userControl);
                        userControl.content = msg;
                        userControl.addMesageIntoFrame(userControlWidth);
                        pnl.ScrollControlIntoView(userControl);
                        posY += userControl.Height;
                        chat.pos = posY;
                        pnl.VerticalScroll.Value = pnl.VerticalScroll.Maximum;
                        pnl.AutoScroll = true;
                        pnl.HorizontalScroll.Visible = false;
                    });
                    this.Invoke(invoker);
                }
                else
                {
                    MethodInvoker invoker = new MethodInvoker(delegate
                    {
                        pnl.AutoScroll = false;
                        userControlContentChatIcon userControl = new userControlContentChatIcon();
                        userControl.addUsernameAndImage($"{parentDirectory}\\{linkAvt}", userName, imgContent, user.userName);
                        userControl.Location = new Point(0, posY);
                        pnl.Controls.Add(userControl);
                        posY += userControl.Height;
                        pnl.ScrollControlIntoView(userControl);
                        chat.pos = posY;
                        pnlContainsIcon.Hide();
                        buttonListIcons.Clear();

                        pnl.AutoScroll = true;
                        pnl.HorizontalScroll.Visible = false;
                    });
                    this.Invoke(invoker);
                }
            }
            catch (Exception ex)
            {

            }
        }
        private void btnSendIcon_Click(object sender, EventArgs e)
        {
            if (pnlContainsIcon.Visible)
            {
                pnlContainsIcon.Hide();
                buttonListIcons.Clear();
            }
            else
            {
                //xóa hết các phần tử bên trong panel
                pnlContainsIcon.Controls.Clear();
                pnlContainsIcon.Padding = new Padding(0);
                buttonListIcons = new List<System.Windows.Forms.Button>();
                for (int i = 0; i < iconNumbers; i++)
                {
                    System.Windows.Forms.Button btn2 = null;
                    if (buttonListIcons.Count % 7 == 0)
                    {
                        if (buttonListIcons.Count != 0)
                            oldButton.Location = new Point(0, 30 + oldButton.Location.Y + 10);
                        btn2 = btn.createButton(oldButton, pnlContainsIcon, System.Drawing.Image.FromFile($"Resources\\{i + 1}.png"), Convert.ToString($"Resources\\{i + 1}.png"), true);
                        btn2.Click += Btn2_Click; ;
                    }
                    else
                    {
                        btn2 = btn.createButton(buttonListIcons[buttonListIcons.Count - 1], pnlContainsIcon, System.Drawing.Image.FromFile($"Resources\\{i + 1}.png"), Convert.ToString($"Resources\\{i + 1}.png"), true);
                        btn2.Click += Btn2_Click;
                    }
                    buttonListIcons.Add(btn2);
                }
                oldButton.Location = new Point(0, 0);
                pnlContainsIcon.Show();
            }
        }
        private void Btn2_Click(object sender, EventArgs e)
        {
            System.Windows.Forms.Button btn = (System.Windows.Forms.Button)sender;
            string path = btn.Text;


            //tiến hành gửi dữ liệu đi
            byte[] imageBytes = File.ReadAllBytes(path);
            string message = (int)setting.chatMulti + "*" + user.userName + "(2):" + Convert.ToBase64String(imageBytes) + "," + user.linkAvatar; ;
            sendData(message);

            writeData(System.Drawing.Image.FromFile(path), user.linkAvatar, "", 2, user.userName, pnlMultiChatFrame);
        }
        private void btnSendMessage_Click(object sender, EventArgs e)
        {
            if (txtSendMessage.Text != "")
            {
                if (txtSendMessage.Text.Length < 100)
                {
                    //tiến hành gửi dữ liệu đi
                    string message = (int)setting.chatMulti + "*" + user.userName + "(1):" + txtSendMessage.Text.Trim() + "," + user.linkAvatar;
                    sendData(message);
                    writeData(null, user.linkAvatar, txtSendMessage.Text.Trim(), 1, user.userName, pnlMultiChatFrame);
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
        private void Chat_btnSendIconChatOne_click(object sender, EventArgs e)
        {
            if (chat != null)
            {
                if (chat.containsIcon.Visible)
                {
                    chat.containsIcon.Hide();
                    chat.listIcons.Clear();
                }
                else
                {
                    //xóa hết các phần tử bên trong panel
                    chat.containsIcon.Controls.Clear();
                    chat.containsIcon.Padding = new Padding(0);
                    chat.listIcons = new List<System.Windows.Forms.Button>();
                    for (int i = 0; i < iconNumbers; i++)
                    {
                        System.Windows.Forms.Button btnChatOne = null;
                        if (chat.listIcons.Count % 4 == 0)
                        {
                            if (chat.listIcons.Count != 0)
                                oldButton.Location = new Point(0, 30 + oldButton.Location.Y + 10);
                            btnChatOne = btn.createButton(oldButton, chat.containsIcon, System.Drawing.Image.FromFile($"Resources\\{i + 1}.png"), Convert.ToString($"Resources\\{i + 1}.png"), true);
                            btnChatOne.Click += BtnChatOne_Click;
                        }
                        else
                        {
                            btnChatOne = btn.createButton(chat.listIcons[chat.listIcons.Count - 1], chat.containsIcon, System.Drawing.Image.FromFile($"Resources\\{i + 1}.png"), Convert.ToString($"Resources\\{i + 1}.png"), true);
                            btnChatOne.Click += BtnChatOne_Click;
                        }
                        chat.listIcons.Add(btnChatOne);
                    }
                    oldButton.Location = new Point(0, 0);
                    chat.containsIcon.Show();
                }
            }
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
                        sendData(message);
                        writeDataChatOne(null, user.linkAvatar, chat.TextBox.Text.Trim(), 1, user.userName, chat.pnlChatOne, chat.pos);
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
            sendData(message);

            writeDataChatOne(System.Drawing.Image.FromFile(path), user.linkAvatar, "", 2, user.userName, chat.pnlChatOne, chat.pos);
            chat.containsIcon.Hide();
            chat.listIcons.Clear();
        }

        //==================================================================================================================================

        //====================================CÁC HÀM DÙNG ĐỂ HIỂN THỊ DỮ LIỆU LÊN GIAO DIỆN DATAGRIDVIEW ==================================
        private async Task displayListMatches()
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
                        if (item.status.ToLower() != "finished" || item.status.ToLower() != "fighting")
                        {
                            string[] rowData = new string[] { item._id, item.roomName, item.ownerRoom, item.count.ToString() + "/2", item.betPoints.ToString(), item.status, item.ipRoom };
                            dtGridContainListRooms.Rows.Add(rowData);
                            //foreach (DataGridViewRow dtGridViewRow in  dtGridContainListRooms.Rows)
                            //{
                            //    if (string.Equals(dtGridViewRow.Cells["id"].Value.ToString(), rowData[0]))
                            //    {
                            //        dtGridContainListRooms.Rows.Add(rowData);
                            //    }
                            //}
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
        private void displayListUsers(List<infoUser> userLists)
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
        public void displayListFriends(List<infoUser> userLists)
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
        public void displayListWaitingAccept(List<infoUser> userLists)
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
        public void displayListRank(List<infoUser> userLists)
        {
            try
            {
                DataGridView dtGridRank = new DataGridView();
                //chứa danh sách điểm user từ cao đến thấp
                //xóa đi dòng cuối cùng trong dataGridView
                dtGridRank.AllowUserToAddRows = false;
                List<infoUser> sortList = userLists.OrderByDescending(user => user.point).ToList();
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
        public async Task displayListHistoryMatch(infoUser user)
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
                                        sendData(message);
                                        MatchInterface player = new MatchInterface(myIpAddress, columnData[e.RowIndex].ToString(), idMatch, columnData[e.RowIndex].ToString(), false, false, 1, match.betPoints, difUser, user);  //chủ phòng sẽ là cờ trắng
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
                        foreach (userControlChatOne userControl in listChats)
                        {
                            if (userControl.Tag.ToString().Contains(user.userName) && userControl.Tag.ToString().Contains(dataGridView.Rows[e.RowIndex].Cells["userName"].Value.ToString()))
                            {
                                pnlChatOne.Show();
                                foreach (System.Windows.Forms.UserControl userControl1 in listChats)
                                    userControl1.Hide();
                                chat = userControl;
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
                                HttpClient client = new HttpClient();
                                string apiPath = apiDeleteFriend + newId;
                                //tiến hành lấy ra _id thỏa mãn
                                await client.DeleteAsync(apiPath);

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
                                    sendData(message);

                                    //cập nhật lại danh sách tất cả người dùng
                                    await getListAllUser();

                                    //xóa bạn bè thì cũng coi như mất luồng chat 
                                    foreach (userControlChatOne control in listChats)
                                    {
                                        if (control.Tag.ToString().Contains(user.userName) && control.Tag.ToString().Contains(difUsername))
                                        {
                                            listChats.Remove(control);
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
                            sendData(message);
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
                                        sendData(message);
                                        //cập nhật lại danh sách bạn bè
                                        List<infoUser> getFriends = await getListUser("friend");
                                        displayListFriends(getFriends);
                                        createChatBetweenClientAndClient();
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
            listChats.Clear();
            rcvDataThread.Abort();
            //tiến hành đóng form lại
            this.Close();
        }
        private async void btnRank_Click(object sender, EventArgs e)
        {
            JToken tkData = await manageApi.callApiUsingMethodGet(apiGetAllUser);
            List<infoUser> users = JsonConvert.DeserializeObject<List<infoUser>>(tkData.ToString());
            displayListRank(users);

            loopChildPanel(rank);
        }
        private async void btnListFriend_Click(object sender, EventArgs e)
        {
            try
            {
                await getListAllUser();

                List<infoUser> getFriends = await getListUser("friend");

                displayListFriends(getFriends);
                getFriends.Clear();
                getFriends = await getListUser("waiting");
                displayListWaitingAccept(getFriends);


                loopChildPanel(userControlLists);

                createChatBetweenClientAndClient();
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
                await displayListHistoryMatch(myUser);
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
                displayListUsers(userLists);
            }
        }
        private void btnCreateRoom_Click(object sender, EventArgs e)
        {
            loopChildPanel(createRoom);
        }
        private async void createChatBetweenClientAndClient()
        {
            //thêm tập hợp các bạn bè vào để chat
            List<string> listFriends = await getListFriends();
            foreach (string userName in listFriends)
            {
                bool check = false;
                if (userName != user.userName)
                {
                    for (int index = 0; index < listChats.Count; index++)
                    {
                        if (listChats[index].Tag.ToString().Contains(user.userName) && listChats[index].Tag.ToString().Contains(userName))
                        {
                            check = true;
                            break;
                        }
                    }
                    if (!check)
                    {
                        chat = new userControlChatOne();
                        chat.Tag = $"{user.userName},{userName}";
                        chat.btnSendMsgChatOne_click += Chat_btnSendMsgChatOne_click; ;
                        chat.btnSendIconChatOne_click += Chat_btnSendIconChatOne_click; ;
                        chat.btnCloseForm_click += Chat_btnCloseForm_click;
                        chat.Dock = DockStyle.Bottom;
                        listChats.Add(chat);
                    }
                }
                check = false;
            }
            chat = null;
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
                        await displayListMatches();
                        matches match = JsonConvert.DeserializeObject<matches>(tkData.ToString());
                        string message = (int)setting.createRoom + "*" + user.userName;
                        sendData(message);

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
