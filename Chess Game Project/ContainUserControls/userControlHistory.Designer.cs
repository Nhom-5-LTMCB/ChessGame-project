namespace Chess_Game_Project.ContainUserControls
{
    partial class userControlHistory
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
            this.pnlChildContainHistory = new System.Windows.Forms.Panel();
            this.dtGridViewHistory = new System.Windows.Forms.DataGridView();
            this.pnlChildContainHistory.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dtGridViewHistory)).BeginInit();
            this.SuspendLayout();
            // 
            // pnlChildContainHistory
            // 
            this.pnlChildContainHistory.Controls.Add(this.dtGridViewHistory);
            this.pnlChildContainHistory.Location = new System.Drawing.Point(0, 0);
            this.pnlChildContainHistory.Name = "pnlChildContainHistory";
            this.pnlChildContainHistory.Size = new System.Drawing.Size(866, 552);
            this.pnlChildContainHistory.TabIndex = 6;
            // 
            // dtGridViewHistory
            // 
            this.dtGridViewHistory.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dtGridViewHistory.Location = new System.Drawing.Point(0, 0);
            this.dtGridViewHistory.Name = "dtGridViewHistory";
            this.dtGridViewHistory.RowHeadersWidth = 51;
            this.dtGridViewHistory.RowTemplate.Height = 24;
            this.dtGridViewHistory.Size = new System.Drawing.Size(866, 552);
            this.dtGridViewHistory.TabIndex = 1;
            // 
            // userControlHistory
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.pnlChildContainHistory);
            this.Name = "userControlHistory";
            this.Size = new System.Drawing.Size(866, 553);
            this.pnlChildContainHistory.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dtGridViewHistory)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel pnlChildContainHistory;
        private System.Windows.Forms.DataGridView dtGridViewHistory;
    }
}
