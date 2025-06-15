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
    public partial class UC_Admin : UserControl
    {
        string connectionString = Program.connectString;
        public UC_Admin()
        {
            InitializeComponent();
            this.Click += UC_Admin_Click;
            Btnmodifty.Visible = false;
            BtnDelete.Visible = false;
        }
        public void ShowBtnmodify()
        {
            Btnmodifty.Visible=true;
        }
        public void HideBtnmodify()
        {
            Btnmodifty.Visible = false;
        }
        public string id { get; set; } 
        public void SetAdminInfor(string Adminusername,string Adminemail,string Id)
        {
            lbemail.Text = Adminemail;
            lbname.Text = Adminusername;
            id = Id;
        }

        private void UC_Admin_Load(object sender, EventArgs e)
        {
           
        }
        private void UC_Admin_Click(object sender, EventArgs e)
        {
            AdminDetailForm detailform = new AdminDetailForm(id);
            detailform.ShowDialog();
        }

        private void Btnmodifty_Click(object sender, EventArgs e)
        {
            EditAdminForm editadminform = new EditAdminForm(id);
            if(editadminform.ShowDialog()==DialogResult.OK)
            {
                var admin = GetAdminById(id);
                SetAdminInfor(admin.Username, admin.Email, id);
            }
        }
        private (string Username, string Email) GetAdminById(string id)
        {
            string query = "SELECT ActorUsername, ActorEmail FROM Actors WHERE ActorID = @id";
            using (SqlConnection conn = new SqlConnection(Program.connectString))
            {
                conn.Open();
                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@id", id);
                SqlDataReader reader = cmd.ExecuteReader();
                if (reader.Read())
                {
                    return (reader["ActorUsername"].ToString(), reader["ActorEmail"].ToString());
                }
            }
            return ("", "");
        }

        public void ShowBtnDelete()
        {
            BtnDelete.Visible = true;
        }
        public void HideBtnDelete()
        {
            BtnDelete.Visible = false;
        }
        private void BtnDelete_Click(object sender, EventArgs e)
        {
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                conn.Open();

                // 1. Kiểm tra nếu actor có role 'master'
                string checkRoleQuery = @"
            SELECT COUNT(*) 
            FROM Actors_Role AR
            INNER JOIN Roles R ON AR.RoleID = R.RoleID
            WHERE AR.ActorID = @id AND R.RoleName = 'Master'";

                using (SqlCommand checkCmd = new SqlCommand(checkRoleQuery, conn))
                {
                    checkCmd.Parameters.AddWithValue("@id", id);
                    int count = (int)checkCmd.ExecuteScalar();

                    if (count > 0)
                    {
                        MessageBox.Show("Không thể xóa người có quyền 'Master'.", "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        return;
                    }
                }

                // 2. Hỏi xác nhận và xóa nếu không phải master
                if (MessageBox.Show("Xoá người này?", "Xác nhận", MessageBoxButtons.YesNo) == DialogResult.Yes)
                {
                    string deleteQuery = "DELETE FROM Actors WHERE ActorID = @id";
                    using (SqlCommand deleteCmd = new SqlCommand(deleteQuery, conn))
                    {
                        deleteCmd.Parameters.AddWithValue("@id", id);
                        deleteCmd.ExecuteNonQuery();
                    }

                    this.Parent.Controls.Remove(this);
                }
            }
        }
    }
}
