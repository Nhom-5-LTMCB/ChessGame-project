﻿namespace Chess_Game_Project
{
    partial class AuthInterface
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(AuthInterface));
            this.pnlContent = new System.Windows.Forms.Panel();
            this.guna2PictureBox2 = new Guna.UI2.WinForms.Guna2PictureBox();
            this.guna2PictureBox1 = new Guna.UI2.WinForms.Guna2PictureBox();
            this.label1 = new System.Windows.Forms.Label();
            this.txtAuthEmail = new Guna.UI2.WinForms.Guna2TextBox();
            this.btnBack = new Guna.UI2.WinForms.Guna2GradientButton();
            this.btnNext = new Guna.UI2.WinForms.Guna2GradientButton();
            this.txtAuthUserName = new Guna.UI2.WinForms.Guna2TextBox();
            this.errorHideLabel = new System.Windows.Forms.Label();
            this.pnlContent.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.guna2PictureBox2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.guna2PictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // pnlContent
            // 
            this.pnlContent.BackColor = System.Drawing.Color.NavajoWhite;
            this.pnlContent.Controls.Add(this.guna2PictureBox2);
            this.pnlContent.Controls.Add(this.guna2PictureBox1);
            this.pnlContent.Controls.Add(this.label1);
            this.pnlContent.Controls.Add(this.txtAuthEmail);
            this.pnlContent.Controls.Add(this.btnBack);
            this.pnlContent.Controls.Add(this.btnNext);
            this.pnlContent.Controls.Add(this.txtAuthUserName);
            this.pnlContent.Location = new System.Drawing.Point(205, 45);
            this.pnlContent.Name = "pnlContent";
            this.pnlContent.Size = new System.Drawing.Size(390, 360);
            this.pnlContent.TabIndex = 12;
            // 
            // guna2PictureBox2
            // 
            this.guna2PictureBox2.Image = ((System.Drawing.Image)(resources.GetObject("guna2PictureBox2.Image")));
            this.guna2PictureBox2.ImageRotate = 0F;
            this.guna2PictureBox2.Location = new System.Drawing.Point(15, 160);
            this.guna2PictureBox2.Name = "guna2PictureBox2";
            this.guna2PictureBox2.Size = new System.Drawing.Size(48, 48);
            this.guna2PictureBox2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.guna2PictureBox2.TabIndex = 28;
            this.guna2PictureBox2.TabStop = false;
            // 
            // guna2PictureBox1
            // 
            this.guna2PictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("guna2PictureBox1.Image")));
            this.guna2PictureBox1.ImageRotate = 0F;
            this.guna2PictureBox1.Location = new System.Drawing.Point(15, 58);
            this.guna2PictureBox1.Name = "guna2PictureBox1";
            this.guna2PictureBox1.Size = new System.Drawing.Size(48, 48);
            this.guna2PictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.guna2PictureBox1.TabIndex = 27;
            this.guna2PictureBox1.TabStop = false;
            // 
            // label1
            // 
            this.label1.Location = new System.Drawing.Point(151, 323);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(82, 10);
            this.label1.TabIndex = 26;
            this.label1.Text = "----------------------";
            this.label1.Click += new System.EventHandler(this.label1_Click);
            // 
            // txtAuthEmail
            // 
            this.txtAuthEmail.BorderColor = System.Drawing.Color.Black;
            this.txtAuthEmail.BorderRadius = 5;
            this.txtAuthEmail.BorderThickness = 2;
            this.txtAuthEmail.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.txtAuthEmail.DefaultText = "";
            this.txtAuthEmail.DisabledState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(208)))), ((int)(((byte)(208)))), ((int)(((byte)(208)))));
            this.txtAuthEmail.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(226)))), ((int)(((byte)(226)))), ((int)(((byte)(226)))));
            this.txtAuthEmail.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.txtAuthEmail.DisabledState.PlaceholderForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.txtAuthEmail.FocusedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.txtAuthEmail.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.txtAuthEmail.HoverState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.txtAuthEmail.Location = new System.Drawing.Point(69, 174);
            this.txtAuthEmail.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.txtAuthEmail.Name = "txtAuthEmail";
            this.txtAuthEmail.PasswordChar = '\0';
            this.txtAuthEmail.PlaceholderForeColor = System.Drawing.Color.DarkGray;
            this.txtAuthEmail.PlaceholderText = "Nhập email";
            this.txtAuthEmail.SelectedText = "";
            this.txtAuthEmail.Size = new System.Drawing.Size(296, 34);
            this.txtAuthEmail.TabIndex = 24;
            // 
            // btnBack
            // 
            this.btnBack.BorderRadius = 10;
            this.btnBack.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.btnBack.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.btnBack.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.btnBack.DisabledState.FillColor2 = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.btnBack.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.btnBack.FillColor = System.Drawing.Color.NavajoWhite;
            this.btnBack.FillColor2 = System.Drawing.Color.NavajoWhite;
            this.btnBack.Font = new System.Drawing.Font("Segoe UI", 12F);
            this.btnBack.ForeColor = System.Drawing.Color.Red;
            this.btnBack.Location = new System.Drawing.Point(128, 290);
            this.btnBack.Name = "btnBack";
            this.btnBack.Size = new System.Drawing.Size(127, 30);
            this.btnBack.TabIndex = 12;
            this.btnBack.Text = "Quay lại";
            // 
            // btnNext
            // 
            this.btnNext.BorderRadius = 20;
            this.btnNext.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.btnNext.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.btnNext.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.btnNext.DisabledState.FillColor2 = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.btnNext.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.btnNext.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(139)))), ((int)(((byte)(121)))), ((int)(((byte)(94)))));
            this.btnNext.FillColor2 = System.Drawing.Color.FromArgb(((int)(((byte)(139)))), ((int)(((byte)(121)))), ((int)(((byte)(94)))));
            this.btnNext.Font = new System.Drawing.Font("Consolas", 12F);
            this.btnNext.ForeColor = System.Drawing.Color.Moccasin;
            this.btnNext.Location = new System.Drawing.Point(103, 239);
            this.btnNext.Name = "btnNext";
            this.btnNext.Size = new System.Drawing.Size(182, 45);
            this.btnNext.TabIndex = 11;
            this.btnNext.Text = "Xác nhận";
            // 
            // txtAuthUserName
            // 
            this.txtAuthUserName.BorderColor = System.Drawing.Color.Black;
            this.txtAuthUserName.BorderRadius = 5;
            this.txtAuthUserName.BorderThickness = 2;
            this.txtAuthUserName.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.txtAuthUserName.DefaultText = "";
            this.txtAuthUserName.DisabledState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(208)))), ((int)(((byte)(208)))), ((int)(((byte)(208)))));
            this.txtAuthUserName.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(226)))), ((int)(((byte)(226)))), ((int)(((byte)(226)))));
            this.txtAuthUserName.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.txtAuthUserName.DisabledState.PlaceholderForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.txtAuthUserName.FocusedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.txtAuthUserName.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.txtAuthUserName.HoverState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.txtAuthUserName.Location = new System.Drawing.Point(69, 72);
            this.txtAuthUserName.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.txtAuthUserName.Name = "txtAuthUserName";
            this.txtAuthUserName.PasswordChar = '\0';
            this.txtAuthUserName.PlaceholderForeColor = System.Drawing.Color.DarkGray;
            this.txtAuthUserName.PlaceholderText = "Nhập tài khoản";
            this.txtAuthUserName.SelectedText = "";
            this.txtAuthUserName.Size = new System.Drawing.Size(296, 34);
            this.txtAuthUserName.TabIndex = 22;
            this.txtAuthUserName.TextChanged += new System.EventHandler(this.txtAuthUserName_TextChanged);
            // 
            // errorHideLabel
            // 
            this.errorHideLabel.AutoSize = true;
            this.errorHideLabel.Location = new System.Drawing.Point(550, 349);
            this.errorHideLabel.Name = "errorHideLabel";
            this.errorHideLabel.Size = new System.Drawing.Size(0, 16);
            this.errorHideLabel.TabIndex = 23;
            // 
            // AuthInterface
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.errorHideLabel);
            this.Controls.Add(this.pnlContent);
            this.Name = "AuthInterface";
            this.Text = "AuthInterface";
            this.pnlContent.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.guna2PictureBox2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.guna2PictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel pnlContent;
        private Guna.UI2.WinForms.Guna2GradientButton btnBack;
        private Guna.UI2.WinForms.Guna2GradientButton btnNext;
        private Guna.UI2.WinForms.Guna2TextBox txtAuthUserName;
        private Guna.UI2.WinForms.Guna2TextBox txtAuthEmail;
        private System.Windows.Forms.Label errorHideLabel;
        private System.Windows.Forms.Label label1;
        private Guna.UI2.WinForms.Guna2PictureBox guna2PictureBox2;
        private Guna.UI2.WinForms.Guna2PictureBox guna2PictureBox1;
    }
}