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
    public partial class UC_Blog_trangchu : UserControl
    {
        string connectionString = Program.connectString;
        public UC_Blog_trangchu()
        {
            InitializeComponent();
            this.Click += UC_Blog_Click;
        }
        public string id { get; set; }
        public void SetPostInfor(string Id,string title,string time,string imageurl)
        {
            id = Id ;
            lbtitle.Text = title;
            lbtime.Text = time;
            picture.SizeMode = PictureBoxSizeMode.Zoom;

            string fullPath = Path.Combine(Application.StartupPath, imageurl);

            if (File.Exists(fullPath))
            {
                picture.Image = Image.FromFile(fullPath);
            }
            else
            {
                picture.Image = null;
            }

        }

        private void picture_Click(object sender, EventArgs e)
        {

        }
        private void UC_Blog_Click(object sender, EventArgs e)
        {
            BlogDetailForm_trangchu detailform = new BlogDetailForm_trangchu(id);
            detailform.ShowDialog();
        }
        private void UC_Blog_Load(object sender, EventArgs e)
        {

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
      
    }
}
