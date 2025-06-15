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
    public partial class FormPQ : Form
    {
        string connectionString = Program.connectString;
        private Form previousForm;
        private void LoadListOfAdmin()
        {
            string query = "SELECT ActorID, ActorUsername,ActorEmail FROM Actors";
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                conn.Open();
                SqlCommand cmd = new SqlCommand(query, conn);
                SqlDataReader reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    string adminusername = reader["ActorUsername"].ToString();
                    string adminemail = reader["ActorEmail"].ToString();
                    string id = reader["ActorID"].ToString();


                    UC_Admin banner = new UC_Admin();
                    banner.SetAdminInfor(adminusername, adminemail,id);
                    flowLayoutPanel1.Controls.Add(banner);
                    flowLayoutPanel1.Controls.SetChildIndex(banner, 0);
                }
            }
        }
        private UC_Admin ucAdmin;
        public FormPQ(Form callerForm)
        {
            InitializeComponent();
            LoadListOfAdmin();
            btnBack.Image = Properties.Resources.btnll;
            previousForm = callerForm;
        }


        private void Add_Click(object sender, EventArgs e)
        {
            AddnewAdmin form = new AddnewAdmin();
            if(form.ShowDialog() == DialogResult.OK)
            {
                flowLayoutPanel1.Controls.Clear();
                LoadListOfAdmin();
            }    
        }

        private void Modify_Click(object sender, EventArgs e)
        {
            foreach (Control ctrl in flowLayoutPanel1.Controls)
            {
                if (ctrl is UC_Admin admin)
                {
                    admin.HideBtnDelete();
                    admin.ShowBtnmodify();
                }
            }
        }

        private void Delete_Click(object sender, EventArgs e)
        {
            foreach (Control ctrl in flowLayoutPanel1.Controls)
            {
                if (ctrl is UC_Admin admin)
                {
                    admin.HideBtnmodify();
                    admin.ShowBtnDelete();
                }
            }
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(TextboxSearch.Text))
            {
                MessageBox.Show("Vui lòng nhập dữ liệu");
                TextboxSearch.Focus();
                return;
            }
            string keyword = TextboxSearch.Text.Trim();
            LoadListOfAdmin(keyword);
        }
        private void LoadListOfAdmin(string keyword)
        {
            flowLayoutPanel1.Controls.Clear();

            string query = "SELECT ActorID, ActorUsername,ActorEmail FROM Actors WHERE ActorUsername LIKE @kw";
            
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                conn.Open();
                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@kw", keyword);
                SqlDataReader reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    string adminusername = reader["ActorUsername"].ToString();
                    string adminemail = reader["ActorEmail"].ToString();
                    string id = reader["ActorID"].ToString();


                    UC_Admin banner = new UC_Admin();
                    banner.SetAdminInfor(adminusername, adminemail, id);
                    flowLayoutPanel1.Controls.Add(banner);
                }
            }
        }

        private void ShowAdmin_Click(object sender, EventArgs e)
        {
            flowLayoutPanel1.Controls.Clear();
            LoadListOfAdmin();
        }

        private void flowLayoutPanel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void btnBack_Click(object sender, EventArgs e)
        {
            previousForm.Show();
            this.Close();
        }
    }
}
