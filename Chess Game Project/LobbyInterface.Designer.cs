namespace Chess_Game_Project
{
    partial class LobbyInterface
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle5 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle6 = new System.Windows.Forms.DataGridViewCellStyle();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(LobbyInterface));
            this.pnlCoverPage = new System.Windows.Forms.Panel();
            this.pnlContent = new System.Windows.Forms.Panel();
            this.dtGridContainListRooms = new Guna.UI2.WinForms.Guna2DataGridView();
            this.Column1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column3 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column4 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column5 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.guna2Panel1 = new Guna.UI2.WinForms.Guna2Panel();
            this.btnSendMessage = new Guna.UI2.WinForms.Guna2Button();
            this.txtSendMessage = new Guna.UI2.WinForms.Guna2TextBox();
            this.btnSendIcon = new Guna.UI2.WinForms.Guna2Button();
            this.btnRandomRoom = new Guna.UI2.WinForms.Guna2Button();
            this.btnCreateRoom = new Guna.UI2.WinForms.Guna2Button();
            this.btnHistory = new Guna.UI2.WinForms.Guna2Button();
            this.btnRank = new Guna.UI2.WinForms.Guna2Button();
            this.btnListFriend = new Guna.UI2.WinForms.Guna2Button();
            this.btnLogout = new Guna.UI2.WinForms.Guna2Button();
            this.btnContainInfoUser = new Guna.UI2.WinForms.Guna2Button();
            this.pnlMultiChatFrame = new Guna.UI2.WinForms.Guna2Panel();
            this.pnlContainsIcon = new System.Windows.Forms.Panel();
            this.lbScore = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.lbUserName = new System.Windows.Forms.Label();
            this.ptboxAvatar = new System.Windows.Forms.PictureBox();
            this.ptbAvatarPage = new System.Windows.Forms.PictureBox();
            this.pnlContainsChild = new System.Windows.Forms.Panel();
            this.pnlContainsUserControl = new System.Windows.Forms.Panel();
            this.pnlChatOne = new System.Windows.Forms.Panel();
            this.pnlCoverPage.SuspendLayout();
            this.pnlContent.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dtGridContainListRooms)).BeginInit();
            this.guna2Panel1.SuspendLayout();
            this.pnlMultiChatFrame.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.ptboxAvatar)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ptbAvatarPage)).BeginInit();
            this.pnlContainsChild.SuspendLayout();
            this.pnlContainsUserControl.SuspendLayout();
            this.SuspendLayout();
            // 
            // pnlCoverPage
            // 
            this.pnlCoverPage.BackColor = System.Drawing.Color.NavajoWhite;
            this.pnlCoverPage.Controls.Add(this.pnlContent);
            this.pnlCoverPage.Controls.Add(this.ptbAvatarPage);
            this.pnlCoverPage.Controls.Add(this.pnlContainsChild);
            this.pnlCoverPage.Location = new System.Drawing.Point(-61, 6);
            this.pnlCoverPage.Name = "pnlCoverPage";
            this.pnlCoverPage.Size = new System.Drawing.Size(1473, 748);
            this.pnlCoverPage.TabIndex = 1;
            // 
            // pnlContent
            // 
            this.pnlContent.Controls.Add(this.dtGridContainListRooms);
            this.pnlContent.Controls.Add(this.guna2Panel1);
            this.pnlContent.Controls.Add(this.btnRandomRoom);
            this.pnlContent.Controls.Add(this.btnCreateRoom);
            this.pnlContent.Controls.Add(this.btnHistory);
            this.pnlContent.Controls.Add(this.btnRank);
            this.pnlContent.Controls.Add(this.btnListFriend);
            this.pnlContent.Controls.Add(this.btnLogout);
            this.pnlContent.Controls.Add(this.btnContainInfoUser);
            this.pnlContent.Controls.Add(this.pnlMultiChatFrame);
            this.pnlContent.Controls.Add(this.lbScore);
            this.pnlContent.Controls.Add(this.label2);
            this.pnlContent.Controls.Add(this.lbUserName);
            this.pnlContent.Controls.Add(this.ptboxAvatar);
            this.pnlContent.Location = new System.Drawing.Point(65, 42);
            this.pnlContent.Name = "pnlContent";
            this.pnlContent.Size = new System.Drawing.Size(1349, 643);
            this.pnlContent.TabIndex = 53;
            // 
            // dtGridContainListRooms
            // 
            dataGridViewCellStyle4.BackColor = System.Drawing.Color.White;
            this.dtGridContainListRooms.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle4;
            dataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle5.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(88)))), ((int)(((byte)(255)))));
            dataGridViewCellStyle5.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle5.ForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle5.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle5.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle5.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dtGridContainListRooms.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle5;
            this.dtGridContainListRooms.ColumnHeadersHeight = 18;
            this.dtGridContainListRooms.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.EnableResizing;
            this.dtGridContainListRooms.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Column1,
            this.Column2,
            this.Column3,
            this.Column4,
            this.Column5});
            dataGridViewCellStyle6.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle6.BackColor = System.Drawing.Color.White;
            dataGridViewCellStyle6.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle6.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(71)))), ((int)(((byte)(69)))), ((int)(((byte)(94)))));
            dataGridViewCellStyle6.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(231)))), ((int)(((byte)(229)))), ((int)(((byte)(255)))));
            dataGridViewCellStyle6.SelectionForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(71)))), ((int)(((byte)(69)))), ((int)(((byte)(94)))));
            dataGridViewCellStyle6.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dtGridContainListRooms.DefaultCellStyle = dataGridViewCellStyle6;
            this.dtGridContainListRooms.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(231)))), ((int)(((byte)(229)))), ((int)(((byte)(255)))));
            this.dtGridContainListRooms.Location = new System.Drawing.Point(442, 185);
            this.dtGridContainListRooms.Name = "dtGridContainListRooms";
            this.dtGridContainListRooms.RowHeadersVisible = false;
            this.dtGridContainListRooms.RowHeadersWidth = 51;
            this.dtGridContainListRooms.RowTemplate.Height = 24;
            this.dtGridContainListRooms.Size = new System.Drawing.Size(889, 396);
            this.dtGridContainListRooms.TabIndex = 87;
            this.dtGridContainListRooms.ThemeStyle.AlternatingRowsStyle.BackColor = System.Drawing.Color.White;
            this.dtGridContainListRooms.ThemeStyle.AlternatingRowsStyle.Font = null;
            this.dtGridContainListRooms.ThemeStyle.AlternatingRowsStyle.ForeColor = System.Drawing.Color.Empty;
            this.dtGridContainListRooms.ThemeStyle.AlternatingRowsStyle.SelectionBackColor = System.Drawing.Color.Empty;
            this.dtGridContainListRooms.ThemeStyle.AlternatingRowsStyle.SelectionForeColor = System.Drawing.Color.Empty;
            this.dtGridContainListRooms.ThemeStyle.BackColor = System.Drawing.Color.White;
            this.dtGridContainListRooms.ThemeStyle.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(231)))), ((int)(((byte)(229)))), ((int)(((byte)(255)))));
            this.dtGridContainListRooms.ThemeStyle.HeaderStyle.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(88)))), ((int)(((byte)(255)))));
            this.dtGridContainListRooms.ThemeStyle.HeaderStyle.BorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            this.dtGridContainListRooms.ThemeStyle.HeaderStyle.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dtGridContainListRooms.ThemeStyle.HeaderStyle.ForeColor = System.Drawing.Color.White;
            this.dtGridContainListRooms.ThemeStyle.HeaderStyle.HeaightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.EnableResizing;
            this.dtGridContainListRooms.ThemeStyle.HeaderStyle.Height = 18;
            this.dtGridContainListRooms.ThemeStyle.ReadOnly = false;
            this.dtGridContainListRooms.ThemeStyle.RowsStyle.BackColor = System.Drawing.Color.White;
            this.dtGridContainListRooms.ThemeStyle.RowsStyle.BorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.SingleHorizontal;
            this.dtGridContainListRooms.ThemeStyle.RowsStyle.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dtGridContainListRooms.ThemeStyle.RowsStyle.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(71)))), ((int)(((byte)(69)))), ((int)(((byte)(94)))));
            this.dtGridContainListRooms.ThemeStyle.RowsStyle.Height = 24;
            this.dtGridContainListRooms.ThemeStyle.RowsStyle.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(231)))), ((int)(((byte)(229)))), ((int)(((byte)(255)))));
            this.dtGridContainListRooms.ThemeStyle.RowsStyle.SelectionForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(71)))), ((int)(((byte)(69)))), ((int)(((byte)(94)))));
            // 
            // Column1
            // 
            this.Column1.HeaderText = "Column1";
            this.Column1.MinimumWidth = 6;
            this.Column1.Name = "Column1";
            // 
            // Column2
            // 
            this.Column2.HeaderText = "Column2";
            this.Column2.MinimumWidth = 6;
            this.Column2.Name = "Column2";
            // 
            // Column3
            // 
            this.Column3.HeaderText = "Column3";
            this.Column3.MinimumWidth = 6;
            this.Column3.Name = "Column3";
            // 
            // Column4
            // 
            this.Column4.HeaderText = "Column4";
            this.Column4.MinimumWidth = 6;
            this.Column4.Name = "Column4";
            // 
            // Column5
            // 
            this.Column5.HeaderText = "Column5";
            this.Column5.MinimumWidth = 6;
            this.Column5.Name = "Column5";
            // 
            // guna2Panel1
            // 
            this.guna2Panel1.BackColor = System.Drawing.Color.SaddleBrown;
            this.guna2Panel1.Controls.Add(this.btnSendMessage);
            this.guna2Panel1.Controls.Add(this.txtSendMessage);
            this.guna2Panel1.Controls.Add(this.btnSendIcon);
            this.guna2Panel1.Location = new System.Drawing.Point(18, 574);
            this.guna2Panel1.Name = "guna2Panel1";
            this.guna2Panel1.Size = new System.Drawing.Size(397, 53);
            this.guna2Panel1.TabIndex = 86;
            // 
            // btnSendMessage
            // 
            this.btnSendMessage.BorderColor = System.Drawing.Color.Red;
            this.btnSendMessage.BorderRadius = 5;
            this.btnSendMessage.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.btnSendMessage.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.btnSendMessage.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.btnSendMessage.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.btnSendMessage.FillColor = System.Drawing.Color.Red;
            this.btnSendMessage.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.btnSendMessage.ForeColor = System.Drawing.Color.White;
            this.btnSendMessage.Image = ((System.Drawing.Image)(resources.GetObject("btnSendMessage.Image")));
            this.btnSendMessage.Location = new System.Drawing.Point(326, 0);
            this.btnSendMessage.Name = "btnSendMessage";
            this.btnSendMessage.Size = new System.Drawing.Size(71, 56);
            this.btnSendMessage.TabIndex = 84;
            // 
            // txtSendMessage
            // 
            this.txtSendMessage.BorderColor = System.Drawing.Color.Black;
            this.txtSendMessage.BorderRadius = 5;
            this.txtSendMessage.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.txtSendMessage.DefaultText = "";
            this.txtSendMessage.DisabledState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(208)))), ((int)(((byte)(208)))), ((int)(((byte)(208)))));
            this.txtSendMessage.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(226)))), ((int)(((byte)(226)))), ((int)(((byte)(226)))));
            this.txtSendMessage.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.txtSendMessage.DisabledState.PlaceholderForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.txtSendMessage.FillColor = System.Drawing.Color.LemonChiffon;
            this.txtSendMessage.FocusedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.txtSendMessage.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.txtSendMessage.HoverState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.txtSendMessage.Location = new System.Drawing.Point(0, -2);
            this.txtSendMessage.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.txtSendMessage.Name = "txtSendMessage";
            this.txtSendMessage.PasswordChar = '\0';
            this.txtSendMessage.PlaceholderText = "";
            this.txtSendMessage.SelectedText = "";
            this.txtSendMessage.Size = new System.Drawing.Size(260, 56);
            this.txtSendMessage.TabIndex = 85;
            // 
            // btnSendIcon
            // 
            this.btnSendIcon.BorderRadius = 5;
            this.btnSendIcon.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.btnSendIcon.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.btnSendIcon.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.btnSendIcon.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.btnSendIcon.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(0)))));
            this.btnSendIcon.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.btnSendIcon.ForeColor = System.Drawing.Color.White;
            this.btnSendIcon.Image = ((System.Drawing.Image)(resources.GetObject("btnSendIcon.Image")));
            this.btnSendIcon.Location = new System.Drawing.Point(259, -2);
            this.btnSendIcon.Name = "btnSendIcon";
            this.btnSendIcon.Size = new System.Drawing.Size(71, 55);
            this.btnSendIcon.TabIndex = 83;
            // 
            // btnRandomRoom
            // 
            this.btnRandomRoom.BorderRadius = 5;
            this.btnRandomRoom.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.btnRandomRoom.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.btnRandomRoom.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.btnRandomRoom.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.btnRandomRoom.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(139)))), ((int)(((byte)(121)))), ((int)(((byte)(94)))));
            this.btnRandomRoom.Font = new System.Drawing.Font("Segoe UI", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnRandomRoom.ForeColor = System.Drawing.Color.White;
            this.btnRandomRoom.Location = new System.Drawing.Point(1022, 587);
            this.btnRandomRoom.Name = "btnRandomRoom";
            this.btnRandomRoom.Size = new System.Drawing.Size(154, 40);
            this.btnRandomRoom.TabIndex = 82;
            this.btnRandomRoom.Text = "Ngẫu nhiên";
            // 
            // btnCreateRoom
            // 
            this.btnCreateRoom.BorderRadius = 5;
            this.btnCreateRoom.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.btnCreateRoom.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.btnCreateRoom.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.btnCreateRoom.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.btnCreateRoom.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(139)))), ((int)(((byte)(121)))), ((int)(((byte)(94)))));
            this.btnCreateRoom.Font = new System.Drawing.Font("Segoe UI", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnCreateRoom.ForeColor = System.Drawing.Color.White;
            this.btnCreateRoom.Location = new System.Drawing.Point(1177, 587);
            this.btnCreateRoom.Name = "btnCreateRoom";
            this.btnCreateRoom.Size = new System.Drawing.Size(154, 40);
            this.btnCreateRoom.TabIndex = 81;
            this.btnCreateRoom.Text = "Tạo phòng";
            // 
            // btnHistory
            // 
            this.btnHistory.Animated = true;
            this.btnHistory.AutoRoundedCorners = true;
            this.btnHistory.BorderRadius = 19;
            this.btnHistory.BorderThickness = 2;
            this.btnHistory.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.btnHistory.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.btnHistory.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.btnHistory.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.btnHistory.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(139)))), ((int)(((byte)(121)))), ((int)(((byte)(94)))));
            this.btnHistory.Font = new System.Drawing.Font("Consolas", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.btnHistory.ForeColor = System.Drawing.Color.White;
            this.btnHistory.Location = new System.Drawing.Point(18, 126);
            this.btnHistory.Name = "btnHistory";
            this.btnHistory.Size = new System.Drawing.Size(204, 40);
            this.btnHistory.TabIndex = 80;
            this.btnHistory.Text = "Lịch sử đấu";
            // 
            // btnRank
            // 
            this.btnRank.Animated = true;
            this.btnRank.AutoRoundedCorners = true;
            this.btnRank.BorderRadius = 24;
            this.btnRank.BorderThickness = 2;
            this.btnRank.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.btnRank.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.btnRank.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.btnRank.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.btnRank.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(139)))), ((int)(((byte)(121)))), ((int)(((byte)(94)))));
            this.btnRank.Font = new System.Drawing.Font("Consolas", 10.2F, System.Drawing.FontStyle.Bold);
            this.btnRank.ForeColor = System.Drawing.Color.White;
            this.btnRank.Location = new System.Drawing.Point(969, 79);
            this.btnRank.Name = "btnRank";
            this.btnRank.Size = new System.Drawing.Size(157, 51);
            this.btnRank.TabIndex = 79;
            this.btnRank.Text = "Bảng xếp hạng";
            // 
            // btnListFriend
            // 
            this.btnListFriend.Animated = true;
            this.btnListFriend.AutoRoundedCorners = true;
            this.btnListFriend.BorderRadius = 24;
            this.btnListFriend.BorderThickness = 2;
            this.btnListFriend.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.btnListFriend.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.btnListFriend.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.btnListFriend.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.btnListFriend.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(139)))), ((int)(((byte)(121)))), ((int)(((byte)(94)))));
            this.btnListFriend.Font = new System.Drawing.Font("Consolas", 10.2F, System.Drawing.FontStyle.Bold);
            this.btnListFriend.ForeColor = System.Drawing.Color.White;
            this.btnListFriend.Location = new System.Drawing.Point(1132, 79);
            this.btnListFriend.Name = "btnListFriend";
            this.btnListFriend.Size = new System.Drawing.Size(180, 51);
            this.btnListFriend.TabIndex = 78;
            this.btnListFriend.Text = "Danh sách bạn bè";
            // 
            // btnLogout
            // 
            this.btnLogout.Animated = true;
            this.btnLogout.AutoRoundedCorners = true;
            this.btnLogout.BorderRadius = 24;
            this.btnLogout.BorderThickness = 2;
            this.btnLogout.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.btnLogout.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.btnLogout.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.btnLogout.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.btnLogout.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(139)))), ((int)(((byte)(121)))), ((int)(((byte)(94)))));
            this.btnLogout.Font = new System.Drawing.Font("Consolas", 10.2F, System.Drawing.FontStyle.Bold);
            this.btnLogout.ForeColor = System.Drawing.Color.White;
            this.btnLogout.Location = new System.Drawing.Point(1132, 16);
            this.btnLogout.Name = "btnLogout";
            this.btnLogout.Size = new System.Drawing.Size(180, 51);
            this.btnLogout.TabIndex = 77;
            this.btnLogout.Text = "Đăng xuất";
            // 
            // btnContainInfoUser
            // 
            this.btnContainInfoUser.Animated = true;
            this.btnContainInfoUser.AutoRoundedCorners = true;
            this.btnContainInfoUser.BorderRadius = 24;
            this.btnContainInfoUser.BorderThickness = 2;
            this.btnContainInfoUser.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.btnContainInfoUser.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.btnContainInfoUser.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.btnContainInfoUser.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.btnContainInfoUser.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(139)))), ((int)(((byte)(121)))), ((int)(((byte)(94)))));
            this.btnContainInfoUser.Font = new System.Drawing.Font("Consolas", 10.2F, System.Drawing.FontStyle.Bold);
            this.btnContainInfoUser.ForeColor = System.Drawing.Color.White;
            this.btnContainInfoUser.Location = new System.Drawing.Point(969, 16);
            this.btnContainInfoUser.Name = "btnContainInfoUser";
            this.btnContainInfoUser.Size = new System.Drawing.Size(157, 51);
            this.btnContainInfoUser.TabIndex = 76;
            this.btnContainInfoUser.Text = "Xem thông tin";
            // 
            // pnlMultiChatFrame
            // 
            this.pnlMultiChatFrame.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.pnlMultiChatFrame.Controls.Add(this.pnlContainsIcon);
            this.pnlMultiChatFrame.Location = new System.Drawing.Point(18, 172);
            this.pnlMultiChatFrame.Name = "pnlMultiChatFrame";
            this.pnlMultiChatFrame.Size = new System.Drawing.Size(397, 396);
            this.pnlMultiChatFrame.TabIndex = 69;
            // 
            // pnlContainsIcon
            // 
            this.pnlContainsIcon.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(192)))), ((int)(((byte)(192)))));
            this.pnlContainsIcon.Location = new System.Drawing.Point(0, 86);
            this.pnlContainsIcon.Name = "pnlContainsIcon";
            this.pnlContainsIcon.Size = new System.Drawing.Size(397, 310);
            this.pnlContainsIcon.TabIndex = 65;
            this.pnlContainsIcon.Paint += new System.Windows.Forms.PaintEventHandler(this.pnlContainsIcon_Paint);
            // 
            // lbScore
            // 
            this.lbScore.AutoSize = true;
            this.lbScore.Font = new System.Drawing.Font("Consolas", 11F, System.Drawing.FontStyle.Bold);
            this.lbScore.Location = new System.Drawing.Point(216, 83);
            this.lbScore.Name = "lbScore";
            this.lbScore.Size = new System.Drawing.Size(30, 22);
            this.lbScore.TabIndex = 64;
            this.lbScore.Text = "10";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Consolas", 11F, System.Drawing.FontStyle.Bold);
            this.label2.Location = new System.Drawing.Point(162, 83);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(60, 22);
            this.label2.TabIndex = 63;
            this.label2.Text = "Điểm:";
            // 
            // lbUserName
            // 
            this.lbUserName.AutoSize = true;
            this.lbUserName.Font = new System.Drawing.Font("Consolas", 11F, System.Drawing.FontStyle.Bold);
            this.lbUserName.Location = new System.Drawing.Point(162, 60);
            this.lbUserName.Name = "lbUserName";
            this.lbUserName.Size = new System.Drawing.Size(80, 22);
            this.lbUserName.TabIndex = 62;
            this.lbUserName.Text = "Longlee";
            // 
            // ptboxAvatar
            // 
            this.ptboxAvatar.Location = new System.Drawing.Point(18, 16);
            this.ptboxAvatar.Name = "ptboxAvatar";
            this.ptboxAvatar.Size = new System.Drawing.Size(127, 104);
            this.ptboxAvatar.TabIndex = 50;
            this.ptboxAvatar.TabStop = false;
            // 
            // ptbAvatarPage
            // 
            this.ptbAvatarPage.BackColor = System.Drawing.Color.NavajoWhite;
            this.ptbAvatarPage.Location = new System.Drawing.Point(0, 0);
            this.ptbAvatarPage.Name = "ptbAvatarPage";
            this.ptbAvatarPage.Size = new System.Drawing.Size(1121, 658);
            this.ptbAvatarPage.TabIndex = 0;
            this.ptbAvatarPage.TabStop = false;
            // 
            // pnlContainsChild
            // 
            this.pnlContainsChild.AutoSize = true;
            this.pnlContainsChild.BackColor = System.Drawing.Color.NavajoWhite;
            this.pnlContainsChild.Controls.Add(this.pnlContainsUserControl);
            this.pnlContainsChild.Location = new System.Drawing.Point(409, 13);
            this.pnlContainsChild.Name = "pnlContainsChild";
            this.pnlContainsChild.Size = new System.Drawing.Size(908, 645);
            this.pnlContainsChild.TabIndex = 70;
            // 
            // pnlContainsUserControl
            // 
            this.pnlContainsUserControl.BackColor = System.Drawing.Color.DimGray;
            this.pnlContainsUserControl.Controls.Add(this.pnlChatOne);
            this.pnlContainsUserControl.Location = new System.Drawing.Point(0, 112);
            this.pnlContainsUserControl.Name = "pnlContainsUserControl";
            this.pnlContainsUserControl.Size = new System.Drawing.Size(905, 530);
            this.pnlContainsUserControl.TabIndex = 1;
            // 
            // pnlChatOne
            // 
            this.pnlChatOne.BackColor = System.Drawing.Color.Gainsboro;
            this.pnlChatOne.Location = new System.Drawing.Point(0, 77);
            this.pnlChatOne.Name = "pnlChatOne";
            this.pnlChatOne.Size = new System.Drawing.Size(506, 459);
            this.pnlChatOne.TabIndex = 5;
            // 
            // LobbyInterface
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1426, 770);
            this.Controls.Add(this.pnlCoverPage);
            this.Name = "LobbyInterface";
            this.Text = "LobbyInterface";
            this.pnlCoverPage.ResumeLayout(false);
            this.pnlCoverPage.PerformLayout();
            this.pnlContent.ResumeLayout(false);
            this.pnlContent.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dtGridContainListRooms)).EndInit();
            this.guna2Panel1.ResumeLayout(false);
            this.pnlMultiChatFrame.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.ptboxAvatar)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ptbAvatarPage)).EndInit();
            this.pnlContainsChild.ResumeLayout(false);
            this.pnlContainsUserControl.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel pnlCoverPage;
        private System.Windows.Forms.Panel pnlContent;
        private System.Windows.Forms.Panel pnlContainsIcon;
        private System.Windows.Forms.Label lbScore;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label lbUserName;
        private System.Windows.Forms.PictureBox ptboxAvatar;
        private System.Windows.Forms.PictureBox ptbAvatarPage;
        private Guna.UI2.WinForms.Guna2Panel pnlMultiChatFrame;
        private System.Windows.Forms.Panel pnlContainsChild;
        private System.Windows.Forms.Panel pnlContainsUserControl;
        private System.Windows.Forms.Panel pnlChatOne;
        private Guna.UI2.WinForms.Guna2Button btnRank;
        private Guna.UI2.WinForms.Guna2Button btnListFriend;
        private Guna.UI2.WinForms.Guna2Button btnLogout;
        private Guna.UI2.WinForms.Guna2Button btnContainInfoUser;
        private Guna.UI2.WinForms.Guna2Button btnHistory;
        private Guna.UI2.WinForms.Guna2Button btnRandomRoom;
        private Guna.UI2.WinForms.Guna2Button btnCreateRoom;
        private Guna.UI2.WinForms.Guna2TextBox txtSendMessage;
        private Guna.UI2.WinForms.Guna2Button btnSendMessage;
        private Guna.UI2.WinForms.Guna2Button btnSendIcon;
        private Guna.UI2.WinForms.Guna2Panel guna2Panel1;
        private Guna.UI2.WinForms.Guna2DataGridView dtGridContainListRooms;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column1;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column2;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column3;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column4;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column5;
    }
}