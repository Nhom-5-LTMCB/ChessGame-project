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
using Newtonsoft.Json;
using System.Xml.Linq;

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
        private void displayAnncount(bool whiteTurn, bool blackTurn)
        {
            if (whiteTurn && !blackTurn) //quân trắng được di chuyển trước
                txtTurnUser.BackColor = Color.White;
            else
                txtTurnUser.BackColor = Color.Black;
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
            // hàm kiểm tra ô nào chứa quân cờ
            //getPiecesOnBoard();

            // hiển thị danh sách các quân cờ
            for (int i = 0; i < 8; i++)
            {
                for (int j = 0; j < 8; j++)
                {
                    //hiển thị các quân cờ lên trên giao diện
                    choose(i, j);
                }
            }
        }
        private void Timer_Tick(object sender, EventArgs e)
        {
            if (setUpTimer)
            {
                timer.Interval = 1000;
            }
            txtCountTime.Text = countTime.ToString();
            //sendMove(0, 0, 1, 0, 0); // mode = 1 tương ứng với dùng để nhận thời gian đếm ngược, 0 là thực hiện với bàn cờ

            countTime--;
            if (countTime == 0)
            {
                whiteTurn = !whiteTurn;
                blackTurn = !blackTurn;
                displayAnncount(whiteTurn, blackTurn);
                countTime = setUpTime;
                //clearMove();
                //thực hiện việc xóa các nút có màu đỏ trong list view nếu có
                for (int i = 0; i < buttonList.Count; i++)
                {
                    if (buttonList[i].BackColor == Color.Red)
                        buttonList[i].BackColor = Color.Transparent;
                }
            }
            if (setUpTimerThread)
            {
                timer.Interval = 1;
                setUpTimerThread = false;
            }
        }
        public MatchInterface(string myIp, string difIp, string matchId, string ipConnectRoom, bool isCreated, bool turn, int piece, int betPoint, infoUser difPlayer, infoUser currentPlayer) : this()
        {
            this.myIp = myIp;
            this.difIp = difIp;
            this.isCreated = isCreated;
            this.matchId = matchId;
            this.betPoint = betPoint;
            this.difPlayer = difPlayer;
            this.currentPlayer = currentPlayer;
            this.ipConnectRoom = ipConnectRoom;

            //chủ phòng sẽ là cờ trắng và biến piece = 0
            lbCurrentPlayer.Text = currentPlayer.userName;
            avtCurrentPlayer.Image = System.Drawing.Image.FromFile($"{parentDirectory}\\" + currentPlayer.linkAvatar);
            avtCurrentPlayer.SizeMode = PictureBoxSizeMode.Zoom;

            if (isCreated) // đây là người tạo phòng cũng tương đương với server
            {
                //đây là lượt mà chủ phòng sẽ được đánh trước
                whiteTurn = turn;
                blackTurn = !turn;
                displayAnncount(whiteTurn, blackTurn);
                clientUDP = new UdpClient(port);
                //rcvDataUDPThread = new Thread(new ThreadStart(rcvDataUDP));
                //rcvDataUDPThread.Start();

                this.piece = piece;
                server = new TcpListener(IPAddress.Any, portConnect);
                server.Start();
                threadWaiting = new Thread(new ThreadStart(waitingAnotherClient));
                threadWaiting.Start();
            }
            else //đây sẽ là người sẽ tham gia vào phòng chơi
            {
                try
                {
                    //đây là lượt mà người còn lại sẽ được đánh
                    blackTurn = turn;
                    whiteTurn = !turn;
                    displayAnncount(whiteTurn, blackTurn);
                    //người chơi sẽ là cờ đen và biến piece = 1
                    this.piece = piece;
                    client = new TcpClient();
                    client.Connect(IPAddress.Parse(ipConnectRoom), portConnect);

                    //tạo ra đối tượng UDP
                    clientUDP = new UdpClient(port);
                    ipEndPoint = new IPEndPoint(IPAddress.Parse(difIp), port);

                    string message = "<<<+" + JsonConvert.SerializeObject(currentPlayer) + "+" + myIp + "+>>>";
                    byte[] sendData = Encoding.UTF8.GetBytes(message);

                    clientUDP.Send(sendData, sendData.Length, ipEndPoint);


                    lbDifPlayer.Text = difPlayer.userName;
                    avtDifPlayer.Image = System.Drawing.Image.FromFile($"{parentDirectory}\\" + difPlayer.linkAvatar);
                    avtDifPlayer.SizeMode = PictureBoxSizeMode.Zoom;

                    //rcvDataUDPThread = new Thread(new ThreadStart(rcvDataUDP));
                    //rcvDataUDPThread.Start();

                    //clientRcvData = new Thread(new ThreadStart(rcvData));
                    //clientRcvData.Start();
                    timer = new System.Windows.Forms.Timer();
                    timer.Tick += Timer_Tick;
                    timer.Interval = 1;
                    setUpTimer = true;
                    setUpTimerThread = true;
                    timer.Start();
                    player.players += 1;
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                    this.Close();
                    return;
                }
            }       
        }
        private void tableBackground_Click(object sender, EventArgs e)
        {
            //sự kiện khi click vào 1 quân cờ bất kỳ
            afterClickOnTable((sender as userControlClick).posX, (sender as userControlClick).posY);
        }
        private System.Drawing.Image choose(int i, int j)
        {
            switch (chessboard.Board[i, j])
            {
                case 00: tableBackground[i, j].BackgroundImage = null; break;
                //Đây là trường hợp của các quân cờ đen
                case 01: tableBackground[i, j].BackgroundImage = System.Drawing.Image.FromFile("Resources\\BlackPawn.png"); break;
                case 02: tableBackground[i, j].BackgroundImage = System.Drawing.Image.FromFile("Resources\\BlackRock.png"); break;
                case 03: tableBackground[i, j].BackgroundImage = System.Drawing.Image.FromFile("Resources\\BlackKnight.png"); break;
                case 04: tableBackground[i, j].BackgroundImage = System.Drawing.Image.FromFile("Resources\\BlackBiShop.png"); break;
                case 05: tableBackground[i, j].BackgroundImage = System.Drawing.Image.FromFile("Resources\\BlackQueen.png"); break;
                case 06: tableBackground[i, j].BackgroundImage = System.Drawing.Image.FromFile("Resources\\BlackKing.png"); break;
                case 07: tableBackground[i, j].BackgroundImage = System.Drawing.Image.FromFile("Resources\\BlackRock.png"); break;
                case 08: tableBackground[i, j].BackgroundImage = System.Drawing.Image.FromFile("Resources\\BlackKnight.png"); break;
                case 09: tableBackground[i, j].BackgroundImage = System.Drawing.Image.FromFile("Resources\\BlackBiShop.png"); break;
                //đây là trường hợp của các quân cờ trắng
                case 11: tableBackground[i, j].BackgroundImage = System.Drawing.Image.FromFile("Resources\\WhitePawn.png"); break;
                case 12: tableBackground[i, j].BackgroundImage = System.Drawing.Image.FromFile("Resources\\WhiteRock.png"); break;
                case 13: tableBackground[i, j].BackgroundImage = System.Drawing.Image.FromFile("Resources\\WhiteKnight.png"); break;
                case 14: tableBackground[i, j].BackgroundImage = System.Drawing.Image.FromFile("Resources\\WhiteBiShop.png"); break;
                case 15: tableBackground[i, j].BackgroundImage = System.Drawing.Image.FromFile("Resources\\WhiteQueen.png"); break;
                case 16: tableBackground[i, j].BackgroundImage = System.Drawing.Image.FromFile("Resources\\WhiteKing.png"); break;
                case 17: tableBackground[i, j].BackgroundImage = System.Drawing.Image.FromFile("Resources\\WhiteRock.png"); break;
                case 18: tableBackground[i, j].BackgroundImage = System.Drawing.Image.FromFile("Resources\\WhiteKnight.png"); break;
                case 19: tableBackground[i, j].BackgroundImage = System.Drawing.Image.FromFile("Resources\\WhiteBiShop.png"); break;
            }
            return tableBackground[i, j].BackgroundImage;
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
        private void waitingAnotherClient()
        {
            while (true)
            {
                if (player.players == 2)
                {
                    client = server.AcceptTcpClient();
                    //serverRcvData = new Thread(new ThreadStart(rcvData));
                    //serverRcvData.Start();
                    break;
                }
            }
        }

        //hiển thị vị trí mới của quân cờ trên giao diện
        private void displayPieces(int posY, int posX, int beforeY, int beforeX)
        {
            for (int i = 0; i < 8; i++)
                for (int j = 0; j < 8; j++)
                    if ((posY == i && posX == j) || ((beforeY == i && beforeX == j)))
                        //hiển thị các quân cờ lên trên giao diện
                        choose(i, j);
            //lưu lại tất cả các nước di chuyển của các quân cờ
            staleArrays();

            //kiểm tra xem quân vua có đang bị chiếu tướng hay không
            chessboard.markStale(tableBackground, chessboard.Board, WhiteStaleArray, BlackStaleArray);
        }
        //hàm lưu lại vị trí di chuyển của các quân cờ
        private void staleArrays()
        {
            //dùng để lưu mọi nước đi của người chơi
            //đối với các quân cờ đen
            BlackStaleArray = new int[8, 8];
            BlackStaleArray = whitePawn.isStale(chessboard.Board, BlackStaleArray);
            BlackStaleArray = whiteKnight1.isStale(chessboard.Board, BlackStaleArray);
            BlackStaleArray = whiteKnight2.isStale(chessboard.Board, BlackStaleArray);
            BlackStaleArray = whiteBiShop1.isStale(chessboard.Board, BlackStaleArray);
            BlackStaleArray = whiteBiShop2.isStale(chessboard.Board, BlackStaleArray);
            BlackStaleArray = whiteRock1.isStale(chessboard.Board, BlackStaleArray);
            BlackStaleArray = whiteRock2.isStale(chessboard.Board, BlackStaleArray);
            BlackStaleArray = whiteQueen.isStale(chessboard.Board, BlackStaleArray);
            //đối với các quân cờ trắng
            WhiteStaleArray = new int[8, 8];
            WhiteStaleArray = blackPawn.isStale(chessboard.Board, WhiteStaleArray);
            WhiteStaleArray = blackKnight1.isStale(chessboard.Board, WhiteStaleArray);
            WhiteStaleArray = blackKnight2.isStale(chessboard.Board, WhiteStaleArray);
            WhiteStaleArray = blackBiShop1.isStale(chessboard.Board, WhiteStaleArray);
            WhiteStaleArray = blackBiShop2.isStale(chessboard.Board, WhiteStaleArray);
            WhiteStaleArray = blackRock1.isStale(chessboard.Board, WhiteStaleArray);
            WhiteStaleArray = blackRock2.isStale(chessboard.Board, WhiteStaleArray);
            WhiteStaleArray = blackQueen.isStale(chessboard.Board, WhiteStaleArray);
        }
        private void afterClickOnTable(int j, int i)
        {
            // khi client chưa tham gia phòng đấu thì không được phép làm gì cả
            if (isCreated && client == null)
            {
                MessageBox.Show("Game chưa bắt đầu, vui lòng đợi người chơi còn lại");
                return;
            }
            else
            {
                if (isChoose)
                {
                    // i tương đương với posY, j tương đương với posX
                    switch (chessboard.PossibleMoves[i, j])
                    {
                        // dùng để lưu lại việc tính toán các đường đi có sẵn của quân cờ
                        // lưu lại vị trí của các quân cờ đã chọn 
                        case 1: //1: tương đương với các quân cờ có thể chọn
                            possibleMovesByPieces(chessboard.Board[i, j], j, i);
                            beforeMove_Y = i;
                            beforeMove_X = j;
                            break;
                        case 2: //2: tương đương với những ô quân cờ có thể di chuyển
                            move = 0;
                            break;
                        // khi người dùng hủy việc chọn quân thì vị trí trên bàn cờ sẽ bị xóa
                        case 3: //3: tương đương với quân cờ được chọn
                            break;
                        case 4:
                            break;
                    }
                    //kiểm tra việc chiếu tướng
                    chessboard.markStale(tableBackground, chessboard.Board, WhiteStaleArray, BlackStaleArray);
                }
                else
                {
                    MessageBox.Show("Vui lòng chọn quân cờ thay thế");
                    return;
                }
            }
        }
        //numberOfPiece là số kí hiệu của quân cờ trên bàn cờ và X, Y là vị trí của quân cờ đó trên bàn cờ
        private void possibleMovesByPieces(int numberOfPiece, int posX, int posY)
        {
            //khi chọn vào 1 quân cờ mới thì vị trí của quân cờ cũ sẽ bị clear đi
            clearMove();

            //kiểm tra nếu đang bị chiếu tướng thì không thể nhập thành
            for (int i = 0; i < 8; i++)
            {
                for (int j = 0; j < 8; j++)
                {
                    if (tableBackground[i, j].BackColor == Color.Red && chessboard.Board[i, j] == 06)
                    {
                        castlingBlackKing = false;
                    }
                    else if (tableBackground[i, j].BackColor == Color.Red && chessboard.Board[i, j] == 16)
                    {
                        castlingWhiteKing = false;
                    }
                }
            }
            switch (numberOfPiece)
            {
                //thuật toán đường di chuyển của quân tốt
                case 1:
                    chessboard.PossibleMoves = blackPawn.getPossibleMoves(chessboard.Board, chessboard.PossibleMoves, posX, posY, blackTurn);
                    break;
                case 2:
                    chessboard.PossibleMoves = blackRock1.getPossibleMoves(chessboard.Board, chessboard.PossibleMoves, posX, posY, blackTurn);
                    break;
                case 3:
                    chessboard.PossibleMoves = blackKnight1.getPossibleMoves(chessboard.Board, chessboard.PossibleMoves, posX, posY, blackTurn);
                    break;
                case 4:
                    chessboard.PossibleMoves = blackBiShop1.getPossibleMoves(chessboard.Board, chessboard.PossibleMoves, posX, posY, blackTurn);
                    break;
                case 5:
                    chessboard.PossibleMoves = blackQueen.getPossibleMoves(chessboard.Board, chessboard.PossibleMoves, posX, posY, blackTurn);
                    break;
                case 6:
                    chessboard.PossibleMoves = blackKing.getPossibleMoves(chessboard.Board, chessboard.PossibleMoves, posX, posY, blackTurn, castlingBlackKing, castlingBlackRock1, castlingBlackRock2);
                    break;
                case 7:
                    chessboard.PossibleMoves = blackRock2.getPossibleMoves(chessboard.Board, chessboard.PossibleMoves, posX, posY, blackTurn);
                    break;
                case 8:
                    chessboard.PossibleMoves = blackKnight2.getPossibleMoves(chessboard.Board, chessboard.PossibleMoves, posX, posY, blackTurn);
                    break;
                case 9:
                    chessboard.PossibleMoves = blackBiShop2.getPossibleMoves(chessboard.Board, chessboard.PossibleMoves, posX, posY, blackTurn);
                    break;
                case 11:
                    chessboard.PossibleMoves = whitePawn.getPossibleMoves(chessboard.Board, chessboard.PossibleMoves, posX, posY, whiteTurn);
                    break;
                case 12:
                    chessboard.PossibleMoves = whiteRock1.getPossibleMoves(chessboard.Board, chessboard.PossibleMoves, posX, posY, whiteTurn);
                    break;
                case 13:
                    chessboard.PossibleMoves = whiteKnight1.getPossibleMoves(chessboard.Board, chessboard.PossibleMoves, posX, posY, whiteTurn);
                    break;
                case 14:
                    chessboard.PossibleMoves = whiteBiShop1.getPossibleMoves(chessboard.Board, chessboard.PossibleMoves, posX, posY, whiteTurn);
                    break;
                case 15:
                    chessboard.PossibleMoves = whiteQueen.getPossibleMoves(chessboard.Board, chessboard.PossibleMoves, posX, posY, whiteTurn);
                    break;
                case 16:
                    chessboard.PossibleMoves = whiteKing.getPossibleMoves(chessboard.Board, chessboard.PossibleMoves, posX, posY, whiteTurn, castlingWhiteKing, castlingWhiteRock1, castlingWhiteRock2);
                    break;
                case 17:
                    chessboard.PossibleMoves = whiteRock2.getPossibleMoves(chessboard.Board, chessboard.PossibleMoves, posX, posY, whiteTurn);
                    break;
                case 18:
                    chessboard.PossibleMoves = whiteKnight2.getPossibleMoves(chessboard.Board, chessboard.PossibleMoves, posX, posY, whiteTurn);
                    break;
                case 19:
                    chessboard.PossibleMoves = whiteBiShop2.getPossibleMoves(chessboard.Board, chessboard.PossibleMoves, posX, posY, whiteTurn);
                    break;
            }
            //những vị trí mà quân cờ được lựa chọn sẽ có giá trị là 3
            chessboard.PossibleMoves[posY, posX] = 3;
            removeMoveThatNotPossible(numberOfPiece, posY, posX);
            //hiển thị các vị trí mà quân cờ có thể di chuyển
            showPossibleMoves();
        }


    }
}
