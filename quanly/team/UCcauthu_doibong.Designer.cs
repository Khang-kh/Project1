namespace quanly
{
    partial class UCcauthucuadoibong
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
            this.LblTen = new System.Windows.Forms.Label();
            this.LblDoi = new System.Windows.Forms.Label();
            this.LblSo = new System.Windows.Forms.Label();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // LblTen
            // 
            this.LblTen.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LblTen.Location = new System.Drawing.Point(256, 30);
            this.LblTen.Name = "LblTen";
            this.LblTen.Size = new System.Drawing.Size(253, 41);
            this.LblTen.TabIndex = 3;
            this.LblTen.Text = "Tên:";
            this.LblTen.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.LblTen.Click += new System.EventHandler(this.LblTen_Click);
            // 
            // LblDoi
            // 
            this.LblDoi.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LblDoi.Location = new System.Drawing.Point(256, 86);
            this.LblDoi.Name = "LblDoi";
            this.LblDoi.Size = new System.Drawing.Size(253, 35);
            this.LblDoi.TabIndex = 4;
            this.LblDoi.Text = "Đội:";
            this.LblDoi.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // LblSo
            // 
            this.LblSo.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LblSo.Location = new System.Drawing.Point(256, 140);
            this.LblSo.Name = "LblSo";
            this.LblSo.Size = new System.Drawing.Size(168, 38);
            this.LblSo.TabIndex = 5;
            this.LblSo.Text = "Số áo:";
            this.LblSo.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.LblSo.Click += new System.EventHandler(this.LblSo_Click);
            // 
            // pictureBox1
            // 
            this.pictureBox1.Location = new System.Drawing.Point(32, 16);
            this.pictureBox1.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(193, 162);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox1.TabIndex = 6;
            this.pictureBox1.TabStop = false;
            this.pictureBox1.Click += new System.EventHandler(this.pictureBox1_Click);
            // 
            // UCcauthucuadoibong
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Window;
            this.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.LblSo);
            this.Controls.Add(this.LblDoi);
            this.Controls.Add(this.LblTen);
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.Name = "UCcauthucuadoibong";
            this.Size = new System.Drawing.Size(836, 203);
            this.Load += new System.EventHandler(this.UCcauthu_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Label LblTen;
        private System.Windows.Forms.Label LblDoi;
        private System.Windows.Forms.Label LblSo;
        private System.Windows.Forms.PictureBox pictureBox1;
    }
}
