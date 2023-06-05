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
        
        private void btnContainInfoUser_Click(object sender, EventArgs e)
        {
          
        }
        private void btnLogout_Click(object sender, EventArgs e)
        {
           
        }
        private void btnRank_Click(object sender, EventArgs e)
        {
            
        }
        private void btnListFriend_Click(object sender, EventArgs e)
        {

           
        }
        private void btnHistory_Click(object sender, EventArgs e)
        {
            
        }
        private void btnRandomRoom_Click(object sender, EventArgs e)
        {

        }
       
        private void mainInterface_FormClosed(object sender, FormClosedEventArgs e)
        {
            
        }

        private void pnlContainsIcon_Paint(object sender, PaintEventArgs e)
        {

        }

        private void btnLogout_Click_1(object sender, EventArgs e)
        {

        }

        private void LobbyInterface_Load(object sender, EventArgs e)
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

        private void pnlMultiChatFrame_Paint(object sender, PaintEventArgs e)
        {

        }



        //==================================================================================================================================
    }
}
