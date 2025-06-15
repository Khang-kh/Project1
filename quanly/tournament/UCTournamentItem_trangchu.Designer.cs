namespace quanly
{
    partial class UCTournamentItem_trangchu
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
            this.panel1 = new System.Windows.Forms.Panel();
            this.lblThoiGian = new System.Windows.Forms.Label();
            this.picLogo = new System.Windows.Forms.PictureBox();
            this.lblTenGiaiDau = new System.Windows.Forms.Label();
            this.lblSTT = new System.Windows.Forms.Label();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picLogo)).BeginInit();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel1.Controls.Add(this.lblThoiGian);
            this.panel1.Controls.Add(this.picLogo);
            this.panel1.Controls.Add(this.lblTenGiaiDau);
            this.panel1.Controls.Add(this.lblSTT);
            this.panel1.Location = new System.Drawing.Point(15, 17);
            this.panel1.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1133, 106);
            this.panel1.TabIndex = 0;
            this.panel1.Paint += new System.Windows.Forms.PaintEventHandler(this.panel1_Paint);
            // 
            // lblThoiGian
            // 
            this.lblThoiGian.Location = new System.Drawing.Point(198, 60);
            this.lblThoiGian.Name = "lblThoiGian";
            this.lblThoiGian.Size = new System.Drawing.Size(249, 29);
            this.lblThoiGian.TabIndex = 3;
            this.lblThoiGian.Text = "Thời gian: ";
            // 
            // picLogo
            // 
            this.picLogo.Location = new System.Drawing.Point(55, 4);
            this.picLogo.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.picLogo.Name = "picLogo";
            this.picLogo.Size = new System.Drawing.Size(128, 96);
            this.picLogo.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.picLogo.TabIndex = 2;
            this.picLogo.TabStop = false;
            // 
            // lblTenGiaiDau
            // 
            this.lblTenGiaiDau.Location = new System.Drawing.Point(198, 4);
            this.lblTenGiaiDau.Name = "lblTenGiaiDau";
            this.lblTenGiaiDau.Size = new System.Drawing.Size(180, 29);
            this.lblTenGiaiDau.TabIndex = 1;
            this.lblTenGiaiDau.Text = "Tên giải đấu: ";
            // 
            // lblSTT
            // 
            this.lblSTT.Location = new System.Drawing.Point(3, 22);
            this.lblSTT.Name = "lblSTT";
            this.lblSTT.Size = new System.Drawing.Size(45, 32);
            this.lblSTT.TabIndex = 0;
            this.lblSTT.Text = "Stt";
            this.lblSTT.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // UCTournamentItem_trangchu
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.Controls.Add(this.panel1);
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.Name = "UCTournamentItem_trangchu";
            this.Size = new System.Drawing.Size(1165, 138);
            this.Load += new System.EventHandler(this.UCTournamentItem_Load);
            this.panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.picLogo)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label lblThoiGian;
        private System.Windows.Forms.PictureBox picLogo;
        private System.Windows.Forms.Label lblTenGiaiDau;
        private System.Windows.Forms.Label lblSTT;
    }
}
