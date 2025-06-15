namespace quanly
{
    partial class BlogDetailForm_trangchu
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(BlogDetailForm_trangchu));
            this.lbtitle = new System.Windows.Forms.Label();
            this.lbauthor = new System.Windows.Forms.Label();
            this.lbcontentt = new System.Windows.Forms.Label();
            this.lbtime = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.picturedetail = new System.Windows.Forms.PictureBox();
            this.BtnQuaylai = new System.Windows.Forms.Button();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picturedetail)).BeginInit();
            this.SuspendLayout();
            // 
            // lbtitle
            // 
            this.lbtitle.BackColor = System.Drawing.Color.AliceBlue;
            this.lbtitle.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbtitle.Location = new System.Drawing.Point(97, 270);
            this.lbtitle.Name = "lbtitle";
            this.lbtitle.Size = new System.Drawing.Size(690, 30);
            this.lbtitle.TabIndex = 4;
            this.lbtitle.Text = "title";
            // 
            // lbauthor
            // 
            this.lbauthor.BackColor = System.Drawing.Color.AliceBlue;
            this.lbauthor.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbauthor.Location = new System.Drawing.Point(705, 12);
            this.lbauthor.Name = "lbauthor";
            this.lbauthor.Size = new System.Drawing.Size(177, 34);
            this.lbauthor.TabIndex = 5;
            this.lbauthor.Text = "author";
            // 
            // lbcontentt
            // 
            this.lbcontentt.BackColor = System.Drawing.Color.AliceBlue;
            this.lbcontentt.ForeColor = System.Drawing.SystemColors.ControlText;
            this.lbcontentt.Location = new System.Drawing.Point(0, 2);
            this.lbcontentt.Name = "lbcontentt";
            this.lbcontentt.Size = new System.Drawing.Size(886, 324);
            this.lbcontentt.TabIndex = 6;
            this.lbcontentt.Text = "Content";
            // 
            // lbtime
            // 
            this.lbtime.BackColor = System.Drawing.Color.AliceBlue;
            this.lbtime.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbtime.Location = new System.Drawing.Point(706, 56);
            this.lbtime.Name = "lbtime";
            this.lbtime.Size = new System.Drawing.Size(177, 32);
            this.lbtime.TabIndex = 7;
            this.lbtime.Text = "time";
            // 
            // panel1
            // 
            this.panel1.AutoScroll = true;
            this.panel1.BackColor = System.Drawing.Color.AliceBlue;
            this.panel1.Controls.Add(this.lbcontentt);
            this.panel1.Location = new System.Drawing.Point(22, 316);
            this.panel1.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(892, 324);
            this.panel1.TabIndex = 8;
            // 
            // picturedetail
            // 
            this.picturedetail.BackColor = System.Drawing.Color.White;
            this.picturedetail.Location = new System.Drawing.Point(230, 12);
            this.picturedetail.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.picturedetail.Name = "picturedetail";
            this.picturedetail.Size = new System.Drawing.Size(470, 246);
            this.picturedetail.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.picturedetail.TabIndex = 1;
            this.picturedetail.TabStop = false;
            // 
            // BtnQuaylai
            // 
            this.BtnQuaylai.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BtnQuaylai.Image = ((System.Drawing.Image)(resources.GetObject("BtnQuaylai.Image")));
            this.BtnQuaylai.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.BtnQuaylai.Location = new System.Drawing.Point(26, 12);
            this.BtnQuaylai.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.BtnQuaylai.Name = "BtnQuaylai";
            this.BtnQuaylai.Size = new System.Drawing.Size(141, 65);
            this.BtnQuaylai.TabIndex = 9;
            this.BtnQuaylai.Text = "Quay lại";
            this.BtnQuaylai.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.BtnQuaylai.UseVisualStyleBackColor = true;
            this.BtnQuaylai.Click += new System.EventHandler(this.BtnQuaylai_Click);
            // 
            // BlogDetailForm_trangchu
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Blue;
            this.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("$this.BackgroundImage")));
            this.ClientSize = new System.Drawing.Size(945, 652);
            this.Controls.Add(this.BtnQuaylai);
            this.Controls.Add(this.lbtime);
            this.Controls.Add(this.lbauthor);
            this.Controls.Add(this.lbtitle);
            this.Controls.Add(this.picturedetail);
            this.Controls.Add(this.panel1);
            this.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.Name = "BlogDetailForm_trangchu";
            this.Text = "Thông tin chi tiết bài báo";
            this.panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.picturedetail)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.PictureBox picturedetail;
        private System.Windows.Forms.Label lbtitle;
        private System.Windows.Forms.Label lbauthor;
        private System.Windows.Forms.Label lbcontentt;
        private System.Windows.Forms.Label lbtime;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button BtnQuaylai;
    }
}