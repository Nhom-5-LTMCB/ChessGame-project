namespace Chess_Game_Project.ContainUserControls
{
    partial class userControlChatOne
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
            this.pnlContainIconsChatOne = new System.Windows.Forms.Panel();
            this.btnCloseForm = new System.Windows.Forms.Button();
            this.btnSendMsgChatOne = new System.Windows.Forms.Button();
            this.btnSendIconChatOne = new System.Windows.Forms.Button();
            this.txtSendMsgChatOne = new System.Windows.Forms.TextBox();
            this.rtbContentChatOne = new System.Windows.Forms.RichTextBox();
            this.userControlContentChatLeft1 = new Chess_Game_Project.ContainUserControls.userControlContentChatMessage();
            this.SuspendLayout();
            // 
            // pnlContainIconsChatOne
            // 
            this.pnlContainIconsChatOne.AutoScroll = true;
            this.pnlContainIconsChatOne.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.pnlContainIconsChatOne.Location = new System.Drawing.Point(370, 98);
            this.pnlContainIconsChatOne.Name = "pnlContainIconsChatOne";
            this.pnlContainIconsChatOne.Size = new System.Drawing.Size(224, 271);
            this.pnlContainIconsChatOne.TabIndex = 11;
            // 
            // btnCloseForm
            // 
            this.btnCloseForm.Location = new System.Drawing.Point(519, 24);
            this.btnCloseForm.Name = "btnCloseForm";
            this.btnCloseForm.Size = new System.Drawing.Size(74, 22);
            this.btnCloseForm.TabIndex = 10;
            this.btnCloseForm.Text = "Thoát";
            this.btnCloseForm.UseVisualStyleBackColor = true;
            // 
            // btnSendMsgChatOne
            // 
            this.btnSendMsgChatOne.Location = new System.Drawing.Point(500, 374);
            this.btnSendMsgChatOne.Name = "btnSendMsgChatOne";
            this.btnSendMsgChatOne.Size = new System.Drawing.Size(94, 36);
            this.btnSendMsgChatOne.TabIndex = 9;
            this.btnSendMsgChatOne.Text = "Gửi";
            this.btnSendMsgChatOne.UseVisualStyleBackColor = true;
            // 
            // btnSendIconChatOne
            // 
            this.btnSendIconChatOne.Location = new System.Drawing.Point(411, 374);
            this.btnSendIconChatOne.Name = "btnSendIconChatOne";
            this.btnSendIconChatOne.Size = new System.Drawing.Size(83, 36);
            this.btnSendIconChatOne.TabIndex = 8;
            this.btnSendIconChatOne.Text = "...";
            this.btnSendIconChatOne.UseVisualStyleBackColor = true;
            // 
            // txtSendMsgChatOne
            // 
            this.txtSendMsgChatOne.Location = new System.Drawing.Point(3, 374);
            this.txtSendMsgChatOne.Multiline = true;
            this.txtSendMsgChatOne.Name = "txtSendMsgChatOne";
            this.txtSendMsgChatOne.Size = new System.Drawing.Size(404, 36);
            this.txtSendMsgChatOne.TabIndex = 7;
            // 
            // rtbContentChatOne
            // 
            this.rtbContentChatOne.Location = new System.Drawing.Point(3, 45);
            this.rtbContentChatOne.Name = "rtbContentChatOne";
            this.rtbContentChatOne.Size = new System.Drawing.Size(592, 324);
            this.rtbContentChatOne.TabIndex = 6;
            this.rtbContentChatOne.Text = "";
            // 
            // userControlContentChatLeft1
            // 
            this.userControlContentChatLeft1.AutoSize = true;
            this.userControlContentChatLeft1.BackColor = System.Drawing.Color.Transparent;
            this.userControlContentChatLeft1.content = null;
            this.userControlContentChatLeft1.Location = new System.Drawing.Point(10, 54);
            this.userControlContentChatLeft1.Name = "userControlContentChatLeft1";
            this.userControlContentChatLeft1.Size = new System.Drawing.Size(294, 73);
            this.userControlContentChatLeft1.TabIndex = 12;
            // 
            // userControlChatOne
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.userControlContentChatLeft1);
            this.Controls.Add(this.pnlContainIconsChatOne);
            this.Controls.Add(this.btnCloseForm);
            this.Controls.Add(this.btnSendMsgChatOne);
            this.Controls.Add(this.btnSendIconChatOne);
            this.Controls.Add(this.txtSendMsgChatOne);
            this.Controls.Add(this.rtbContentChatOne);
            this.Font = new System.Drawing.Font("Consolas", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.Name = "userControlChatOne";
            this.Size = new System.Drawing.Size(599, 414);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel pnlContainIconsChatOne;
        private System.Windows.Forms.Button btnCloseForm;
        private System.Windows.Forms.Button btnSendMsgChatOne;
        private System.Windows.Forms.Button btnSendIconChatOne;
        private System.Windows.Forms.TextBox txtSendMsgChatOne;
        private System.Windows.Forms.RichTextBox rtbContentChatOne;
        private userControlContentChatMessage userControlContentChatLeft1;
    }
}
