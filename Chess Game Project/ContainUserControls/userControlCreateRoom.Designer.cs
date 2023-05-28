namespace Chess_Game_Project.ContainUserControls
{
    partial class userControlCreateRoom
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
            this.pnlCreateRoom = new System.Windows.Forms.Panel();
            this.txtBetPoints = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.btnAcceptCreateRoom = new System.Windows.Forms.Button();
            this.txtRoomName = new System.Windows.Forms.TextBox();
            this.pnlCreateRoom.SuspendLayout();
            this.SuspendLayout();
            // 
            // pnlCreateRoom
            // 
            this.pnlCreateRoom.Controls.Add(this.txtBetPoints);
            this.pnlCreateRoom.Controls.Add(this.label3);
            this.pnlCreateRoom.Controls.Add(this.label1);
            this.pnlCreateRoom.Controls.Add(this.btnAcceptCreateRoom);
            this.pnlCreateRoom.Controls.Add(this.txtRoomName);
            this.pnlCreateRoom.Location = new System.Drawing.Point(0, 3);
            this.pnlCreateRoom.Name = "pnlCreateRoom";
            this.pnlCreateRoom.Size = new System.Drawing.Size(437, 241);
            this.pnlCreateRoom.TabIndex = 3;
            // 
            // txtBetPoints
            // 
            this.txtBetPoints.Location = new System.Drawing.Point(99, 117);
            this.txtBetPoints.Name = "txtBetPoints";
            this.txtBetPoints.Size = new System.Drawing.Size(245, 22);
            this.txtBetPoints.TabIndex = 9;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(97, 98);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(105, 16);
            this.label3.TabIndex = 8;
            this.label3.Text = "Nhập điểm cược";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(97, 35);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(102, 16);
            this.label1.TabIndex = 7;
            this.label1.Text = "Nhập tên phòng";
            // 
            // btnAcceptCreateRoom
            // 
            this.btnAcceptCreateRoom.Location = new System.Drawing.Point(129, 172);
            this.btnAcceptCreateRoom.Name = "btnAcceptCreateRoom";
            this.btnAcceptCreateRoom.Size = new System.Drawing.Size(175, 41);
            this.btnAcceptCreateRoom.TabIndex = 6;
            this.btnAcceptCreateRoom.Text = "Tạo phòng";
            this.btnAcceptCreateRoom.UseVisualStyleBackColor = true;
            // 
            // txtRoomName
            // 
            this.txtRoomName.Location = new System.Drawing.Point(99, 55);
            this.txtRoomName.Name = "txtRoomName";
            this.txtRoomName.Size = new System.Drawing.Size(245, 22);
            this.txtRoomName.TabIndex = 4;
            // 
            // userControlCreateRoom
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.pnlCreateRoom);
            this.Name = "userControlCreateRoom";
            this.Size = new System.Drawing.Size(436, 245);
            this.pnlCreateRoom.ResumeLayout(false);
            this.pnlCreateRoom.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel pnlCreateRoom;
        private System.Windows.Forms.TextBox txtBetPoints;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnAcceptCreateRoom;
        private System.Windows.Forms.TextBox txtRoomName;
    }
}
