namespace Chess_Game_Project.ContainUserControls
{
    partial class userControlLists
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.pnlListFriends = new System.Windows.Forms.Panel();
            this.tbControls = new System.Windows.Forms.TabControl();
            this.tbFindUser = new System.Windows.Forms.TabPage();
            this.dtAllUsers = new System.Windows.Forms.DataGridView();
            this.btnFindUser = new System.Windows.Forms.Button();
            this.txtFindUser = new System.Windows.Forms.TextBox();
            this.tbFriends = new System.Windows.Forms.TabPage();
            this.dtListFriends = new System.Windows.Forms.DataGridView();
            this.tbAccept = new System.Windows.Forms.TabPage();
            this.dtAcceptFriend = new System.Windows.Forms.DataGridView();
            this.pnlListFriends.SuspendLayout();
            this.tbControls.SuspendLayout();
            this.tbFindUser.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dtAllUsers)).BeginInit();
            this.tbFriends.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dtListFriends)).BeginInit();
            this.tbAccept.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dtAcceptFriend)).BeginInit();
            this.SuspendLayout();
            // 
            // pnlListFriends
            // 
            this.pnlListFriends.Controls.Add(this.tbControls);
            this.pnlListFriends.Location = new System.Drawing.Point(0, 0);
            this.pnlListFriends.Name = "pnlListFriends";
            this.pnlListFriends.Size = new System.Drawing.Size(866, 566);
            this.pnlListFriends.TabIndex = 31;
            this.pnlListFriends.Visible = false;
            // 
            // tbControls
            // 
            this.tbControls.Controls.Add(this.tbFindUser);
            this.tbControls.Controls.Add(this.tbFriends);
            this.tbControls.Controls.Add(this.tbAccept);
            this.tbControls.Location = new System.Drawing.Point(0, 54);
            this.tbControls.Name = "tbControls";
            this.tbControls.SelectedIndex = 0;
            this.tbControls.Size = new System.Drawing.Size(866, 512);
            this.tbControls.TabIndex = 1;
            // 
            // tbFindUser
            // 
            this.tbFindUser.Controls.Add(this.dtAllUsers);
            this.tbFindUser.Controls.Add(this.btnFindUser);
            this.tbFindUser.Controls.Add(this.txtFindUser);
            this.tbFindUser.Location = new System.Drawing.Point(4, 25);
            this.tbFindUser.Name = "tbFindUser";
            this.tbFindUser.Padding = new System.Windows.Forms.Padding(10);
            this.tbFindUser.Size = new System.Drawing.Size(858, 483);
            this.tbFindUser.TabIndex = 0;
            this.tbFindUser.Text = "Tìm kiếm";
            this.tbFindUser.UseVisualStyleBackColor = true;
            // 
            // dtAllUsers
            // 
            this.dtAllUsers.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dtAllUsers.Location = new System.Drawing.Point(76, 61);
            this.dtAllUsers.Name = "dtAllUsers";
            this.dtAllUsers.RowHeadersWidth = 51;
            this.dtAllUsers.RowTemplate.Height = 24;
            this.dtAllUsers.Size = new System.Drawing.Size(696, 419);
            this.dtAllUsers.TabIndex = 3;
            // 
            // btnFindUser
            // 
            this.btnFindUser.Location = new System.Drawing.Point(463, 20);
            this.btnFindUser.Name = "btnFindUser";
            this.btnFindUser.Size = new System.Drawing.Size(126, 23);
            this.btnFindUser.TabIndex = 2;
            this.btnFindUser.Text = "Tìm kiếm";
            this.btnFindUser.UseVisualStyleBackColor = true;
            // 
            // txtFindUser
            // 
            this.txtFindUser.Location = new System.Drawing.Point(235, 20);
            this.txtFindUser.Name = "txtFindUser";
            this.txtFindUser.Size = new System.Drawing.Size(222, 22);
            this.txtFindUser.TabIndex = 1;
            // 
            // tbFriends
            // 
            this.tbFriends.Controls.Add(this.dtListFriends);
            this.tbFriends.Location = new System.Drawing.Point(4, 25);
            this.tbFriends.Name = "tbFriends";
            this.tbFriends.Padding = new System.Windows.Forms.Padding(3);
            this.tbFriends.Size = new System.Drawing.Size(858, 483);
            this.tbFriends.TabIndex = 1;
            this.tbFriends.Text = "Danh sách bạn bè";
            this.tbFriends.UseVisualStyleBackColor = true;
            // 
            // dtListFriends
            // 
            this.dtListFriends.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dtListFriends.Location = new System.Drawing.Point(51, 14);
            this.dtListFriends.Name = "dtListFriends";
            this.dtListFriends.RowHeadersWidth = 51;
            this.dtListFriends.RowTemplate.Height = 24;
            this.dtListFriends.Size = new System.Drawing.Size(770, 469);
            this.dtListFriends.TabIndex = 0;
            // 
            // tbAccept
            // 
            this.tbAccept.Controls.Add(this.dtAcceptFriend);
            this.tbAccept.Location = new System.Drawing.Point(4, 25);
            this.tbAccept.Name = "tbAccept";
            this.tbAccept.Padding = new System.Windows.Forms.Padding(3);
            this.tbAccept.Size = new System.Drawing.Size(858, 483);
            this.tbAccept.TabIndex = 2;
            this.tbAccept.Text = "Chấp nhận lời mời";
            this.tbAccept.UseVisualStyleBackColor = true;
            // 
            // dtAcceptFriend
            // 
            this.dtAcceptFriend.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dtAcceptFriend.Location = new System.Drawing.Point(87, 41);
            this.dtAcceptFriend.Name = "dtAcceptFriend";
            this.dtAcceptFriend.RowHeadersWidth = 51;
            this.dtAcceptFriend.RowTemplate.Height = 24;
            this.dtAcceptFriend.Size = new System.Drawing.Size(688, 429);
            this.dtAcceptFriend.TabIndex = 0;
            // 
            // userControlLists
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.pnlListFriends);
            this.Name = "userControlLists";
            this.Size = new System.Drawing.Size(867, 566);
            this.pnlListFriends.ResumeLayout(false);
            this.tbControls.ResumeLayout(false);
            this.tbFindUser.ResumeLayout(false);
            this.tbFindUser.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dtAllUsers)).EndInit();
            this.tbFriends.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dtListFriends)).EndInit();
            this.tbAccept.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dtAcceptFriend)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel pnlListFriends;
        private System.Windows.Forms.TabControl tbControls;
        private System.Windows.Forms.TabPage tbFindUser;
        private System.Windows.Forms.DataGridView dtAllUsers;
        private System.Windows.Forms.Button btnFindUser;
        private System.Windows.Forms.TextBox txtFindUser;
        private System.Windows.Forms.TabPage tbFriends;
        private System.Windows.Forms.DataGridView dtListFriends;
        private System.Windows.Forms.TabPage tbAccept;
        private System.Windows.Forms.DataGridView dtAcceptFriend;
    }
}
