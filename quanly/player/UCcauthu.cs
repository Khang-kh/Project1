using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace quanly
{
    public partial class UCcauthu_doibong : UserControl
    {
        public event EventHandler SuaClick;
        public event EventHandler XoaClick;

        private bool _isEditMode = false;
        private bool _isDeleteMode = false;
        public string PlayerId { get; set; }

        public bool IsEditMode
        {
            get { return _isEditMode; }
            set
            {
                _isEditMode = value;
                BtnSua.Visible = _isEditMode;
            }
        }

        public bool IsDeleteMode // Thuộc tính cho chế độ xóa
        {
            get { return _isDeleteMode; }
            set
            {
                _isDeleteMode = value;
                BtnXoa.Visible = _isDeleteMode; // Ẩn/hiện nút xóa
            }
        }
        public Image Avatar
        {
            get => pictureBox1.Image;
            set => pictureBox1.Image = value;
        }
        private void LblSo_Click(object sender, EventArgs e)
        {

        }

        public string PlayerName
        {
            get => LblTen.Text;
            set => LblTen.Text = value;
        }

        public string ShirtNumber
        {
            get => LblSo.Text;
            set => LblSo.Text = "Số áo: " + value;
        }

        public string TeamName
        {
            get => LblDoi.Text;
            set => LblDoi.Text = "Đội: " + value;
        }
        
        private void LblTen_Click(object sender, EventArgs e)
        {

        }

        public UCcauthu_doibong()
        {
            InitializeComponent();
            BtnSua.Visible = false;
            BtnXoa.Visible = false;
            this.Click += UCcauthu_Click;
        }
        private void UCcauthu_Click(object sender, EventArgs e)
        {
            Thongtinchitietcauthu detailform = new Thongtinchitietcauthu(this.PlayerId);
            detailform.ShowDialog();
        }

        private void BtnSua_Click(object sender, EventArgs e)
        {
            if (SuaClick != null)
            {
                SuaClick(this, EventArgs.Empty); // Truyền chính UserControl này làm sender
            }
        }

        

        public void SetEditMode(bool editMode)
        {
            IsEditMode = editMode;
        }

         public void SetDeleteMode(bool deleteMode) // Phương thức thiết lập chế độ xóa
         {
            IsDeleteMode = deleteMode;
         }
        private void UCcauthu_Load(object sender, EventArgs e)
        {

        }

        private void BtnXoa_Click_1(object sender, EventArgs e)
        {
            if (XoaClick != null)
            {
                XoaClick(this, EventArgs.Empty); // Gọi sự kiện XoaClick
            }
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }
    }

}
