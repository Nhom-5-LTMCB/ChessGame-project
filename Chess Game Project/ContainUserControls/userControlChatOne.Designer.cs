﻿namespace Chess_Game_Project.ContainUserControls
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
            this.userControlContentChatLeft1 = new Chess_Game_Project.ContainUserControls.userControlContentChatLeft();
            this.SuspendLayout();
            // 
            // pnlContainIconsChatOne
            // 
            this.pnlContainIconsChatOne.AutoScroll = true;
            this.pnlContainIconsChatOne.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.pnlContainIconsChatOne.Location = new System.Drawing.Point(423, 104);
            this.pnlContainIconsChatOne.Name = "pnlContainIconsChatOne";
            this.pnlContainIconsChatOne.Size = new System.Drawing.Size(256, 289);
            this.pnlContainIconsChatOne.TabIndex = 11;
            // 
            // btnCloseForm
            // 
            this.btnCloseForm.Location = new System.Drawing.Point(593, 26);
            this.btnCloseForm.Name = "btnCloseForm";
            this.btnCloseForm.Size = new System.Drawing.Size(85, 23);
            this.btnCloseForm.TabIndex = 10;
            this.btnCloseForm.Text = "Close";
            this.btnCloseForm.UseVisualStyleBackColor = true;
            // 
            // btnSendMsgChatOne
            // 
            this.btnSendMsgChatOne.Location = new System.Drawing.Point(571, 399);
            this.btnSendMsgChatOne.Name = "btnSendMsgChatOne";
            this.btnSendMsgChatOne.Size = new System.Drawing.Size(107, 38);
            this.btnSendMsgChatOne.TabIndex = 9;
            this.btnSendMsgChatOne.Text = "Send";
            this.btnSendMsgChatOne.UseVisualStyleBackColor = true;
            // 
            // btnSendIconChatOne
            // 
            this.btnSendIconChatOne.Location = new System.Drawing.Point(470, 399);
            this.btnSendIconChatOne.Name = "btnSendIconChatOne";
            this.btnSendIconChatOne.Size = new System.Drawing.Size(95, 38);
            this.btnSendIconChatOne.TabIndex = 8;
            this.btnSendIconChatOne.Text = "...";
            this.btnSendIconChatOne.UseVisualStyleBackColor = true;
            // 
            // txtSendMsgChatOne
            // 
            this.txtSendMsgChatOne.Location = new System.Drawing.Point(3, 399);
            this.txtSendMsgChatOne.Multiline = true;
            this.txtSendMsgChatOne.Name = "txtSendMsgChatOne";
            this.txtSendMsgChatOne.Size = new System.Drawing.Size(461, 38);
            this.txtSendMsgChatOne.TabIndex = 7;
            // 
            // rtbContentChatOne
            // 
            this.rtbContentChatOne.Location = new System.Drawing.Point(3, 48);
            this.rtbContentChatOne.Name = "rtbContentChatOne";
            this.rtbContentChatOne.Size = new System.Drawing.Size(676, 345);
            this.rtbContentChatOne.TabIndex = 6;
            this.rtbContentChatOne.Text = "";
            // 
            // userControlContentChatLeft1
            // 
            this.userControlContentChatLeft1.BackColor = System.Drawing.Color.Transparent;
            this.userControlContentChatLeft1.Location = new System.Drawing.Point(12, 58);
            this.userControlContentChatLeft1.Name = "userControlContentChatLeft1";
            this.userControlContentChatLeft1.Size = new System.Drawing.Size(336, 78);
            this.userControlContentChatLeft1.TabIndex = 12;
            // 
            // userControlChatOne
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.userControlContentChatLeft1);
            this.Controls.Add(this.pnlContainIconsChatOne);
            this.Controls.Add(this.btnCloseForm);
            this.Controls.Add(this.btnSendMsgChatOne);
            this.Controls.Add(this.btnSendIconChatOne);
            this.Controls.Add(this.txtSendMsgChatOne);
            this.Controls.Add(this.rtbContentChatOne);
            this.Name = "userControlChatOne";
            this.Size = new System.Drawing.Size(685, 442);
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
        private userControlContentChatLeft userControlContentChatLeft1;
    }
}
