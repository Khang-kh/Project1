namespace quanly
{
    partial class UC_Admin
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
            this.lbname = new System.Windows.Forms.Label();
            this.lbemail = new System.Windows.Forms.Label();
            this.Btnmodifty = new System.Windows.Forms.Button();
            this.BtnDelete = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // lbname
            // 
            this.lbname.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lbname.Location = new System.Drawing.Point(3, 40);
            this.lbname.Name = "lbname";
            this.lbname.Size = new System.Drawing.Size(111, 28);
            this.lbname.TabIndex = 1;
            this.lbname.Text = "Username";
            // 
            // lbemail
            // 
            this.lbemail.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lbemail.Location = new System.Drawing.Point(120, 40);
            this.lbemail.Name = "lbemail";
            this.lbemail.Size = new System.Drawing.Size(175, 28);
            this.lbemail.TabIndex = 2;
            this.lbemail.Text = "Email";
            // 
            // Btnmodifty
            // 
            this.Btnmodifty.Location = new System.Drawing.Point(3, 3);
            this.Btnmodifty.Name = "Btnmodifty";
            this.Btnmodifty.Size = new System.Drawing.Size(75, 34);
            this.Btnmodifty.TabIndex = 3;
            this.Btnmodifty.Text = "Sửa";
            this.Btnmodifty.UseVisualStyleBackColor = true;
            this.Btnmodifty.Click += new System.EventHandler(this.Btnmodifty_Click);
            // 
            // BtnDelete
            // 
            this.BtnDelete.Location = new System.Drawing.Point(220, 3);
            this.BtnDelete.Name = "BtnDelete";
            this.BtnDelete.Size = new System.Drawing.Size(75, 34);
            this.BtnDelete.TabIndex = 4;
            this.BtnDelete.Text = "Xóa";
            this.BtnDelete.UseVisualStyleBackColor = true;
            this.BtnDelete.Click += new System.EventHandler(this.BtnDelete_Click);
            // 
            // UC_Admin
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(128)))));
            this.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.Controls.Add(this.BtnDelete);
            this.Controls.Add(this.Btnmodifty);
            this.Controls.Add(this.lbemail);
            this.Controls.Add(this.lbname);
            this.Name = "UC_Admin";
            this.Size = new System.Drawing.Size(298, 91);
            this.Load += new System.EventHandler(this.UC_Admin_Load);
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Label lbname;
        private System.Windows.Forms.Label lbemail;
        private System.Windows.Forms.Button Btnmodifty;
        private System.Windows.Forms.Button BtnDelete;
    }
}
