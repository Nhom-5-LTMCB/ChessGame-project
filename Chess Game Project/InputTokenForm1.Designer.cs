namespace Chess_Game_Project
{
    partial class InputTokenForm1
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
            this.txtAuth = new System.Windows.Forms.TextBox();
            this.btnSendTokenAgain = new System.Windows.Forms.Button();
            this.authLabel = new System.Windows.Forms.Label();
            this.btnNext = new System.Windows.Forms.Button();
            this.pnlContent.SuspendLayout();
            this.SuspendLayout();
            // 
            // pnlContent
            // 
            this.pnlContent.Controls.Add(this.txtAuth);
            this.pnlContent.Controls.Add(this.btnSendTokenAgain);
            this.pnlContent.Controls.Add(this.authLabel);
            this.pnlContent.Controls.Add(this.btnNext);
            this.pnlContent.Location = new System.Drawing.Point(105, 25);
            this.pnlContent.Name = "pnlContent";
            this.pnlContent.Size = new System.Drawing.Size(591, 400);
            this.pnlContent.TabIndex = 15;
            // 
            // txtAuth
            // 
            this.txtAuth.Location = new System.Drawing.Point(188, 146);
            this.txtAuth.Name = "txtAuth";
            this.txtAuth.Size = new System.Drawing.Size(262, 22);
            this.txtAuth.TabIndex = 11;
            // 
            // btnSendTokenAgain
            // 
            this.btnSendTokenAgain.Location = new System.Drawing.Point(188, 175);
            this.btnSendTokenAgain.Name = "btnSendTokenAgain";
            this.btnSendTokenAgain.Size = new System.Drawing.Size(96, 27);
            this.btnSendTokenAgain.TabIndex = 13;
            this.btnSendTokenAgain.Text = "Gửi lại mã";
            this.btnSendTokenAgain.UseVisualStyleBackColor = true;
            // 
            // authLabel
            // 
            this.authLabel.AutoSize = true;
            this.authLabel.Location = new System.Drawing.Point(185, 127);
            this.authLabel.Name = "authLabel";
            this.authLabel.Size = new System.Drawing.Size(113, 16);
            this.authLabel.TabIndex = 10;
            this.authLabel.Text = "Nhập mã xác thực";
            // 
            // btnNext
            // 
            this.btnNext.Location = new System.Drawing.Point(232, 226);
            this.btnNext.Name = "btnNext";
            this.btnNext.Size = new System.Drawing.Size(153, 45);
            this.btnNext.TabIndex = 12;
            this.btnNext.Text = "Xác nhận";
            this.btnNext.UseVisualStyleBackColor = true;
            // 
            // InputTokenForm1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.pnlContent);
            this.Name = "InputTokenForm1";
            this.Text = "InputTokenForm1";
            this.pnlContent.ResumeLayout(false);
            this.pnlContent.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel pnlContent;
        private System.Windows.Forms.TextBox txtAuth;
        private System.Windows.Forms.Button btnSendTokenAgain;
        private System.Windows.Forms.Label authLabel;
        private System.Windows.Forms.Button btnNext;
    }
}