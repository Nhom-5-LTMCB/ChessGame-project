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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            this.tbControls = new Guna.UI2.WinForms.Guna2TabControl();
            this.tbFindUser = new System.Windows.Forms.TabPage();
            this.dtAllUsers = new Guna.UI2.WinForms.Guna2DataGridView();
            this.txtFindUser = new Guna.UI2.WinForms.Guna2TextBox();
            this.btnFindUser = new Guna.UI2.WinForms.Guna2GradientButton();
            this.tbFriends = new System.Windows.Forms.TabPage();
            this.dtListFriends = new System.Windows.Forms.DataGridView();
            this.tbAccept = new System.Windows.Forms.TabPage();
            this.dtAcceptFriend = new System.Windows.Forms.DataGridView();
            this.tbControls.SuspendLayout();
            this.tbFindUser.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dtAllUsers)).BeginInit();
            this.tbFriends.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dtListFriends)).BeginInit();
            this.tbAccept.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dtAcceptFriend)).BeginInit();
            this.SuspendLayout();
            // 
            // tbControls
            // 
            this.tbControls.Alignment = System.Windows.Forms.TabAlignment.Left;
            this.tbControls.Controls.Add(this.tbFindUser);
            this.tbControls.Controls.Add(this.tbFriends);
            this.tbControls.Controls.Add(this.tbAccept);
            this.tbControls.Font = new System.Drawing.Font("Consolas", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tbControls.ItemSize = new System.Drawing.Size(180, 40);
            this.tbControls.Location = new System.Drawing.Point(8, 8);
            this.tbControls.Name = "tbControls";
            this.tbControls.SelectedIndex = 0;
            this.tbControls.Size = new System.Drawing.Size(867, 566);
            this.tbControls.TabButtonHoverState.BorderColor = System.Drawing.Color.Empty;
            this.tbControls.TabButtonHoverState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(52)))), ((int)(((byte)(70)))));
            this.tbControls.TabButtonHoverState.Font = new System.Drawing.Font("Segoe UI Semibold", 10F);
            this.tbControls.TabButtonHoverState.ForeColor = System.Drawing.Color.White;
            this.tbControls.TabButtonHoverState.InnerColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(52)))), ((int)(((byte)(70)))));
            this.tbControls.TabButtonIdleState.BorderColor = System.Drawing.Color.Empty;
            this.tbControls.TabButtonIdleState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(33)))), ((int)(((byte)(42)))), ((int)(((byte)(57)))));
            this.tbControls.TabButtonIdleState.Font = new System.Drawing.Font("Segoe UI Semibold", 10F);
            this.tbControls.TabButtonIdleState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(156)))), ((int)(((byte)(160)))), ((int)(((byte)(167)))));
            this.tbControls.TabButtonIdleState.InnerColor = System.Drawing.Color.FromArgb(((int)(((byte)(33)))), ((int)(((byte)(42)))), ((int)(((byte)(57)))));
            this.tbControls.TabButtonSelectedState.BorderColor = System.Drawing.Color.Empty;
            this.tbControls.TabButtonSelectedState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(29)))), ((int)(((byte)(37)))), ((int)(((byte)(49)))));
            this.tbControls.TabButtonSelectedState.Font = new System.Drawing.Font("Segoe UI Semibold", 10F);
            this.tbControls.TabButtonSelectedState.ForeColor = System.Drawing.Color.White;
            this.tbControls.TabButtonSelectedState.InnerColor = System.Drawing.Color.FromArgb(((int)(((byte)(76)))), ((int)(((byte)(132)))), ((int)(((byte)(255)))));
            this.tbControls.TabButtonSize = new System.Drawing.Size(180, 40);
            this.tbControls.TabIndex = 1;
            this.tbControls.TabMenuBackColor = System.Drawing.Color.DarkGray;
            // 
            // tbFindUser
            // 
            this.tbFindUser.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.tbFindUser.Controls.Add(this.dtAllUsers);
            this.tbFindUser.Controls.Add(this.txtFindUser);
            this.tbFindUser.Controls.Add(this.btnFindUser);
            this.tbFindUser.Font = new System.Drawing.Font("Consolas", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tbFindUser.Location = new System.Drawing.Point(184, 4);
            this.tbFindUser.Name = "tbFindUser";
            this.tbFindUser.Padding = new System.Windows.Forms.Padding(3);
            this.tbFindUser.Size = new System.Drawing.Size(679, 558);
            this.tbFindUser.TabIndex = 0;
            this.tbFindUser.Text = "Tìm kiếm";
            // 
            // dtAllUsers
            // 
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.White;
            this.dtAllUsers.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            this.dtAllUsers.BackgroundColor = System.Drawing.Color.DarkGray;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(88)))), ((int)(((byte)(255)))));
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Consolas", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dtAllUsers.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle2;
            this.dtAllUsers.ColumnHeadersHeight = 4;
            this.dtAllUsers.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.EnableResizing;
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = System.Drawing.Color.White;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Consolas", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle3.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(71)))), ((int)(((byte)(69)))), ((int)(((byte)(94)))));
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(231)))), ((int)(((byte)(229)))), ((int)(((byte)(255)))));
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(71)))), ((int)(((byte)(69)))), ((int)(((byte)(94)))));
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dtAllUsers.DefaultCellStyle = dataGridViewCellStyle3;
            this.dtAllUsers.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(231)))), ((int)(((byte)(229)))), ((int)(((byte)(255)))));
            this.dtAllUsers.Location = new System.Drawing.Point(44, 93);
            this.dtAllUsers.Name = "dtAllUsers";
            this.dtAllUsers.RowHeadersVisible = false;
            this.dtAllUsers.RowHeadersWidth = 51;
            this.dtAllUsers.RowTemplate.Height = 24;
            this.dtAllUsers.Size = new System.Drawing.Size(587, 419);
            this.dtAllUsers.TabIndex = 9;
            this.dtAllUsers.ThemeStyle.AlternatingRowsStyle.BackColor = System.Drawing.Color.White;
            this.dtAllUsers.ThemeStyle.AlternatingRowsStyle.Font = null;
            this.dtAllUsers.ThemeStyle.AlternatingRowsStyle.ForeColor = System.Drawing.Color.Empty;
            this.dtAllUsers.ThemeStyle.AlternatingRowsStyle.SelectionBackColor = System.Drawing.Color.Empty;
            this.dtAllUsers.ThemeStyle.AlternatingRowsStyle.SelectionForeColor = System.Drawing.Color.Empty;
            this.dtAllUsers.ThemeStyle.BackColor = System.Drawing.Color.DarkGray;
            this.dtAllUsers.ThemeStyle.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(231)))), ((int)(((byte)(229)))), ((int)(((byte)(255)))));
            this.dtAllUsers.ThemeStyle.HeaderStyle.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(88)))), ((int)(((byte)(255)))));
            this.dtAllUsers.ThemeStyle.HeaderStyle.BorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            this.dtAllUsers.ThemeStyle.HeaderStyle.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.dtAllUsers.ThemeStyle.HeaderStyle.ForeColor = System.Drawing.Color.White;
            this.dtAllUsers.ThemeStyle.HeaderStyle.HeaightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.EnableResizing;
            this.dtAllUsers.ThemeStyle.HeaderStyle.Height = 4;
            this.dtAllUsers.ThemeStyle.ReadOnly = false;
            this.dtAllUsers.ThemeStyle.RowsStyle.BackColor = System.Drawing.Color.White;
            this.dtAllUsers.ThemeStyle.RowsStyle.BorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.SingleHorizontal;
            this.dtAllUsers.ThemeStyle.RowsStyle.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.dtAllUsers.ThemeStyle.RowsStyle.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(71)))), ((int)(((byte)(69)))), ((int)(((byte)(94)))));
            this.dtAllUsers.ThemeStyle.RowsStyle.Height = 24;
            this.dtAllUsers.ThemeStyle.RowsStyle.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(231)))), ((int)(((byte)(229)))), ((int)(((byte)(255)))));
            this.dtAllUsers.ThemeStyle.RowsStyle.SelectionForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(71)))), ((int)(((byte)(69)))), ((int)(((byte)(94)))));
            // 
            // txtFindUser
            // 
            this.txtFindUser.BorderRadius = 10;
            this.txtFindUser.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.txtFindUser.DefaultText = "";
            this.txtFindUser.DisabledState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(208)))), ((int)(((byte)(208)))), ((int)(((byte)(208)))));
            this.txtFindUser.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(226)))), ((int)(((byte)(226)))), ((int)(((byte)(226)))));
            this.txtFindUser.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.txtFindUser.DisabledState.PlaceholderForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.txtFindUser.FocusedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.txtFindUser.Font = new System.Drawing.Font("Consolas", 10.2F);
            this.txtFindUser.HoverState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.txtFindUser.Location = new System.Drawing.Point(44, 58);
            this.txtFindUser.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.txtFindUser.Name = "txtFindUser";
            this.txtFindUser.PasswordChar = '\0';
            this.txtFindUser.PlaceholderText = "Nhập ID/tên người chơi khác";
            this.txtFindUser.SelectedText = "";
            this.txtFindUser.Size = new System.Drawing.Size(407, 28);
            this.txtFindUser.TabIndex = 8;
            // 
            // btnFindUser
            // 
            this.btnFindUser.BackColor = System.Drawing.Color.Transparent;
            this.btnFindUser.BorderColor = System.Drawing.Color.Transparent;
            this.btnFindUser.BorderRadius = 10;
            this.btnFindUser.ButtonMode = Guna.UI2.WinForms.Enums.ButtonMode.ToogleButton;
            this.btnFindUser.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.btnFindUser.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.btnFindUser.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.btnFindUser.DisabledState.FillColor2 = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.btnFindUser.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.btnFindUser.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(42)))), ((int)(((byte)(42)))), ((int)(((byte)(114)))));
            this.btnFindUser.FillColor2 = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(159)))), ((int)(((byte)(253)))));
            this.btnFindUser.Font = new System.Drawing.Font("Consolas", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnFindUser.ForeColor = System.Drawing.Color.White;
            this.btnFindUser.Location = new System.Drawing.Point(473, 57);
            this.btnFindUser.Name = "btnFindUser";
            this.btnFindUser.Size = new System.Drawing.Size(127, 29);
            this.btnFindUser.TabIndex = 7;
            this.btnFindUser.Text = "TÌm kiếm";
            // 
            // tbFriends
            // 
            this.tbFriends.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.tbFriends.Controls.Add(this.dtListFriends);
            this.tbFriends.Font = new System.Drawing.Font("Consolas", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tbFriends.Location = new System.Drawing.Point(184, 4);
            this.tbFriends.Name = "tbFriends";
            this.tbFriends.Padding = new System.Windows.Forms.Padding(3);
            this.tbFriends.Size = new System.Drawing.Size(679, 558);
            this.tbFriends.TabIndex = 1;
            this.tbFriends.Text = "Danh sách bạn bè";
            // 
            // dtListFriends
            // 
            this.dtListFriends.BackgroundColor = System.Drawing.Color.DarkGray;
            this.dtListFriends.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dtListFriends.Location = new System.Drawing.Point(20, 27);
            this.dtListFriends.Name = "dtListFriends";
            this.dtListFriends.RowHeadersWidth = 51;
            this.dtListFriends.RowTemplate.Height = 24;
            this.dtListFriends.Size = new System.Drawing.Size(639, 491);
            this.dtListFriends.TabIndex = 1;
            // 
            // tbAccept
            // 
            this.tbAccept.Controls.Add(this.dtAcceptFriend);
            this.tbAccept.Font = new System.Drawing.Font("Consolas", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tbAccept.Location = new System.Drawing.Point(184, 4);
            this.tbAccept.Name = "tbAccept";
            this.tbAccept.Padding = new System.Windows.Forms.Padding(3);
            this.tbAccept.Size = new System.Drawing.Size(679, 558);
            this.tbAccept.TabIndex = 2;
            this.tbAccept.Text = "Chấp nhận lời mời";
            this.tbAccept.UseVisualStyleBackColor = true;
            // 
            // dtAcceptFriend
            // 
            this.dtAcceptFriend.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dtAcceptFriend.Location = new System.Drawing.Point(24, 27);
            this.dtAcceptFriend.Name = "dtAcceptFriend";
            this.dtAcceptFriend.RowHeadersWidth = 51;
            this.dtAcceptFriend.RowTemplate.Height = 24;
            this.dtAcceptFriend.Size = new System.Drawing.Size(631, 505);
            this.dtAcceptFriend.TabIndex = 1;
            // 
            // userControlLists
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.tbControls);
            this.Name = "userControlLists";
            this.Size = new System.Drawing.Size(867, 566);
            this.tbControls.ResumeLayout(false);
            this.tbFindUser.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dtAllUsers)).EndInit();
            this.tbFriends.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dtListFriends)).EndInit();
            this.tbAccept.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dtAcceptFriend)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private Guna.UI2.WinForms.Guna2TabControl tbControls;
        private System.Windows.Forms.TabPage tbFindUser;
        private Guna.UI2.WinForms.Guna2DataGridView dtAllUsers;
        private Guna.UI2.WinForms.Guna2TextBox txtFindUser;
        private Guna.UI2.WinForms.Guna2GradientButton btnFindUser;
        private System.Windows.Forms.TabPage tbFriends;
        private System.Windows.Forms.DataGridView dtListFriends;
        private System.Windows.Forms.TabPage tbAccept;
        private System.Windows.Forms.DataGridView dtAcceptFriend;
    }
}
