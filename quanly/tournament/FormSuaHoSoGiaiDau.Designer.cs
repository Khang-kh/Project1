namespace quanly
{
    partial class FormSuaHoSoGiaiDau
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormSuaHoSoGiaiDau));
            this.lblNgayBatDau = new System.Windows.Forms.Label();
            this.txtListPlayer = new System.Windows.Forms.Label();
            this.lblNgayKetThuc = new System.Windows.Forms.Label();
            this.lbgd = new System.Windows.Forms.Label();
            this.btnUpload = new System.Windows.Forms.Button();
            this.btnBack = new System.Windows.Forms.Button();
            this.picLogoTournament = new System.Windows.Forms.PictureBox();
            this.dateTimePickerStart = new System.Windows.Forms.DateTimePicker();
            this.dateTimePickerEnd = new System.Windows.Forms.DateTimePicker();
            this.pl = new System.Windows.Forms.Panel();
            this.btnDeleteTeam = new System.Windows.Forms.Button();
            this.btnAddTeam = new System.Windows.Forms.Button();
            this.btnSave = new System.Windows.Forms.Button();
            this.flpTeamList = new System.Windows.Forms.FlowLayoutPanel();
            this.txtTounamentName = new System.Windows.Forms.TextBox();
            ((System.ComponentModel.ISupportInitialize)(this.picLogoTournament)).BeginInit();
            this.pl.SuspendLayout();
            this.SuspendLayout();
            // 
            // lblNgayBatDau
            // 
            this.lblNgayBatDau.BackColor = System.Drawing.Color.GhostWhite;
            this.lblNgayBatDau.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblNgayBatDau.Location = new System.Drawing.Point(359, 75);
            this.lblNgayBatDau.Name = "lblNgayBatDau";
            this.lblNgayBatDau.Size = new System.Drawing.Size(138, 33);
            this.lblNgayBatDau.TabIndex = 45;
            this.lblNgayBatDau.Text = "Ngày bắt đầu:";
            this.lblNgayBatDau.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // txtListPlayer
            // 
            this.txtListPlayer.BackColor = System.Drawing.Color.AliceBlue;
            this.txtListPlayer.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtListPlayer.Location = new System.Drawing.Point(3, 7);
            this.txtListPlayer.Name = "txtListPlayer";
            this.txtListPlayer.Size = new System.Drawing.Size(217, 42);
            this.txtListPlayer.TabIndex = 50;
            this.txtListPlayer.Text = "Danh sách đội đăng ký:";
            this.txtListPlayer.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblNgayKetThuc
            // 
            this.lblNgayKetThuc.BackColor = System.Drawing.Color.GhostWhite;
            this.lblNgayKetThuc.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblNgayKetThuc.Location = new System.Drawing.Point(359, 129);
            this.lblNgayKetThuc.Name = "lblNgayKetThuc";
            this.lblNgayKetThuc.Size = new System.Drawing.Size(138, 34);
            this.lblNgayKetThuc.TabIndex = 46;
            this.lblNgayKetThuc.Text = "Ngày kết thúc:";
            this.lblNgayKetThuc.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.lblNgayKetThuc.Click += new System.EventHandler(this.label2_Click);
            // 
            // lbgd
            // 
            this.lbgd.BackColor = System.Drawing.Color.GhostWhite;
            this.lbgd.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbgd.Location = new System.Drawing.Point(359, 13);
            this.lbgd.Name = "lbgd";
            this.lbgd.Size = new System.Drawing.Size(138, 36);
            this.lbgd.TabIndex = 43;
            this.lbgd.Text = "Tên giải đấu:";
            this.lbgd.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // btnUpload
            // 
            this.btnUpload.BackColor = System.Drawing.Color.Blue;
            this.btnUpload.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.btnUpload.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnUpload.Location = new System.Drawing.Point(199, 174);
            this.btnUpload.Name = "btnUpload";
            this.btnUpload.Size = new System.Drawing.Size(90, 38);
            this.btnUpload.TabIndex = 42;
            this.btnUpload.Text = "Upload";
            this.btnUpload.UseVisualStyleBackColor = false;
            this.btnUpload.Click += new System.EventHandler(this.btnUpload_Click);
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
            this.btnBack.Location = new System.Drawing.Point(11, 10);
            this.btnBack.Name = "btnBack";
            this.btnBack.Size = new System.Drawing.Size(125, 36);
            this.btnBack.TabIndex = 39;
            this.btnBack.Text = "Quay lại";
            this.btnBack.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnBack.UseVisualStyleBackColor = false;
            this.btnBack.Click += new System.EventHandler(this.btnBack_Click);
            // 
            // picLogoTournament
            // 
            this.picLogoTournament.BackColor = System.Drawing.Color.GhostWhite;
            this.picLogoTournament.Location = new System.Drawing.Point(168, 9);
            this.picLogoTournament.Name = "picLogoTournament";
            this.picLogoTournament.Size = new System.Drawing.Size(172, 158);
            this.picLogoTournament.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.picLogoTournament.TabIndex = 41;
            this.picLogoTournament.TabStop = false;
            // 
            // dateTimePickerStart
            // 
            this.dateTimePickerStart.Location = new System.Drawing.Point(539, 79);
            this.dateTimePickerStart.Name = "dateTimePickerStart";
            this.dateTimePickerStart.Size = new System.Drawing.Size(248, 22);
            this.dateTimePickerStart.TabIndex = 54;
            // 
            // dateTimePickerEnd
            // 
            this.dateTimePickerEnd.Location = new System.Drawing.Point(539, 134);
            this.dateTimePickerEnd.Name = "dateTimePickerEnd";
            this.dateTimePickerEnd.Size = new System.Drawing.Size(248, 22);
            this.dateTimePickerEnd.TabIndex = 55;
            // 
            // pl
            // 
            this.pl.BackColor = System.Drawing.Color.Navy;
            this.pl.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pl.Controls.Add(this.btnDeleteTeam);
            this.pl.Controls.Add(this.btnAddTeam);
            this.pl.Controls.Add(this.btnSave);
            this.pl.Controls.Add(this.flpTeamList);
            this.pl.Controls.Add(this.txtListPlayer);
            this.pl.Location = new System.Drawing.Point(22, 218);
            this.pl.Name = "pl";
            this.pl.Size = new System.Drawing.Size(942, 543);
            this.pl.TabIndex = 56;
            // 
            // btnDeleteTeam
            // 
            this.btnDeleteTeam.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.btnDeleteTeam.Location = new System.Drawing.Point(137, 487);
            this.btnDeleteTeam.Name = "btnDeleteTeam";
            this.btnDeleteTeam.Size = new System.Drawing.Size(121, 41);
            this.btnDeleteTeam.TabIndex = 52;
            this.btnDeleteTeam.Text = "Xóa đội bóng";
            this.btnDeleteTeam.UseVisualStyleBackColor = true;
            this.btnDeleteTeam.Click += new System.EventHandler(this.btnDeleteTeam_Click);
            // 
            // btnAddTeam
            // 
            this.btnAddTeam.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.btnAddTeam.Location = new System.Drawing.Point(7, 487);
            this.btnAddTeam.Name = "btnAddTeam";
            this.btnAddTeam.Size = new System.Drawing.Size(121, 41);
            this.btnAddTeam.TabIndex = 51;
            this.btnAddTeam.Text = "Thêm đội bóng";
            this.btnAddTeam.UseVisualStyleBackColor = true;
            this.btnAddTeam.Click += new System.EventHandler(this.btnAddTeam_Click);
            // 
            // btnSave
            // 
            this.btnSave.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.btnSave.Location = new System.Drawing.Point(776, 484);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(130, 44);
            this.btnSave.TabIndex = 38;
            this.btnSave.Text = "Lưu";
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // flpTeamList
            // 
            this.flpTeamList.AutoScroll = true;
            this.flpTeamList.BackColor = System.Drawing.Color.AliceBlue;
            this.flpTeamList.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.flpTeamList.Location = new System.Drawing.Point(3, 53);
            this.flpTeamList.Name = "flpTeamList";
            this.flpTeamList.Padding = new System.Windows.Forms.Padding(10);
            this.flpTeamList.Size = new System.Drawing.Size(922, 425);
            this.flpTeamList.TabIndex = 48;
            this.flpTeamList.Paint += new System.Windows.Forms.PaintEventHandler(this.flpTeamList_Paint);
            // 
            // txtTounamentName
            // 
            this.txtTounamentName.Location = new System.Drawing.Point(539, 18);
            this.txtTounamentName.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.txtTounamentName.Multiline = true;
            this.txtTounamentName.Name = "txtTounamentName";
            this.txtTounamentName.Size = new System.Drawing.Size(248, 33);
            this.txtTounamentName.TabIndex = 58;
            // 
            // FormSuaHoSoGiaiDau
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoScroll = true;
            this.BackColor = System.Drawing.Color.Blue;
            this.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("$this.BackgroundImage")));
            this.ClientSize = new System.Drawing.Size(1009, 777);
            this.Controls.Add(this.txtTounamentName);
            this.Controls.Add(this.pl);
            this.Controls.Add(this.dateTimePickerEnd);
            this.Controls.Add(this.dateTimePickerStart);
            this.Controls.Add(this.btnUpload);
            this.Controls.Add(this.btnBack);
            this.Controls.Add(this.picLogoTournament);
            this.Controls.Add(this.lblNgayBatDau);
            this.Controls.Add(this.lblNgayKetThuc);
            this.Controls.Add(this.lbgd);
            this.Name = "FormSuaHoSoGiaiDau";
            this.Text = "Sửa hồ sơ giải đấu";
            this.Load += new System.EventHandler(this.FormSuaHoSoGiaiDau_Load);
            ((System.ComponentModel.ISupportInitialize)(this.picLogoTournament)).EndInit();
            this.pl.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Button btnUpload;
        private System.Windows.Forms.Button btnBack;
        private System.Windows.Forms.PictureBox picLogoTournament;
        private System.Windows.Forms.Label lblNgayBatDau;
        private System.Windows.Forms.Label txtListPlayer;
        private System.Windows.Forms.Label lblNgayKetThuc;
        private System.Windows.Forms.Label lbgd;
        private System.Windows.Forms.DateTimePicker dateTimePickerStart;
        private System.Windows.Forms.DateTimePicker dateTimePickerEnd;
        private System.Windows.Forms.Panel pl;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.FlowLayoutPanel flpTeamList;
        private System.Windows.Forms.TextBox txtTounamentName;
        private System.Windows.Forms.Button btnAddTeam;
        private System.Windows.Forms.Button btnDeleteTeam;
    }
}