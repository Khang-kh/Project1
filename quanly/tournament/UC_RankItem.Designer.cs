namespace quanly
{
    partial class UC_RankItem
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
            this.lblPosition = new System.Windows.Forms.Label();
            this.picLogo = new System.Windows.Forms.PictureBox();
            this.lblTeamName = new System.Windows.Forms.Label();
            this.lblWins = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.lblPoints = new System.Windows.Forms.Label();
            this.lblLosses = new System.Windows.Forms.Label();
            this.lblDraws = new System.Windows.Forms.Label();
            this.backgroundWorker1 = new System.ComponentModel.BackgroundWorker();
            ((System.ComponentModel.ISupportInitialize)(this.picLogo)).BeginInit();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // lblPosition
            // 
            this.lblPosition.Location = new System.Drawing.Point(19, 55);
            this.lblPosition.Name = "lblPosition";
            this.lblPosition.Size = new System.Drawing.Size(64, 29);
            this.lblPosition.TabIndex = 2;
            this.lblPosition.Text = "Hạng: ";
            this.lblPosition.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // picLogo
            // 
            this.picLogo.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.picLogo.Location = new System.Drawing.Point(102, 4);
            this.picLogo.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.picLogo.Name = "picLogo";
            this.picLogo.Size = new System.Drawing.Size(147, 132);
            this.picLogo.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.picLogo.TabIndex = 3;
            this.picLogo.TabStop = false;
            // 
            // lblTeamName
            // 
            this.lblTeamName.Location = new System.Drawing.Point(306, 55);
            this.lblTeamName.Name = "lblTeamName";
            this.lblTeamName.Size = new System.Drawing.Size(91, 29);
            this.lblTeamName.TabIndex = 4;
            this.lblTeamName.Text = "Đội bóng:";
            this.lblTeamName.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblWins
            // 
            this.lblWins.Location = new System.Drawing.Point(624, 55);
            this.lblWins.Name = "lblWins";
            this.lblWins.Size = new System.Drawing.Size(60, 29);
            this.lblWins.TabIndex = 5;
            this.lblWins.Text = "Thắng:";
            // 
            // panel1
            // 
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel1.Controls.Add(this.lblPoints);
            this.panel1.Controls.Add(this.lblLosses);
            this.panel1.Controls.Add(this.lblDraws);
            this.panel1.Controls.Add(this.lblPosition);
            this.panel1.Controls.Add(this.lblWins);
            this.panel1.Controls.Add(this.picLogo);
            this.panel1.Controls.Add(this.lblTeamName);
            this.panel1.Location = new System.Drawing.Point(3, 4);
            this.panel1.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1039, 151);
            this.panel1.TabIndex = 6;
            this.panel1.Paint += new System.Windows.Forms.PaintEventHandler(this.panel1_Paint);
            // 
            // lblPoints
            // 
            this.lblPoints.Location = new System.Drawing.Point(858, 55);
            this.lblPoints.Name = "lblPoints";
            this.lblPoints.Size = new System.Drawing.Size(52, 29);
            this.lblPoints.TabIndex = 8;
            this.lblPoints.Text = "Tổng điểm:";
            this.lblPoints.Click += new System.EventHandler(this.label3_Click);
            // 
            // lblLosses
            // 
            this.lblLosses.Location = new System.Drawing.Point(761, 55);
            this.lblLosses.Name = "lblLosses";
            this.lblLosses.Size = new System.Drawing.Size(51, 29);
            this.lblLosses.TabIndex = 7;
            this.lblLosses.Text = "Thua:";
            this.lblLosses.Click += new System.EventHandler(this.label2_Click);
            // 
            // lblDraws
            // 
            this.lblDraws.Location = new System.Drawing.Point(703, 55);
            this.lblDraws.Name = "lblDraws";
            this.lblDraws.Size = new System.Drawing.Size(52, 29);
            this.lblDraws.TabIndex = 6;
            this.lblDraws.Text = "Hòa:";
            // 
            // UC_RankItem
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.panel1);
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.Name = "UC_RankItem";
            this.Size = new System.Drawing.Size(1045, 159);
            this.Load += new System.EventHandler(this.UC_RankItem_Load);
            ((System.ComponentModel.ISupportInitialize)(this.picLogo)).EndInit();
            this.panel1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label lblPosition;
        private System.Windows.Forms.PictureBox picLogo;
        private System.Windows.Forms.Label lblTeamName;
        private System.Windows.Forms.Label lblWins;
        private System.Windows.Forms.Panel panel1;
        private System.ComponentModel.BackgroundWorker backgroundWorker1;
        private System.Windows.Forms.Label lblLosses;
        private System.Windows.Forms.Label lblDraws;
        private System.Windows.Forms.Label lblPoints;
    }
}
