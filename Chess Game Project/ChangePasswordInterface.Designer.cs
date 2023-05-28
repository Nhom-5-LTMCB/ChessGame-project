namespace Chess_Game_Project
{
    partial class ChangePasswordInterface
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
            this.btnNext = new System.Windows.Forms.Button();
            this.errorConfirmPassword = new System.Windows.Forms.Label();
            this.passwordLabel = new System.Windows.Forms.Label();
            this.errorNewPassword = new System.Windows.Forms.Label();
            this.txtNewPassword = new System.Windows.Forms.TextBox();
            this.txtConfirmPassword = new System.Windows.Forms.TextBox();
            this.confirmPasswordLabel = new System.Windows.Forms.Label();
            this.pnlContent.SuspendLayout();
            this.SuspendLayout();
            // 
            // pnlContent
            // 
            this.pnlContent.Controls.Add(this.btnNext);
            this.pnlContent.Controls.Add(this.errorConfirmPassword);
            this.pnlContent.Controls.Add(this.passwordLabel);
            this.pnlContent.Controls.Add(this.errorNewPassword);
            this.pnlContent.Controls.Add(this.txtNewPassword);
            this.pnlContent.Controls.Add(this.txtConfirmPassword);
            this.pnlContent.Controls.Add(this.confirmPasswordLabel);
            this.pnlContent.Location = new System.Drawing.Point(31, 33);
            this.pnlContent.Name = "pnlContent";
            this.pnlContent.Size = new System.Drawing.Size(738, 384);
            this.pnlContent.TabIndex = 22;
            // 
            // btnNext
            // 
            this.btnNext.Location = new System.Drawing.Point(296, 233);
            this.btnNext.Name = "btnNext";
            this.btnNext.Size = new System.Drawing.Size(153, 45);
            this.btnNext.TabIndex = 16;
            this.btnNext.Text = "Xác nhận";
            this.btnNext.UseVisualStyleBackColor = true;
            // 
            // errorConfirmPassword
            // 
            this.errorConfirmPassword.AutoSize = true;
            this.errorConfirmPassword.Location = new System.Drawing.Point(110, 131);
            this.errorConfirmPassword.Name = "errorConfirmPassword";
            this.errorConfirmPassword.Size = new System.Drawing.Size(0, 16);
            this.errorConfirmPassword.TabIndex = 20;
            // 
            // passwordLabel
            // 
            this.passwordLabel.AutoSize = true;
            this.passwordLabel.Location = new System.Drawing.Point(247, 71);
            this.passwordLabel.Name = "passwordLabel";
            this.passwordLabel.Size = new System.Drawing.Size(122, 16);
            this.passwordLabel.TabIndex = 14;
            this.passwordLabel.Text = "Nhập mật khẩu mới";
            // 
            // errorNewPassword
            // 
            this.errorNewPassword.AutoSize = true;
            this.errorNewPassword.Location = new System.Drawing.Point(110, 49);
            this.errorNewPassword.Name = "errorNewPassword";
            this.errorNewPassword.Size = new System.Drawing.Size(0, 16);
            this.errorNewPassword.TabIndex = 19;
            // 
            // txtNewPassword
            // 
            this.txtNewPassword.Location = new System.Drawing.Point(250, 90);
            this.txtNewPassword.Name = "txtNewPassword";
            this.txtNewPassword.Size = new System.Drawing.Size(262, 22);
            this.txtNewPassword.TabIndex = 15;
            // 
            // txtConfirmPassword
            // 
            this.txtConfirmPassword.Location = new System.Drawing.Point(250, 172);
            this.txtConfirmPassword.Name = "txtConfirmPassword";
            this.txtConfirmPassword.Size = new System.Drawing.Size(262, 22);
            this.txtConfirmPassword.TabIndex = 18;
            // 
            // confirmPasswordLabel
            // 
            this.confirmPasswordLabel.AutoSize = true;
            this.confirmPasswordLabel.Location = new System.Drawing.Point(247, 153);
            this.confirmPasswordLabel.Name = "confirmPasswordLabel";
            this.confirmPasswordLabel.Size = new System.Drawing.Size(119, 16);
            this.confirmPasswordLabel.TabIndex = 17;
            this.confirmPasswordLabel.Text = "Xác nhận mật khẩu";
            // 
            // ChangePasswordInterface
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.pnlContent);
            this.Name = "ChangePasswordInterface";
            this.Text = "ChangePasswordInterface";
            this.pnlContent.ResumeLayout(false);
            this.pnlContent.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel pnlContent;
        private System.Windows.Forms.Button btnNext;
        private System.Windows.Forms.Label errorConfirmPassword;
        private System.Windows.Forms.Label passwordLabel;
        private System.Windows.Forms.Label errorNewPassword;
        private System.Windows.Forms.TextBox txtNewPassword;
        private System.Windows.Forms.TextBox txtConfirmPassword;
        private System.Windows.Forms.Label confirmPasswordLabel;
    }
}