namespace quanly
{
    partial class UC_RankItem_doibong
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
            this.lbTournamnetName = new System.Windows.Forms.Label();
            this.lblWins = new System.Windows.Forms.Label();
            this.lblLosses = new System.Windows.Forms.Label();
            this.lblDraws = new System.Windows.Forms.Label();
            this.backgroundWorker1 = new System.ComponentModel.BackgroundWorker();
            this.lblPoints = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.picLogo)).BeginInit();
            this.SuspendLayout();
            // 
            // lblPosition
            // 
            this.lblPosition.Location = new System.Drawing.Point(20, 66);
            this.lblPosition.Name = "lblPosition";
            this.lblPosition.Size = new System.Drawing.Size(64, 29);
            this.lblPosition.TabIndex = 2;
            this.lblPosition.Text = "Hạng:";
            this.lblPosition.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // picLogo
            // 
            this.picLogo.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.picLogo.Location = new System.Drawing.Point(103, 15);
            this.picLogo.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.picLogo.Name = "picLogo";
            this.picLogo.Size = new System.Drawing.Size(147, 132);
            this.picLogo.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.picLogo.TabIndex = 3;
            this.picLogo.TabStop = false;
            // 
            // lbTournamnetName
            // 
            this.lbTournamnetName.Location = new System.Drawing.Point(306, 85);
            this.lbTournamnetName.Name = "lbTournamnetName";
            this.lbTournamnetName.Size = new System.Drawing.Size(91, 29);
            this.lbTournamnetName.TabIndex = 4;
            this.lbTournamnetName.Text = "Giải đấu";
            this.lbTournamnetName.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblWins
            // 
            this.lblWins.Location = new System.Drawing.Point(482, 85);
            this.lblWins.Name = "lblWins";
            this.lblWins.Size = new System.Drawing.Size(60, 29);
            this.lblWins.TabIndex = 5;
            this.lblWins.Text = "Thắng:";
            // 
            // lblLosses
            // 
            this.lblLosses.Location = new System.Drawing.Point(619, 85);
            this.lblLosses.Name = "lblLosses";
            this.lblLosses.Size = new System.Drawing.Size(51, 29);
            this.lblLosses.TabIndex = 7;
            this.lblLosses.Text = "Thua:";
            this.lblLosses.Click += new System.EventHandler(this.label2_Click);
            // 
            // lblDraws
            // 
            this.lblDraws.Location = new System.Drawing.Point(561, 85);
            this.lblDraws.Name = "lblDraws";
            this.lblDraws.Size = new System.Drawing.Size(52, 29);
            this.lblDraws.TabIndex = 6;
            this.lblDraws.Text = "Hòa:";
            // 
            // lblPoints
            // 
            this.lblPoints.Location = new System.Drawing.Point(735, 85);
            this.lblPoints.Name = "lblPoints";
            this.lblPoints.Size = new System.Drawing.Size(52, 29);
            this.lblPoints.TabIndex = 8;
            this.lblPoints.Text = "Tổng điểm:";
            this.lblPoints.Click += new System.EventHandler(this.label3_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(318, 43);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(68, 20);
            this.label1.TabIndex = 9;
            this.label1.Text = "Giải đấu";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(484, 43);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(58, 20);
            this.label2.TabIndex = 10;
            this.label2.Text = "Thắng:";
            this.label2.Click += new System.EventHandler(this.label2_Click_1);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(561, 43);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(43, 20);
            this.label3.TabIndex = 11;
            this.label3.Text = "Hòa:";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(619, 43);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(49, 20);
            this.label4.TabIndex = 12;
            this.label4.Text = "Thua:";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(735, 43);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(49, 20);
            this.label5.TabIndex = 13;
            this.label5.Text = "Tổng:";
            // 
            // UC_RankItem_doibong
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.lblPoints);
            this.Controls.Add(this.lblLosses);
            this.Controls.Add(this.lbTournamnetName);
            this.Controls.Add(this.lblDraws);
            this.Controls.Add(this.picLogo);
            this.Controls.Add(this.lblPosition);
            this.Controls.Add(this.lblWins);
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.Name = "UC_RankItem_doibong";
            this.Size = new System.Drawing.Size(836, 176);
            this.Load += new System.EventHandler(this.UC_RankItem_Load);
            ((System.ComponentModel.ISupportInitialize)(this.picLogo)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblPosition;
        private System.Windows.Forms.PictureBox picLogo;
        private System.Windows.Forms.Label lbTournamnetName;
        private System.Windows.Forms.Label lblWins;
        private System.ComponentModel.BackgroundWorker backgroundWorker1;
        private System.Windows.Forms.Label lblLosses;
        private System.Windows.Forms.Label lblDraws;
        private System.Windows.Forms.Label lblPoints;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
    }
}
