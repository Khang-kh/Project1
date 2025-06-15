namespace quanly
{
    partial class FormSuaHoSoDoiBong
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormSuaHoSoDoiBong));
            this.btnSaveTeam = new System.Windows.Forms.Button();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.txtTeamName = new System.Windows.Forms.Label();
            this.picTeamlogo = new System.Windows.Forms.PictureBox();
            this.btnBack = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.picTeamlogo)).BeginInit();
            this.SuspendLayout();
            // 
            // btnSaveTeam
            // 
            this.btnSaveTeam.BackColor = System.Drawing.Color.White;
            this.btnSaveTeam.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSaveTeam.Location = new System.Drawing.Point(628, 231);
            this.btnSaveTeam.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnSaveTeam.Name = "btnSaveTeam";
            this.btnSaveTeam.Size = new System.Drawing.Size(123, 58);
            this.btnSaveTeam.TabIndex = 31;
            this.btnSaveTeam.Text = "Lưu";
            this.btnSaveTeam.UseVisualStyleBackColor = false;
            this.btnSaveTeam.Click += new System.EventHandler(this.btnSaveTeam_Click);
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(269, 142);
            this.textBox1.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.textBox1.Multiline = true;
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(343, 29);
            this.textBox1.TabIndex = 22;
            // 
            // txtTeamName
            // 
            this.txtTeamName.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtTeamName.Location = new System.Drawing.Point(265, 91);
            this.txtTeamName.Name = "txtTeamName";
            this.txtTeamName.Size = new System.Drawing.Size(113, 31);
            this.txtTeamName.TabIndex = 21;
            this.txtTeamName.Text = "Tên đội bóng";
            this.txtTeamName.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // picTeamlogo
            // 
            this.picTeamlogo.Location = new System.Drawing.Point(59, 69);
            this.picTeamlogo.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.picTeamlogo.Name = "picTeamlogo";
            this.picTeamlogo.Size = new System.Drawing.Size(160, 138);
            this.picTeamlogo.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage;
            this.picTeamlogo.TabIndex = 19;
            this.picTeamlogo.TabStop = false;
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
            this.btnBack.Location = new System.Drawing.Point(21, 11);
            this.btnBack.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnBack.Name = "btnBack";
            this.btnBack.Size = new System.Drawing.Size(107, 46);
            this.btnBack.TabIndex = 17;
            this.btnBack.Text = "Quay lại";
            this.btnBack.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnBack.UseVisualStyleBackColor = false;
            this.btnBack.Click += new System.EventHandler(this.btnBack_Click);
            // 
            // button2
            // 
            this.button2.BackColor = System.Drawing.Color.White;
            this.button2.Location = new System.Drawing.Point(98, 221);
            this.button2.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(91, 38);
            this.button2.TabIndex = 33;
            this.button2.Text = "Upload";
            this.button2.UseVisualStyleBackColor = false;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // FormSuaHoSoDoiBong
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("$this.BackgroundImage")));
            this.ClientSize = new System.Drawing.Size(763, 317);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.btnSaveTeam);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.txtTeamName);
            this.Controls.Add(this.picTeamlogo);
            this.Controls.Add(this.btnBack);
            this.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.Name = "FormSuaHoSoDoiBong";
            this.Text = "FormSuaHoSoDoiBong";
            this.Load += new System.EventHandler(this.FormSuaHoSoDoiBong_Load);
            ((System.ComponentModel.ISupportInitialize)(this.picTeamlogo)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Button btnSaveTeam;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.Label txtTeamName;
        private System.Windows.Forms.PictureBox picTeamlogo;
        private System.Windows.Forms.Button btnBack;
        private System.Windows.Forms.Button button2;
    }
}