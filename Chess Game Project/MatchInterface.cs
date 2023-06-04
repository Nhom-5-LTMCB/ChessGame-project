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
using System.Web.UI.WebControls;

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
        private List<System.Windows.Forms.Button> buttonList = new List<System.Windows.Forms.Button>();
        private List<System.Windows.Forms.Button> buttonListIcons = new List<System.Windows.Forms.Button>();
        private infoUser difPlayer = null;
        private infoUser currentPlayer = null;
        private System.Windows.Forms.Button oldButton = new System.Windows.Forms.Button()
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
        private void addTextBoxIntoPanelHorizontal(System.Windows.Forms.Panel pnl)
        {
            for (int i = 0; i < 8; i++)
            {
                int posX = i == 0 ? 0 : i * 50;
                int posY = pnl.Height / 2 - 15 / 2;
                System.Windows.Forms.TextBox tb = new System.Windows.Forms.TextBox()
                {
                    Size = new Size(50, 15),
                    Location = new Point(posX, posY),
                };
                tb.TextAlign = HorizontalAlignment.Center;
                tb.BorderStyle = System.Windows.Forms.BorderStyle.None;
                tb.Font = new Font(tb.Font, FontStyle.Bold);
                tb.Text = Convert.ToString((char)('A' + i));
                tb.BackColor = Color.LightCyan;
                tb.ReadOnly = true;
                pnl.Controls.Add(tb);
            }
        }
        private void addTextBoxIntoPanelVertical(System.Windows.Forms.Panel pnl)
        {
            for (int i = 0; i < 8; i++)
            {
                int posX = i == 0 ? 0 : i * 50;
                int posY = pnl.Width / 2 - 15 / 2;
                System.Windows.Forms.Button btn = new System.Windows.Forms.Button()
                {
                    Size = new Size(15, 50),
                    Location = new Point(posY, posX),
                };
                btn.FlatAppearance.MouseOverBackColor = Color.Transparent;
                btn.Font = new Font(btn.Font, FontStyle.Bold);
                btn.FlatStyle = FlatStyle.Flat;
                btn.FlatAppearance.BorderSize = 0;
                btn.BackColor = Color.LightCyan;
                btn.Text = Convert.ToString(1 + i);
                btn.Enabled = true;
                pnl.Controls.Add(btn);
            }
        }

        public MatchInterface()
        {
            InitializeComponent();
            pnlContainsIcon.Hide();
            txtCountTime.ReadOnly = true;
            txtCountTime.Text = countTime.ToString();

            //tạo một ma trận có kích thước 8 * 8
            chessboard.Board = new int[8, 8]
            {
                { 02, 03, 04, 05, 06, 09, 08, 07},
                { 01, 01, 01, 01, 01, 01, 01, 01},
                { 00, 00, 00, 00, 00, 00, 00, 00},
                { 00, 00, 00, 00, 00, 00, 00 ,00},
                { 00, 00, 00, 00, 00, 00, 00 ,00},
                { 00, 00, 00, 00, 00, 00, 00 ,00},
                { 11, 11, 11, 11, 11, 11, 11, 11},
                { 12, 13, 14, 15, 16, 19, 18, 17},
            };

            chessboard.PossibleMoves = new int[8, 8];
            tableBackground = new userControlClick[8, 8];

            CheckForIllegalCrossThreadCalls = false;
            //horizontal
            System.Windows.Forms.Panel pnl = new System.Windows.Forms.Panel()
            {
                Size = new Size(400, 15),
                Location = new Point(310, 100)
            };
            System.Windows.Forms.Panel pnl1 = new System.Windows.Forms.Panel()
            {
                Size = new Size(pnl.Size.Width, pnl.Size.Height),
                Location = new Point(pnl.Location.X, pnl.Location.Y + 50 * 8 + 25)
            };
            addTextBoxIntoPanelHorizontal(pnl);
            addTextBoxIntoPanelHorizontal(pnl1);
            pnlContent.Controls.Add(pnl);
            pnlContent.Controls.Add(pnl1);

            //vertical
            System.Windows.Forms.Panel pnl2 = new System.Windows.Forms.Panel()
            {
                Size = new Size(pnl.Size.Height, pnl.Size.Width),
                Location = new Point(290, 120)
            };

            System.Windows.Forms.Panel pnl3 = new System.Windows.Forms.Panel()
            {
                Size = new Size(pnl.Size.Height, pnl.Size.Width),
                Location = new Point(pnl2.Location.X + 50 * 8 + 25, pnl2.Location.Y)
            };
            addTextBoxIntoPanelVertical(pnl2);
            addTextBoxIntoPanelVertical(pnl3);
            pnlContent.Controls.Add(pnl2);
            pnlContent.Controls.Add(pnl3);

            for (int i = 0; i < 8; i++) // tượng trưng cho các dòng
            {
                for (int j = 0; j < 8; j++) //tượng trưng cho các cột
                {
                    tableBackground[i, j] = new userControlClick();
                    tableBackground[i, j].Parent = pnlContent;
                    tableBackground[i, j].Location = new Point(j * 50 + 310, i * 50 + 120);
                    tableBackground[i, j].posX = j;
                    tableBackground[i, j].posY = i;
                    tableBackground[i, j].Size = new Size(50, 50);
                    tableBackground[i, j].Click += tableBackground_Click;
                    if (i % 2 == 0)
                        if (j % 2 == 1) tableBackground[i, j].BackColor = Color.Brown;
                        else tableBackground[i, j].BackColor = Color.White;
                    else
                        if (j % 2 == 1) tableBackground[i, j].BackColor = Color.White;
                    else tableBackground[i, j].BackColor = Color.Brown;
                    tableBackground[i, j].BackgroundImageLayout = ImageLayout.Center;
                }
            }

        }
        private void tableBackground_Click(object sender, EventArgs e)
        {

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
