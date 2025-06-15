namespace quanly.schedule
{
    partial class AddnewSchedule
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
            this.btnBack = new System.Windows.Forms.Button();
            this.homepic = new System.Windows.Forms.PictureBox();
            this.awaypic = new System.Windows.Forms.PictureBox();
            this.dateTime = new System.Windows.Forms.DateTimePicker();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.comboBoxStatus = new System.Windows.Forms.ComboBox();
            this.lbScore = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.comboBoxHomeTeam = new System.Windows.Forms.ComboBox();
            this.comboBoxAwayTeam = new System.Windows.Forms.ComboBox();
            this.lbnha = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.comboBoxTournament = new System.Windows.Forms.ComboBox();
            this.buttonHomelineup = new System.Windows.Forms.Button();
            this.buttonSublineup = new System.Windows.Forms.Button();
            this.buttonSave = new System.Windows.Forms.Button();
            this.textBoxLocation = new System.Windows.Forms.TextBox();
            this.textBoxHome = new System.Windows.Forms.TextBox();
            this.textBoxAway = new System.Windows.Forms.TextBox();
            this.buttonExit = new System.Windows.Forms.Button();
            this.panel1 = new System.Windows.Forms.Panel();
            ((System.ComponentModel.ISupportInitialize)(this.homepic)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.awaypic)).BeginInit();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
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
            this.btnBack.Location = new System.Drawing.Point(23, 23);
            this.btnBack.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.btnBack.Name = "btnBack";
            this.btnBack.Size = new System.Drawing.Size(137, 45);
            this.btnBack.TabIndex = 26;
            this.btnBack.Text = "Quay lại";
            this.btnBack.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnBack.UseVisualStyleBackColor = false;
            this.btnBack.Click += new System.EventHandler(this.btnBack_Click);
            // 
            // homepic
            // 
            this.homepic.Location = new System.Drawing.Point(32, 164);
            this.homepic.Name = "homepic";
            this.homepic.Size = new System.Drawing.Size(343, 262);
            this.homepic.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.homepic.TabIndex = 27;
            this.homepic.TabStop = false;
            // 
            // awaypic
            // 
            this.awaypic.Location = new System.Drawing.Point(656, 164);
            this.awaypic.Name = "awaypic";
            this.awaypic.Size = new System.Drawing.Size(343, 262);
            this.awaypic.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.awaypic.TabIndex = 28;
            this.awaypic.TabStop = false;
            // 
            // dateTime
            // 
            this.dateTime.CustomFormat = "\"dd/MM/yyyy HH:mm\"";
            this.dateTime.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dateTime.Location = new System.Drawing.Point(18, 167);
            this.dateTime.Name = "dateTime";
            this.dateTime.Size = new System.Drawing.Size(253, 26);
            this.dateTime.TabIndex = 29;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.label1.Location = new System.Drawing.Point(80, 134);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(125, 20);
            this.label1.TabIndex = 30;
            this.label1.Text = "Thời gian thi đấu";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.BackColor = System.Drawing.SystemColors.HighlightText;
            this.label2.Location = new System.Drawing.Point(80, 220);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(143, 20);
            this.label2.TabIndex = 32;
            this.label2.Text = "Trạng thái trận đấu";
            // 
            // comboBoxStatus
            // 
            this.comboBoxStatus.FormattingEnabled = true;
            this.comboBoxStatus.Location = new System.Drawing.Point(84, 254);
            this.comboBoxStatus.Name = "comboBoxStatus";
            this.comboBoxStatus.Size = new System.Drawing.Size(121, 28);
            this.comboBoxStatus.TabIndex = 33;
            // 
            // lbScore
            // 
            this.lbScore.AutoSize = true;
            this.lbScore.BackColor = System.Drawing.SystemColors.HighlightText;
            this.lbScore.Location = new System.Drawing.Point(125, 306);
            this.lbScore.Name = "lbScore";
            this.lbScore.Size = new System.Drawing.Size(46, 20);
            this.lbScore.TabIndex = 34;
            this.lbScore.Text = "Tỉ số:";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.BackColor = System.Drawing.Color.White;
            this.label5.Location = new System.Drawing.Point(17, 82);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(127, 20);
            this.label5.TabIndex = 37;
            this.label5.Text = "Địa điểm thi đấu:";
            // 
            // comboBoxHomeTeam
            // 
            this.comboBoxHomeTeam.FormattingEnabled = true;
            this.comboBoxHomeTeam.Location = new System.Drawing.Point(32, 452);
            this.comboBoxHomeTeam.Name = "comboBoxHomeTeam";
            this.comboBoxHomeTeam.Size = new System.Drawing.Size(236, 28);
            this.comboBoxHomeTeam.TabIndex = 39;
            // 
            // comboBoxAwayTeam
            // 
            this.comboBoxAwayTeam.FormattingEnabled = true;
            this.comboBoxAwayTeam.Location = new System.Drawing.Point(763, 452);
            this.comboBoxAwayTeam.Name = "comboBoxAwayTeam";
            this.comboBoxAwayTeam.Size = new System.Drawing.Size(236, 28);
            this.comboBoxAwayTeam.TabIndex = 40;
            // 
            // lbnha
            // 
            this.lbnha.AutoSize = true;
            this.lbnha.Location = new System.Drawing.Point(34, 126);
            this.lbnha.Name = "lbnha";
            this.lbnha.Size = new System.Drawing.Size(64, 20);
            this.lbnha.TabIndex = 41;
            this.lbnha.Text = "Đội nhà";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(919, 126);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(80, 20);
            this.label4.TabIndex = 42;
            this.label4.Text = "Đội khách";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.BackColor = System.Drawing.SystemColors.Window;
            this.label3.Location = new System.Drawing.Point(46, 29);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(99, 20);
            this.label3.TabIndex = 43;
            this.label3.Text = "Tên giải đấu:";
            // 
            // comboBoxTournament
            // 
            this.comboBoxTournament.FormattingEnabled = true;
            this.comboBoxTournament.Location = new System.Drawing.Point(150, 29);
            this.comboBoxTournament.Name = "comboBoxTournament";
            this.comboBoxTournament.Size = new System.Drawing.Size(104, 28);
            this.comboBoxTournament.TabIndex = 44;
            // 
            // buttonHomelineup
            // 
            this.buttonHomelineup.Location = new System.Drawing.Point(32, 499);
            this.buttonHomelineup.Name = "buttonHomelineup";
            this.buttonHomelineup.Size = new System.Drawing.Size(162, 45);
            this.buttonHomelineup.TabIndex = 45;
            this.buttonHomelineup.Text = "Đội hình đội nhà";
            this.buttonHomelineup.UseVisualStyleBackColor = true;
            this.buttonHomelineup.Click += new System.EventHandler(this.buttonHomelineup_Click);
            // 
            // buttonSublineup
            // 
            this.buttonSublineup.Location = new System.Drawing.Point(839, 499);
            this.buttonSublineup.Name = "buttonSublineup";
            this.buttonSublineup.Size = new System.Drawing.Size(160, 45);
            this.buttonSublineup.TabIndex = 46;
            this.buttonSublineup.Text = "Đội hình đội khách";
            this.buttonSublineup.UseVisualStyleBackColor = true;
            this.buttonSublineup.Click += new System.EventHandler(this.buttonSublineup_Click);
            // 
            // buttonSave
            // 
            this.buttonSave.Location = new System.Drawing.Point(921, 573);
            this.buttonSave.Name = "buttonSave";
            this.buttonSave.Size = new System.Drawing.Size(78, 41);
            this.buttonSave.TabIndex = 47;
            this.buttonSave.Text = "Lưu";
            this.buttonSave.UseVisualStyleBackColor = true;
            this.buttonSave.Click += new System.EventHandler(this.buttonSave_Click);
            // 
            // textBoxLocation
            // 
            this.textBoxLocation.Location = new System.Drawing.Point(150, 79);
            this.textBoxLocation.Name = "textBoxLocation";
            this.textBoxLocation.Size = new System.Drawing.Size(100, 26);
            this.textBoxLocation.TabIndex = 48;
            // 
            // textBoxHome
            // 
            this.textBoxHome.Location = new System.Drawing.Point(44, 329);
            this.textBoxHome.Name = "textBoxHome";
            this.textBoxHome.Size = new System.Drawing.Size(100, 26);
            this.textBoxHome.TabIndex = 49;
            // 
            // textBoxAway
            // 
            this.textBoxAway.Location = new System.Drawing.Point(154, 329);
            this.textBoxAway.Name = "textBoxAway";
            this.textBoxAway.Size = new System.Drawing.Size(100, 26);
            this.textBoxAway.TabIndex = 50;
            // 
            // buttonExit
            // 
            this.buttonExit.Location = new System.Drawing.Point(486, 573);
            this.buttonExit.Name = "buttonExit";
            this.buttonExit.Size = new System.Drawing.Size(78, 41);
            this.buttonExit.TabIndex = 51;
            this.buttonExit.Text = "Thoát";
            this.buttonExit.UseVisualStyleBackColor = true;
            this.buttonExit.Click += new System.EventHandler(this.buttonExit_Click);
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.label3);
            this.panel1.Controls.Add(this.textBoxAway);
            this.panel1.Controls.Add(this.comboBoxTournament);
            this.panel1.Controls.Add(this.textBoxHome);
            this.panel1.Controls.Add(this.textBoxLocation);
            this.panel1.Controls.Add(this.label5);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Controls.Add(this.dateTime);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Controls.Add(this.comboBoxStatus);
            this.panel1.Controls.Add(this.lbScore);
            this.panel1.Location = new System.Drawing.Point(379, 58);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(275, 368);
            this.panel1.TabIndex = 52;
            // 
            // AddnewSchedule
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = global::quanly.Properties.Resources.hình_nền;
            this.ClientSize = new System.Drawing.Size(1040, 626);
            this.Controls.Add(this.buttonExit);
            this.Controls.Add(this.buttonSave);
            this.Controls.Add(this.buttonSublineup);
            this.Controls.Add(this.buttonHomelineup);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.lbnha);
            this.Controls.Add(this.comboBoxAwayTeam);
            this.Controls.Add(this.comboBoxHomeTeam);
            this.Controls.Add(this.awaypic);
            this.Controls.Add(this.homepic);
            this.Controls.Add(this.btnBack);
            this.Controls.Add(this.panel1);
            this.Name = "AddnewSchedule";
            this.Text = "AddnewSchedule";
            ((System.ComponentModel.ISupportInitialize)(this.homepic)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.awaypic)).EndInit();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnBack;
        private System.Windows.Forms.PictureBox homepic;
        private System.Windows.Forms.PictureBox awaypic;
        private System.Windows.Forms.DateTimePicker dateTime;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox comboBoxStatus;
        private System.Windows.Forms.Label lbScore;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.ComboBox comboBoxHomeTeam;
        private System.Windows.Forms.ComboBox comboBoxAwayTeam;
        private System.Windows.Forms.Label lbnha;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ComboBox comboBoxTournament;
        private System.Windows.Forms.Button buttonHomelineup;
        private System.Windows.Forms.Button buttonSublineup;
        private System.Windows.Forms.Button buttonSave;
        private System.Windows.Forms.TextBox textBoxLocation;
        private System.Windows.Forms.TextBox textBoxHome;
        private System.Windows.Forms.TextBox textBoxAway;
        private System.Windows.Forms.Button buttonExit;
        private System.Windows.Forms.Panel panel1;
    }
}