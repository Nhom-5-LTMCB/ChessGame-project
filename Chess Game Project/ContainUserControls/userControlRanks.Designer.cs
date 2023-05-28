namespace Chess_Game_Project.ContainUserControls
{
    partial class userControlRanks
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
            this.pnlRanker = new System.Windows.Forms.Panel();
            this.panel2 = new System.Windows.Forms.Panel();
            this.lbCurrentRank = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.lbYourRank = new System.Windows.Forms.Label();
            this.pnlYourLevel = new System.Windows.Forms.FlowLayoutPanel();
            this.dtGridRank = new System.Windows.Forms.DataGridView();
            this.pnlRanker.SuspendLayout();
            this.panel2.SuspendLayout();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dtGridRank)).BeginInit();
            this.SuspendLayout();
            // 
            // pnlRanker
            // 
            this.pnlRanker.Controls.Add(this.panel2);
            this.pnlRanker.Controls.Add(this.panel1);
            this.pnlRanker.Controls.Add(this.pnlYourLevel);
            this.pnlRanker.Controls.Add(this.dtGridRank);
            this.pnlRanker.Location = new System.Drawing.Point(0, 0);
            this.pnlRanker.Name = "pnlRanker";
            this.pnlRanker.Size = new System.Drawing.Size(577, 546);
            this.pnlRanker.TabIndex = 4;
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.Color.IndianRed;
            this.panel2.Controls.Add(this.lbCurrentRank);
            this.panel2.Location = new System.Drawing.Point(292, 490);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(284, 59);
            this.panel2.TabIndex = 4;
            // 
            // lbCurrentRank
            // 
            this.lbCurrentRank.AutoSize = true;
            this.lbCurrentRank.Font = new System.Drawing.Font("Microsoft Sans Serif", 19.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbCurrentRank.Location = new System.Drawing.Point(17, 10);
            this.lbCurrentRank.Name = "lbCurrentRank";
            this.lbCurrentRank.Size = new System.Drawing.Size(0, 38);
            this.lbCurrentRank.TabIndex = 0;
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.panel1.Controls.Add(this.lbYourRank);
            this.panel1.Location = new System.Drawing.Point(0, 490);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(293, 59);
            this.panel1.TabIndex = 3;
            // 
            // lbYourRank
            // 
            this.lbYourRank.AutoSize = true;
            this.lbYourRank.Font = new System.Drawing.Font("Microsoft Sans Serif", 19.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbYourRank.Location = new System.Drawing.Point(17, 10);
            this.lbYourRank.Name = "lbYourRank";
            this.lbYourRank.Size = new System.Drawing.Size(232, 38);
            this.lbYourRank.TabIndex = 4;
            this.lbYourRank.Text = "Hạng của bạn";
            // 
            // pnlYourLevel
            // 
            this.pnlYourLevel.Location = new System.Drawing.Point(3, 490);
            this.pnlYourLevel.Name = "pnlYourLevel";
            this.pnlYourLevel.Size = new System.Drawing.Size(573, 59);
            this.pnlYourLevel.TabIndex = 2;
            // 
            // dtGridRank
            // 
            this.dtGridRank.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dtGridRank.Location = new System.Drawing.Point(3, -3);
            this.dtGridRank.Name = "dtGridRank";
            this.dtGridRank.RowHeadersWidth = 51;
            this.dtGridRank.RowTemplate.Height = 24;
            this.dtGridRank.Size = new System.Drawing.Size(573, 494);
            this.dtGridRank.TabIndex = 1;
            // 
            // userControlRanks
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.pnlRanker);
            this.Name = "userControlRanks";
            this.Size = new System.Drawing.Size(572, 547);
            this.pnlRanker.ResumeLayout(false);
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dtGridRank)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel pnlRanker;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Label lbCurrentRank;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label lbYourRank;
        private System.Windows.Forms.FlowLayoutPanel pnlYourLevel;
        private System.Windows.Forms.DataGridView dtGridRank;
    }
}
