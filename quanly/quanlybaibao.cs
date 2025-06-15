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
    public partial class FormBaibao : Form
    {
        string connectionString = Program.connectString;
        private Form previousForm;
        public FormBaibao(Form callerForm)
        {
            InitializeComponent();
            btnBack.Image = Properties.Resources.btnll;
            LoadListOfBlog();
            previousForm = callerForm;
        }
        private void LoadListOfBlog()
        {
            string query = "SELECT postID, title, createdAt, imageURL FROM Post ORDER BY createdAt DESC";
            using(SqlConnection conn = new SqlConnection(connectionString))
            {
                conn.Open();
                SqlCommand cmd = new SqlCommand(query, conn);
                SqlDataReader reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    string postId = reader["PostID"].ToString();
                    string title = reader["title"].ToString();
                    DateTime createdAt = Convert.ToDateTime(reader["createdAt"]);

                    // định dạng lại createdAt thành chuỗi theo định dạng 
                    string formattedDate = createdAt.ToString("yyyy-MM-dd HH:mm:ss");
                    // Lấy URL ảnh
                    string imageURL = reader["imageURL"].ToString();

                    UC_Blog1 banner = new UC_Blog1();
                    banner.SetPostInfor(postId,title,formattedDate, imageURL);
                    flowLayoutPanel1.Controls.Add(banner);
                }

            }    
        }

        private void ShowAll_Click(object sender, EventArgs e)
        {
            flowLayoutPanel1.Controls.Clear();
            LoadListOfBlog();
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
            LoadListOfBlog(keyword);
        }
        private void LoadListOfBlog(string keyword)
        {
            flowLayoutPanel1.Controls.Clear();

            string query = "SELECT postID, title, createdAt, imageURL " + "FROM Post WHERE title LIKE @kw";

            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                conn.Open();
                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@kw", "%" + keyword + "%");
                SqlDataReader reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    string postId = reader["PostID"].ToString();
                    string title = reader["title"].ToString();
                    DateTime createdAt = Convert.ToDateTime(reader["createdAt"]);

                    // định dạng lại createdAt thành chuỗi theo định dạng 
                    string formattedDate = createdAt.ToString("yyyy-MM-dd HH:mm:ss");
                    // Lấy URL ảnh
                    string imageURL = reader["imageURL"].ToString();

                    UC_Blog1 banner = new UC_Blog1();
                    banner.SetPostInfor(postId, title, formattedDate, imageURL);
                    flowLayoutPanel1.Controls.Add(banner);
                }
            }
        }

        private void Add_Click(object sender, EventArgs e)
        {
            AddnewBlog form = new AddnewBlog();
            if (form.ShowDialog() == DialogResult.OK)
            {
                flowLayoutPanel1.Controls.Clear();
                LoadListOfBlog();
            }
        }

        private void Modify_Click(object sender, EventArgs e)
        {
            foreach(Control ctrl in flowLayoutPanel1.Controls)
            {
                if(ctrl is UC_Blog1 blog)
                {
                    blog.HideBtnDelete();
                    blog.ShowBtnModify();
                }    
            }    
        }

        private void Delete_Click(object sender, EventArgs e)
        {
            foreach (Control ctrl in flowLayoutPanel1.Controls)
            {
                if (ctrl is UC_Blog1 blog)
                {
                    blog.ShowBtnDelete();
                    blog.HideBtnModify();
                }
            }
        }

        private void btnBack_Click(object sender, EventArgs e)
        {
            previousForm.Show();
            this.Close();
        }
    }
}
