namespace quanly
{
    partial class FormTaoHoSoGiaiDau
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormTaoHoSoGiaiDau));
            this.lblTounamentName = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.label3 = new System.Windows.Forms.Label();
            this.btnDeleteTeam = new System.Windows.Forms.Button();
            this.btnAddTeam = new System.Windows.Forms.Button();
            this.btnSave = new System.Windows.Forms.Button();
            this.flpTeamList = new System.Windows.Forms.FlowLayoutPanel();
            this.txtTounamentName = new System.Windows.Forms.TextBox();
            this.dateTimePickerStart = new System.Windows.Forms.DateTimePicker();
            this.dateTimePickerEnd = new System.Windows.Forms.DateTimePicker();
            this.btnUploadLogoTournament = new System.Windows.Forms.Button();
            this.picLogoTournament = new System.Windows.Forms.PictureBox();
            this.btnBack = new System.Windows.Forms.Button();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picLogoTournament)).BeginInit();
            this.SuspendLayout();
            // 
            // lblTounamentName
            // 
            this.lblTounamentName.BackColor = System.Drawing.Color.White;
            this.lblTounamentName.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTounamentName.Location = new System.Drawing.Point(366, 12);
            this.lblTounamentName.Name = "lblTounamentName";
            this.lblTounamentName.Size = new System.Drawing.Size(142, 36);
            this.lblTounamentName.TabIndex = 28;
            this.lblTounamentName.Text = "Tên giải đấu:";
            this.lblTounamentName.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.lblTounamentName.Click += new System.EventHandler(this.lblTounamentName_Click);
            // 
            // label1
            // 
            this.label1.BackColor = System.Drawing.Color.White;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(366, 68);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(142, 30);
            this.label1.TabIndex = 30;
            this.label1.Text = "Ngày bắt đầu:";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label2
            // 
            this.label2.BackColor = System.Drawing.Color.White;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(366, 118);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(142, 35);
            this.label2.TabIndex = 31;
            this.label2.Text = "Ngày kết thúc: ";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.Navy;
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel1.Controls.Add(this.label3);
            this.panel1.Controls.Add(this.btnDeleteTeam);
            this.panel1.Controls.Add(this.btnAddTeam);
            this.panel1.Controls.Add(this.btnSave);
            this.panel1.Controls.Add(this.flpTeamList);
            this.panel1.Location = new System.Drawing.Point(19, 210);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(894, 600);
            this.panel1.TabIndex = 34;
            this.panel1.Paint += new System.Windows.Forms.PaintEventHandler(this.panel1_Paint);
            // 
            // label3
            // 
            this.label3.BackColor = System.Drawing.Color.AliceBlue;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(5, 7);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(224, 42);
            this.label3.TabIndex = 51;
            this.label3.Text = "Danh sách đội đăng ký:";
            this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // btnDeleteTeam
            // 
            this.btnDeleteTeam.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.btnDeleteTeam.Location = new System.Drawing.Point(152, 546);
            this.btnDeleteTeam.Name = "btnDeleteTeam";
            this.btnDeleteTeam.Size = new System.Drawing.Size(121, 41);
            this.btnDeleteTeam.TabIndex = 49;
            this.btnDeleteTeam.Text = "Xóa đội bóng";
            this.btnDeleteTeam.UseVisualStyleBackColor = true;
            this.btnDeleteTeam.Click += new System.EventHandler(this.btnDeleteTeam_Click);
            // 
            // btnAddTeam
            // 
            this.btnAddTeam.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.btnAddTeam.Location = new System.Drawing.Point(6, 546);
            this.btnAddTeam.Name = "btnAddTeam";
            this.btnAddTeam.Size = new System.Drawing.Size(121, 41);
            this.btnAddTeam.TabIndex = 36;
            this.btnAddTeam.Text = "Thêm đội bóng";
            this.btnAddTeam.UseVisualStyleBackColor = true;
            this.btnAddTeam.Click += new System.EventHandler(this.btnAddTeam_Click);
            // 
            // btnSave
            // 
            this.btnSave.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.btnSave.Location = new System.Drawing.Point(764, 546);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(121, 41);
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
            this.flpTeamList.Location = new System.Drawing.Point(6, 53);
            this.flpTeamList.Name = "flpTeamList";
            this.flpTeamList.Size = new System.Drawing.Size(879, 479);
            this.flpTeamList.TabIndex = 48;
            this.flpTeamList.Paint += new System.Windows.Forms.PaintEventHandler(this.flpTeamList_Paint);
            // 
            // txtTounamentName
            // 
            this.txtTounamentName.Location = new System.Drawing.Point(534, 12);
            this.txtTounamentName.Multiline = true;
            this.txtTounamentName.Name = "txtTounamentName";
            this.txtTounamentName.Size = new System.Drawing.Size(263, 36);
            this.txtTounamentName.TabIndex = 39;
            this.txtTounamentName.TextChanged += new System.EventHandler(this.txtTounamentName_TextChanged);
            // 
            // dateTimePickerStart
            // 
            this.dateTimePickerStart.Location = new System.Drawing.Point(534, 71);
            this.dateTimePickerStart.Name = "dateTimePickerStart";
            this.dateTimePickerStart.Size = new System.Drawing.Size(264, 22);
            this.dateTimePickerStart.TabIndex = 40;
            this.dateTimePickerStart.ValueChanged += new System.EventHandler(this.dateTimePicker1_ValueChanged);
            // 
            // dateTimePickerEnd
            // 
            this.dateTimePickerEnd.Location = new System.Drawing.Point(533, 123);
            this.dateTimePickerEnd.Name = "dateTimePickerEnd";
            this.dateTimePickerEnd.Size = new System.Drawing.Size(264, 22);
            this.dateTimePickerEnd.TabIndex = 41;
            this.dateTimePickerEnd.ValueChanged += new System.EventHandler(this.dateTimePicker2_ValueChanged);
            // 
            // btnUploadLogoTournament
            // 
            this.btnUploadLogoTournament.BackColor = System.Drawing.Color.Transparent;
            this.btnUploadLogoTournament.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnUploadLogoTournament.Location = new System.Drawing.Point(204, 166);
            this.btnUploadLogoTournament.Name = "btnUploadLogoTournament";
            this.btnUploadLogoTournament.Size = new System.Drawing.Size(90, 38);
            this.btnUploadLogoTournament.TabIndex = 27;
            this.btnUploadLogoTournament.Text = "Upload";
            this.btnUploadLogoTournament.UseVisualStyleBackColor = false;
            this.btnUploadLogoTournament.Click += new System.EventHandler(this.btnUpload_Click);
            // 
            // picLogoTournament
            // 
            this.picLogoTournament.BackColor = System.Drawing.Color.AliceBlue;
            this.picLogoTournament.Location = new System.Drawing.Point(172, 6);
            this.picLogoTournament.Name = "picLogoTournament";
            this.picLogoTournament.Size = new System.Drawing.Size(172, 153);
            this.picLogoTournament.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.picLogoTournament.TabIndex = 26;
            this.picLogoTournament.TabStop = false;
            this.picLogoTournament.Click += new System.EventHandler(this.picLogoTournament_Click);
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
            this.btnBack.Name = "btnBack";
            this.btnBack.Size = new System.Drawing.Size(122, 36);
            this.btnBack.TabIndex = 24;
            this.btnBack.Text = "Quay lại";
            this.btnBack.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnBack.UseVisualStyleBackColor = false;
            this.btnBack.Click += new System.EventHandler(this.btnBack_Click);
            // 
            // FormTaoHoSoGiaiDau
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoScroll = true;
            this.BackColor = System.Drawing.Color.Blue;
            this.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("$this.BackgroundImage")));
            this.ClientSize = new System.Drawing.Size(940, 822);
            this.Controls.Add(this.dateTimePickerEnd);
            this.Controls.Add(this.dateTimePickerStart);
            this.Controls.Add(this.txtTounamentName);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.lblTounamentName);
            this.Controls.Add(this.btnUploadLogoTournament);
            this.Controls.Add(this.picLogoTournament);
            this.Controls.Add(this.btnBack);
            this.Name = "FormTaoHoSoGiaiDau";
            this.Text = "Thêm giải đấu";
            this.Load += new System.EventHandler(this.FormTaoHoSoGiaiDau_Load);
            this.panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.picLogoTournament)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Label lblTounamentName;
        private System.Windows.Forms.Button btnUploadLogoTournament;
        private System.Windows.Forms.PictureBox picLogoTournament;
        private System.Windows.Forms.Button btnBack;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.TextBox txtTounamentName;
        private System.Windows.Forms.FlowLayoutPanel flpTeamList;
        private System.Windows.Forms.Button btnAddTeam;
        private System.Windows.Forms.DateTimePicker dateTimePickerStart;
        private System.Windows.Forms.DateTimePicker dateTimePickerEnd;
        private System.Windows.Forms.Button btnDeleteTeam;
        private System.Windows.Forms.Label label3;
    }
}