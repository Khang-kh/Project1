using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.ListView;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.StartPanel;

namespace quanly
{
    public partial class EditAdminForm : Form
    {
        private string adminID;
        private string connectionString = Program.connectString;
        public EditAdminForm(string id)
        {
            InitializeComponent();
            this.adminID = id;
            LoadAdminInfo();
        }
        private void LoadAdminInfo()
        {
            string query = "SELECT ActorUsername,ActorPassword, ActorEmail FROM Actors WHERE ActorID = @id";
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                conn.Open();
                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@id", adminID);

                SqlDataReader reader = cmd.ExecuteReader();
                if (reader.Read())
                {
                    textBoxUsername.Text = reader["ActorUsername"].ToString();
                    textBoxEmail.Text = reader["ActorEmail"].ToString();
                    textBoxPassword.Text = reader["ActorPassword"].ToString();
                }
            }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (IsUsernameOrEmailExists(textBoxUsername.Text, textBoxEmail.Text))
            {
                MessageBox.Show("Username/Email Admin đã tồn tại. Vui lòng chọn tên khác", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }


            string query = "UPDATE Actors SET ActorUsername = @username, ActorEmail = @email, ActorPassword = @password WHERE ActorID = @id";
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                conn.Open();
                SqlCommand cmd = new SqlCommand(query, conn);
                if (string.IsNullOrWhiteSpace(textBoxUsername.Text) || string.IsNullOrWhiteSpace(textBoxPassword.Text) || string.IsNullOrWhiteSpace(textBoxEmail.Text))
                {
                    MessageBox.Show("Bạn nhập thiếu thông tin cần thiết. Vui lòng bổ sung");
                    return;
                }
                else
                {
                    cmd.Parameters.AddWithValue("@username", textBoxUsername.Text);
                    cmd.Parameters.AddWithValue("@email", textBoxEmail.Text);
                    cmd.Parameters.AddWithValue("@password", textBoxPassword.Text);
                    cmd.Parameters.AddWithValue("@id", adminID);
                }

                int rows = cmd.ExecuteNonQuery();
                if (rows > 0)
                {
                    MessageBox.Show("Cập nhật thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    this.DialogResult = DialogResult.OK;
                    this.Close();
                }
                else
                {
                    MessageBox.Show("Cập nhật thất bại.", "Đã xảy ra lỗi. Vui lòng thử lại sau.", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }

            }
        }
        private bool IsUsernameOrEmailExists(string username, string email)
        {
            string query = "SELECT COUNT(*) FROM Actors WHERE (ActorUsername = @username OR ActorEmail = @email) AND ActorID != @id";

            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                conn.Open();
                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@username", username);
                    cmd.Parameters.AddWithValue("@email", email);
                    cmd.Parameters.AddWithValue("@id", adminID);

                    int count = (int)cmd.ExecuteScalar();
                    return count > 0;
                }
            }
        }

        private void BtnQuaylai_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
