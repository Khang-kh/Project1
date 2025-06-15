using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Reflection.Emit;
using System.Runtime.Remoting.Contexts;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace quanly
{
    public partial class BlogDetailForm_trangchu : Form
    {
        string connectionString = Program.connectString;
        private string Id;
        public BlogDetailForm_trangchu(string Id)
        {
            InitializeComponent();
            this.Id = Id;
            LoadBlogDetail();
        }
        private void LoadBlogDetail()
        {
            string query = "SELECT *FROM Post WHERE PostID = @id";
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
                        lbtitle.Text = reader["title"].ToString();
                        lbauthor.Text = reader["author"].ToString();
                        lbcontentt.Text = reader["content"].ToString();
                        
                        // Đảm bảo Panel có thể cuộn
                        panel1.AutoScroll = true;

                        // Cấu hình cho panel1 để không bị che mất nội dung
                        panel1.BorderStyle = BorderStyle.FixedSingle;

                        DateTime createdAt = Convert.ToDateTime(reader["createdAt"]);
                        string formattedDate = createdAt.ToString("yyyy-MM-dd HH:mm:ss");
                        lbtime.Text = formattedDate;
                        string imageURL = reader["imageURL"].ToString();
                        picturedetail.SizeMode = PictureBoxSizeMode.Zoom;

                        if (!string.IsNullOrWhiteSpace(imageURL))
                        {
                            try
                            {
                                string absolutePath = Path.Combine(Application.StartupPath, imageURL);
                                picturedetail.LoadAsync(absolutePath);
                            }
                            catch (Exception ex)
                            {
                                MessageBox.Show("Lỗi khi tải ảnh:\n" + ex.Message);
                            }
                        }

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
