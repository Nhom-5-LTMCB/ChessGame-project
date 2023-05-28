namespace Chess_Game_Project
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
            this.pnlContent = new System.Windows.Forms.Panel();
            this.btnBack = new System.Windows.Forms.Button();
            this.userNamLabel = new System.Windows.Forms.Label();
            this.btnNext = new System.Windows.Forms.Button();
            this.txtAuthUserName = new System.Windows.Forms.TextBox();
            this.txtAuthEmail = new System.Windows.Forms.TextBox();
            this.gmailLabel = new System.Windows.Forms.Label();
            this.pnlContent.SuspendLayout();
            this.SuspendLayout();
            // 
            // pnlContent
            // 
            this.pnlContent.Controls.Add(this.btnBack);
            this.pnlContent.Controls.Add(this.userNamLabel);
            this.pnlContent.Controls.Add(this.btnNext);
            this.pnlContent.Controls.Add(this.txtAuthUserName);
            this.pnlContent.Controls.Add(this.txtAuthEmail);
            this.pnlContent.Controls.Add(this.gmailLabel);
            this.pnlContent.Location = new System.Drawing.Point(205, 45);
            this.pnlContent.Name = "pnlContent";
            this.pnlContent.Size = new System.Drawing.Size(390, 360);
            this.pnlContent.TabIndex = 12;
            // 
            // btnBack
            // 
            this.btnBack.Location = new System.Drawing.Point(176, 205);
            this.btnBack.Name = "btnBack";
            this.btnBack.Size = new System.Drawing.Size(120, 45);
            this.btnBack.TabIndex = 10;
            this.btnBack.Text = "Quay lại";
            this.btnBack.UseVisualStyleBackColor = true;
            // 
            // userNamLabel
            // 
            this.userNamLabel.AutoSize = true;
            this.userNamLabel.Location = new System.Drawing.Point(31, 58);
            this.userNamLabel.Name = "userNamLabel";
            this.userNamLabel.Size = new System.Drawing.Size(103, 16);
            this.userNamLabel.TabIndex = 5;
            this.userNamLabel.Text = "Nhập username";
            // 
            // btnNext
            // 
            this.btnNext.Location = new System.Drawing.Point(34, 205);
            this.btnNext.Name = "btnNext";
            this.btnNext.Size = new System.Drawing.Size(136, 45);
            this.btnNext.TabIndex = 9;
            this.btnNext.Text = "Xác nhận";
            this.btnNext.UseVisualStyleBackColor = true;
            // 
            // txtAuthUserName
            // 
            this.txtAuthUserName.Location = new System.Drawing.Point(34, 77);
            this.txtAuthUserName.Name = "txtAuthUserName";
            this.txtAuthUserName.Size = new System.Drawing.Size(262, 22);
            this.txtAuthUserName.TabIndex = 6;
            // 
            // txtAuthEmail
            // 
            this.txtAuthEmail.Location = new System.Drawing.Point(34, 147);
            this.txtAuthEmail.Name = "txtAuthEmail";
            this.txtAuthEmail.Size = new System.Drawing.Size(262, 22);
            this.txtAuthEmail.TabIndex = 8;
            // 
            // gmailLabel
            // 
            this.gmailLabel.AutoSize = true;
            this.gmailLabel.Location = new System.Drawing.Point(31, 128);
            this.gmailLabel.Name = "gmailLabel";
            this.gmailLabel.Size = new System.Drawing.Size(76, 16);
            this.gmailLabel.TabIndex = 7;
            this.gmailLabel.Text = "Nhập email";
            // 
            // AuthInterface
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.pnlContent);
            this.Name = "AuthInterface";
            this.Text = "AuthInterface";
            this.pnlContent.ResumeLayout(false);
            this.pnlContent.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel pnlContent;
        private System.Windows.Forms.Button btnBack;
        private System.Windows.Forms.Label userNamLabel;
        private System.Windows.Forms.Button btnNext;
        private System.Windows.Forms.TextBox txtAuthUserName;
        private System.Windows.Forms.TextBox txtAuthEmail;
        private System.Windows.Forms.Label gmailLabel;
    }
}