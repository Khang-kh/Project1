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
using static System.Windows.Forms.VisualStyles.VisualStyleElement.ListView;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.StartPanel;

namespace quanly
{
    public partial class AddnewAdmin : Form
    {
        string connectionString = Program.connectString;
        public AddnewAdmin()
        {
            InitializeComponent();
        }
        private bool IsUsernameOrEmailExists(string username, string email)
        {
            string query = "SELECT COUNT(*) FROM Actors WHERE ActorUsername = @username OR ActorEmail = @email";

            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                conn.Open();
                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@username", username);
                    cmd.Parameters.AddWithValue("@email", email);

                    int count = (int)cmd.ExecuteScalar();
                    return count > 0;
                }
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string Username = textBoxUsername.Text;
            string Password = textBoxPassword.Text;
            string Email = textBoxEmail.Text;
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                string query = "INSERT INTO Actors (ActorUsername,ActorPassword,ActorEmail) VALUES (@username,@password,@email)";
                if (IsUsernameOrEmailExists(textBoxUsername.Text, textBoxEmail.Text))
                {
                    MessageBox.Show("Username/Email Admin đã tồn tại. Vui lòng chọn tên khác");
                    return;
                }
                else if(string.IsNullOrWhiteSpace(Username) || string.IsNullOrWhiteSpace(Password) || string.IsNullOrWhiteSpace(Email))
                {
                    MessageBox.Show("Bạn nhập thiếu thông tin cần thiết. Vui lòng bổ sung");
                    return;
                }
                else
                {

                    SqlCommand cmd = new SqlCommand(query, conn);
                    cmd.Parameters.AddWithValue("@username", Username);
                    cmd.Parameters.AddWithValue("@password", Password);
                    cmd.Parameters.AddWithValue("@email", Email);
                    conn.Open();
                    cmd.ExecuteNonQuery();
                    this.DialogResult = DialogResult.OK;
                }
            }
        }

        private void BtnQuaylai_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
