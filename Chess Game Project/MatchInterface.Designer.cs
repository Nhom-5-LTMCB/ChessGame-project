using System.Drawing;
using System.Windows.Forms;

namespace Chess_Game_Project
{
    partial class MatchInterface
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
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges1 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges2 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges3 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges4 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges5 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges6 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges7 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges8 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges9 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges10 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            pnlContent = new Panel();
            txtMessage = new Guna.UI2.WinForms.Guna2TextBox();
            txtCountTime = new Guna.UI2.WinForms.Guna2TextBox();
            btnSendData = new Guna.UI2.WinForms.Guna2Button();
            btnOutRoom = new Guna.UI2.WinForms.Guna2Button();
            btnSendIcon = new Guna.UI2.WinForms.Guna2Button();
            lbDifPlayer = new Label();
            lbCurrentPlayer = new Label();
            avtDifPlayer = new PictureBox();
            avtCurrentPlayer = new PictureBox();
            label3 = new Label();
            txtTurnUser = new TextBox();
            pnlContainsIcon = new Panel();
            listChat = new RichTextBox();
            pnlContainPieces = new Panel();
            pnlContent.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)avtDifPlayer).BeginInit();
            ((System.ComponentModel.ISupportInitialize)avtCurrentPlayer).BeginInit();
            SuspendLayout();
            // 
            // pnlContent
            // 
            pnlContent.Controls.Add(txtMessage);
            pnlContent.Controls.Add(txtCountTime);
            pnlContent.Controls.Add(btnSendData);
            pnlContent.Controls.Add(btnOutRoom);
            pnlContent.Controls.Add(btnSendIcon);
            pnlContent.Controls.Add(lbDifPlayer);
            pnlContent.Controls.Add(lbCurrentPlayer);
            pnlContent.Controls.Add(avtDifPlayer);
            pnlContent.Controls.Add(avtCurrentPlayer);
            pnlContent.Controls.Add(label3);
            pnlContent.Controls.Add(txtTurnUser);
            pnlContent.Controls.Add(pnlContainsIcon);
            pnlContent.Controls.Add(listChat);
            pnlContent.Controls.Add(pnlContainPieces);
            pnlContent.Location = new Point(2, 15);
            pnlContent.Margin = new Padding(3, 4, 3, 4);
            pnlContent.Name = "pnlContent";
            pnlContent.Size = new Size(1409, 814);
            pnlContent.TabIndex = 1;
            // 
            // txtMessage
            // 
            txtMessage.BorderColor = Color.Black;
            txtMessage.BorderRadius = 5;
            txtMessage.Cursor = Cursors.IBeam;
            txtMessage.CustomizableEdges = customizableEdges1;
            txtMessage.DefaultText = "";
            txtMessage.DisabledState.BorderColor = Color.FromArgb(208, 208, 208);
            txtMessage.DisabledState.FillColor = Color.FromArgb(226, 226, 226);
            txtMessage.DisabledState.ForeColor = Color.FromArgb(138, 138, 138);
            txtMessage.DisabledState.PlaceholderForeColor = Color.FromArgb(138, 138, 138);
            txtMessage.FillColor = Color.LemonChiffon;
            txtMessage.FocusedState.BorderColor = Color.FromArgb(94, 148, 255);
            txtMessage.Font = new Font("Segoe UI", 9F, FontStyle.Regular, GraphicsUnit.Point);
            txtMessage.HoverState.BorderColor = Color.FromArgb(94, 148, 255);
            txtMessage.Location = new Point(1007, 726);
            txtMessage.Margin = new Padding(3, 5, 3, 5);
            txtMessage.Name = "txtMessage";
            txtMessage.PasswordChar = '\0';
            txtMessage.PlaceholderText = "";
            txtMessage.SelectedText = "";
            txtMessage.ShadowDecoration.CustomizableEdges = customizableEdges2;
            txtMessage.Size = new Size(253, 52);
            txtMessage.TabIndex = 38;
            // 
            // txtCountTime
            // 
            txtCountTime.BorderColor = Color.Black;
            txtCountTime.BorderRadius = 5;
            txtCountTime.Cursor = Cursors.IBeam;
            txtCountTime.CustomizableEdges = customizableEdges3;
            txtCountTime.DefaultText = "";
            txtCountTime.DisabledState.BorderColor = Color.FromArgb(208, 208, 208);
            txtCountTime.DisabledState.FillColor = Color.FromArgb(226, 226, 226);
            txtCountTime.DisabledState.ForeColor = Color.FromArgb(138, 138, 138);
            txtCountTime.DisabledState.PlaceholderForeColor = Color.FromArgb(138, 138, 138);
            txtCountTime.FillColor = Color.LemonChiffon;
            txtCountTime.FocusedState.BorderColor = Color.FromArgb(94, 148, 255);
            txtCountTime.Font = new Font("Segoe UI", 9F, FontStyle.Regular, GraphicsUnit.Point);
            txtCountTime.HoverState.BorderColor = Color.FromArgb(94, 148, 255);
            txtCountTime.Location = new Point(618, 64);
            txtCountTime.Margin = new Padding(3, 5, 3, 5);
            txtCountTime.Name = "txtCountTime";
            txtCountTime.PasswordChar = '\0';
            txtCountTime.PlaceholderText = "";
            txtCountTime.SelectedText = "";
            txtCountTime.ShadowDecoration.CustomizableEdges = customizableEdges4;
            txtCountTime.Size = new Size(178, 60);
            txtCountTime.TabIndex = 37;
            // 
            // btnSendData
            // 
            btnSendData.BorderColor = Color.Red;
            btnSendData.BorderRadius = 5;
            btnSendData.CustomizableEdges = customizableEdges5;
            btnSendData.DisabledState.BorderColor = Color.DarkGray;
            btnSendData.DisabledState.CustomBorderColor = Color.DarkGray;
            btnSendData.DisabledState.FillColor = Color.FromArgb(169, 169, 169);
            btnSendData.DisabledState.ForeColor = Color.FromArgb(141, 141, 141);
            btnSendData.FillColor = Color.Red;
            btnSendData.Font = new Font("Segoe UI", 9F, FontStyle.Regular, GraphicsUnit.Point);
            btnSendData.ForeColor = Color.White;
            btnSendData.Location = new Point(1327, 726);
            btnSendData.Margin = new Padding(3, 4, 3, 4);
            btnSendData.Name = "btnSendData";
            btnSendData.ShadowDecoration.CustomizableEdges = customizableEdges6;
            btnSendData.Size = new Size(62, 52);
            btnSendData.TabIndex = 36;
            btnSendData.Text = ">";
            // 
            // btnOutRoom
            // 
            btnOutRoom.BorderRadius = 5;
            btnOutRoom.BorderThickness = 1;
            btnOutRoom.CustomizableEdges = customizableEdges7;
            btnOutRoom.DisabledState.BorderColor = Color.DarkGray;
            btnOutRoom.DisabledState.CustomBorderColor = Color.DarkGray;
            btnOutRoom.DisabledState.FillColor = Color.FromArgb(169, 169, 169);
            btnOutRoom.DisabledState.ForeColor = Color.FromArgb(141, 141, 141);
            btnOutRoom.FillColor = Color.FromArgb(255, 128, 128);
            btnOutRoom.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point);
            btnOutRoom.ForeColor = Color.White;
            btnOutRoom.Location = new Point(1107, 64);
            btnOutRoom.Margin = new Padding(3, 4, 3, 4);
            btnOutRoom.Name = "btnOutRoom";
            btnOutRoom.ShadowDecoration.CustomizableEdges = customizableEdges8;
            btnOutRoom.Size = new Size(125, 70);
            btnOutRoom.TabIndex = 34;
            btnOutRoom.Text = "Thoát phòng";
            // 
            // btnSendIcon
            // 
            btnSendIcon.BorderRadius = 5;
            btnSendIcon.CustomizableEdges = customizableEdges9;
            btnSendIcon.DisabledState.BorderColor = Color.DarkGray;
            btnSendIcon.DisabledState.CustomBorderColor = Color.DarkGray;
            btnSendIcon.DisabledState.FillColor = Color.FromArgb(169, 169, 169);
            btnSendIcon.DisabledState.ForeColor = Color.FromArgb(141, 141, 141);
            btnSendIcon.FillColor = Color.FromArgb(255, 128, 0);
            btnSendIcon.Font = new Font("Segoe UI", 9F, FontStyle.Regular, GraphicsUnit.Point);
            btnSendIcon.ForeColor = Color.White;
            btnSendIcon.Location = new Point(1266, 726);
            btnSendIcon.Margin = new Padding(3, 4, 3, 4);
            btnSendIcon.Name = "btnSendIcon";
            btnSendIcon.ShadowDecoration.CustomizableEdges = customizableEdges10;
            btnSendIcon.Size = new Size(61, 52);
            btnSendIcon.TabIndex = 35;
            btnSendIcon.Text = "...";
            // 
            // lbDifPlayer
            // 
            lbDifPlayer.AutoSize = true;
            lbDifPlayer.Location = new Point(917, 21);
            lbDifPlayer.Name = "lbDifPlayer";
            lbDifPlayer.Size = new Size(0, 20);
            lbDifPlayer.TabIndex = 29;
            // 
            // lbCurrentPlayer
            // 
            lbCurrentPlayer.AutoSize = true;
            lbCurrentPlayer.Location = new Point(427, 21);
            lbCurrentPlayer.Name = "lbCurrentPlayer";
            lbCurrentPlayer.Size = new Size(0, 20);
            lbCurrentPlayer.TabIndex = 28;
            // 
            // avtDifPlayer
            // 
            avtDifPlayer.Location = new Point(911, 45);
            avtDifPlayer.Margin = new Padding(3, 4, 3, 4);
            avtDifPlayer.Name = "avtDifPlayer";
            avtDifPlayer.Size = new Size(85, 89);
            avtDifPlayer.TabIndex = 27;
            avtDifPlayer.TabStop = false;
            // 
            // avtCurrentPlayer
            // 
            avtCurrentPlayer.Location = new Point(413, 45);
            avtCurrentPlayer.Margin = new Padding(3, 4, 3, 4);
            avtCurrentPlayer.Name = "avtCurrentPlayer";
            avtCurrentPlayer.Size = new Size(85, 89);
            avtCurrentPlayer.TabIndex = 26;
            avtCurrentPlayer.TabStop = false;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new Font("Segoe UI", 8F, FontStyle.Bold, GraphicsUnit.Point);
            label3.Location = new Point(1323, 18);
            label3.Name = "label3";
            label3.Size = new Size(66, 19);
            label3.TabIndex = 24;
            label3.Text = "Lượt của";
            // 
            // txtTurnUser
            // 
            txtTurnUser.Enabled = false;
            txtTurnUser.Location = new Point(1248, 45);
            txtTurnUser.Margin = new Padding(3, 4, 3, 4);
            txtTurnUser.Multiline = true;
            txtTurnUser.Name = "txtTurnUser";
            txtTurnUser.Size = new Size(141, 116);
            txtTurnUser.TabIndex = 23;
            // 
            // pnlContainsIcon
            // 
            pnlContainsIcon.Location = new Point(1007, 338);
            pnlContainsIcon.Margin = new Padding(3, 4, 3, 4);
            pnlContainsIcon.Name = "pnlContainsIcon";
            pnlContainsIcon.Size = new Size(382, 391);
            pnlContainsIcon.TabIndex = 22;
            // 
            // listChat
            // 
            listChat.Location = new Point(1009, 170);
            listChat.Margin = new Padding(3, 4, 3, 4);
            listChat.Name = "listChat";
            listChat.Size = new Size(380, 558);
            listChat.TabIndex = 16;
            listChat.Text = "";
            // 
            // pnlContainPieces
            // 
            pnlContainPieces.BackColor = SystemColors.ActiveCaption;
            pnlContainPieces.Location = new Point(3, 158);
            pnlContainPieces.Margin = new Padding(3, 4, 3, 4);
            pnlContainPieces.Name = "pnlContainPieces";
            pnlContainPieces.Size = new Size(290, 621);
            pnlContainPieces.TabIndex = 17;
            // 
            // MatchInterface
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1432, 854);
            Controls.Add(pnlContent);
            Margin = new Padding(3, 4, 3, 4);
            Name = "MatchInterface";
            Text = "MatchInterface";
            pnlContent.ResumeLayout(false);
            pnlContent.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)avtDifPlayer).EndInit();
            ((System.ComponentModel.ISupportInitialize)avtCurrentPlayer).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private System.Windows.Forms.Panel pnlContent;
        private System.Windows.Forms.Label lbDifPlayer;
        private System.Windows.Forms.Label lbCurrentPlayer;
        private System.Windows.Forms.PictureBox avtDifPlayer;
        private System.Windows.Forms.PictureBox avtCurrentPlayer;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtTurnUser;
        private System.Windows.Forms.Panel pnlContainsIcon;
        private System.Windows.Forms.RichTextBox listChat;
        private System.Windows.Forms.Panel pnlContainPieces;
        private Guna.UI2.WinForms.Guna2Button btnOutRoom;
        private Guna.UI2.WinForms.Guna2TextBox txtCountTime;
        private Guna.UI2.WinForms.Guna2Button btnSendData;
        private Guna.UI2.WinForms.Guna2Button btnSendIcon;
        private Guna.UI2.WinForms.Guna2TextBox txtMessage;
    }
}