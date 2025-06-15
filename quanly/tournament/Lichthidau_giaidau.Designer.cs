namespace quanly.tournament
{
    partial class Lichthidau_giaidau
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Lichthidau_giaidau));
            this.flowLayoutPanel1 = new System.Windows.Forms.FlowLayoutPanel();
            this.label1 = new System.Windows.Forms.Label();
            this.BtnQuaylai = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // flowLayoutPanel1
            // 
            this.flowLayoutPanel1.Location = new System.Drawing.Point(32, 287);
            this.flowLayoutPanel1.Name = "flowLayoutPanel1";
            this.flowLayoutPanel1.Size = new System.Drawing.Size(1065, 567);
            this.flowLayoutPanel1.TabIndex = 0;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 20F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(384, 53);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(374, 46);
            this.label1.TabIndex = 1;
            this.label1.Text = "Lịch thi đấu giải đấu";
            // 
            // BtnQuaylai
            // 
            this.BtnQuaylai.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BtnQuaylai.Image = ((System.Drawing.Image)(resources.GetObject("BtnQuaylai.Image")));
            this.BtnQuaylai.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.BtnQuaylai.Location = new System.Drawing.Point(32, 13);
            this.BtnQuaylai.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.BtnQuaylai.Name = "BtnQuaylai";
            this.BtnQuaylai.Size = new System.Drawing.Size(141, 65);
            this.BtnQuaylai.TabIndex = 2;
            this.BtnQuaylai.Text = "Quay lại";
            this.BtnQuaylai.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.BtnQuaylai.UseVisualStyleBackColor = true;
            this.BtnQuaylai.Click += new System.EventHandler(this.BtnQuaylai_Click);
            // 
            // Lichthidau_giaidau
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = global::quanly.Properties.Resources.hình_nền;
            this.ClientSize = new System.Drawing.Size(1136, 904);
            this.Controls.Add(this.BtnQuaylai);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.flowLayoutPanel1);
            this.Name = "Lichthidau_giaidau";
            this.Text = "Lichthidau_giaidau";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button BtnQuaylai;
    }
}