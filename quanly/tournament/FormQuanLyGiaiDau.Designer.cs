namespace quanly
{
    partial class FormQuanLyGiaiDau
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormQuanLyGiaiDau));
            this.imageList1 = new System.Windows.Forms.ImageList(this.components);
            this.btnSearch = new System.Windows.Forms.Button();
            this.txtSearch = new System.Windows.Forms.TextBox();
            this.lblTimKiemGiaiDau = new System.Windows.Forms.Label();
            this.btnHienThiTatCa = new System.Windows.Forms.Button();
            this.btnXoaGiaiDau = new System.Windows.Forms.Button();
            this.btnSuaGiaiDau = new System.Windows.Forms.Button();
            this.btnThemGiaiDau = new System.Windows.Forms.Button();
            this.flowLayoutPanel1 = new System.Windows.Forms.FlowLayoutPanel();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.dtpStart = new System.Windows.Forms.DateTimePicker();
            this.dtpEnd = new System.Windows.Forms.DateTimePicker();
            this.lblTitle = new System.Windows.Forms.Label();
            this.btnBack = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // imageList1
            // 
            this.imageList1.ColorDepth = System.Windows.Forms.ColorDepth.Depth8Bit;
            this.imageList1.ImageSize = new System.Drawing.Size(16, 16);
            this.imageList1.TransparentColor = System.Drawing.Color.Transparent;
            // 
            // btnSearch
            // 
            this.btnSearch.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSearch.Location = new System.Drawing.Point(733, 183);
            this.btnSearch.Name = "btnSearch";
            this.btnSearch.Size = new System.Drawing.Size(195, 42);
            this.btnSearch.TabIndex = 37;
            this.btnSearch.Text = "Tìm kiếm";
            this.btnSearch.UseVisualStyleBackColor = true;
            this.btnSearch.Click += new System.EventHandler(this.btnTimKiem_Click);
            // 
            // txtSearch
            // 
            this.txtSearch.Location = new System.Drawing.Point(420, 139);
            this.txtSearch.Multiline = true;
            this.txtSearch.Name = "txtSearch";
            this.txtSearch.Size = new System.Drawing.Size(265, 34);
            this.txtSearch.TabIndex = 36;
            this.txtSearch.TextChanged += new System.EventHandler(this.txtTimKiem_TextChanged);
            // 
            // lblTimKiemGiaiDau
            // 
            this.lblTimKiemGiaiDau.BackColor = System.Drawing.Color.White;
            this.lblTimKiemGiaiDau.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTimKiemGiaiDau.Location = new System.Drawing.Point(186, 139);
            this.lblTimKiemGiaiDau.Name = "lblTimKiemGiaiDau";
            this.lblTimKiemGiaiDau.Size = new System.Drawing.Size(198, 34);
            this.lblTimKiemGiaiDau.TabIndex = 35;
            this.lblTimKiemGiaiDau.Text = "Tìm kiếm giải đấu:";
            this.lblTimKiemGiaiDau.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // btnHienThiTatCa
            // 
            this.btnHienThiTatCa.BackColor = System.Drawing.Color.White;
            this.btnHienThiTatCa.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnHienThiTatCa.Location = new System.Drawing.Point(758, 661);
            this.btnHienThiTatCa.Name = "btnHienThiTatCa";
            this.btnHienThiTatCa.Size = new System.Drawing.Size(206, 44);
            this.btnHienThiTatCa.TabIndex = 34;
            this.btnHienThiTatCa.Text = "Hiển thị tất cả giải đấu";
            this.btnHienThiTatCa.UseVisualStyleBackColor = false;
            this.btnHienThiTatCa.Click += new System.EventHandler(this.btnHienThiTatCa_Click);
            // 
            // btnXoaGiaiDau
            // 
            this.btnXoaGiaiDau.BackColor = System.Drawing.Color.White;
            this.btnXoaGiaiDau.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnXoaGiaiDau.Location = new System.Drawing.Point(526, 661);
            this.btnXoaGiaiDau.Name = "btnXoaGiaiDau";
            this.btnXoaGiaiDau.Size = new System.Drawing.Size(170, 44);
            this.btnXoaGiaiDau.TabIndex = 33;
            this.btnXoaGiaiDau.Text = "Xóa giải đấu";
            this.btnXoaGiaiDau.UseVisualStyleBackColor = false;
            this.btnXoaGiaiDau.Click += new System.EventHandler(this.btnXoaGiaiDau_Click);
            // 
            // btnSuaGiaiDau
            // 
            this.btnSuaGiaiDau.BackColor = System.Drawing.Color.White;
            this.btnSuaGiaiDau.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSuaGiaiDau.Location = new System.Drawing.Point(305, 661);
            this.btnSuaGiaiDau.Name = "btnSuaGiaiDau";
            this.btnSuaGiaiDau.Size = new System.Drawing.Size(170, 44);
            this.btnSuaGiaiDau.TabIndex = 32;
            this.btnSuaGiaiDau.Text = "Sửa giải đấu";
            this.btnSuaGiaiDau.UseVisualStyleBackColor = false;
            this.btnSuaGiaiDau.Click += new System.EventHandler(this.btnSuaGiaiDau_Click);
            // 
            // btnThemGiaiDau
            // 
            this.btnThemGiaiDau.BackColor = System.Drawing.Color.White;
            this.btnThemGiaiDau.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnThemGiaiDau.Location = new System.Drawing.Point(78, 661);
            this.btnThemGiaiDau.Name = "btnThemGiaiDau";
            this.btnThemGiaiDau.Size = new System.Drawing.Size(170, 44);
            this.btnThemGiaiDau.TabIndex = 31;
            this.btnThemGiaiDau.Text = "Thêm giải đấu";
            this.btnThemGiaiDau.UseVisualStyleBackColor = false;
            this.btnThemGiaiDau.Click += new System.EventHandler(this.btnThemGiaiDau_Click);
            // 
            // flowLayoutPanel1
            // 
            this.flowLayoutPanel1.AutoScroll = true;
            this.flowLayoutPanel1.BackColor = System.Drawing.Color.White;
            this.flowLayoutPanel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.flowLayoutPanel1.Location = new System.Drawing.Point(41, 285);
            this.flowLayoutPanel1.Name = "flowLayoutPanel1";
            this.flowLayoutPanel1.Size = new System.Drawing.Size(979, 349);
            this.flowLayoutPanel1.TabIndex = 38;
            this.flowLayoutPanel1.Paint += new System.Windows.Forms.PaintEventHandler(this.flowLayoutPanel1_Paint);
            // 
            // label1
            // 
            this.label1.BackColor = System.Drawing.Color.White;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(186, 189);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(198, 28);
            this.label1.TabIndex = 39;
            this.label1.Text = "Ngày bắt đầu:";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label2
            // 
            this.label2.BackColor = System.Drawing.Color.White;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(186, 234);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(198, 28);
            this.label2.TabIndex = 40;
            this.label2.Text = "Ngày kết thúc:";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // dtpStart
            // 
            this.dtpStart.Location = new System.Drawing.Point(420, 195);
            this.dtpStart.Name = "dtpStart";
            this.dtpStart.ShowCheckBox = true;
            this.dtpStart.Size = new System.Drawing.Size(265, 22);
            this.dtpStart.TabIndex = 41;
            // 
            // dtpEnd
            // 
            this.dtpEnd.Location = new System.Drawing.Point(420, 240);
            this.dtpEnd.Name = "dtpEnd";
            this.dtpEnd.ShowCheckBox = true;
            this.dtpEnd.Size = new System.Drawing.Size(265, 22);
            this.dtpEnd.TabIndex = 42;
            // 
            // lblTitle
            // 
            this.lblTitle.BackColor = System.Drawing.Color.White;
            this.lblTitle.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTitle.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.lblTitle.Location = new System.Drawing.Point(365, 32);
            this.lblTitle.Name = "lblTitle";
            this.lblTitle.Size = new System.Drawing.Size(320, 67);
            this.lblTitle.TabIndex = 30;
            this.lblTitle.Text = "Quản Lý Giải Đấu";
            this.lblTitle.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // btnBack
            // 
            this.btnBack.BackColor = System.Drawing.SystemColors.Window;
            this.btnBack.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnBack.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnBack.Image = global::quanly.Properties.Resources.btnll;
            this.btnBack.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnBack.Location = new System.Drawing.Point(6, 13);
            this.btnBack.Name = "btnBack";
            this.btnBack.Size = new System.Drawing.Size(127, 46);
            this.btnBack.TabIndex = 29;
            this.btnBack.Text = "Quay lại";
            this.btnBack.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnBack.UseVisualStyleBackColor = false;
            this.btnBack.Click += new System.EventHandler(this.btnBack_Click);
            // 
            // FormQuanLyGiaiDau
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Blue;
            this.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("$this.BackgroundImage")));
            this.ClientSize = new System.Drawing.Size(1057, 750);
            this.Controls.Add(this.dtpEnd);
            this.Controls.Add(this.dtpStart);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.flowLayoutPanel1);
            this.Controls.Add(this.btnSearch);
            this.Controls.Add(this.txtSearch);
            this.Controls.Add(this.lblTimKiemGiaiDau);
            this.Controls.Add(this.btnHienThiTatCa);
            this.Controls.Add(this.btnXoaGiaiDau);
            this.Controls.Add(this.btnSuaGiaiDau);
            this.Controls.Add(this.btnThemGiaiDau);
            this.Controls.Add(this.lblTitle);
            this.Controls.Add(this.btnBack);
            this.Name = "FormQuanLyGiaiDau";
            this.Text = "Quản lý giải đấu";
            this.Load += new System.EventHandler(this.FormQuanLyGiaiDau_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ImageList imageList1;
        private System.Windows.Forms.Button btnSearch;
        private System.Windows.Forms.TextBox txtSearch;
        private System.Windows.Forms.Label lblTimKiemGiaiDau;
        private System.Windows.Forms.Button btnHienThiTatCa;
        private System.Windows.Forms.Button btnXoaGiaiDau;
        private System.Windows.Forms.Button btnSuaGiaiDau;
        private System.Windows.Forms.Button btnThemGiaiDau;
        private System.Windows.Forms.Label lblTitle;
        private System.Windows.Forms.Button btnBack;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.DateTimePicker dtpStart;
        private System.Windows.Forms.DateTimePicker dtpEnd;
    }
}