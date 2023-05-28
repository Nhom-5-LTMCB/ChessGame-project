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
            this.pnlCoverPage = new System.Windows.Forms.Panel();
            this.pnlContent = new System.Windows.Forms.Panel();
            this.pnlContainsIcon = new System.Windows.Forms.Panel();
            this.lbScore = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.lbUserName = new System.Windows.Forms.Label();
            this.btnRandomRoom = new System.Windows.Forms.Button();
            this.btnCreateRoom = new System.Windows.Forms.Button();
            this.dtGridContainListRooms = new System.Windows.Forms.DataGridView();
            this.btnSendMessage = new System.Windows.Forms.Button();
            this.btnSendIcon = new System.Windows.Forms.Button();
            this.txtSendMessage = new System.Windows.Forms.TextBox();
            this.rtbChat = new System.Windows.Forms.RichTextBox();
            this.btnHistory = new System.Windows.Forms.Button();
            this.btnMakeFriend = new System.Windows.Forms.Button();
            this.btnRank = new System.Windows.Forms.Button();
            this.btnLogout = new System.Windows.Forms.Button();
            this.btnContainInfoUser = new System.Windows.Forms.Button();
            this.ptboxAvatar = new System.Windows.Forms.PictureBox();
            this.ptbAvatarPage = new System.Windows.Forms.PictureBox();
            this.userControlContentChatLeft1 = new Chess_Game_Project.ContainUserControls.userControlContentChatLeft();
            this.btnExit = new System.Windows.Forms.Button();
            this.pnlContainsUserControl = new System.Windows.Forms.Panel();
            this.pnlChatOne = new System.Windows.Forms.Panel();
            this.pnlContainsChild = new System.Windows.Forms.Panel();
            this.pnlCoverPage.SuspendLayout();
            this.pnlContent.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dtGridContainListRooms)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ptboxAvatar)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ptbAvatarPage)).BeginInit();
            this.pnlContainsUserControl.SuspendLayout();
            this.pnlContainsChild.SuspendLayout();
            this.SuspendLayout();
            // 
            // pnlCoverPage
            // 
            this.pnlCoverPage.Controls.Add(this.pnlContent);
            this.pnlCoverPage.Controls.Add(this.ptbAvatarPage);
            this.pnlCoverPage.Location = new System.Drawing.Point(-61, 6);
            this.pnlCoverPage.Name = "pnlCoverPage";
            this.pnlCoverPage.Size = new System.Drawing.Size(1473, 748);
            this.pnlCoverPage.TabIndex = 1;
            // 
            // pnlContent
            // 
            this.pnlContent.Controls.Add(this.pnlContainsChild);
            this.pnlContent.Controls.Add(this.userControlContentChatLeft1);
            this.pnlContent.Controls.Add(this.pnlContainsIcon);
            this.pnlContent.Controls.Add(this.lbScore);
            this.pnlContent.Controls.Add(this.label2);
            this.pnlContent.Controls.Add(this.lbUserName);
            this.pnlContent.Controls.Add(this.btnRandomRoom);
            this.pnlContent.Controls.Add(this.btnCreateRoom);
            this.pnlContent.Controls.Add(this.dtGridContainListRooms);
            this.pnlContent.Controls.Add(this.btnSendMessage);
            this.pnlContent.Controls.Add(this.btnSendIcon);
            this.pnlContent.Controls.Add(this.txtSendMessage);
            this.pnlContent.Controls.Add(this.rtbChat);
            this.pnlContent.Controls.Add(this.btnHistory);
            this.pnlContent.Controls.Add(this.btnMakeFriend);
            this.pnlContent.Controls.Add(this.btnRank);
            this.pnlContent.Controls.Add(this.btnLogout);
            this.pnlContent.Controls.Add(this.btnContainInfoUser);
            this.pnlContent.Controls.Add(this.ptboxAvatar);
            this.pnlContent.Location = new System.Drawing.Point(65, 42);
            this.pnlContent.Name = "pnlContent";
            this.pnlContent.Size = new System.Drawing.Size(1349, 643);
            this.pnlContent.TabIndex = 53;
            // 
            // pnlContainsIcon
            // 
            this.pnlContainsIcon.Location = new System.Drawing.Point(18, 350);
            this.pnlContainsIcon.Name = "pnlContainsIcon";
            this.pnlContainsIcon.Size = new System.Drawing.Size(397, 227);
            this.pnlContainsIcon.TabIndex = 65;
            // 
            // lbScore
            // 
            this.lbScore.AutoSize = true;
            this.lbScore.Location = new System.Drawing.Point(210, 133);
            this.lbScore.Name = "lbScore";
            this.lbScore.Size = new System.Drawing.Size(0, 16);
            this.lbScore.TabIndex = 64;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(160, 133);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(41, 16);
            this.label2.TabIndex = 63;
            this.label2.Text = "Điểm:";
            // 
            // lbUserName
            // 
            this.lbUserName.AutoSize = true;
            this.lbUserName.Location = new System.Drawing.Point(162, 115);
            this.lbUserName.Name = "lbUserName";
            this.lbUserName.Size = new System.Drawing.Size(0, 16);
            this.lbUserName.TabIndex = 62;
            // 
            // btnRandomRoom
            // 
            this.btnRandomRoom.Location = new System.Drawing.Point(1017, 574);
            this.btnRandomRoom.Name = "btnRandomRoom";
            this.btnRandomRoom.Size = new System.Drawing.Size(154, 40);
            this.btnRandomRoom.TabIndex = 61;
            this.btnRandomRoom.Text = "Tham gia ngẫu nhiên";
            this.btnRandomRoom.UseVisualStyleBackColor = true;
            // 
            // btnCreateRoom
            // 
            this.btnCreateRoom.Location = new System.Drawing.Point(1177, 574);
            this.btnCreateRoom.Name = "btnCreateRoom";
            this.btnCreateRoom.Size = new System.Drawing.Size(154, 40);
            this.btnCreateRoom.TabIndex = 60;
            this.btnCreateRoom.Text = "Tạo phòng";
            this.btnCreateRoom.UseVisualStyleBackColor = true;
            // 
            // dtGridContainListRooms
            // 
            this.dtGridContainListRooms.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dtGridContainListRooms.Location = new System.Drawing.Point(481, 154);
            this.dtGridContainListRooms.Name = "dtGridContainListRooms";
            this.dtGridContainListRooms.RowHeadersWidth = 51;
            this.dtGridContainListRooms.RowTemplate.Height = 24;
            this.dtGridContainListRooms.Size = new System.Drawing.Size(850, 414);
            this.dtGridContainListRooms.TabIndex = 59;
            // 
            // btnSendMessage
            // 
            this.btnSendMessage.Location = new System.Drawing.Point(344, 574);
            this.btnSendMessage.Name = "btnSendMessage";
            this.btnSendMessage.Size = new System.Drawing.Size(71, 42);
            this.btnSendMessage.TabIndex = 58;
            this.btnSendMessage.Text = ">";
            this.btnSendMessage.UseVisualStyleBackColor = true;
            // 
            // btnSendIcon
            // 
            this.btnSendIcon.Location = new System.Drawing.Point(279, 574);
            this.btnSendIcon.Name = "btnSendIcon";
            this.btnSendIcon.Size = new System.Drawing.Size(59, 42);
            this.btnSendIcon.TabIndex = 57;
            this.btnSendIcon.Text = "...";
            this.btnSendIcon.UseVisualStyleBackColor = true;
            // 
            // txtSendMessage
            // 
            this.txtSendMessage.Location = new System.Drawing.Point(18, 574);
            this.txtSendMessage.Multiline = true;
            this.txtSendMessage.Name = "txtSendMessage";
            this.txtSendMessage.Size = new System.Drawing.Size(255, 42);
            this.txtSendMessage.TabIndex = 56;
            // 
            // rtbChat
            // 
            this.rtbChat.Location = new System.Drawing.Point(18, 230);
            this.rtbChat.Name = "rtbChat";
            this.rtbChat.Size = new System.Drawing.Size(397, 347);
            this.rtbChat.TabIndex = 55;
            this.rtbChat.Text = "";
            // 
            // btnHistory
            // 
            this.btnHistory.Location = new System.Drawing.Point(18, 184);
            this.btnHistory.Name = "btnHistory";
            this.btnHistory.Size = new System.Drawing.Size(159, 40);
            this.btnHistory.TabIndex = 66;
            this.btnHistory.Text = "Lịch sử đấu";
            // 
            // btnMakeFriend
            // 
            this.btnMakeFriend.Location = new System.Drawing.Point(1195, 89);
            this.btnMakeFriend.Name = "btnMakeFriend";
            this.btnMakeFriend.Size = new System.Drawing.Size(136, 51);
            this.btnMakeFriend.TabIndex = 54;
            this.btnMakeFriend.Text = "Danh sách";
            this.btnMakeFriend.UseVisualStyleBackColor = true;
            // 
            // btnRank
            // 
            this.btnRank.Location = new System.Drawing.Point(1044, 89);
            this.btnRank.Name = "btnRank";
            this.btnRank.Size = new System.Drawing.Size(136, 51);
            this.btnRank.TabIndex = 53;
            this.btnRank.Text = "Bảng xếp hạng";
            this.btnRank.UseVisualStyleBackColor = true;
            // 
            // btnLogout
            // 
            this.btnLogout.Location = new System.Drawing.Point(1195, 32);
            this.btnLogout.Name = "btnLogout";
            this.btnLogout.Size = new System.Drawing.Size(136, 51);
            this.btnLogout.TabIndex = 52;
            this.btnLogout.Text = "Đăng xuất";
            this.btnLogout.UseVisualStyleBackColor = true;
            // 
            // btnContainInfoUser
            // 
            this.btnContainInfoUser.Location = new System.Drawing.Point(1044, 32);
            this.btnContainInfoUser.Name = "btnContainInfoUser";
            this.btnContainInfoUser.Size = new System.Drawing.Size(136, 51);
            this.btnContainInfoUser.TabIndex = 51;
            this.btnContainInfoUser.Text = "Xem thông tin";
            this.btnContainInfoUser.UseVisualStyleBackColor = true;
            // 
            // ptboxAvatar
            // 
            this.ptboxAvatar.Location = new System.Drawing.Point(23, 32);
            this.ptboxAvatar.Name = "ptboxAvatar";
            this.ptboxAvatar.Size = new System.Drawing.Size(131, 117);
            this.ptboxAvatar.TabIndex = 50;
            this.ptboxAvatar.TabStop = false;
            // 
            // ptbAvatarPage
            // 
            this.ptbAvatarPage.Location = new System.Drawing.Point(0, 0);
            this.ptbAvatarPage.Name = "ptbAvatarPage";
            this.ptbAvatarPage.Size = new System.Drawing.Size(1121, 658);
            this.ptbAvatarPage.TabIndex = 0;
            this.ptbAvatarPage.TabStop = false;
            // 
            // userControlContentChatLeft1
            // 
            this.userControlContentChatLeft1.BackColor = System.Drawing.Color.Transparent;
            this.userControlContentChatLeft1.Location = new System.Drawing.Point(18, 230);
            this.userControlContentChatLeft1.Name = "userControlContentChatLeft1";
            this.userControlContentChatLeft1.Size = new System.Drawing.Size(336, 78);
            this.userControlContentChatLeft1.TabIndex = 67;
            // 
            // btnExit
            // 
            this.btnExit.Location = new System.Drawing.Point(1299, 0);
            this.btnExit.Name = "btnExit";
            this.btnExit.Size = new System.Drawing.Size(53, 48);
            this.btnExit.TabIndex = 0;
            this.btnExit.Text = "X";
            this.btnExit.UseVisualStyleBackColor = true;
            // 
            // pnlContainsUserControl
            // 
            this.pnlContainsUserControl.BackColor = System.Drawing.Color.DimGray;
            this.pnlContainsUserControl.Controls.Add(this.pnlChatOne);
            this.pnlContainsUserControl.Location = new System.Drawing.Point(0, 58);
            this.pnlContainsUserControl.Name = "pnlContainsUserControl";
            this.pnlContainsUserControl.Size = new System.Drawing.Size(1352, 584);
            this.pnlContainsUserControl.TabIndex = 1;
            // 
            // pnlChatOne
            // 
            this.pnlChatOne.BackColor = System.Drawing.Color.Gainsboro;
            this.pnlChatOne.Location = new System.Drawing.Point(0, 103);
            this.pnlChatOne.Name = "pnlChatOne";
            this.pnlChatOne.Size = new System.Drawing.Size(753, 454);
            this.pnlChatOne.TabIndex = 5;
            // 
            // pnlContainsChild
            // 
            this.pnlContainsChild.AutoSize = true;
            this.pnlContainsChild.BackColor = System.Drawing.Color.RosyBrown;
            this.pnlContainsChild.Controls.Add(this.pnlContainsUserControl);
            this.pnlContainsChild.Controls.Add(this.btnExit);
            this.pnlContainsChild.Location = new System.Drawing.Point(0, 0);
            this.pnlContainsChild.Name = "pnlContainsChild";
            this.pnlContainsChild.Size = new System.Drawing.Size(1355, 645);
            this.pnlContainsChild.TabIndex = 68;
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
            this.pnlContent.ResumeLayout(false);
            this.pnlContent.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dtGridContainListRooms)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ptboxAvatar)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ptbAvatarPage)).EndInit();
            this.pnlContainsUserControl.ResumeLayout(false);
            this.pnlContainsChild.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel pnlCoverPage;
        private System.Windows.Forms.Panel pnlContent;
        private System.Windows.Forms.Panel pnlContainsIcon;
        private System.Windows.Forms.Label lbScore;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label lbUserName;
        private System.Windows.Forms.Button btnRandomRoom;
        private System.Windows.Forms.Button btnCreateRoom;
        private System.Windows.Forms.DataGridView dtGridContainListRooms;
        private System.Windows.Forms.Button btnSendMessage;
        private System.Windows.Forms.Button btnSendIcon;
        private System.Windows.Forms.TextBox txtSendMessage;
        private System.Windows.Forms.RichTextBox rtbChat;
        private System.Windows.Forms.Button btnHistory;
        private System.Windows.Forms.Button btnMakeFriend;
        private System.Windows.Forms.Button btnRank;
        private System.Windows.Forms.Button btnLogout;
        private System.Windows.Forms.Button btnContainInfoUser;
        private System.Windows.Forms.PictureBox ptboxAvatar;
        private System.Windows.Forms.PictureBox ptbAvatarPage;
        private ContainUserControls.userControlContentChatLeft userControlContentChatLeft1;
        private System.Windows.Forms.Panel pnlContainsChild;
        private System.Windows.Forms.Panel pnlContainsUserControl;
        private System.Windows.Forms.Panel pnlChatOne;
        private System.Windows.Forms.Button btnExit;
    }
}