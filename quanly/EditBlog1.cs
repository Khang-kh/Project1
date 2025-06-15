using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.TaskbarClock;

namespace quanly
{
    public partial class EditBlog : Form
    {
        private string postID;
        private string connectionString = Program.connectString;
        public EditBlog(string id)
        {
            InitializeComponent();
            this.postID = id;
            LoadBlogInfor();
        }
        private void LoadBlogInfor()
        {
            string query = "SELECT *FROM Post WHERE PostID = @id";
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                try
                {
                    conn.Open();
                    SqlCommand cmd = new SqlCommand(query, conn);
                    cmd.Parameters.AddWithValue("@id", postID);

                    SqlDataReader reader = cmd.ExecuteReader();
                    if (reader.Read())
                    {
                        titlebox.Text = reader["title"].ToString();
                        textboxauthor.Text = reader["author"].ToString();
                        textcontent.Text = reader["content"].ToString();
                        // Cấu hình TextBox cho phù hợp với panel
                        textcontent.Multiline = true;
                        textcontent.ScrollBars = ScrollBars.Vertical;
                        textcontent.WordWrap = true;

                        // Đảm bảo Panel có thể cuộn
                        panel1.AutoScroll = true;

                        // Cấu hình cho panel1 để không bị che mất nội dung
                        panel1.BorderStyle = BorderStyle.FixedSingle;


                        string imageURL = reader["imageURL"].ToString();
                        picturedetail.SizeMode = PictureBoxSizeMode.Zoom;

                        if (!string.IsNullOrWhiteSpace(imageURL))
                        {
                            try
                            {
                                picturedetail.LoadAsync(imageURL);
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

        private void savebtn_Click(object sender, EventArgs e)
        {
            string Title = titlebox.Text;
            string Content = textcontent.Text;
            string Author = textboxauthor.Text;
            string Time = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");
            string imageURL = picturedetail.ImageLocation ?? "";

            if (!string.IsNullOrEmpty(selectedImagePath))
            {
                string imageName = Path.GetFileName(selectedImagePath);
                string savePath = Path.Combine(Application.StartupPath, "Images", imageName);
                Directory.CreateDirectory(Path.GetDirectoryName(savePath)); // Tạo folder nếu chưa có
                File.Copy(selectedImagePath, savePath, true); // Copy ảnh
                imageURL = "Images/" + imageName; // Đường dẫn tương đối lưu vào DB
                picturedetail.ImageLocation = imageURL;
            }

            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                string query = "UPDATE Post SET title = @Title, content = @Content ,author = @Author,createdAt = @Time,imageURL = @URL WHERE postID = @id ";
                if (IsTitleExists(Title))
                {
                    MessageBox.Show("Tên bài báo đã tồn tại!");
                    return;
                }
                else if (string.IsNullOrWhiteSpace(Title) || string.IsNullOrWhiteSpace(Content))
                {
                    MessageBox.Show("Tiêu đề và nội dung không được để trống!");
                    return;
                }
                else
                {
                    SqlCommand cmd = new SqlCommand(query, conn);
                    cmd.Parameters.AddWithValue("@Title", Title);
                    cmd.Parameters.AddWithValue("@Content", Content);
                    cmd.Parameters.AddWithValue("@Author", Author);
                    cmd.Parameters.AddWithValue("@Time", Time);
                    cmd.Parameters.AddWithValue("@URL", imageURL);
                    cmd.Parameters.AddWithValue("@id", postID);
                    conn.Open();
                    cmd.ExecuteNonQuery();
                    this.DialogResult = DialogResult.OK;
                    int rowsAffected = cmd.ExecuteNonQuery();
                    if (rowsAffected > 0)
                    {
                        MessageBox.Show("Cập nhật bài báo thành công.");
                    }
                    else
                    {
                        MessageBox.Show("Không có bản ghi nào được cập nhật.");
                    }
                    this.Close();
                }
            }
        }
        // Khai báo ở mức form-level để dùng được trong nhiều hàm
        string selectedImagePath = "";

        private bool IsTitleExists(string title)
        {
            string query = "SELECT COUNT(*) FROM Post WHERE title = @title AND PostID != @id";

            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                conn.Open();
                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@title", title);
                    cmd.Parameters.AddWithValue("@id", postID);
                    int count = (int)cmd.ExecuteScalar();
                    return count > 0;
                }
            }
        }
        private void upload_Click_1(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Filter = "Image files (*.jpg;*.jpeg;*.png)|*.jpg;*.jpeg;*.png";

            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                selectedImagePath = openFileDialog.FileName;
                picturedetail.Image = Image.FromFile(selectedImagePath); // Hiển thị ảnh
                picturedetail.SizeMode = PictureBoxSizeMode.Zoom;
            }
        }

        private void BtnQuaylai_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
