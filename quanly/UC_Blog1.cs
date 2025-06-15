using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace quanly
{
    public partial class UC_Blog1 : UserControl
    {
        string connectionString = Program.connectString;
        public UC_Blog1()
        {
            InitializeComponent();
            this.Click += UC_Blog_Click;
            btnModify.Visible = false;
            btnDelete.Visible = false;
        }
        public void ShowBtnModify()
        {
            btnModify.Visible = true;
        }
        public void HideBtnModify()
        {
            btnModify.Visible = false;
        }
        public string id { get; set; }
        public void SetPostInfor(string Id,string title,string time,string imageurl)
        {
            id = Id ;
            lbtitle.Text = title;
            lbtime.Text = time;
            picture.SizeMode = PictureBoxSizeMode.Zoom;

            if (!string.IsNullOrWhiteSpace(imageurl))
            {
                try
                {
                    picture.LoadAsync(imageurl);// Load ảnh bất đồng bộ, đỡ bị treo UI
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Lỗi khi tải ảnh:\n" + ex.Message);
                }
            }
        }

        private void picture_Click(object sender, EventArgs e)
        {

        }
        private void UC_Blog_Click(object sender, EventArgs e)
        {
            BlogDetailForm detailform = new BlogDetailForm(id);
            detailform.ShowDialog();
        }
        private void UC_Blog_Load(object sender, EventArgs e)
        {

        }

        private void btnModify_Click(object sender, EventArgs e)
        {
            EditBlog editblog = new EditBlog(id);
            if(editblog.ShowDialog() == DialogResult.OK)
            {
                var blog = GetBlogById(id,picture);
                SetPostInfor(id,blog.title, blog.time, blog.imageurl);

            }    
        }
        private (string title,string time, string imageurl) GetBlogById(string id, PictureBox picture)
        {
            string query = "SELECT title, createdAt, imageURL FROM Post WHERE PostID = @id";
            using (SqlConnection conn = new SqlConnection(Program.connectString))
            {
                conn.Open();
                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@id", id);
                SqlDataReader reader = cmd.ExecuteReader();
                if (reader.Read())
                {
                    DateTime createdAt = Convert.ToDateTime(reader["createdAt"]);
                    string formattedDate = createdAt.ToString("yyyy-MM-dd HH:mm:ss");
                    string imageURL = reader["imageURL"].ToString();
                    picture.SizeMode = PictureBoxSizeMode.Zoom;

                    if (!string.IsNullOrWhiteSpace(imageURL))
                    {
                        try
                        {
                            picture.LoadAsync(imageURL);
                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show("Lỗi khi tải ảnh:\n" + ex.Message);
                        }
                    }
                    return (reader["title"].ToString(), formattedDate,imageURL);
                }
                return ("", "","");
            }
        }
        public void ShowBtnDelete()
        {
            btnDelete.Visible = true;
        }
        public void HideBtnDelete()
        {
            btnDelete.Visible = false;
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                conn.Open();

                if (MessageBox.Show("Xoá bài báo này?", "Xác nhận", MessageBoxButtons.YesNo) == DialogResult.Yes)
                {
                    string deleteQuery = "DELETE FROM Post WHERE postID = @id";
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
