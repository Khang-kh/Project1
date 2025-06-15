using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace quanly
{
    public partial class AdminDetailForm : Form
    {
        string connectionString = Program.connectString;
        private string Id;
        public AdminDetailForm(string Id)
        {
            InitializeComponent();
            this.Id = Id;
            LoadAdminDetail();
        }
        private void LoadAdminDetail()
        {
            string query = "SELECT * FROM Actors WHERE ActorID = @id";

            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                try
                {
                    conn.Open();
                    SqlCommand cmd = new SqlCommand(query, conn);
                    cmd.Parameters.AddWithValue("@id", Id);

                    SqlDataReader reader = cmd.ExecuteReader();
                    if (reader.Read())
                    {
                        lbUsername.Text = reader["ActorUsername"].ToString();
                        lbEmail.Text = reader["ActorEmail"].ToString();
                        lbPassword.Text = reader["ActorPassword"].ToString();
                    }
                    reader.Close();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Lỗi: " + ex.Message);
                }
            }
        }

        private void BtnQuaylai_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
