using Chess_Game_Project.classes;
using Chess_Game_Project.ContainUserControls;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net.Sockets;
using System.Net;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using chessgames.backPieces;
using chessgames.whitePieces;

namespace Chess_Game_Project
{
    public partial class MatchInterface : Form
    {
        #region pieces
        //khai báo các quân cờ đen
        private BlackPawn blackPawn = new BlackPawn();
        private BlackRock1 blackRock1 = new BlackRock1();
        private BlackRock2 blackRock2 = new BlackRock2();
        private BlackKnight1 blackKnight1 = new BlackKnight1();
        private BlackKnight2 blackKnight2 = new BlackKnight2();
        private BlackBiShop1 blackBiShop1 = new BlackBiShop1();
        private BlackBiShop2 blackBiShop2 = new BlackBiShop2();
        private BlackQueen blackQueen = new BlackQueen();
        private BlackKing blackKing = new BlackKing();
        //khai báo các quân cờ trắng
        private WhitePawn whitePawn = new WhitePawn();
        private WhiteKnight1 whiteKnight1 = new WhiteKnight1();
        private WhiteKnight2 whiteKnight2 = new WhiteKnight2();
        private WhiteBiShop1 whiteBiShop1 = new WhiteBiShop1();
        private WhiteBiShop2 whiteBiShop2 = new WhiteBiShop2();
        private WhiteKing whiteKing = new WhiteKing();
        private WhiteQueen whiteQueen = new WhiteQueen();
        private WhiteRock1 whiteRock1 = new WhiteRock1();
        private WhiteRock2 whiteRock2 = new WhiteRock2();
        #endregion

        #region boolsChess
        private bool whiteTurn;
        private bool blackTurn;
        private bool gameOver = false;
        private bool castlingBlackRock1 = true;
        private bool castlingBlackRock2 = true;
        private bool castlingBlackKing = true;
        private bool castlingWhiteRock1 = true;
        private bool castlingWhiteRock2 = true;
        private bool checkEnable = false;
        private bool castlingWhiteKing = true;
        private bool isCreated;
        private bool canNotMove = false; // ngăn không cho đối phương di chuyển khi user chọn thành công quân cờ mới
        private bool isChoose = true; //trường này khi quân tốt di chuyển tới cuối bàn cờ thì nếu chọn quân mới rồi mới được quyền đánh
        private bool setUpTimer = false;
        private bool setUpTimerThread = false;
        #endregion

        #region integers
        private int beforeMove_X;
        private int beforeMove_Y;
        private int getChangMove_X;
        private int getChangMove_Y;
        private int move;
        private int portConnect = 8080;
        private int playerMoved = 0;
        private int castlingPiece = 0;
        private int changePieceValue = 0;
        private int piece = -1;
        private int countTime = 60;
        private int setUpTime = 60;
        private int iconNumbers = 29;
        private int betPoint = 0;
        private int currentScore = 0;
        private int currentDifPlayerScore = 0;
        #endregion

        #region info user
        private string matchId;
        private string ipConnectRoom;
        private string parentDirectory = Directory.GetParent(Application.StartupPath)?.Parent?.FullName + "\\Images";
        private string myIp;
        private string difIp;
        private int port = 1000;
        #endregion

        #region apiPath
        private string apiResultMatch = "https://chessmates.onrender.com/api/v1/matches/edit/resultMatch/";
        private string apiUpdateScore = "https://chessmates.onrender.com/api/v1/users/updatePoint/";
        private string apiGetUserId = "https://chessmates.onrender.com/api/v1/users/";
        private string apiDeleteRoom = "https://chessmates.onrender.com/api/v1/matches/delete/";
        #endregion

        #region variable
        private ChessBoard chessboard = new ChessBoard();
        private userControlClick[,] tableBackground;
        private int[,] WhiteStaleArray = new int[8, 8];
        private int[,] BlackStaleArray = new int[8, 8];
        private Thread serverRcvData = null;
        private Thread clientRcvData = null;
        private Thread threadWaiting = null;
        private Stream stream = null;
        private TcpClient client = null;
        private TcpListener server = null;
        private List<Button> buttonList = new List<Button>();
        private List<Button> buttonListIcons = new List<Button>();
        private infoUser difPlayer = null;
        private infoUser currentPlayer = null;
        private Button oldButton = new Button()
        {
            Height = 0,
            Width = 0
        };
        private button btn = new button();
        private UdpClient clientUDP = null;
        private Thread rcvDataUDPThread = null;
        private IPEndPoint ipEndPoint = null;
        private System.Windows.Forms.Timer timer = null;
        private int posY = 0;
        #endregion
        public MatchInterface()
        {
            InitializeComponent();

        }

        private void MatchInterface_Load(object sender, EventArgs e)
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
            // Đưa Panel vào chính giữa màn hình
            pnlContent.Location = new Point((this.Width - pnlContent.Width) / 2,
                                        (this.Height - pnlContent.Height) / 2);
            pnlContent.BackColor = Color.Transparent;
            pnlContent.Parent = this;
            this.TransparencyKey = Color.Empty;
            pnlContent.BringToFront();

            listChat.Parent = pnlChatClientFrame;
            pnlContainsIcon.Parent = pnlChatClientFrame;
            pnlContainsIcon.BringToFront();
        }
    }
}
