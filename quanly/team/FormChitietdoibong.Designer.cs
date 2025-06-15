namespace quanly
{
    partial class FormChitietdoibong
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormChitietdoibong));
            this.LblChitietdoibong = new System.Windows.Forms.Label();
            this.picTeamlogo = new System.Windows.Forms.PictureBox();
            this.txtTeamName = new System.Windows.Forms.Label();
            this.TxtTendoi = new System.Windows.Forms.TextBox();
            this.flowLayoutPanel1 = new System.Windows.Forms.FlowLayoutPanel();
            this.buttonCauthu = new System.Windows.Forms.Button();
            this.buttonSchedule = new System.Windows.Forms.Button();
            this.buttonRank = new System.Windows.Forms.Button();
            this.BtnQuaylai = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.picTeamlogo)).BeginInit();
            this.SuspendLayout();
            // 
            // LblChitietdoibong
            // 
            this.LblChitietdoibong.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LblChitietdoibong.Location = new System.Drawing.Point(495, 44);
            this.LblChitietdoibong.Name = "LblChitietdoibong";
            this.LblChitietdoibong.Size = new System.Drawing.Size(213, 70);
            this.LblChitietdoibong.TabIndex = 0;
            this.LblChitietdoibong.Text = "Chi tiết đội bóng";
            this.LblChitietdoibong.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // picTeamlogo
            // 
            this.picTeamlogo.Image = global::quanly.Properties.Resources.user_image_with_black_background;
            this.picTeamlogo.Location = new System.Drawing.Point(165, 44);
            this.picTeamlogo.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.picTeamlogo.Name = "picTeamlogo";
            this.picTeamlogo.Size = new System.Drawing.Size(160, 199);
            this.picTeamlogo.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage;
            this.picTeamlogo.TabIndex = 20;
            this.picTeamlogo.TabStop = false;
            // 
            // txtTeamName
            // 
            this.txtTeamName.AutoSize = true;
            this.txtTeamName.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtTeamName.Location = new System.Drawing.Point(419, 136);
            this.txtTeamName.Name = "txtTeamName";
            this.txtTeamName.Size = new System.Drawing.Size(127, 25);
            this.txtTeamName.TabIndex = 22;
            this.txtTeamName.Text = "Tên đội bóng";
            // 
            // TxtTendoi
            // 
            this.TxtTendoi.Location = new System.Drawing.Point(423, 190);
            this.TxtTendoi.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.TxtTendoi.Multiline = true;
            this.TxtTendoi.Name = "TxtTendoi";
            this.TxtTendoi.Size = new System.Drawing.Size(398, 35);
            this.TxtTendoi.TabIndex = 23;
            // 
            // flowLayoutPanel1
            // 
            this.flowLayoutPanel1.AutoScroll = true;
            this.flowLayoutPanel1.Location = new System.Drawing.Point(144, 333);
            this.flowLayoutPanel1.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.flowLayoutPanel1.Name = "flowLayoutPanel1";
            this.flowLayoutPanel1.Size = new System.Drawing.Size(836, 553);
            this.flowLayoutPanel1.TabIndex = 33;
            this.flowLayoutPanel1.Paint += new System.Windows.Forms.PaintEventHandler(this.flowLayoutPanel1_Paint);
            // 
            // buttonCauthu
            // 
            this.buttonCauthu.Location = new System.Drawing.Point(165, 263);
            this.buttonCauthu.Name = "buttonCauthu";
            this.buttonCauthu.Size = new System.Drawing.Size(129, 46);
            this.buttonCauthu.TabIndex = 34;
            this.buttonCauthu.Text = "Cầu thủ";
            this.buttonCauthu.UseVisualStyleBackColor = true;
            this.buttonCauthu.Click += new System.EventHandler(this.buttonCauthu_Click);
            // 
            // buttonSchedule
            // 
            this.buttonSchedule.Location = new System.Drawing.Point(320, 263);
            this.buttonSchedule.Name = "buttonSchedule";
            this.buttonSchedule.Size = new System.Drawing.Size(129, 46);
            this.buttonSchedule.TabIndex = 35;
            this.buttonSchedule.Text = "Lịch thi đấu";
            this.buttonSchedule.UseVisualStyleBackColor = true;
            this.buttonSchedule.Click += new System.EventHandler(this.buttonSchedule_Click);
            // 
            // buttonRank
            // 
            this.buttonRank.Location = new System.Drawing.Point(487, 263);
            this.buttonRank.Name = "buttonRank";
            this.buttonRank.Size = new System.Drawing.Size(129, 46);
            this.buttonRank.TabIndex = 36;
            this.buttonRank.Text = "Thành tích";
            this.buttonRank.UseVisualStyleBackColor = true;
            this.buttonRank.Click += new System.EventHandler(this.buttonRank_Click);
            // 
            // BtnQuaylai
            // 
            this.BtnQuaylai.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BtnQuaylai.Image = ((System.Drawing.Image)(resources.GetObject("BtnQuaylai.Image")));
            this.BtnQuaylai.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.BtnQuaylai.Location = new System.Drawing.Point(12, 13);
            this.BtnQuaylai.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.BtnQuaylai.Name = "BtnQuaylai";
            this.BtnQuaylai.Size = new System.Drawing.Size(141, 65);
            this.BtnQuaylai.TabIndex = 37;
            this.BtnQuaylai.Text = "Quay lại";
            this.BtnQuaylai.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.BtnQuaylai.UseVisualStyleBackColor = true;
            this.BtnQuaylai.Click += new System.EventHandler(this.BtnQuaylai_Click);
            // 
            // FormChitietdoibong
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("$this.BackgroundImage")));
            this.ClientSize = new System.Drawing.Size(1037, 899);
            this.Controls.Add(this.BtnQuaylai);
            this.Controls.Add(this.buttonRank);
            this.Controls.Add(this.buttonSchedule);
            this.Controls.Add(this.buttonCauthu);
            this.Controls.Add(this.flowLayoutPanel1);
            this.Controls.Add(this.TxtTendoi);
            this.Controls.Add(this.txtTeamName);
            this.Controls.Add(this.picTeamlogo);
            this.Controls.Add(this.LblChitietdoibong);
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.Name = "FormChitietdoibong";
            this.Text = "FormChitietdoibong";
            this.Load += new System.EventHandler(this.FormChitietdoibong_Load);
            ((System.ComponentModel.ISupportInitialize)(this.picTeamlogo)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label LblChitietdoibong;
        private System.Windows.Forms.PictureBox picTeamlogo;
        private System.Windows.Forms.Label txtTeamName;
        private System.Windows.Forms.TextBox TxtTendoi;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel1;
        private System.Windows.Forms.Button buttonCauthu;
        private System.Windows.Forms.Button buttonSchedule;
        private System.Windows.Forms.Button buttonRank;
        private System.Windows.Forms.Button BtnQuaylai;
    }
}