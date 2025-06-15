using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace quanly
{
    public partial class UserControl_Dangnhap : UserControl
    {
        string connectionString = Program.connectString;
        public UserControl_Dangnhap()
        {
            InitializeComponent();
        }

        private void ButtonDangnhap_Click(object sender, EventArgs e)
        {
            string username = textBoxUsername.Text.Trim();
            string password = textBoxPassword.Text.Trim();

            if (string.IsNullOrEmpty(username) || string.IsNullOrEmpty(password))
            {
                MessageBox.Show("Vui lòng nhập đầy đủ thông tin!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            string query = "SELECT COUNT(*) FROM Actors WHERE ActorUsername = @username AND ActorPassword = @password";

            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@username", username);
                    cmd.Parameters.AddWithValue("@password", password);

                    try
                    {
                        conn.Open();
                        int count = (int)cmd.ExecuteScalar();

                        if (count > 0)
                        {
                            SessionManager.CurrentUsername = username;
                            // Đăng nhập thành công
                            giaodienchinh mainForm = this.ParentForm as giaodienchinh;
                            MessageBox.Show("Đăng nhập thành công");
                            if (mainForm != null)
                            {
                                mainForm.HienThiChucNangSauDangNhap();
                            }

                            this.Hide();
                        }
                        else
                        {
                            MessageBox.Show("Tên đăng nhập hoặc mật khẩu không đúng!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Lỗi kết nối CSDL: " + ex.Message);
                    }
                }
            }
        }

        private void ButtonBack_Click(object sender, EventArgs e)
        {
            // Gọi Form trước khi xóa UserControl
            Form parentForm = this.FindForm(); // LẤY FORM TRƯỚC

            if (parentForm is giaodienchinh formChinh)
            {
                formChinh.Molaicacnutchucnangkhibamquaylai(); // BẬT LẠI NÚT TRƯỚC
            }

            // Sau đó mới xóa chính nó ra khỏi giao diện
            if (this.Parent != null)
            {
                this.Parent.Controls.Remove(this); // XÓA SAU
            }
        }
        protected override void OnVisibleChanged(EventArgs e)
        {
            base.OnVisibleChanged(e);

            if (this.Visible)
            {
                textBoxUsername.Text = "";
                textBoxPassword.Text = "";
            }
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void UserControl_Dangnhap_Load(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }
    }
}
