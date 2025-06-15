namespace quanly
{
    partial class FormQLPlayer
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormQLPlayer));
            this.flowLayoutPanel1 = new System.Windows.Forms.FlowLayoutPanel();
            this.BtnQuaylai = new System.Windows.Forms.Button();
            this.LblQuanlycauthu = new System.Windows.Forms.Label();
            this.LblTimkiemcauthu = new System.Windows.Forms.Label();
            this.LblDoibong = new System.Windows.Forms.Label();
            this.LblSoao = new System.Windows.Forms.Label();
            this.TxtCauthu = new System.Windows.Forms.TextBox();
            this.TxtDoibong = new System.Windows.Forms.TextBox();
            this.TxtSoao = new System.Windows.Forms.TextBox();
            this.BtnTimkiem = new System.Windows.Forms.Button();
            this.BtnThem = new System.Windows.Forms.Button();
            this.BtnSuacauthu = new System.Windows.Forms.Button();
            this.BtnXoacauthu = new System.Windows.Forms.Button();
            this.BtnHienthi = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // flowLayoutPanel1
            // 
            this.flowLayoutPanel1.AutoScroll = true;
            this.flowLayoutPanel1.BackColor = System.Drawing.Color.White;
            this.flowLayoutPanel1.Location = new System.Drawing.Point(62, 297);
            this.flowLayoutPanel1.Margin = new System.Windows.Forms.Padding(0);
            this.flowLayoutPanel1.Name = "flowLayoutPanel1";
            this.flowLayoutPanel1.Size = new System.Drawing.Size(875, 180);
            this.flowLayoutPanel1.TabIndex = 0;
            this.flowLayoutPanel1.Paint += new System.Windows.Forms.PaintEventHandler(this.flowLayoutPanel1_Paint);
            // 
            // BtnQuaylai
            // 
            this.BtnQuaylai.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BtnQuaylai.Image = ((System.Drawing.Image)(resources.GetObject("BtnQuaylai.Image")));
            this.BtnQuaylai.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.BtnQuaylai.Location = new System.Drawing.Point(25, 24);
            this.BtnQuaylai.Name = "BtnQuaylai";
            this.BtnQuaylai.Size = new System.Drawing.Size(125, 52);
            this.BtnQuaylai.TabIndex = 1;
            this.BtnQuaylai.Text = "Quay lại";
            this.BtnQuaylai.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.BtnQuaylai.UseVisualStyleBackColor = true;
            this.BtnQuaylai.Click += new System.EventHandler(this.BtnQuaylai_Click);
            // 
            // LblQuanlycauthu
            // 
            this.LblQuanlycauthu.BackColor = System.Drawing.Color.AliceBlue;
            this.LblQuanlycauthu.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LblQuanlycauthu.Location = new System.Drawing.Point(406, 4);
            this.LblQuanlycauthu.Name = "LblQuanlycauthu";
            this.LblQuanlycauthu.Size = new System.Drawing.Size(192, 56);
            this.LblQuanlycauthu.TabIndex = 2;
            this.LblQuanlycauthu.Text = "Quản lý cầu thủ";
            this.LblQuanlycauthu.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // LblTimkiemcauthu
            // 
            this.LblTimkiemcauthu.BackColor = System.Drawing.Color.AliceBlue;
            this.LblTimkiemcauthu.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LblTimkiemcauthu.Location = new System.Drawing.Point(188, 72);
            this.LblTimkiemcauthu.Name = "LblTimkiemcauthu";
            this.LblTimkiemcauthu.Size = new System.Drawing.Size(244, 46);
            this.LblTimkiemcauthu.TabIndex = 3;
            this.LblTimkiemcauthu.Text = "Tên cầu thủ";
            this.LblTimkiemcauthu.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // LblDoibong
            // 
            this.LblDoibong.BackColor = System.Drawing.Color.AliceBlue;
            this.LblDoibong.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LblDoibong.Location = new System.Drawing.Point(299, 135);
            this.LblDoibong.Name = "LblDoibong";
            this.LblDoibong.Size = new System.Drawing.Size(134, 46);
            this.LblDoibong.TabIndex = 4;
            this.LblDoibong.Text = "Đội bóng";
            this.LblDoibong.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.LblDoibong.Click += new System.EventHandler(this.LblDoibong_Click);
            // 
            // LblSoao
            // 
            this.LblSoao.BackColor = System.Drawing.Color.AliceBlue;
            this.LblSoao.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LblSoao.Location = new System.Drawing.Point(332, 196);
            this.LblSoao.Name = "LblSoao";
            this.LblSoao.Size = new System.Drawing.Size(100, 46);
            this.LblSoao.TabIndex = 5;
            this.LblSoao.Text = "Số áo:";
            this.LblSoao.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.LblSoao.Click += new System.EventHandler(this.LblSoao_Click);
            // 
            // TxtCauthu
            // 
            this.TxtCauthu.Location = new System.Drawing.Point(438, 72);
            this.TxtCauthu.Multiline = true;
            this.TxtCauthu.Name = "TxtCauthu";
            this.TxtCauthu.Size = new System.Drawing.Size(375, 46);
            this.TxtCauthu.TabIndex = 6;
            // 
            // TxtDoibong
            // 
            this.TxtDoibong.Location = new System.Drawing.Point(438, 135);
            this.TxtDoibong.Multiline = true;
            this.TxtDoibong.Name = "TxtDoibong";
            this.TxtDoibong.Size = new System.Drawing.Size(375, 46);
            this.TxtDoibong.TabIndex = 7;
            // 
            // TxtSoao
            // 
            this.TxtSoao.Location = new System.Drawing.Point(438, 196);
            this.TxtSoao.Multiline = true;
            this.TxtSoao.Name = "TxtSoao";
            this.TxtSoao.Size = new System.Drawing.Size(375, 46);
            this.TxtSoao.TabIndex = 9;
            // 
            // BtnTimkiem
            // 
            this.BtnTimkiem.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BtnTimkiem.Location = new System.Drawing.Point(422, 247);
            this.BtnTimkiem.Name = "BtnTimkiem";
            this.BtnTimkiem.Size = new System.Drawing.Size(154, 46);
            this.BtnTimkiem.TabIndex = 10;
            this.BtnTimkiem.Text = "Tìm kiếm";
            this.BtnTimkiem.UseVisualStyleBackColor = true;
            this.BtnTimkiem.Click += new System.EventHandler(this.BtnTimkiem_Click);
            // 
            // BtnThem
            // 
            this.BtnThem.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BtnThem.Location = new System.Drawing.Point(62, 490);
            this.BtnThem.Name = "BtnThem";
            this.BtnThem.Size = new System.Drawing.Size(170, 44);
            this.BtnThem.TabIndex = 11;
            this.BtnThem.Text = "Thêm cầu thủ";
            this.BtnThem.UseVisualStyleBackColor = true;
            this.BtnThem.Click += new System.EventHandler(this.BtnThem_Click);
            // 
            // BtnSuacauthu
            // 
            this.BtnSuacauthu.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BtnSuacauthu.Location = new System.Drawing.Point(297, 490);
            this.BtnSuacauthu.Name = "BtnSuacauthu";
            this.BtnSuacauthu.Size = new System.Drawing.Size(170, 44);
            this.BtnSuacauthu.TabIndex = 12;
            this.BtnSuacauthu.Text = "Sửa cầu thủ";
            this.BtnSuacauthu.UseVisualStyleBackColor = true;
            this.BtnSuacauthu.Click += new System.EventHandler(this.BtnSuacauthu_Click);
            // 
            // BtnXoacauthu
            // 
            this.BtnXoacauthu.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BtnXoacauthu.Location = new System.Drawing.Point(530, 490);
            this.BtnXoacauthu.Name = "BtnXoacauthu";
            this.BtnXoacauthu.Size = new System.Drawing.Size(170, 44);
            this.BtnXoacauthu.TabIndex = 13;
            this.BtnXoacauthu.Text = "Xóa cầu thủ";
            this.BtnXoacauthu.UseVisualStyleBackColor = true;
            this.BtnXoacauthu.Click += new System.EventHandler(this.BtnXoacauthu_Click);
            // 
            // BtnHienthi
            // 
            this.BtnHienthi.BackColor = System.Drawing.Color.AliceBlue;
            this.BtnHienthi.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BtnHienthi.Location = new System.Drawing.Point(767, 490);
            this.BtnHienthi.Name = "BtnHienthi";
            this.BtnHienthi.Size = new System.Drawing.Size(170, 44);
            this.BtnHienthi.TabIndex = 14;
            this.BtnHienthi.Text = "Hiển thị tất cả";
            this.BtnHienthi.UseVisualStyleBackColor = false;
            this.BtnHienthi.Click += new System.EventHandler(this.BtnHienthi_Click);
            // 
            // FormQLPlayer
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Blue;
            this.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("$this.BackgroundImage")));
            this.ClientSize = new System.Drawing.Size(992, 565);
            this.Controls.Add(this.BtnHienthi);
            this.Controls.Add(this.BtnXoacauthu);
            this.Controls.Add(this.BtnSuacauthu);
            this.Controls.Add(this.BtnThem);
            this.Controls.Add(this.BtnTimkiem);
            this.Controls.Add(this.TxtSoao);
            this.Controls.Add(this.TxtDoibong);
            this.Controls.Add(this.TxtCauthu);
            this.Controls.Add(this.LblSoao);
            this.Controls.Add(this.LblDoibong);
            this.Controls.Add(this.LblTimkiemcauthu);
            this.Controls.Add(this.LblQuanlycauthu);
            this.Controls.Add(this.BtnQuaylai);
            this.Controls.Add(this.flowLayoutPanel1);
            this.Name = "FormQLPlayer";
            this.Text = "Quản lý cầu thủ";
            this.Load += new System.EventHandler(this.Quanlycauthu_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel1;
        private System.Windows.Forms.Button BtnQuaylai;
        private System.Windows.Forms.Label LblQuanlycauthu;
        private System.Windows.Forms.Label LblTimkiemcauthu;
        private System.Windows.Forms.Label LblDoibong;
        private System.Windows.Forms.Label LblSoao;
        private System.Windows.Forms.TextBox TxtCauthu;
        private System.Windows.Forms.TextBox TxtDoibong;
        private System.Windows.Forms.TextBox TxtSoao;
        private System.Windows.Forms.Button BtnTimkiem;
        private System.Windows.Forms.Button BtnThem;
        private System.Windows.Forms.Button BtnSuacauthu;
        private System.Windows.Forms.Button BtnXoacauthu;
        private System.Windows.Forms.Button BtnHienthi;
    }
}

