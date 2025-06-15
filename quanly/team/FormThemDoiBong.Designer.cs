namespace quanly
{
    partial class FormThemDoiBong
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormThemDoiBong));
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            this.txtTeamName = new System.Windows.Forms.Label();
            this.Txttendoibong = new System.Windows.Forms.TextBox();
            this.btnSaveTeam = new System.Windows.Forms.Button();
            this.btnUploadLogo = new System.Windows.Forms.Button();
            this.picTeamlogo = new System.Windows.Forms.PictureBox();
            this.btnBack = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.picTeamlogo)).BeginInit();
            this.SuspendLayout();
            // 
            // openFileDialog1
            // 
            this.openFileDialog1.FileName = "openFileDialog1";
            // 
            // txtTeamName
            // 
            this.txtTeamName.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtTeamName.Location = new System.Drawing.Point(243, 85);
            this.txtTeamName.Name = "txtTeamName";
            this.txtTeamName.Size = new System.Drawing.Size(113, 30);
            this.txtTeamName.TabIndex = 5;
            this.txtTeamName.Text = "Tên đội bóng";
            this.txtTeamName.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // Txttendoibong
            // 
            this.Txttendoibong.Location = new System.Drawing.Point(247, 138);
            this.Txttendoibong.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.Txttendoibong.Multiline = true;
            this.Txttendoibong.Name = "Txttendoibong";
            this.Txttendoibong.Size = new System.Drawing.Size(353, 29);
            this.Txttendoibong.TabIndex = 6;
            // 
            // btnSaveTeam
            // 
            this.btnSaveTeam.BackColor = System.Drawing.Color.White;
            this.btnSaveTeam.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSaveTeam.Location = new System.Drawing.Point(603, 228);
            this.btnSaveTeam.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnSaveTeam.Name = "btnSaveTeam";
            this.btnSaveTeam.Size = new System.Drawing.Size(123, 58);
            this.btnSaveTeam.TabIndex = 15;
            this.btnSaveTeam.Text = "Lưu";
            this.btnSaveTeam.UseVisualStyleBackColor = false;
            this.btnSaveTeam.Click += new System.EventHandler(this.btnSaveTeam_Click);
            // 
            // btnUploadLogo
            // 
            this.btnUploadLogo.BackColor = System.Drawing.Color.White;
            this.btnUploadLogo.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnUploadLogo.Location = new System.Drawing.Point(92, 228);
            this.btnUploadLogo.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnUploadLogo.Name = "btnUploadLogo";
            this.btnUploadLogo.Size = new System.Drawing.Size(91, 38);
            this.btnUploadLogo.TabIndex = 4;
            this.btnUploadLogo.Text = "Upload";
            this.btnUploadLogo.UseVisualStyleBackColor = false;
            this.btnUploadLogo.Click += new System.EventHandler(this.btnUploadLogo_Click);
            // 
            // picTeamlogo
            // 
            this.picTeamlogo.Location = new System.Drawing.Point(63, 64);
            this.picTeamlogo.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.picTeamlogo.Name = "picTeamlogo";
            this.picTeamlogo.Size = new System.Drawing.Size(146, 148);
            this.picTeamlogo.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage;
            this.picTeamlogo.TabIndex = 3;
            this.picTeamlogo.TabStop = false;
            this.picTeamlogo.Click += new System.EventHandler(this.picTeamlogo_Click);
            // 
            // btnBack
            // 
            this.btnBack.BackColor = System.Drawing.SystemColors.Window;
            this.btnBack.FlatAppearance.BorderSize = 0;
            this.btnBack.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnBack.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnBack.ForeColor = System.Drawing.Color.Black;
            this.btnBack.Image = global::quanly.Properties.Resources.btnll;
            this.btnBack.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnBack.Location = new System.Drawing.Point(12, 12);
            this.btnBack.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnBack.Name = "btnBack";
            this.btnBack.Size = new System.Drawing.Size(132, 37);
            this.btnBack.TabIndex = 1;
            this.btnBack.Text = "Quay lại";
            this.btnBack.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnBack.UseVisualStyleBackColor = false;
            this.btnBack.Click += new System.EventHandler(this.btnBack_Click);
            // 
            // FormThemDoiBong
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("$this.BackgroundImage")));
            this.ClientSize = new System.Drawing.Size(747, 323);
            this.Controls.Add(this.btnSaveTeam);
            this.Controls.Add(this.Txttendoibong);
            this.Controls.Add(this.txtTeamName);
            this.Controls.Add(this.btnUploadLogo);
            this.Controls.Add(this.picTeamlogo);
            this.Controls.Add(this.btnBack);
            this.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.Name = "FormThemDoiBong";
            this.Text = "ThemDoiBong";
            this.Load += new System.EventHandler(this.FormThemDoiBong_Load);
            ((System.ComponentModel.ISupportInitialize)(this.picTeamlogo)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnBack;
        private System.Windows.Forms.PictureBox picTeamlogo;
        private System.Windows.Forms.Button btnUploadLogo;
        private System.Windows.Forms.OpenFileDialog openFileDialog1;
        private System.Windows.Forms.Label txtTeamName;
        private System.Windows.Forms.TextBox Txttendoibong;
        private System.Windows.Forms.Button btnSaveTeam;
    }
}