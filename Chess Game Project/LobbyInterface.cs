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
        public LobbyInterface()
        {
            InitializeComponent();
           
        }
        
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



        //==================================================================================================================================
    }
}
