namespace quanly
{
    partial class AddnewBlog
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(AddnewBlog));
            this.panel1 = new System.Windows.Forms.Panel();
            this.textBox = new System.Windows.Forms.TextBox();
            this.lbcontent = new System.Windows.Forms.Label();
            this.lbauthor = new System.Windows.Forms.Label();
            this.lbtitle = new System.Windows.Forms.Label();
            this.titlebox = new System.Windows.Forms.TextBox();
            this.authorbox = new System.Windows.Forms.TextBox();
            this.savebtn = new System.Windows.Forms.Button();
            this.upload = new System.Windows.Forms.Button();
            this.picturedetail = new System.Windows.Forms.PictureBox();
            this.BtnQuaylai = new System.Windows.Forms.Button();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picturedetail)).BeginInit();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.AutoScroll = true;
            this.panel1.BackColor = System.Drawing.Color.AliceBlue;
            this.panel1.Controls.Add(this.textBox);
            this.panel1.Location = new System.Drawing.Point(25, 354);
            this.panel1.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(892, 296);
            this.panel1.TabIndex = 13;
            // 
            // textBox
            // 
            this.textBox.Location = new System.Drawing.Point(0, 0);
            this.textBox.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.textBox.Multiline = true;
            this.textBox.Name = "textBox";
            this.textBox.Size = new System.Drawing.Size(892, 294);
            this.textBox.TabIndex = 7;
            this.textBox.TextChanged += new System.EventHandler(this.textBox_TextChanged);
            // 
            // lbcontent
            // 
            this.lbcontent.AutoSize = true;
            this.lbcontent.BackColor = System.Drawing.Color.AliceBlue;
            this.lbcontent.Location = new System.Drawing.Point(27, 331);
            this.lbcontent.Name = "lbcontent";
            this.lbcontent.Size = new System.Drawing.Size(72, 20);
            this.lbcontent.TabIndex = 6;
            this.lbcontent.Text = "Nội dung";
            // 
            // lbauthor
            // 
            this.lbauthor.BackColor = System.Drawing.Color.AliceBlue;
            this.lbauthor.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbauthor.Location = new System.Drawing.Point(703, 12);
            this.lbauthor.Name = "lbauthor";
            this.lbauthor.Size = new System.Drawing.Size(94, 34);
            this.lbauthor.TabIndex = 11;
            this.lbauthor.Text = "Tác giả";
            // 
            // lbtitle
            // 
            this.lbtitle.BackColor = System.Drawing.Color.AliceBlue;
            this.lbtitle.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbtitle.Location = new System.Drawing.Point(112, 300);
            this.lbtitle.Name = "lbtitle";
            this.lbtitle.Size = new System.Drawing.Size(107, 30);
            this.lbtitle.TabIndex = 10;
            this.lbtitle.Text = "Tiêu đề";
            // 
            // titlebox
            // 
            this.titlebox.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.titlebox.Location = new System.Drawing.Point(226, 295);
            this.titlebox.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.titlebox.Name = "titlebox";
            this.titlebox.Size = new System.Drawing.Size(470, 35);
            this.titlebox.TabIndex = 14;
            // 
            // authorbox
            // 
            this.authorbox.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.authorbox.Location = new System.Drawing.Point(804, 12);
            this.authorbox.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.authorbox.Name = "authorbox";
            this.authorbox.Size = new System.Drawing.Size(100, 30);
            this.authorbox.TabIndex = 15;
            // 
            // savebtn
            // 
            this.savebtn.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.savebtn.Location = new System.Drawing.Point(417, 656);
            this.savebtn.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.savebtn.Name = "savebtn";
            this.savebtn.Size = new System.Drawing.Size(129, 44);
            this.savebtn.TabIndex = 17;
            this.savebtn.Text = "Lưu";
            this.savebtn.UseVisualStyleBackColor = true;
            this.savebtn.Click += new System.EventHandler(this.savebtn_Click);
            // 
            // upload
            // 
            this.upload.Location = new System.Drawing.Point(407, 255);
            this.upload.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.upload.Name = "upload";
            this.upload.Size = new System.Drawing.Size(111, 34);
            this.upload.TabIndex = 18;
            this.upload.Text = "Upload";
            this.upload.UseVisualStyleBackColor = true;
            this.upload.Click += new System.EventHandler(this.upload_Click);
            // 
            // picturedetail
            // 
            this.picturedetail.BackColor = System.Drawing.Color.AliceBlue;
            this.picturedetail.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.picturedetail.Location = new System.Drawing.Point(227, 2);
            this.picturedetail.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.picturedetail.Name = "picturedetail";
            this.picturedetail.Size = new System.Drawing.Size(470, 246);
            this.picturedetail.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.picturedetail.TabIndex = 9;
            this.picturedetail.TabStop = false;
            // 
            // BtnQuaylai
            // 
            this.BtnQuaylai.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BtnQuaylai.Image = ((System.Drawing.Image)(resources.GetObject("BtnQuaylai.Image")));
            this.BtnQuaylai.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.BtnQuaylai.Location = new System.Drawing.Point(12, 12);
            this.BtnQuaylai.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.BtnQuaylai.Name = "BtnQuaylai";
            this.BtnQuaylai.Size = new System.Drawing.Size(141, 65);
            this.BtnQuaylai.TabIndex = 19;
            this.BtnQuaylai.Text = "Quay lại";
            this.BtnQuaylai.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.BtnQuaylai.UseVisualStyleBackColor = true;
            this.BtnQuaylai.Click += new System.EventHandler(this.BtnQuaylai_Click);
            // 
            // AddnewBlog
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Blue;
            this.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("$this.BackgroundImage")));
            this.ClientSize = new System.Drawing.Size(960, 711);
            this.Controls.Add(this.BtnQuaylai);
            this.Controls.Add(this.upload);
            this.Controls.Add(this.savebtn);
            this.Controls.Add(this.authorbox);
            this.Controls.Add(this.titlebox);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.lbcontent);
            this.Controls.Add(this.lbauthor);
            this.Controls.Add(this.lbtitle);
            this.Controls.Add(this.picturedetail);
            this.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.Name = "AddnewBlog";
            this.Text = "Thêm bài báo";
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picturedetail)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label lbcontent;
        private System.Windows.Forms.Label lbauthor;
        private System.Windows.Forms.Label lbtitle;
        private System.Windows.Forms.PictureBox picturedetail;
        private System.Windows.Forms.TextBox textBox;
        private System.Windows.Forms.TextBox titlebox;
        private System.Windows.Forms.TextBox authorbox;
        private System.Windows.Forms.Button savebtn;
        private System.Windows.Forms.Button upload;
        private System.Windows.Forms.Button BtnQuaylai;
    }
}