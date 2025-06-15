namespace quanly
{
    partial class FormBaibao
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormBaibao));
            this.btnBack = new System.Windows.Forms.Button();
            this.Control = new System.Windows.Forms.Label();
            this.lb = new System.Windows.Forms.Label();
            this.TextboxSearch = new System.Windows.Forms.TextBox();
            this.btnSearch = new System.Windows.Forms.Button();
            this.flowLayoutPanel1 = new System.Windows.Forms.FlowLayoutPanel();
            this.ShowAll = new System.Windows.Forms.Button();
            this.Delete = new System.Windows.Forms.Button();
            this.Modify = new System.Windows.Forms.Button();
            this.Add = new System.Windows.Forms.Button();
            this.SuspendLayout();
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
            this.btnBack.Size = new System.Drawing.Size(125, 44);
            this.btnBack.TabIndex = 8;
            this.btnBack.Text = "Quay lại";
            this.btnBack.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnBack.UseVisualStyleBackColor = false;
            this.btnBack.Click += new System.EventHandler(this.btnBack_Click);
            // 
            // Control
            // 
            this.Control.BackColor = System.Drawing.Color.White;
            this.Control.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Control.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.Control.Location = new System.Drawing.Point(307, 21);
            this.Control.Name = "Control";
            this.Control.Size = new System.Drawing.Size(314, 78);
            this.Control.TabIndex = 9;
            this.Control.Text = "Quản Lý Bài báo";
            this.Control.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lb
            // 
            this.lb.BackColor = System.Drawing.Color.White;
            this.lb.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lb.Location = new System.Drawing.Point(108, 144);
            this.lb.Name = "lb";
            this.lb.Size = new System.Drawing.Size(169, 34);
            this.lb.TabIndex = 10;
            this.lb.Text = "Tìm kiếm Bài báo";
            this.lb.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // TextboxSearch
            // 
            this.TextboxSearch.Location = new System.Drawing.Point(307, 144);
            this.TextboxSearch.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.TextboxSearch.Multiline = true;
            this.TextboxSearch.Name = "TextboxSearch";
            this.TextboxSearch.Size = new System.Drawing.Size(314, 34);
            this.TextboxSearch.TabIndex = 11;
            // 
            // btnSearch
            // 
            this.btnSearch.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSearch.Location = new System.Drawing.Point(364, 194);
            this.btnSearch.Name = "btnSearch";
            this.btnSearch.Size = new System.Drawing.Size(195, 37);
            this.btnSearch.TabIndex = 12;
            this.btnSearch.Text = "Tìm kiếm";
            this.btnSearch.UseVisualStyleBackColor = true;
            this.btnSearch.Click += new System.EventHandler(this.btnSearch_Click);
            // 
            // flowLayoutPanel1
            // 
            this.flowLayoutPanel1.AutoScroll = true;
            this.flowLayoutPanel1.BackColor = System.Drawing.Color.White;
            this.flowLayoutPanel1.Location = new System.Drawing.Point(25, 237);
            this.flowLayoutPanel1.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.flowLayoutPanel1.Name = "flowLayoutPanel1";
            this.flowLayoutPanel1.Size = new System.Drawing.Size(875, 180);
            this.flowLayoutPanel1.TabIndex = 42;
            // 
            // ShowAll
            // 
            this.ShowAll.BackColor = System.Drawing.Color.White;
            this.ShowAll.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ShowAll.Location = new System.Drawing.Point(710, 437);
            this.ShowAll.Name = "ShowAll";
            this.ShowAll.Size = new System.Drawing.Size(179, 44);
            this.ShowAll.TabIndex = 46;
            this.ShowAll.Text = "Hiển thị tất cả";
            this.ShowAll.UseVisualStyleBackColor = false;
            this.ShowAll.Click += new System.EventHandler(this.ShowAll_Click);
            // 
            // Delete
            // 
            this.Delete.BackColor = System.Drawing.Color.White;
            this.Delete.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Delete.Location = new System.Drawing.Point(495, 437);
            this.Delete.Name = "Delete";
            this.Delete.Size = new System.Drawing.Size(170, 44);
            this.Delete.TabIndex = 45;
            this.Delete.Text = "Xóa Bài báo";
            this.Delete.UseVisualStyleBackColor = false;
            this.Delete.Click += new System.EventHandler(this.Delete_Click);
            // 
            // Modify
            // 
            this.Modify.BackColor = System.Drawing.Color.White;
            this.Modify.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Modify.Location = new System.Drawing.Point(269, 437);
            this.Modify.Name = "Modify";
            this.Modify.Size = new System.Drawing.Size(170, 44);
            this.Modify.TabIndex = 44;
            this.Modify.Text = "Sửa Bài báo";
            this.Modify.UseVisualStyleBackColor = false;
            this.Modify.Click += new System.EventHandler(this.Modify_Click);
            // 
            // Add
            // 
            this.Add.BackColor = System.Drawing.Color.White;
            this.Add.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Add.Location = new System.Drawing.Point(34, 437);
            this.Add.Name = "Add";
            this.Add.Size = new System.Drawing.Size(170, 44);
            this.Add.TabIndex = 43;
            this.Add.Text = "Thêm Bài báo";
            this.Add.UseVisualStyleBackColor = false;
            this.Add.Click += new System.EventHandler(this.Add_Click);
            // 
            // FormBaibao
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Blue;
            this.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("$this.BackgroundImage")));
            this.ClientSize = new System.Drawing.Size(924, 501);
            this.Controls.Add(this.ShowAll);
            this.Controls.Add(this.Delete);
            this.Controls.Add(this.Modify);
            this.Controls.Add(this.Add);
            this.Controls.Add(this.flowLayoutPanel1);
            this.Controls.Add(this.btnSearch);
            this.Controls.Add(this.TextboxSearch);
            this.Controls.Add(this.lb);
            this.Controls.Add(this.Control);
            this.Controls.Add(this.btnBack);
            this.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.Name = "FormBaibao";
            this.Text = "Bài báo";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnBack;
        private System.Windows.Forms.Label Control;
        private System.Windows.Forms.Label lb;
        private System.Windows.Forms.TextBox TextboxSearch;
        private System.Windows.Forms.Button btnSearch;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel1;
        private System.Windows.Forms.Button ShowAll;
        private System.Windows.Forms.Button Delete;
        private System.Windows.Forms.Button Modify;
        private System.Windows.Forms.Button Add;
    }
}

