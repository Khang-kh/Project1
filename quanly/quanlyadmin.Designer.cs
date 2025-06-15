namespace quanly
{
    partial class FormPQ
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormPQ));
            this.Control = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.TextboxSearch = new System.Windows.Forms.TextBox();
            this.btnSearch = new System.Windows.Forms.Button();
            this.Delete = new System.Windows.Forms.Button();
            this.Modify = new System.Windows.Forms.Button();
            this.Add = new System.Windows.Forms.Button();
            this.flowLayoutPanel1 = new System.Windows.Forms.FlowLayoutPanel();
            this.btnBack = new System.Windows.Forms.Button();
            this.ShowAdmin = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // Control
            // 
            this.Control.BackColor = System.Drawing.Color.White;
            this.Control.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Control.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.Control.Location = new System.Drawing.Point(287, 10);
            this.Control.Name = "Control";
            this.Control.Size = new System.Drawing.Size(314, 78);
            this.Control.TabIndex = 8;
            this.Control.Text = "Quản Lý Admin";
            this.Control.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label1
            // 
            this.label1.BackColor = System.Drawing.Color.White;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(79, 134);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(169, 34);
            this.label1.TabIndex = 9;
            this.label1.Text = "Tìm kiếm Admin";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // TextboxSearch
            // 
            this.TextboxSearch.Location = new System.Drawing.Point(287, 134);
            this.TextboxSearch.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.TextboxSearch.Multiline = true;
            this.TextboxSearch.Name = "TextboxSearch";
            this.TextboxSearch.Size = new System.Drawing.Size(314, 34);
            this.TextboxSearch.TabIndex = 10;
            // 
            // btnSearch
            // 
            this.btnSearch.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSearch.Location = new System.Drawing.Point(343, 198);
            this.btnSearch.Name = "btnSearch";
            this.btnSearch.Size = new System.Drawing.Size(195, 37);
            this.btnSearch.TabIndex = 11;
            this.btnSearch.Text = "Tìm kiếm";
            this.btnSearch.UseVisualStyleBackColor = true;
            this.btnSearch.Click += new System.EventHandler(this.btnSearch_Click);
            // 
            // Delete
            // 
            this.Delete.BackColor = System.Drawing.Color.White;
            this.Delete.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Delete.Location = new System.Drawing.Point(470, 423);
            this.Delete.Name = "Delete";
            this.Delete.Size = new System.Drawing.Size(170, 44);
            this.Delete.TabIndex = 39;
            this.Delete.Text = "Xóa Admin";
            this.Delete.UseVisualStyleBackColor = false;
            this.Delete.Click += new System.EventHandler(this.Delete_Click);
            // 
            // Modify
            // 
            this.Modify.BackColor = System.Drawing.Color.White;
            this.Modify.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Modify.Location = new System.Drawing.Point(256, 423);
            this.Modify.Name = "Modify";
            this.Modify.Size = new System.Drawing.Size(170, 44);
            this.Modify.TabIndex = 38;
            this.Modify.Text = "Sửa Admin";
            this.Modify.UseVisualStyleBackColor = false;
            this.Modify.Click += new System.EventHandler(this.Modify_Click);
            // 
            // Add
            // 
            this.Add.BackColor = System.Drawing.Color.White;
            this.Add.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Add.Location = new System.Drawing.Point(26, 423);
            this.Add.Name = "Add";
            this.Add.Size = new System.Drawing.Size(170, 44);
            this.Add.TabIndex = 37;
            this.Add.Text = "Thêm Admin";
            this.Add.UseVisualStyleBackColor = false;
            this.Add.Click += new System.EventHandler(this.Add_Click);
            // 
            // flowLayoutPanel1
            // 
            this.flowLayoutPanel1.AutoScroll = true;
            this.flowLayoutPanel1.BackColor = System.Drawing.Color.White;
            this.flowLayoutPanel1.Location = new System.Drawing.Point(11, 260);
            this.flowLayoutPanel1.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.flowLayoutPanel1.Name = "flowLayoutPanel1";
            this.flowLayoutPanel1.Size = new System.Drawing.Size(872, 142);
            this.flowLayoutPanel1.TabIndex = 41;
            this.flowLayoutPanel1.Paint += new System.Windows.Forms.PaintEventHandler(this.flowLayoutPanel1_Paint);
            // 
            // btnBack
            // 
            this.btnBack.BackColor = System.Drawing.SystemColors.Window;
            this.btnBack.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnBack.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnBack.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnBack.ImageKey = "(none)";
            this.btnBack.Location = new System.Drawing.Point(11, 10);
            this.btnBack.Name = "btnBack";
            this.btnBack.Size = new System.Drawing.Size(123, 46);
            this.btnBack.TabIndex = 7;
            this.btnBack.Text = "Quay lại";
            this.btnBack.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnBack.UseVisualStyleBackColor = false;
            this.btnBack.Click += new System.EventHandler(this.btnBack_Click);
            // 
            // ShowAdmin
            // 
            this.ShowAdmin.BackColor = System.Drawing.Color.White;
            this.ShowAdmin.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ShowAdmin.Location = new System.Drawing.Point(686, 423);
            this.ShowAdmin.Name = "ShowAdmin";
            this.ShowAdmin.Size = new System.Drawing.Size(179, 44);
            this.ShowAdmin.TabIndex = 42;
            this.ShowAdmin.Text = "Hiển thị tất cả Admin";
            this.ShowAdmin.UseVisualStyleBackColor = false;
            this.ShowAdmin.Click += new System.EventHandler(this.ShowAdmin_Click);
            // 
            // FormPQ
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Blue;
            this.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("$this.BackgroundImage")));
            this.ClientSize = new System.Drawing.Size(895, 486);
            this.Controls.Add(this.ShowAdmin);
            this.Controls.Add(this.flowLayoutPanel1);
            this.Controls.Add(this.Delete);
            this.Controls.Add(this.Modify);
            this.Controls.Add(this.Add);
            this.Controls.Add(this.btnSearch);
            this.Controls.Add(this.TextboxSearch);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.Control);
            this.Controls.Add(this.btnBack);
            this.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.Name = "FormPQ";
            this.Text = "Phân Quyền";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnBack;
        private System.Windows.Forms.Label Control;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox TextboxSearch;
        private System.Windows.Forms.Button btnSearch;
        private System.Windows.Forms.Button Delete;
        private System.Windows.Forms.Button Modify;
        private System.Windows.Forms.Button Add;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel1;
        private System.Windows.Forms.Button ShowAdmin;
    }
}

